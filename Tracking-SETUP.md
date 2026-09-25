# Tracking: prijem, verifikacija, pakovanje i skeniranje

Preuzmite **Tracking-kutije.zip**. Projekt je `Tracking.Standalone/src/Tracking.Web/Tracking.Web.csproj`.

Nova verzija povezuje tok od prijema vreće do napunjene kutije. Uključuje konačni rezultat verifikacije, razloge odbijanja, formiranje kutija po kategoriji i kombinaciji, raspodjelu iz vreća, pregled porijekla i zaključavanje punjenja. Skeniranje ostaje nezavisno. Postojeća prava nisu reorganizovana.

Za postojeću SQL Server instalaciju koja ima nadogradnju 05, primijenite **database/07-upgrade-packaging.sql**, uz prethodni backup i prilagođen naziv baze. Zadržite svoju konekciju i korisničke naloge. Birače nije potrebno uvoziti za pakovanje.

Detaljne upute i primjer za prezentaciju: [UPGRADE-PACKAGING.md](UPGRADE-PACKAGING.md).

Za novu bazu: šema 01 → 02 → 04 → 05 → 07, zatim inicijalizacija prvog korisnika. 03 služi uvozu biračkih mjesta, a 06 uvozu birača; provjerite izborne podatke prije tih uvoza. Za skeniranje i ElectionCode slijedite [UPGRADE-SCANNING.md](UPGRADE-SCANNING.md). SQLite se migrira pri pokretanju.

Obuhvat završava napunjenom kutijom prihvaćenih koverti. KR pakovanje, sortiranje, brojanje listića i integracija brzih skenera ostaju za naredni dogovor.

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
- Pri prijemu unesite/izaberite broj generisane vreće ili skenirajte barkod. Biračko mjesto se preuzima iz registra; nema ručnog polja. Vreća mora pripadati kategoriji prijema. Poštanska vreća može imati više unosa unutar iste otvorene pošiljke; druge kategorije primaju se jednom.
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

## Radni tok u ovoj verziji

1. **Razlozi odbijanja**: administrator/supervizor dodaje, uređuje i deaktivira razloge po kategorijama. Šifrarnik je inicijalno prazan; unesite važeće razloge svoje komisije. Neaktivni razlozi ne nude se za nove unose; raniji zapisi čuvaju tadašnji naziv i količinu.
2. **Prijem**: izaberite kategoriju. Za Mobilne, Nepotvrđene, DKP i Odsustvo „Novi prijem” otvara direktan unos poznate vreće, količine i datuma; oznaka prijema se dodjeljuje automatski. Nakon snimanja provjerite podatke i kliknite „Završi prijem”.
3. **Pošta**: otvorite pošiljku s najavljenim količinama. U istu vreću možete unositi više stavki s različitim pretincima, redovnom ili brzom poštom i napomenama. Neuručene pošiljke i ostali materijali evidentiraju se zasebno. Supervizor može ispraviti svaki unos uz obavezan razlog. Zatvaranje provjerava i koverte i materijale; završeni prijem je zaključan.
4. **Priprema i verifikacija**: završene vreće pojavljuju se u pregledu, s pretragom i filterima kategorije/statusa. Otvorite vreću i unesite kontrolno prebrojanu količinu. Ako se razlikuje od prijema, ponovite brojanje, označite potvrdu i upišite obrazloženje. Prvobitna količina ostaje sačuvana.
5. **Priprema**: upišite prihvaćene i odbijene koverte te raspored odbijenih po razlozima. Prihvaćene + odbijene moraju biti jednake kontrolnom brojanju; zbir razloga mora biti jednak odbijenima. Svaka odbijena koverta računa se pod jednim razlogom.
6. **Verifikacija – prijem materijala**: unesite stvarno preuzeti broj prihvaćenih koverata. Mora se poklapati s pripremom. Kod neslaganja supervizor može vratiti vreću na pripremu uz obrazloženje. Tada slijede novo brojanje i nova priprema; prethodni rezultati i razlozi ostaju u historiji.

Operater prijema radi prijem, brojanje, pripremu i prijem na verifikaciju. Supervizor/administrator održava razloge, ispravlja prijem i vraća vreće. Uloga Pregled nema mogućnost snimanja. Svako snimanje provjerava da drugi operater nije u međuvremenu promijenio podatke.

Ova verzija završava na **prijemu materijala na verifikaciju**. Pojedinačna verifikacija glasača/koverata, skeniranje, pakovanje, kutije i daljnje sortiranje nisu u ovom dogovorenom obuhvatu. Odbijene koverte evidentiraju se po razlozima uz izvornu vreću; ne kreira se poseban daljnji tok za odbijene poštanske koverte.

## Šta skripta 04 čuva i dodaje

Dodaje status obrade i kontrolne količine vreće, detalje poštanskih unosa, evidenciju odvojenih materijala i šifrarnik razloga. Postojeće količine vreća prenose se u po jednu početnu stavku. Postojeće neuručene/ostale količine prenose se kao evidentirani materijali, jer ih je prethodna verzija tako vodila. Korisnici, login, vreće i prvobitne količine ostaju sačuvani. Ponovljeno izvršavanje preskače već primijenjenu migraciju. Prije nadogradnje napravite backup; skripte izvršavajte u SSMS-u.

SQLite se nadograđuje automatski na pokretanju. Prije zamjene aplikacije zaustavite je i sačuvajte kopiju App_Data. Za SQL Server izvršite SQL skripte prije pokretanja nove verzije.

