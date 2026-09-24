-- Tracking: nezavisno skeniranje i evidencija izlaznosti.
-- Backup postojece baze; zaustavite aplikaciju. Odaberite odgovarajucu bazu.
USE [Tracking];
GO
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
    THROW 51000, 'Prvo primijenite postojece Tracking migracije 01, 02 i 04.', 1;
IF NOT EXISTS (SELECT 1 FROM [__EFMigrationsHistory] WHERE MigrationId = N'20260924070610_BagWorkflowSqlServer')
    THROW 51000, 'Prvo primijenite 04-upgrade-bag-workflow.sql.', 1;
BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE TABLE [ScanningSessions] (
        [Id] int NOT NULL IDENTITY,
        [ElectionCode] nvarchar(50) NOT NULL,
        [Category] int NOT NULL,
        [PollingStationCode] nvarchar(10) NOT NULL,
        [Status] int NOT NULL,
        [StartedById] nvarchar(450) NOT NULL,
        [StartedAtUtc] datetime2 NOT NULL,
        [CompletedById] nvarchar(450) NULL,
        [CompletedAtUtc] datetime2 NULL,
        [Version] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ScanningSessions] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_ScanningSession_Category] CHECK (Category IN (1,2,3,4,5,6)),
        CONSTRAINT [CK_ScanningSession_Station] CHECK ((Category = 4 AND PollingStationCode = '') OR (Category <> 4 AND PollingStationCode <> '')),
        CONSTRAINT [CK_ScanningSession_Status] CHECK ((Status IN (1,2) AND CompletedAtUtc IS NULL AND CompletedById IS NULL) OR (Status = 3 AND CompletedAtUtc IS NOT NULL AND CompletedById IS NOT NULL)),
        CONSTRAINT [FK_ScanningSessions_AspNetUsers_CompletedById] FOREIGN KEY ([CompletedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ScanningSessions_AspNetUsers_StartedById] FOREIGN KEY ([StartedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE TABLE [Voters] (
        [Id] int NOT NULL IDENTITY,
        [SourceId] int NULL,
        [ElectionCode] nvarchar(50) NOT NULL,
        [Jmbg] nvarchar(13) NOT NULL,
        [FirstName] nvarchar(60) NULL,
        [LastName] nvarchar(60) NULL,
        [ParentsName] nvarchar(50) NULL,
        [DateOfBirth] datetime2 NULL,
        [IsEligible] bit NOT NULL,
        [SourceEligibilityCode] nvarchar(1) NULL,
        [SourceTypeCode] nvarchar(1) NULL,
        [PollingStationCode] nvarchar(10) NULL,
        [VoteForMunicipalityCode] nvarchar(4) NULL,
        [VoteInMunicipalityCode] nvarchar(4) NULL,
        [CurrentMunicipalityCode] nvarchar(50) NULL,
        CONSTRAINT [PK_Voters] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE TABLE [ScanAttempts] (
        [Id] bigint NOT NULL IDENTITY,
        [ScanningSessionId] int NOT NULL,
        [VoterId] int NULL,
        [JmbgLast4] nvarchar(4) NOT NULL,
        [Accepted] bit NOT NULL,
        [Result] nvarchar(250) NOT NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_ScanAttempts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ScanAttempts_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ScanAttempts_ScanningSessions_ScanningSessionId] FOREIGN KEY ([ScanningSessionId]) REFERENCES [ScanningSessions] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ScanAttempts_Voters_VoterId] FOREIGN KEY ([VoterId]) REFERENCES [Voters] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE TABLE [VotesCast] (
        [Id] bigint NOT NULL IDENTITY,
        [ElectionCode] nvarchar(50) NOT NULL,
        [VoterId] int NOT NULL,
        [ScanningSessionId] int NOT NULL,
        [Category] int NOT NULL,
        [RegisteredPollingStationCode] nvarchar(10) NULL,
        [RegisteredSourceTypeCode] nvarchar(1) NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_VotesCast] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_VotesCast_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_VotesCast_ScanningSessions_ScanningSessionId] FOREIGN KEY ([ScanningSessionId]) REFERENCES [ScanningSessions] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_VotesCast_Voters_VoterId] FOREIGN KEY ([VoterId]) REFERENCES [Voters] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_ScanAttempts_CreatedById] ON [ScanAttempts] ([CreatedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_ScanAttempts_ScanningSessionId_Id] ON [ScanAttempts] ([ScanningSessionId], [Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_ScanAttempts_VoterId] ON [ScanAttempts] ([VoterId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_ScanningSessions_CompletedById] ON [ScanningSessions] ([CompletedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_ScanningSessions_ElectionCode_Category_PollingStationCode] ON [ScanningSessions] ([ElectionCode], [Category], [PollingStationCode]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_ScanningSessions_StartedById] ON [ScanningSessions] ([StartedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Voters_ElectionCode_Jmbg] ON [Voters] ([ElectionCode], [Jmbg]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_Voters_ElectionCode_SourceTypeCode_PollingStationCode] ON [Voters] ([ElectionCode], [SourceTypeCode], [PollingStationCode]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_VotesCast_CreatedById] ON [VotesCast] ([CreatedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_VotesCast_ElectionCode_VoterId] ON [VotesCast] ([ElectionCode], [VoterId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_VotesCast_ScanningSessionId] ON [VotesCast] ([ScanningSessionId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    CREATE INDEX [IX_VotesCast_VoterId] ON [VotesCast] ([VoterId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924095559_ScanningSqlServer'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260924095559_ScanningSqlServer', N'10.0.5');
END;

COMMIT;
GO

