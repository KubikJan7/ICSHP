----------------------------------------------------
ICSHP - Semestrální práce
----------------------------------------------------

Téma 
 - Remake videohry Asteroids

Základní body
 - Herní plocha bez hranic (2D torus)
 - Reprezentace herních objektů pomocí základních geometrických tvarů
 - Ovládání hráčovi vesmírné lodě klávesami (šipky, wasd -> pohyb; mezerník - střelba; shift - cestování hyperprostorem)
 - Pohyb hráčovi lodě zahrnuje i jednoduchou simulaci setrvačnosti
 - Jednoduchá vizualizace kolizí
 - Náhodné generování asteroidů a jejich pohybu na začátku hry a po jejich zničení
 - 3 velikosti asteroidů -> při kolizi rozpad na 2 menší
 - Jednoduchá AI nepřátelských lodí -> pohyb jedním směrem, střelba
 - Zvyšování herního skóre při ničení nepřátelských herních objektů
 - Zásahem hráč ztrácí 1 život (začíná se 3)
 - Při dosažení skóre 10 000 získání životu navíc
 - Postupné navyšování obtížnosti
 
Rozšiřující body
 - Lepší vizualizace -> propracovanější reprezentace herních objektů, přidání pozadí, animace explozí atd.
 - Přidání zvukových efektů (střelba, kolize, ...)
 - Propracovanější AI -> vyhýbání se asteroidům a střelám hráče, krytí se za asteroidy...
 
Poznámka
 - V požadavcích zadání je uvedeno, že má hra obsahovat načítání 
   herní mapy/plochy ze souborů. Herní plocha tohoto typu videohry 
   však neobsahuje objekty, jež by bylo vhodné takto načítat. 
   Jako řešení by se nabízelo odklonění se od konceptu původní hry 
   a přidání pevných herních objektů (překážek), kterým by se hráč 
   musel vyhýbat. 