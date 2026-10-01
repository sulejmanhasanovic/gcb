# Skeniranje i evidencija izlaznosti

## Postavljanje u postojeću SQL Server bazu

1. Zaustavite aplikaciju i napravite backup. Koristite novi paket `Tracking-skeniranje.zip` i postojeću konekciju/korisničke naloge.
2. Ako su prijem i verifikacija već nadograđeni skriptom 04, izvršite `database/05-upgrade-scanning.sql`. Dodaje Voters, VotesCast, ScanningSessions i ScanAttempts. Ne mijenja postojeće prijeme, vreće niti izvorne tabele Voter/p3_VotesCast.
3. Prenesite postojeću tabelu **dbo.Voter s podacima** u istu bazu ako još nije tamo. Dostavljeni `voter_votecast_insert sp.sql` sadrži strukturu/procedure, ali sam po sebi ne učitava birački spisak. Stare procedure ne treba instalirati za novi modul.
4. U `database/06-import-voters.sql` upišite tačan `@ElectionCode` i pokrenite skriptu. Izborna šifra mora biti jednaka vrijednosti iz `SELECT DISTINCT ElectionCode FROM dbo.PollingStations`. Ako registar još ne postoji/prazan je, upišite stvarnu šifru izbora i koristite je dosljedno. Prazna vrijednost namjerno zaustavlja uvoz.
5. U postojećem `appsettings.Development.json` za Visual Studio dodajte odjeljak `Tracking` prikazan ispod, uz postojeće `Database` i `ConnectionStrings`. Za objavljeni server koristite odgovarajuću konfiguraciju okruženja ili `Tracking__ElectionCode`.
6. Pokrenite novu aplikaciju. U Administracija → Korisnici i uloge dostupna je nova uloga **Operater skeniranja**. Postojeći administratori, supervizori i operateri prijema također mogu skenirati; uloga Pregled ne može unositi niti završavati skeniranje.

```json
"Tracking": {
  "ElectionCode": "UPISITE_STVARNU_SIFRU_IZBORA"
}
```

Ovo je odjeljak unutar postojećeg JSON objekta, ne zaseban kompletan fajl. Ako ElectionCode nije podešen, aplikacija ga može prepoznati samo kada registar i birački spisak sadrže tačno jedan izborni ciklus. Konekcija je i dalje `ConnectionStrings:Tracking`, provider `Database:Provider = SqlServer`.

Prilagodite `USE [Tracking]` u obje skripte ako se vaša baza drugačije zove. Za potpuno novu bazu redoslijed je **01 → 02 → 03 → 04 → 05 → 06**, zatim inicijalizacija administratora. Skripta 03 učitava ranije dostavljeni registar specijalnih mjesta; provjerite odgovara li vašim izborima prije uvoza.

## Uvoz birača

- `RegID` → `Jmbg`; tekst od 13 cifara, početne nule ostaju sačuvane. `PersonalID` nije korišten kao zamjena.
- `Eligible = '1'` → `IsEligible = 1`. Ostale vrijednosti, uključujući NULL, nemaju pravo glasa. Izvorna oznaka se čuva u SourceEligibilityCode.
- `TypeOfPollingStationCode` → `SourceTypeCode`: N/Nepotvrđeni, 2/Odsustvo, M/Mobilni, O/Pošta, D/DKP, 1/Redovni.
- `PSCode` → `PollingStationCode` ako kolona postoji; inače se koristi `PollingStation` iz dostavljenog SQL-a. Rezultat skripte prikazuje odabranu kolonu. Provjerite je ako vaš izvor sadrži obje.
- Čuvaju se izvorni ID, ime, prezime, ime roditelja, datum rođenja i opštinske šifre potrebne modulu. Ostale izvorne kolone ostaju u netaknutoj tabeli Voter.
- Jedinstvenost je po izborima i JMBG. Neispravni identifikatori, duplikati i preduge vrijednosti zaustavljaju cijeli uvoz bez djelimičnog upisa. Identifikatori se ne ispisuju u porukama grešaka.
- Prije početka skeniranja ponovni uvoz istih podataka preskače postojeće birače. Različite vrijednosti postojećeg birača prekidaju uvoz umjesto prepisivanja. Poslije otvaranja prve sesije za te izbore skripta blokira uvoz.
- Stari p3_VotesCast zapisi se ne prenose. VotesCast kreće prazan i puni se samo uspješnim novim skeniranjem. Ovo je novi ciklus evidentiranja, ne migracija već izvršenog skeniranja.
- Nepoznate izvorne kategorije ostaju sačuvane u spisku, ali se ne pretvaraju u Redovne i ne ulaze u prikaz izlaznosti šest podržanih kategorija.

## Rad u aplikaciji

Meni: **Generisanje vreća → Prijem pošiljki → Prijem i verifikacija → Skeniranje → Administracija**. Grupe se otvaraju klikom, aktivna cjelina je automatski proširena. Biračka mjesta i razlozi odbijanja su u Administraciji.

U Skeniranju odaberite kategoriju pa biračko mjesto. **Započni skeniranje** kreira samo status, bez kopiranja birača. Za Redovne se šifre mjesta prepoznaju iz Voters, pa ne treba generisati vreće. Pošta ima jednu zajedničku sesiju za izbore i ne zahtijeva pojedinačno biračko mjesto ili vreću.

Unesite/skenirajte JMBG i pritisnite Enter. Sistem provjerava postojanje birača, pravo glasa, kategoriju, pripadnost otvorenom mjestu (osim Pošte) i prethodno evidentiranje. Za sve kategorije vrijede ista pravila; Nepotvrđeni ne prihvataju birače tipa O. Samo prihvaćen unos kreira VotesCast. Odbijeni pokušaj se čuva zasebno s razlogom, operaterom i UTC vremenom.

Poslije svakog unosa polje JMBG je prazno i fokusirano za sljedećeg birača. Na tabeli se prikazuju samo posljednje četiri cifre JMBG; puni JMBG se ne prenosi kroz URL. Prikazani brojači vrijede za cijelo mjesto/sesiju, uključujući sve operatere.

Statusi: **Započeto → U toku → Završeno**. Prvi prihvaćen unos postavlja U toku. Otvorite **Završi skeniranje** i potvrdite završetak; nakon toga je moguć pregled, bez novih unosa. Završavanje je dopušteno i bez evidentiranih birača. Ponovno otvaranje i poništavanje evidencija nisu dio ove etape.

Prikaz uključuje izlaznost kategorije i ukupno za šest podržanih kategorija. Redoslijed kategorija u meniju je Nepotvrđeni, Odsustvo, Mobilni, Pošta, DKP, Redovni; aplikacija ne blokira jednu kategoriju zbog statusa druge.

## Provjera

SQLite migracije se automatski primjenjuju pri pokretanju. SQL skripte su samo za SQL Server. Provedene su provjere modela, nadogradnje, poslovnih pravila, konkurentnih upisa i web formi na zasebnoj SQLite bazi sa sintetičkim podacima. SQL Server migracija je generisana i pregledana; lokalna SQL Server instanca nije bila dostupna alatu zbog greške Windows/SSL autentikacije, pa skripte 05 i 06 nisu izvršene na SQL Serveru. Provjerite ih na kopiji svoje baze prije operativnog rada.
