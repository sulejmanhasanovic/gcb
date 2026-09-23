# Nadogradnja: biračka mjesta i generisane vreće

## Ako već imate bazu i korisnika iz prve etape

1. Preuzmite i raspakujte `Tracking-registar-vreca.zip`. Projekt je u `Tracking.Standalone/src/Tracking.Web/Tracking.Web.csproj`.
2. Zaustavite staru aplikaciju i napravite backup postojeće baze Tracking.
3. U SSMS-u na istoj SQL Server instanci izvršite `database/02-upgrade-bag-registry.sql`, zatim `database/03-import-polling-stations.sql`. Ako vaša baza ima drugo ime, prilagodite `USE [Tracking]` na početku obje skripte. Prva skripta dodaje tabele i vezu s prijemom, a druga učitava 662 biračka mjesta. Ne brišu korisnike, pošiljke niti stare vreće. Ponovljeno izvršavanje preskače postojeće migracije/mjesta.
4. U novom projektu podesite konekciju na **istu bazu**, pa pokrenite aplikaciju. Prijavite se postojećim korisnikom. Ne kreirajte novog administratora.

Za potpuno novu bazu izvršite skripte redom **01 → 02 → 03**, pa pokrenite `Start-Tracking.ps1 -SqlServer '.\SQLEXPRESS' -TrustServerCertificate -Initialize` i unesite prvi administratorski nalog.

## Visual Studio i konekcija

PowerShell varijable iz skripte ne prenose se automatski u već otvoreni Visual Studio. Dodajte sljedeća dva odjeljka u `src/Tracking.Web/appsettings.Development.json`, uz postojeći Logging ako ga ima:

```json
{
  "Database": { "Provider": "SqlServer" },
  "ConnectionStrings": {
    "Tracking": "Server=.\\SQLEXPRESS;Database=Tracking;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
  }
}
```

Zamijenite server i bazu svojim vrijednostima iz SSMS-a. Dvostruka kosa crta je JSON zapis za jednu kosu crtu. Ovaj primjer koristi Windows autentikaciju. `TrustServerCertificate=True` je za lokalni testni server sa samopotpisanim certifikatom; na serveru s važećim certifikatom koristite False. SQL lozinke čuvajte u User Secrets ili varijablama okruženja, ne u repozitoriju.

Iz direktorija `Tracking.Standalone` možete i dalje pokrenuti:

```powershell
.\Start-Tracking.ps1 -SqlServer '.\SQLEXPRESS' -TrustServerCertificate
```

Skripta bez `-SqlServer` podrazumijeva SQLite, osim ako je `Database__Provider` već postavljen na SqlServer u njenom okruženju. Za SQL uvijek koristite gornju naredbu ili odgovarajuće varijable okruženja. Ne miješajte SQL i SQLite naloge.

## SQLite proba

```powershell
.\Start-Tracking.ps1 -ImportPollingStations
```

SQLite migracije primjenjuju se na pokretanju, a prekidač učitava priloženi JSON. Pri prvom pokretanju unesite administratora. Uvoz možete ponoviti: postojeća mjesta se ne prepisuju. SQL skripte su samo za SQL Server.

## Korištenje

- **Biračka mjesta**: pregled, pretraga i filtriranje šifrarnika, s prikazom svih osam izvornih brojeva glasača. Brojevi glasača ne utiču na količine koverata.
- **Generisane vreće**: administrator i supervizor mogu generisati, pojedinačno dodavati i brisati nezaprimljene vreće. Ostale role imaju pregled.
- Za Mobilne, Nepotvrđene, DKP i Odsustvo odaberite kategoriju i sva mjesta ili jedno mjesto. Broj vreće jednak je šifri mjesta, npr. `001A501`; postojeće vreće se preskaču.
- Za Poštu unesite količinu 1–1.000. Brojevi rastu `001`, `002`, … i ne ponavljaju se nakon brisanja. Preskaču se oznake već korištene u starim prijemima.
- Pregled omogućava filtriranje po kategoriji i statusu, pretragu, izbor više nezaprimljenih vreća i brisanje. Ako ijedna od odabranih vreća bude zaprimljena, cijeli zahtjev za brisanje se odbija.
- Pri prijemu unesite/izaberite broj generisane vreće ili skenirajte barkod. Biračko mjesto se preuzima iz registra; nema ručnog polja. Vreća mora pripadati kategoriji prijema i ne smije već biti zaprimljena.
- Stare zaprimljene vreće ostaju u svojim pošiljkama. Ne kreiraju se retroaktivno u registru; njihove oznake se ne mogu ponovo generisati.
- Jedan šifrarnik/izborni ciklus po bazi. Uvoz drugog ciklusa u postojeću bazu se odbija.

## Porijeklo i mapiranje podataka

Izvor: `sulejmanhasanovic/gcb/pollingstation.sql`, tabela `PollingStation2026MTFinal`, pregledana 24.09.2026. Izvor nije izvršavan nad novom bazom.

| Izvorni tip | Kategorija u Tracking | Broj mjesta |
|---|---|---:|
| M | Mobilni (2) | 385 |
| N | Nepotvrđeni (3) | 143 |
| D | DKP (4) | 20 |
| 2 | Odsustvo (5) | 114 |

Izvorni tip **O označava Poštu**, a ne Odsustvo. Redovna mjesta (1), lično (9) i zbirni zapis Pošta (O) nisu u ovom šifrarniku za generisanje. Svih 662 uključena zapisa imaju izvorno Vazi=D; oznaka je sačuvana u SourceValidityCode.

| Izvorna kolona | Nova kolona |
|---|---|
| PSCode / PSName / PSNameCyr | Code / Name / NameCyrillic |
| TypeOfPollingStationCode / Vazi | SourceTypeCode / SourceValidityCode |
| Regular / Absentee / ByMail / Total | RegularVoters / AbsenteeVoters / ByMailVoters / TotalVoters |
| Redovni / Licno / Postari / Dkp | RegisteredRegularVoters / InPersonVoters / PostalVoters / DkpVoters |

ElectionCode, MunicipalityCode i MunicipalityName zadržavaju nazive. Šifre su tekstualne, a sve količine nullable bigint; izvorne NULL vrijednosti se ne pretvaraju u nule. Dvije izvorne kolone Regular i Redovni ostaju zasebne. Lokacije i geografske koordinate nisu preuzete.

## Obuhvat ove nadogradnje

Ova etapa dodaje registar i povezivanje s postojećim prijemom. Prilagođavanje grupnog prijema Pošte prema slikama, zaseban neposredni prijem drugih kategorija, izmjene zaprimljenih količina, šifrarnik razloga odbijanja, kontrolno brojanje i prijem za verifikaciju ostaju naredna dogovorena etapa. Postojeće pravilo zatvaranja prijema po količini nije promijenjeno.

## Provjera

Automatizovane provjere uključuju nadogradnju SQLite baze sa starim prijemom, uvoz, duplikate, numeraciju, svih pet kategorija, zaštitu brisanja i historiju. SQL Server migracije i DDL su generisani i provjereni bez spajanja na živu SQL Server instancu. Izvršavanje SQL skripti na SQL Serveru ostaje provjera na vašoj testnoj instanci.
