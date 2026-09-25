-- Tracking: zavrsetak verifikacije i pakovanje u kutije.
-- Zaustavite aplikaciju i napravite backup. Prilagodite naziv baze.
USE [Tracking];
GO
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
    THROW 51000, 'Prvo primijenite Tracking skripte 01, 02, 04 i 05.', 1;
IF NOT EXISTS (SELECT 1 FROM [__EFMigrationsHistory] WHERE MigrationId = N'20260924095559_ScanningSqlServer')
    THROW 51000, 'Prvo primijenite 05-upgrade-scanning.sql.', 1;
BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    ALTER TABLE [Bags] DROP CONSTRAINT [CK_Bag_Stage];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    ALTER TABLE [AuditEntries] ADD [BoxId] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE TABLE [Combinations] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(10) NOT NULL,
        [Levels] nvarchar(200) NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Combinations] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE TABLE [VerificationResults] (
        [BagId] int NOT NULL,
        [Accepted] int NOT NULL,
        [Rejected] int NOT NULL,
        [Comment] nvarchar(1000) NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_VerificationResults] PRIMARY KEY ([BagId]),
        CONSTRAINT [CK_Verification_Counts] CHECK (Accepted >= 0 AND Rejected >= 0 AND Accepted + Rejected <= 1000000),
        CONSTRAINT [FK_VerificationResults_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_VerificationResults_Bags_BagId] FOREIGN KEY ([BagId]) REFERENCES [Bags] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE TABLE [Boxes] (
        [Id] int NOT NULL IDENTITY,
        [Group] int NOT NULL,
        [CombinationId] int NOT NULL,
        [Status] int NOT NULL,
        [Version] uniqueidentifier NOT NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        [FilledById] nvarchar(450) NULL,
        [FilledAtUtc] datetime2 NULL,
        CONSTRAINT [PK_Boxes] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Box_Group] CHECK ("Group" IN (1,2,3,4,5)),
        CONSTRAINT [CK_Box_Status] CHECK ((Status = 1 AND FilledById IS NULL AND FilledAtUtc IS NULL) OR (Status = 2 AND FilledById IS NOT NULL AND FilledAtUtc IS NOT NULL)),
        CONSTRAINT [FK_Boxes_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Boxes_AspNetUsers_FilledById] FOREIGN KEY ([FilledById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Boxes_Combinations_CombinationId] FOREIGN KEY ([CombinationId]) REFERENCES [Combinations] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE TABLE [VerificationRejections] (
        [Id] int NOT NULL IDENTITY,
        [BagId] int NOT NULL,
        [RejectionReasonId] int NOT NULL,
        [ReasonName] nvarchar(200) NOT NULL,
        [Quantity] int NOT NULL,
        [Comment] nvarchar(1000) NULL,
        CONSTRAINT [PK_VerificationRejections] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_VerificationRejection_Quantity] CHECK (Quantity > 0 AND Quantity <= 1000000),
        CONSTRAINT [FK_VerificationRejections_RejectionReasons_RejectionReasonId] FOREIGN KEY ([RejectionReasonId]) REFERENCES [RejectionReasons] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_VerificationRejections_VerificationResults_BagId] FOREIGN KEY ([BagId]) REFERENCES [VerificationResults] ([BagId]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE TABLE [BoxItems] (
        [Id] int NOT NULL IDENTITY,
        [BagId] int NOT NULL,
        [BoxId] int NOT NULL,
        [Quantity] int NOT NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_BoxItems] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_BoxItem_Quantity] CHECK (Quantity > 0 AND Quantity <= 1000000),
        CONSTRAINT [FK_BoxItems_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BoxItems_Bags_BagId] FOREIGN KEY ([BagId]) REFERENCES [Bags] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BoxItems_Boxes_BoxId] FOREIGN KEY ([BoxId]) REFERENCES [Boxes] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'IsActive', N'Levels') AND [object_id] = OBJECT_ID(N'[Combinations]'))
        SET IDENTITY_INSERT [Combinations] ON;
    EXEC(N'INSERT INTO [Combinations] ([Id], [Code], [IsActive], [Levels])
    VALUES (1, N''K01'', CAST(1 AS bit), N''201, 401, 511, 7012''),
    (2, N''K02'', CAST(1 AS bit), N''202, 402, 515, 7012''),
    (3, N''K03'', CAST(1 AS bit), N''203, 402, 515, 7012''),
    (4, N''K04'', CAST(1 AS bit), N''203, 403, 515, 7012''),
    (5, N''K05'', CAST(1 AS bit), N''203, 404, 515, 7012''),
    (6, N''K06'', CAST(1 AS bit), N''204, 405, 514, 7012''),
    (7, N''K07'', CAST(1 AS bit), N''204, 406, 514, 7012''),
    (8, N''K08'', CAST(1 AS bit), N''205, 407, 513, 7012''),
    (9, N''K09'', CAST(1 AS bit), N''206, 408, 514, 7012''),
    (10, N''K10'', CAST(1 AS bit), N''207, 409, 512, 7012''),
    (11, N''K11'', CAST(1 AS bit), N''208, 410, 512, 7012''),
    (12, N''K12'', CAST(1 AS bit), N''209, 407, 513, 7012''),
    (13, N''K13'', CAST(1 AS bit), N''209, 411, 513, 7012''),
    (14, N''K14'', CAST(1 AS bit), N''210, 412, 511, 7012''),
    (15, N''K15'', CAST(1 AS bit), N''301, 521, 600, 703''),
    (16, N''K16'', CAST(1 AS bit), N''302, 521, 600, 703''),
    (17, N''K17'', CAST(1 AS bit), N''303, 521, 600, 703''),
    (18, N''K18'', CAST(1 AS bit), N''304, 522, 600, 703''),
    (19, N''K19'', CAST(1 AS bit), N''305, 522, 600, 703''),
    (20, N''K20'', CAST(1 AS bit), N''306, 522, 600, 703''),
    (21, N''K21'', CAST(1 AS bit), N''307, 523, 600, 703''),
    (22, N''K22'', CAST(1 AS bit), N''308, 523, 600, 703''),
    (23, N''K23'', CAST(1 AS bit), N''309, 523, 600, 703''),
    (24, N''K24'', CAST(1 AS bit), N''402, 515, 7012''),
    (25, N''KXX'', CAST(0 AS bit), N'''')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'IsActive', N'Levels') AND [object_id] = OBJECT_ID(N'[Combinations]'))
        SET IDENTITY_INSERT [Combinations] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    EXEC(N'ALTER TABLE [Bags] ADD CONSTRAINT [CK_Bag_Stage] CHECK (Stage IN (1,2,3,4,5,6))');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_AuditEntries_BoxId_AtUtc] ON [AuditEntries] ([BoxId], [AtUtc]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_Boxes_CombinationId] ON [Boxes] ([CombinationId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_Boxes_CreatedById] ON [Boxes] ([CreatedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_Boxes_FilledById] ON [Boxes] ([FilledById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_Boxes_Group_Status_CombinationId] ON [Boxes] ([Group], [Status], [CombinationId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_BoxItems_BagId_BoxId] ON [BoxItems] ([BagId], [BoxId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_BoxItems_BoxId] ON [BoxItems] ([BoxId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_BoxItems_CreatedById] ON [BoxItems] ([CreatedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Combinations_Code] ON [Combinations] ([Code]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_VerificationRejections_BagId_RejectionReasonId] ON [VerificationRejections] ([BagId], [RejectionReasonId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_VerificationRejections_RejectionReasonId] ON [VerificationRejections] ([RejectionReasonId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    CREATE INDEX [IX_VerificationResults_CreatedById] ON [VerificationResults] ([CreatedById]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924234006_PackagingSqlServer'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260924234006_PackagingSqlServer', N'10.0.5');
END;

COMMIT;
GO


