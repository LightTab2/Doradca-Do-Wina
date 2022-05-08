(deftemplate question
   (slot text)
   (slot fact)
   (multislot answers)
   (slot type)
)

(defrule whoQ
    (not (who ?x))
    (not (question (text ?name) (fact who) (answers $?answers) (type ?type)))
    =>
    (assert (question (text "Kto będzie pić?") (fact who) (answers "Ja" "Ktoś inny") (type single)))
)

(defrule gatheringQ
    (who "Ktoś inny")
    ?oldQuestion <- (question (text ?name) (fact who) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Czy jesteś na jakimś zebraniu?") (fact gathering) (answers "Tak" "Nie") (type single)))
)

(defrule gatheringTypeQ
    (gathering "Tak")
    ?oldQuestion <- (question (text ?name) (fact gathering) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Jakie jest to zebranie?") (fact gatheringType) (answers "Kolacja" "Wieczór panieński/kawalerski" "Grill na plaży" "Otwarcie wystawy" "Spotkanie") (type single)))
)

(defrule knowQ
    (or
        (and
            (gatheringType "Spotkanie")
            ?oldQuestion <- (question (text ?name) (fact gatheringType) (answers $?answers) (type ?type))
        )
        (and
            (gift "Tak")
            (like "Tak")
            ?oldQuestion <- (question (text ?name) (fact like) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Znasz ich?") (fact know) (answers "Nie" "Tak") (type single)))
)

(defrule likeQ
    (or
        (and
            (gatheringType "Spotkanie")
            (know "Tak")
            ?oldQuestion <- (question (text ?name) (fact know) (answers $?answers) (type ?type))
        )
        (and
            (gift "Tak")
            ?oldQuestion <- (question (text ?name) (fact gift) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Kochają wino?") (fact like) (answers "Nie" "Tak") (type single)))
)

(defrule loveQ
    (know "Tak")
    (like "Tak")
    (or
        ?oldQuestion <- (question (text ?name) (fact like) (answers $?answers) (type ?type))
        ?oldQuestion <- (question (text ?name) (fact know) (answers $?answers) (type ?type))
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Czy są to Twoi najlepsi znajomi?") (fact love) (answers "Nie" "Tak") (type single)))
)

(defrule honestQ
    (love "Tak")
    ?oldQuestion <- (question (text ?name) (fact love) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Bądź szczery.") (fact honest) (answers "No może jednak nie są..." "Tak, są") (type single)))
)

(defrule cookQ
    (gatheringType "Kolacja")
    ?oldQuestion <- (question (text ?name) (fact gatheringType) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Kto gotuje?") (fact cook) (answers "Ja" "On(a)") (type single)))
)

(defrule giftQ
    (gathering "Nie")
    ?oldQuestion <- (question (text ?name) (fact gathering) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Czy dajesz komuś prezent?") (fact gift) (answers "Nie" "Tak") (type single)))
)

(defrule homeQ
    (who "Ja")
    ?oldQuestion <- (question (text ?name) (fact who) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Czy jesteś w domu?") (fact home) (answers "Nie" "Tak") (type single)))
)

(defrule aloneQ
    (or
        (and
            (home "Tak")
            ?oldQuestion <- (question (text ?name) (fact home) (answers $?answers) (type ?type))
        )
        (and
            (place "Specjalna okazja")
            (special "Nowy rok")
            ?oldQuestion <- (question (text ?name) (fact special) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Sam(a)?") (fact alone) (answers "Nie" "Tak") (type single)))
)

(defrule workQ
    (home "Tak")
    (alone "Tak")
    ?oldQuestion <- (question (text ?name) (fact alone) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Odpoczynek po pracy?") (fact work) (answers "Nie" "Tak") (type single)))
)

(defrule drunkQ
    (alone "Tak")
    (work "Nie")
    ?oldQuestion <- (question (text ?name) (fact work) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Chcesz się upić?") (fact drunk) (answers "Nie" "Tak") (type single)))
)

(defrule dinnerQ
    (home "Tak")
    (alone "Nie")
    ?oldQuestion <- (question (text ?name) (fact alone) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Obiad?") (fact dinner) (answers "Nie" "Tak") (type single)))
)

(defrule mainQ
    (or
        (and
            (dinner "Tak")
            ?oldQuestion <- (question (text ?name) (fact dinner) (answers $?answers) (type ?type))
        )
        (and
            (place "Obiad")
            ?oldQuestion <- (question (text ?name) (fact place) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Czy wino jest daniem głównym?") (fact main) (answers "Nie" "Tak") (type single)))
)

(defrule drunkQ
    (alone "Tak")
    (work "Nie")
    ?oldQuestion <- (question (text ?name) (fact work) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Chcesz się upić?") (fact drunk) (answers "Nie" "Tak") (type single)))
)

(defrule fancyQ
    (or
        (and
            (drunk "Nie")
            ?oldQuestion <- (question (text ?name) (fact drunk) (answers $?answers) (type ?type))
        )
        (and
            (place "Restauracja")
            ?oldQuestion <- (question (text ?name) (fact place) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Ma być wykwintnie?") (fact fancy) (answers "Nie" "Oui.") (type single)))
)

(defrule dailyQ
    (drunk "Nie")
    (fancy "Nie")
    ?oldQuestion <- (question (text ?name) (fact fancy) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Uprawiasz elitarne codzinne picie wina?") (fact daily) (answers "Nie" "Owszem") (type single)))
)

(defrule collectionQ
    (fancy "Nie")
    (daily "Nie")
    ?oldQuestion <- (question (text ?name) (fact daily) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Kolejna butla do kolekcji win?") (fact collection) (answers "Nie" "Tak") (type single)))
)

(defrule worldQ
    (or
        (and
            (collection "Tak")
            ?oldQuestion <- (question (text ?name) (fact collection) (answers $?answers) (type ?type))
        )
        (and
            (pronoun "Tak")
            ?oldQuestion <- (question (text ?name) (fact pronoun) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Stary czy nowy świat?") (fact world) (answers "Że co?" "Stary!" "Nowy") (type single)))
)

(defrule cultQ
    (world "Nowy")
    ?oldQuestion <- (question (text ?name) (fact world) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Kręci Cię okultyzm?") (fact cult) (answers "Nie" "Tak") (type single)))
)

(defrule orangeQ
    (or
        (and
            (daily "Owszem")
            ?oldQuestion <- (question (text ?name) (fact daily) (answers $?answers) (type ?type))
        )
        (and
            (cookWine "Nie")
            ?oldQuestion <- (question (text ?name) (fact cookWine) (answers $?answers) (type ?type))
        )
    )
    =>
    (retract ?oldQuestion)
    (assert (question (text "Lubisz oranżadę?") (fact orange) (answers "Nie" "Tak") (type single)))
)

(defrule dirtQ
    (orange "Nie")
    ?oldQuestion <- (question (text ?name) (fact orange) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Degustowałaś/eś w ziemi za młodu?") (fact dirt) (answers "Nie" "Mniam") (type single)))
)

(defrule butterQ
    (dirt "Nie")
    ?oldQuestion <- (question (text ?name) (fact dirt) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "No to może chociaż w maśle?") (fact butter) (answers "Nie" "Tak!") (type single)))
)

(defrule placeQ
    (who "Ja")
    (home "Nie")
    ?oldQuestion <- (question (text ?name) (fact home) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Dokąd wyszłaś/wyszedłeś?") (fact place) (answers "Obiad" "Restauracja" "Kemping" "Miejsce publiczne" "Specjalna okazja") (type single)))
)

(defrule microwaveQ
    (main "Nie")
    ?oldQuestion <- (question (text ?name) (fact main) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Obiad odgrzewany w mikrofali?") (fact microwave) (answers "Nie" "Tak") (type single)))
)

(defrule cookWineQ
    (microwave "Nie")
    ?oldQuestion <- (question (text ?name) (fact microwave) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Używasz wina do gotowania?") (fact cookWine) (answers "Nie" "Tak") (type single)))
)

(defrule windowQ
    (place "Restauracja")
    (fancy "Nie")
    ?oldQuestion <- (question (text ?name) (fact fancy) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Zamówienie z okna?") (fact window) (answers "Nie" "Tak...?") (type single)))
)

(defrule pronounQ
    (place "Restauracja")
    (fancy "Oui.")
    ?oldQuestion <- (question (text ?name) (fact fancy) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Jesteś w stanie wymówić zawartość menu?") (fact pronoun) (answers "Nie" "Tak") (type single)))
)

(defrule specialQ
    (place "Specjalna okazja")
    ?oldQuestion <- (question (text ?name) (fact place) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Jaka jest to okazja?") (fact special) (answers "Nowy rok" "Urodziny" "Rocznica" "Randka w ciemno" "Ślub bez zgody rodziców, w ukryciu") (type single)))
)

(defrule oldQ
    (special "Urodziny")
    ?oldQuestion <- (question (text ?name) (fact special) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Czy widziałeś/aś już wiele wiosen?") (fact old) (answers "Jeszcze dużo przede mną" "Wiele") (type single)))
)

(defrule anniversayQ
    (special "Rocznica")
    ?oldQuestion <- (question (text ?name) (fact special) (answers $?answers) (type ?type))
    =>
    (retract ?oldQuestion)
    (assert (question (text "Która to rocznica?") (fact anniversary) (answers "1." "2+") (type single)))
)