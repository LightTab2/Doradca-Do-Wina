(defrule boringR
    (gatheringType "Spotkanie")
    (know "Nie")
    =>
    (assert (wine "Weź jakąś nieinteresującą butelkę i trzymaj kciuki, że nikt jej nie otworzy."))
)

(defrule CalPinotNoirR
    (or
        (honest "Tak, są")
        (anniversary "1.")
        (old "Wiele")
    )
    =>
    (assert (wine "Warto pomyśleć o California Pinot Noir."))
)

(defrule noDeserveR
    (or
        (like "Nie")
        (love "Nie")
        (and
            (gift "Tak")
            (know "Nie")
        )
        (cook "Ja")
        (honest "No może jednak nie są...")
    )
    =>
    (assert (wine "Nie zasługują na wino! Nic im nie dawaj."))
)

(defrule vodkaR
    (gatheringType "Wieczór panieński/kawalerski")
    =>
    (assert (wine "Lepiej zostaw wino w domu i weź ze sobą whiskey lub wódkę."))
)


(defrule redR
    (cook "On(a)")
    =>
    (assert (wine "Kup największą butelkę dostępnego czerwonego wina ze zmieszanych winogron."))
)

(defrule noBecahR
    (gatheringType "Grill na plaży")
    =>
    (assert (wine "Nawet jak przyniesiesz fajną butelkę wina, to mogą Ci ją skonfiskować. Na plaży nie może być szkła."))
)

(defrule noBeachR
    (gatheringType "Otwarcie wystawy")
    =>
    (assert (wine "Cokolwiek, najlepiej najtańsze. Tutaj rzadko mają jakieś poczucie smaku."))
)

(defrule PinotNoirR
    (work "Tak")
    =>
    (assert (wine "Rozkoszuj się Pinot Noir."))
)

(defrule ZinShiR
    (drunk "Tak")
    =>
    (assert (wine "Polecam Zinfandel lub Shiraz."))
)

(defrule SanGreR
    (or
        (and
            (drunk "Nie")
            (fancy "Oui.")
        )
        (main "Tak")
        (and
            (special "Nowy rok")
            (alone "Tak")
        )
    )
    =>
    (assert (wine "Polecam coś egzotycznego np.: Sangiovese, Grenache."))
)

(defrule ArgbecR
    (orange "Tak")
    =>
    (assert (wine "Polecam wino z dominującym smakiem owoców np. Argentyński Malbec."))
)

(defrule ChieilR
    (dirt "Mniam")
    =>
    (assert (wine "...Chinon lub Bourgueil."))
)

(defrule butterR
    (butter "Tak!")
    =>
    (assert (wine "Polecam Butter Chardonnay."))
)

(defrule worldR
    (world "Stary!")
    =>
    (assert (wine "Wszystko, tylko nie Bordeaux ani Burgundy."))
)

(defrule CalCabernetR
    (or
        (window "Nie")
        (cult "Nie")
    )
    =>
    (assert (wine "Butla Słońca: California Cabernet."))
)

(defrule budgetR
    (or
        (microwave "Tak")
        (window "Tak...?")
    )
    =>
    (assert (wine "Co powiesz na skrzynkę 3 litrów taniego wina?"))
)

(defrule cookR
    (cookWine "Tak")
    =>
    (assert (wine "Niedrogie białe wino np. Sauvignon Blanc."))
)

(defrule pronounR
    (pronoun "Nie")
    =>
    (assert (wine "Zapytaj o Cotes Du Rhone."))
)

(defrule cultR
    (cult "Tak")
    =>
    (assert (wine "Klasyka: Sine Qua Non albo Cayuse."))
)

(defrule publicR
     (or
        (place "Miejsce publiczne")
        (place "Kemping")
    )
    =>
    (assert (wine "Niebudzące podejrzeń wino w kartoniku."))
)

(defrule newYearR
    (special "Nowy rok")
    (alone "Nie")
    =>
    (assert (wine "Tanie gazowane np. Hiszpańska Cava."))
)

(defrule anniversaryR
    (anniversary "2+")
    =>
    (assert (wine "Nie martw się o różnorodność. Zawsze Merlot."))
)

(defrule sweetR
    (or
        (old "Jeszcze dużo przede mną")
        (special "Randka w ciemno")
        (special "Ślub bez zgody rodziców, w ukryciu")
    )
    =>
    (assert (wine "Coś słodkiego np. Riesling albo Chenin Blanc."))
)

(defrule noClueR
    (or
        (butter "Nie")
        (world "Że co?")
        (dinner "Nie")
        (gift "Nie")
        (collection "Nie")
    )
    =>
    (assert (wine "Niestety nie wiem, co doradzić."))
)