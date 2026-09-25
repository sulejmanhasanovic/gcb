-- Uvoz iz dostavljene dbo.Voter u novu dbo.Voters u istoj odabranoj bazi.
-- Izvorna Voter i p3_VotesCast se ne mijenjaju. Stari glasovi se NE prenose.
-- Prvo izvrsiti 05-upgrade-scanning.sql. Backup; aplikacija zaustavljena tokom uvoza.
-- Ako je izvor u drugoj bazi, prvo ga prenesite u dbo.Voter ove baze.
USE [Tracking];
GO
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;

-- OBAVEZNO upisite tacnu sifru izbora, jednaku PollingStations.ElectionCode
-- i postavci Tracking:ElectionCode. Primjer nije unaprijed odabran.
DECLARE @ElectionCode nvarchar(50) = N'';
IF NULLIF(LTRIM(RTRIM(@ElectionCode)),N'') IS NULL
    THROW 51000, 'Upisite @ElectionCode prije izvrsavanja uvoza.', 1;
SET @ElectionCode = LTRIM(RTRIM(@ElectionCode));
IF OBJECT_ID(N'dbo.Voters',N'U') IS NULL OR OBJECT_ID(N'dbo.ScanningSessions',N'U') IS NULL
    THROW 51000, 'Prvo izvrsite 05-upgrade-scanning.sql.', 1;
IF OBJECT_ID(N'dbo.Voter',N'U') IS NULL
    THROW 51000, 'Izvorna tabela dbo.Voter nije pronadjena u odabranoj bazi.', 1;
IF EXISTS (SELECT 1 FROM dbo.PollingStations WHERE ElectionCode <> @ElectionCode)
    THROW 51000, 'Sifra izbora ne odgovara postojecem registru birackih mjesta.', 1;

-- Poslani SQL ima PollingStation; novija struktura moze imati PSCode.
DECLARE @StationColumn sysname = CASE
    WHEN COL_LENGTH(N'dbo.Voter',N'PSCode') IS NOT NULL THEN N'PSCode'
    WHEN COL_LENGTH(N'dbo.Voter',N'PollingStation') IS NOT NULL THEN N'PollingStation'
    ELSE NULL END;
IF @StationColumn IS NULL THROW 51000, 'Voter mora sadrzavati PSCode ili PollingStation.', 1;

