# Tracking — samostalna aplikacija, etapa 1

ASP.NET Core MVC / .NET 10. Zaseban Identity login, korisnici i role, prijem pošiljki i vreća, grupe Pošta / Mobilni / Nepotvrđeni, pretraga, provjera količina, zaključavanje prijema i historija promjena. Novi projekt se nalazi u `Tracking.Standalone`; stara `Tracking` aplikacija ostaje neizmijenjena.

## Pokretanje na drugom računaru sa SQL Serverom

Potrebno: .NET 10 SDK, SQL Server (preporučeno 2022 ili noviji), SQL Server Management Studio i pristup NuGetu za prvo preuzimanje paketa.

1. Preuzmite ovu granu repozitorija i otvorite direktorij `Tracking.Standalone`.
2. U SSMS-u otvorite `database/01-create-tracking.sql`, povežite se na željeni SQL Server i izvršite skriptu. Kreira novu bazu **Tracking**, Identity tabele, poslovne tabele, indekse i evidenciju migracija. Ne izvršavajte je nad postojećom poslovnom bazom. Za drugo ime izmijenite `Tracking` na tri mjesta u početnom dijelu skripte.
3. U PowerShellu iz direktorija `Tracking.Standalone` pokrenite (zamijenite naziv instance):

```powershell
.\Start-Tracking.ps1 -SqlServer '.\SQLEXPRESS' -TrustServerCertificate -Initialize
```

`-TrustServerCertificate` namijenjen je lokalnom testnom SQL Serveru sa samopotpisanim certifikatom. Izostavite ga kada server ima važeći certifikat. Koristi se Windows autentikacija trenutnog korisnika. Taj korisnik mora imati prava nad novom bazom; skripta ne kreira SQL login.

4. Unesite korisničko ime, e-mail i lozinku prvog administratora. Lozinka: najmanje 12 znakova, veliko i malo slovo, broj i poseban znak. Nema unaprijed postavljene lozinke; ne zapisuje se u projekt.
5. Otvorite **http://localhost:5180**. Server radi dok je PowerShell otvoren. Zaustavlja se sa Ctrl+C. Naredni put pokrenite istu naredbu bez `-Initialize`. Parametar `-Port 5181` omogućava drugi lokalni port.

Ako koristite SQL autentikaciju, postavite `Database__Provider=SqlServer` i `ConnectionStrings__Tracking` u okruženju ili tajnama servera, pa pokrenite `Start-Tracking.ps1 -Initialize` bez parametra `-SqlServer`. Lozinku konekcije ne upisujte u Git. Primjer strukture konekcije: `Server=SERVER;Database=Tracking;User ID=USER;Password=SECRET;Encrypt=True;TrustServerCertificate=False`.

## Bez SQL Servera

`Start-Tracking.ps1` bez parametara koristi SQLite u `src/Tracking.Web/App_Data/`. Pri prvom pokretanju traži podatke administratora. Provideri koriste različite migracije; nema automatskog prenosa podataka između SQLite i SQL Servera.

## Šta je uključeno

- Identity autentikacija, promjena vlastite lozinke i lockout (5 pogrešnih pokušaja / 15 minuta).
- Administrator kreira korisnike sa ulogama administrator, supervizor, prijem ili pregled; prava se provjeravaju na serveru.
- Neuručene pošiljke i ostali materijali vode se odvojeno od koverata u vrećama. Za Poštu se razlikuju redovne koverte i brza pošta.
- Jedinstvene oznake, kontrola ukupnih količina, obavezan razlog ispravke zaglavlja i zaštita od istovremenih izmjena. Završeni prijem se ne može mijenjati.
- Audit upisuje prethodno/novo stanje, korisnički ID i vrijeme. Primljena vreća i audit upisuju se transakcijski.

## Granice radne verzije

Ovo je zasebna nova baza, bez uvoza stare baze, postojećih eIdentity proširenja ili izvršavanja starih SQL procedura. Za Mobilne i Nepotvrđene koristi se zajednički ekran zaglavlja prijema; to nije identična migracija starog modela u kojem se direktno evidentiraju vreće. Šifre mjesta/timova i barkodovi zasad se unose ručno ili skenerom; stari šifrarnici još nisu povezani.

Verifikacija sadržaja, kontrolno brojanje, odbijanja, kutije, sortiranje listića, izvještaji, ispravke vreća, ponovno otvaranje prijema i napredno upravljanje postojećim korisnicima ostaju za naredne etape. Covid nije uključen.

## Postavljanje na server

Za lokalno isprobavanje koristite gornju skriptu. Za IIS instalirajte .NET 10 Hosting Bundle i napravite publish:

```powershell
dotnet publish src/Tracking.Web -c Release -o publish
```

Postavite `ASPNETCORE_ENVIRONMENT=Production`, `Database__Provider=SqlServer`, `ConnectionStrings__Tracking` i `Tracking__DataDirectory` na trajnu lokaciju izvan web direktorija. Identitet aplikacije mora imati pristup bazi i pisanje u direktorij za Data Protection ključeve. Konfigurišite HTTPS, ograničite pristup tom direktoriju i pripremite backup prije stvarnih podataka. Pokretanje skripte lokalno ne objavljuje aplikaciju na internetu.

## Provjera

Prije SQL Server dopune prošlo je 26 provjera domene/SQLite baze i 31 HTTP provjera prijave, CSRF zaštite, prava, sva tri toka prijema, pretrage i lockouta. SQL Server dopuna ima zasebnu generisanu migraciju i idempotentni SQL. Rezultat aktuelne provjere nalazi se u `VALIDATION.md`. Testna baza i testni nalozi nisu dio projekta.
