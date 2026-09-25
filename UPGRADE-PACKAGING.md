# Nadogradnja: od vreće do napunjene kutije

Ova verzija povezuje prijem, kontrolno brojanje, pripremu, prijem na verifikaciju, konačni rezultat verifikacije i pakovanje prihvaćenih koverti u kutije. Skeniranje je i dalje nezavisno. Postojeće uloge nisu reorganizovane.

## Postojeća SQL Server instalacija

1. Zaustavite aplikaciju i napravite sigurnosnu kopiju baze.
2. Raspakujte Tracking-kutije.zip u novi direktorij. Projekt: Tracking.Standalone/src/Tracking.Web/Tracking.Web.csproj.
3. U SQL Server Management Studio otvorite database/07-upgrade-packaging.sql. Prilagodite USE [Tracking] svom nazivu baze. Skripta zahtijeva prethodnu nadogradnju 05 i može se ponoviti bez dupliranja migracije.
4. Izvršite skriptu prvo na kopiji baze. Zadržite svoju SQL Server konekciju i Database:Provider=SqlServer. Ne prepisujte konfiguraciju praznom demonstracijskom konfiguracijom.
5. Pokrenite novi projekt. Postojeći korisnici, vreće, prijemi i podaci skeniranja ostaju sačuvani. Vreće ranije primljene na verifikaciju čekaju novi konačni rezultat; ništa se automatski ne proglašava verificiranim.

Za novu SQL Server bazu primijenite 01, 02, 04, 05 i 07. Skripta 03 služi uvozu biračkih mjesta, a 06 uvozu birača za nezavisno skeniranje; uvoz birača nije potreban za prezentaciju pakovanja. Za radne izbore koristite odgovarajući registar, ne stari primjer. Postupak kreiranja prvog korisnika je u README.md.

SQLite migrira pri pokretanju. Sačuvajte svoj App_Data ili Tracking:DataDirectory; ZIP ne sadrži bazu ni korisničke naloge. Pri nadogradnji napravite kopiju SQLite baze dok aplikacija ne radi.

## Tok za prezentaciju

1. Generišite dvije poštanske vreće. Otvorite pošiljku s 200 koverti i zaprimite 80 u prvu, 120 u drugu vreću. Završite prijem.
2. Na detalju svake vreće evidentirajte kontrolno brojanje, pripremu i prijem na verifikaciju. Radi jednostavnog primjera u pripremi prihvatite sve.
3. U završetku verifikacije evidentirajte 78 prihvaćenih i 2 odbijene u prvoj, 118 prihvaćenih i 2 odbijene u drugoj vreći. Prije toga dodajte odgovarajući razlog za Poštu u administraciji. Zbir razloga mora odgovarati odbijenoj količini.
4. U Pakovanje i kutije formirajte kutije Pošta/K01 i Pošta/K02. Oznake KUT-000001 itd. aplikacija dodjeljuje automatski; brojevi nisu ručni unos.
5. Iz prve vreće rasporedite 50 u K01 i 28 u K02. Iz druge rasporedite 118 u K01. Izbor kombinacije je ručni prema fizičkom materijalu, bez izvođenja iz skeniranja ili opštine fizičkog biračkog mjesta.
6. Potvrdite završetak pakovanja obje vreće. Kutije sada imaju 168 i 28 koverti. Otvorite kutiju i potvrdite da je napunjena.
7. Na detalju kutije pokažite izvorne vreće, količine, status i historiju operatera/vremena. Iz kutije se može otvoriti pakovanje vreće, a zatim cijela njena obrada.

## Pravila ove verzije

- Količine iz pripreme i konačne verifikacije su odvojene. Konačno prihvaćeno + konačno odbijeno mora biti jednako preuzetom na verifikaciju.
- Svaka kutija ima jednu kategoriju i jednu kombinaciju. Sadržaj se izvodi iz stavki vreća–kutija; nema ručnog prepisivanja ukupnog broja.
- Jedna vreća može puniti više kutija, a jedna kutija primati iz više vreća. Posebna ograničenja po kategorijama ostavljena su za kasniji dogovor.
- Prihvaćena količina ne može se rasporediti dvaput. Sadržaj se dodaje samo u formiranu kutiju iste kategorije.
- Prije završetka pakovanja pogrešna stavka može se ukloniti uz razlog i postojeće ovlaštenje za korekcije. Nakon završetka pakovanja vreće stavke su zaključane. Konačna verifikacija i napunjena kutija se u ovoj etapi ne otvaraju ponovo.
- Kutija se može završiti tek kad nije prazna i kad je završeno pakovanje svih njenih izvornih vreća.
- Statusi kutije trenutno su 1 Formirana i 2 Napunjena, usklađeni sa starim šifrarnikom. Nema automatskog slanja na sortiranje.
- Ugrađene su 24 različite kombinacije K01–K24 iz dostavljenog combinations.sql. KXX je vidljiv, ali nije dostupan za pakovanje dok se ne razriješi opcija Brčko. MunicipalityCode/Tip mapa nije uvoz opština niti automatska raspodjela materijala.
- Odbijeno u pripremi i na verifikaciji ostaje vidljivo i evidentirano s razlozima. Fizičko pakovanje odbijenih/KR materijala i pojedinačni registar odbijenih birača nisu dio ove etape. Status vreće glasi „Prihvaćene koverte zapakovane” da ne sugeriše završetak te zasebne grane.
- BoxSorting i unos listića po nivoima nisu implementirani. Integracija brzih skenera zahtijeva stvarni format rezultata i pravila povezivanja s kutijom; nije zamjena za nezavisno skeniranje JMBG.

## Provjera

147 provjera postojećeg prijema/obrade, 72 provjere skeniranja, 96 novih provjera verifikacije i pakovanja te 50 HTTP provjera pakovanja prošle su. Novi testovi obuhvataju svih pet kategorija, dijeljenje/spajanje, količine, zaključavanje, audit, CSRF, postojeća prava i stvarne konkurentne upise.

SQL Server migracija i idempotentna skripta su generisane; provjereno je slaganje modela i migracija oba providera. Ova nadogradnja nije izvršena na živom SQL Serveru. SQLite nova baza i nadogradnja sa sačuvanim starim prijemom su testirane. NuGet audit mrežno nije bio dostupan (NU1900).