BEGIN TRY
    BEGIN TRANSACTION;
    IF EXISTS (SELECT 1 FROM dbo.ScanningSessions WITH (UPDLOCK,HOLDLOCK) WHERE ElectionCode=@ElectionCode)
        THROW 51000, 'Skeniranje je vec zapoceto. Uvoz ili izmjena spiska vise nije dozvoljena ovom skriptom.', 1;
    CREATE TABLE #VoterImport (
        SourceId int NULL, Jmbg nvarchar(100) NULL,
        FirstName nvarchar(100) NULL, LastName nvarchar(100) NULL, ParentsName nvarchar(100) NULL,
        DateOfBirth datetime2 NULL, SourceEligibilityCode nvarchar(100) NULL,
        SourceTypeCode nvarchar(100) NULL, PollingStationCode nvarchar(100) NULL,
        VoteForMunicipalityCode nvarchar(100) NULL, VoteInMunicipalityCode nvarchar(100) NULL,
        CurrentMunicipalityCode nvarchar(100) NULL
    );
    DECLARE @Sql nvarchar(max) = N'
        INSERT INTO #VoterImport
            (SourceId,Jmbg,FirstName,LastName,ParentsName,DateOfBirth,SourceEligibilityCode,
             SourceTypeCode,PollingStationCode,VoteForMunicipalityCode,VoteInMunicipalityCode,CurrentMunicipalityCode)
        SELECT ID,LTRIM(RTRIM(RegID)),FirstName,LastName,ParentsName,DateOfBirth,
            NULLIF(LTRIM(RTRIM(Eligible)),N''''),NULLIF(UPPER(LTRIM(RTRIM(TypeOfPollingStationCode))),N''''),
            NULLIF(UPPER(LTRIM(RTRIM('+QUOTENAME(@StationColumn)+N'))),N''''),
            VoteForMunicipalityCode,VoteInMunicipalityCode,CurrentMunicipalityCode
        FROM dbo.Voter WITH (HOLDLOCK);';
    EXEC sys.sp_executesql @Sql;
    IF NOT EXISTS (SELECT 1 FROM #VoterImport) THROW 51000, 'Izvorni biracki spisak je prazan.', 1;
    IF EXISTS (SELECT 1 FROM #VoterImport WHERE Jmbg IS NULL OR LEN(Jmbg)<>13 OR Jmbg COLLATE Latin1_General_100_BIN2 LIKE N'%[^0-9]%')
        THROW 51000, 'RegID mora sadrzavati 13 cifara. Uvoz nije izvrsen; provjerite izvor.', 1;
    IF EXISTS (SELECT Jmbg FROM #VoterImport GROUP BY Jmbg HAVING COUNT(*)>1)
        THROW 51000, 'Izvor sadrzi duple RegID vrijednosti. Uvoz nije izvrsen.', 1;
    IF EXISTS (SELECT 1 FROM #VoterImport WHERE LEN(FirstName)>60 OR LEN(LastName)>60 OR LEN(ParentsName)>50
        OR LEN(SourceEligibilityCode)>1 OR LEN(SourceTypeCode)>1 OR LEN(PollingStationCode)>10
        OR LEN(VoteForMunicipalityCode)>4 OR LEN(VoteInMunicipalityCode)>4 OR LEN(CurrentMunicipalityCode)>50)
        THROW 51000, 'Podaci prelaze podrzane duzine kolona. Nista nije skraceno niti uvezeno.', 1;
    IF EXISTS (SELECT 1 FROM #VoterImport WHERE SourceEligibilityCode=N'1'
        AND SourceTypeCode IN (N'1',N'2',N'N',N'M',N'D') AND PollingStationCode IS NULL)
        THROW 51000, 'Birac s pravom glasa nema sifru birackog mjesta. Provjerite izvor.', 1;

    -- Ponovni uvoz istih podataka je bezopasan; razlike se ne prepisuju precutno.
    IF EXISTS (
        SELECT 1 FROM #VoterImport s JOIN dbo.Voters v WITH (UPDLOCK,HOLDLOCK)
            ON v.ElectionCode=@ElectionCode AND v.Jmbg=s.Jmbg
        WHERE EXISTS (
            SELECT s.SourceId,s.FirstName,s.LastName,s.ParentsName,s.DateOfBirth,s.SourceEligibilityCode,
                s.SourceTypeCode,s.PollingStationCode,s.VoteForMunicipalityCode,s.VoteInMunicipalityCode,s.CurrentMunicipalityCode,
                CAST(CASE WHEN s.SourceEligibilityCode=N'1' THEN 1 ELSE 0 END AS bit)
            EXCEPT
            SELECT v.SourceId,v.FirstName,v.LastName,v.ParentsName,v.DateOfBirth,v.SourceEligibilityCode,
                v.SourceTypeCode,v.PollingStationCode,v.VoteForMunicipalityCode,v.VoteInMunicipalityCode,v.CurrentMunicipalityCode,v.IsEligible
        )
    ) THROW 51000, 'Postojeci biraci se razlikuju od izvora. Uvoz je zaustavljen bez prepisivanja.', 1;

    INSERT INTO dbo.Voters (SourceId,ElectionCode,Jmbg,FirstName,LastName,ParentsName,DateOfBirth,
        IsEligible,SourceEligibilityCode,SourceTypeCode,PollingStationCode,
        VoteForMunicipalityCode,VoteInMunicipalityCode,CurrentMunicipalityCode)
    SELECT s.SourceId,@ElectionCode,s.Jmbg,s.FirstName,s.LastName,s.ParentsName,s.DateOfBirth,
        CAST(CASE WHEN s.SourceEligibilityCode=N'1' THEN 1 ELSE 0 END AS bit),s.SourceEligibilityCode,
        s.SourceTypeCode,s.PollingStationCode,s.VoteForMunicipalityCode,s.VoteInMunicipalityCode,s.CurrentMunicipalityCode
    FROM #VoterImport s WHERE NOT EXISTS (SELECT 1 FROM dbo.Voters v WITH (UPDLOCK,HOLDLOCK)
        WHERE v.ElectionCode=@ElectionCode AND v.Jmbg=s.Jmbg);
    DECLARE @Imported int=@@ROWCOUNT;
    DROP TABLE #VoterImport;
    COMMIT;
    SELECT @Imported AS ImportedVoters, @StationColumn AS SourceStationColumn;
    SELECT SourceTypeCode, COUNT_BIG(*) AS TotalVoters,
        SUM(CAST(IsEligible AS bigint)) AS EligibleVoters
    FROM dbo.Voters WHERE ElectionCode=@ElectionCode GROUP BY SourceTypeCode;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK;
    THROW;
END CATCH;
