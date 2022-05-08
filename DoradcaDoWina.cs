using CLIPSNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DoradcaDoWina
{
    public partial class DoradcaDoWina : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private class Question
        {
            public string text = "";                            //Pytanie
            public string fact = "";                            //Fakt, który doda odpiwedź na pytanie
            public List<string> answers = new List<string>();   //Możliwe odpowiedzi
            public List<string> givenAnswers = new List<string>();//Udzielone odpowiedzi
            public bool bMulti = false;                         //Charakter pytania
        }

        private CLIPSNET.Environment clips = new CLIPSNET.Environment();
        private List<Question> questions = new List<Question>();
        private bool bReset = false;                            //Trzeba zasygnalizować, czy nextButton działa jako przycisk resetu, czy jako przejście do następnego pytania
        public DoradcaDoWina()
        {
            InitializeComponent();
            //Wczytuje plikli Clipsa i uruchamia reguły
            clips.LoadFromResource("DoradcaDoWina", "DoradcaDoWina.Resources.pytania.clp");
            clips.LoadFromResource("DoradcaDoWina", "DoradcaDoWina.Resources.wina.clp");
            clips.Run();

            //Pobranie i wyświetlenie pierwszego pytania
            FetchNextQuestion();
            ProcessLastQuestion();
        }

        //Zbiera pierwsze z dostępnych pytań wygenerowanych przez CLIPS
        private void FetchNextQuestion()
        {
            Question newQuestion = new Question();

            //Najpierw sprawdzamy, czy już można doradzić wino dla użytkownika
            MultifieldValue wine = (MultifieldValue)clips.Eval("(find-fact ((?x wine)) true)");
            if (wine.Count != 0)
            {
                //Wynik naszego przetwarzania będzie przechowywany w liście pytań, ponieważ jest to wygodne
                //Np. nie musimy tworzyć specjalnej logiki sprawdzającej przy cofaniu pytania, czy ostatnio
                //przetwarzaliśmy wynik czy pytanie
                newQuestion.text = ((StringValue)((MultifieldValue)((FactAddressValue)wine[0])["implied"])[0]).Value;
                //Nadanie odpowiedzi na "pytanie" zanim je zadamy, daje nam gwarancję, że będziemy mogli
                //jednoznacznie rozróżnić wynik od pytania (każde normalnie pytanie posiada odpowiedź pustą)
                newQuestion.givenAnswers.Add("wine");
                questions.Add(newQuestion);

                nextButton.Text = "Reset";
                bReset = true;
                return;
            }

            //Zbieramy wszystkie pytania, ale interesuje nas tylko pierwsze
            MultifieldValue allQuestions = (MultifieldValue)clips.Eval("(find-all-facts ((?x question)) true)");
            //Taka sytuacja nie powinna się zdarzyć. Oznacza to błąd w .clp, jednak dla bezpieczeństwa
            //obsługujemy przypadek, gdy zabrakło pytań
            if (allQuestions.Count == 0)
            {
                nextButton.Text = "Reset";
                bReset = true;
                return;
            }
            //Program pozostawił możliwość rozwijania się i zadawania wielu pytań na raz, ale obecny diagram sugeruje,
            //że taka sytuacja nie powinna zajsć, więc sprawdzamy, czy rzeczywiście jest tylko jedno dostępne pytanie
            Debug.Assert(allQuestions.Count == 1);

            //Zbiera adres pierwszego pytania, dzięki któremu można dostać się do poszczególnych elementów pytania
            FactAddressValue question = (FactAddressValue)allQuestions[0];

            //Wpisanie danych z CLIPS do naszej pamięci
            //Nie sterujemy w programie ruchem, a chcemy je zapisać, żeby móc cofać się w udzielaniu odpowiedzi
            //To trochę przypomina sterowanie ruchem, jednak jest to w istocie zarządzanie faktami wgranymi do CLIPS
            newQuestion.text = ((StringValue)question["text"]).Value;
            newQuestion.fact = ((LexemeValue)question["fact"]).Value;
            newQuestion.bMulti = ((LexemeValue)question["type"]).Value == "multi";
            foreach (StringValue answer in (MultifieldValue)question["answers"])
                newQuestion.answers.Add(answer.Value);
            questions.Add(newQuestion);
        }

        private void ProcessLastQuestion()
        {
            Question last = questions.Last();
            //Ustawiamy przełącznik, żeby nie rysowało artefaktów podczas generacji przycisków
            //Nie działa perfekcyjnie, ale daje sporą poprawę...
            SendMessage(Handle, 11, false, 0);
            choicesPanel.Controls.Clear();

            //Ustawia treść pytania na ekranie
            messageLabel.Text = last.text;
            //Generuje możliwe odpowiedzi do zaznaczenia
            foreach (string answer in last.answers)
            {
                ButtonBase newButton;
                if (last.bMulti)
                    newButton = new CheckBox();
                else
                    newButton = new RadioButton();
                newButton.Text = answer;

                //W przypadku cofania, zaznaczamy ostatnią udzieloną odpowieź
                if (questions.Count != 0)
                    if (last.bMulti) ((CheckBox)newButton).Checked = questions.Last().givenAnswers.Contains(newButton.Text);
                    else ((RadioButton)newButton).Checked = questions.Last().givenAnswers.Contains(newButton.Text);

                newButton.AutoSize = true;
                newButton.Cursor = Cursors.Hand;
                newButton.BackColor = Color.FromArgb(0, 0, 0, 0);

                choicesPanel.Controls.Add(newButton);
            }
            //choicesPanel.

            choicesPanel.Refresh();
            //Z powrotem włączamy rysowanie. Trzeba wywołać Refresh()
            SendMessage(Handle, 11, true, 0);
            Refresh();
        }

        private void AddFact(string fact, string answer)
        {
            string theString = "(assert (" + fact + " \"" + answer + "\"))";
            clips.Eval(theString);
            clips.Run();
        }

        private void NextButtonClick(object sender, EventArgs e)
        {
            //Doradziliśmy wino, możemy rozpocząć od nowa
            if (bReset)
            {
                questions.Clear();
                prevButton.Enabled = false;
                bReset = false;
                nextButton.Text = "Następne";

                clips.Reset();
                clips.Run();
                FetchNextQuestion();
                ProcessLastQuestion();
                return;
            }
            Question last = questions.Last();

            //Sprawdza, czy jakaś odpowiedź została wybrana i wychodzi, jeżeli nie
            if (last.bMulti)
            {
                if (choicesPanel.Controls.OfType<CheckBox>().FirstOrDefault(r => r.Checked) == null)
                    return;
            }
            else if(choicesPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked) == null)
                    return;

            IEnumerable<ButtonBase> allChecked;
            if (last.bMulti) allChecked = choicesPanel.Controls.OfType<CheckBox>().Where(r => r.Checked);
            else allChecked = choicesPanel.Controls.OfType<RadioButton>().Where(r => r.Checked);

            //Dla każdego zaznaczonego przycisku dodaje go do listy udzielonych odpowiedzy w ostatnim pytaniu i 
            //dodaje ten fakt do CLIPS, po czym uruchamia go
            last.givenAnswers.Clear(); //Może być niepusta po cofaniu się w pytaniach
            foreach (ButtonBase button in allChecked)
            {
                last.givenAnswers.Add(button.Text);
                AddFact(last.fact, button.Text);
            }
            //Pobiera i wyświetla następne pytanie
            FetchNextQuestion();
            ProcessLastQuestion();
            //Skoro poruszyliśmy się w przód, to można poruszyć się w tył 
            prevButton.Enabled = true;
        }

        private void PrevButtonClick(object sender, EventArgs e)
        {
            //Resetujemy CLIPS, ponawiamy wszystkie dodania faktów oraz uruchomienia
            //Dlaczego nie wystarczy sam retract?
            //Takie coś sprawiłoby, że bardziej skomplikowane reguły, które robią więcej zmian niż tylko
            //Dodanie faktu wynikającego z odpowiedzi użytkownika, nie wycofałyby swoich zmian
            //Przez to stan mógłby być zupełnie inny niż ten, co był w poprzednim pytaniu
            clips.Reset();
            clips.Run();
            questions.Remove(questions.Last());
            for (int i = 0; i != questions.Count() - 1; ++i)
                foreach (string answer in questions[i].givenAnswers)
                    AddFact(questions[i].fact, answer);
            ProcessLastQuestion();
            //Możemy się cofać, aż wrócimy do pierwszego pytania
            if (questions.Count == 1)
                prevButton.Enabled = false;
            //Ostatnie pytanie przestaje być ostatnim pytanie, jeżeli się cofnęliśmy
            if (bReset)
            {
                nextButton.Text = "Następne";
                bReset = false;
            }
        }
    }
}
