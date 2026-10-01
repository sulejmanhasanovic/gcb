-- Nadogradnja postojece Tracking baze iz prve etape. Prvo napravite backup.
USE [Tracking];
GO
SET QUOTED_IDENTIFIER ON;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL THROW 50001, 'Prvo izvrsite 01-create-tracking.sql.', 1;
GO
BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    ALTER TABLE [Shipments] DROP CONSTRAINT [CK_Shipment_Group];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [GeneratedBagId] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE TABLE [BagSequences] (
        [Id] int NOT NULL,
        [NextNumber] bigint NOT NULL,
        [Version] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_BagSequences] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE TABLE [PollingStations] (
        [Id] int NOT NULL IDENTITY,
        [ElectionCode] nvarchar(50) NOT NULL,
        [Code] nvarchar(10) NOT NULL,
        [Name] nvarchar(50) NULL,
        [NameCyrillic] nvarchar(50) NULL,
        [MunicipalityCode] nvarchar(10) NULL,
        [MunicipalityName] nvarchar(255) NULL,
        [SourceTypeCode] nvarchar(1) NOT NULL,
        [SourceValidityCode] nvarchar(1) NULL,
        [Group] int NOT NULL,
        [IsActive] bit NOT NULL,
        [RegularVoters] bigint NULL,
        [AbsenteeVoters] bigint NULL,
        [ByMailVoters] bigint NULL,
        [TotalVoters] bigint NULL,
        [RegisteredRegularVoters] bigint NULL,
        [InPersonVoters] bigint NULL,
        [PostalVoters] bigint NULL,
        [DkpVoters] bigint NULL,
        CONSTRAINT [PK_PollingStations] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_PollingStation_Group] CHECK ("Group" IN (2, 3, 4, 5))
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE TABLE [GeneratedBags] (
        [Id] int NOT NULL IDENTITY,
        [Barcode] nvarchar(40) NOT NULL,
        [Group] int NOT NULL,
        [PollingStationId] int NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_GeneratedBags] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_GeneratedBag_Group] CHECK (("Group" = 1 AND PollingStationId IS NULL) OR ("Group" IN (2,3,4,5) AND PollingStationId IS NOT NULL)),
        CONSTRAINT [FK_GeneratedBags_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_GeneratedBags_PollingStations_PollingStationId] FOREIGN KEY ([PollingStationId]) REFERENCES [PollingStations] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    EXEC(N'ALTER TABLE [Shipments] ADD CONSTRAINT [CK_Shipment_Group] CHECK ("Group" IN (1, 2, 3, 4, 5))');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Bags_GeneratedBagId] ON [Bags] ([GeneratedBagId]) WHERE [GeneratedBagId] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_GeneratedBags_Barcode] ON [GeneratedBags] ([Barcode]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE INDEX [IX_GeneratedBags_CreatedById] ON [GeneratedBags] ([CreatedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_GeneratedBags_PollingStationId] ON [GeneratedBags] ([PollingStationId]) WHERE "PollingStationId" IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_PollingStations_Code] ON [PollingStations] ([Code]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    CREATE INDEX [IX_PollingStations_Group_MunicipalityCode] ON [PollingStations] ([Group], [MunicipalityCode]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD CONSTRAINT [FK_Bags_GeneratedBags_GeneratedBagId] FOREIGN KEY ([GeneratedBagId]) REFERENCES [GeneratedBags] ([Id]) ON DELETE NO ACTION;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260923234628_BagRegistrySqlServer'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260923234628_BagRegistrySqlServer', N'10.0.5');
END;

COMMIT;
GO


