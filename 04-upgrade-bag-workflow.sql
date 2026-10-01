-- Tracking: prijem, kontrolno brojanje, priprema i prijem za verifikaciju.
-- Backup postojece baze, zaustavljena aplikacija. Prethodno izvrsiti skriptu 02.
USE [Tracking];
GO
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
    THROW 51000, 'Prvo primijenite skripte 01 i 02 na ovu bazu.', 1;
IF NOT EXISTS (SELECT 1 FROM [__EFMigrationsHistory] WHERE MigrationId = N'20260923234628_BagRegistrySqlServer')
    THROW 51000, 'Prvo primijenite 02-upgrade-bag-registry.sql.', 1;
BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [ApprovedEnvelopes] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [CountedAtUtc] datetime2 NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [CountedEnvelopes] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [DifferenceReason] nvarchar(1000) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [PreparationComment] nvarchar(1000) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [PreparedAtUtc] datetime2 NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [RejectedEnvelopes] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [RunId] uniqueidentifier NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [Stage] int NOT NULL DEFAULT 1;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [VerificationAtUtc] datetime2 NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [VerificationComment] nvarchar(1000) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [VerificationReceived] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [Bags] ADD [Version] uniqueidentifier NOT NULL DEFAULT '1badf100-2026-4024-8024-000000000001';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    ALTER TABLE [AuditEntries] ADD [BagId] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE TABLE [BagReceiptEntries] (
        [Id] int NOT NULL IDENTITY,
        [BagId] int NOT NULL,
        [RegularEnvelopes] int NOT NULL,
        [ExpressEnvelopes] int NOT NULL,
        [TotalEnvelopes] int NOT NULL,
        [PoBox] nvarchar(20) NULL,
        [Comment] nvarchar(1000) NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_BagReceiptEntries] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Receipt_Counts] CHECK (TotalEnvelopes > 0 AND TotalEnvelopes <= 1000000 AND RegularEnvelopes >= 0 AND ExpressEnvelopes >= 0),
        CONSTRAINT [FK_BagReceiptEntries_Bags_BagId] FOREIGN KEY ([BagId]) REFERENCES [Bags] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE TABLE [MaterialReceipts] (
        [Id] int NOT NULL IDENTITY,
        [ShipmentId] int NOT NULL,
        [IsUndelivered] bit NOT NULL,
        [Quantity] int NOT NULL,
        [Comment] nvarchar(1000) NULL,
        [CreatedById] nvarchar(450) NOT NULL,
        [CreatedAtUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_MaterialReceipts] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Material_Quantity] CHECK (Quantity > 0 AND Quantity <= 1000000),
        CONSTRAINT [FK_MaterialReceipts_Shipments_ShipmentId] FOREIGN KEY ([ShipmentId]) REFERENCES [Shipments] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE TABLE [RejectionReasons] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(200) NOT NULL,
        [NormalizedName] nvarchar(200) NOT NULL,
        [Group] int NOT NULL,
        [IsActive] bit NOT NULL,
        [Version] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_RejectionReasons] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Reason_Group] CHECK ("Group" IN (1,2,3,4,5))
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE TABLE [BagRejections] (
        [Id] int NOT NULL IDENTITY,
        [BagId] int NOT NULL,
        [RunId] uniqueidentifier NOT NULL,
        [RejectionReasonId] int NOT NULL,
        [ReasonName] nvarchar(200) NOT NULL,
        [Quantity] int NOT NULL,
        [Comment] nvarchar(1000) NULL,
        CONSTRAINT [PK_BagRejections] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Rejection_Quantity] CHECK (Quantity > 0 AND Quantity <= 1000000),
        CONSTRAINT [FK_BagRejections_Bags_BagId] FOREIGN KEY ([BagId]) REFERENCES [Bags] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BagRejections_RejectionReasons_RejectionReasonId] FOREIGN KEY ([RejectionReasonId]) REFERENCES [RejectionReasons] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    EXEC(N'ALTER TABLE [Bags] ADD CONSTRAINT [CK_Bag_Stage] CHECK (Stage IN (1,2,3,4))');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    EXEC(N'ALTER TABLE [Bags] ADD CONSTRAINT [CK_Bag_Workflow] CHECK ((Stage = 1) OR (CountedEnvelopes IS NOT NULL AND CountedEnvelopes BETWEEN 0 AND 1000000 AND RunId IS NOT NULL AND (Stage = 2 OR (ApprovedEnvelopes IS NOT NULL AND RejectedEnvelopes IS NOT NULL AND ApprovedEnvelopes >= 0 AND RejectedEnvelopes >= 0 AND ApprovedEnvelopes + RejectedEnvelopes = CountedEnvelopes AND (Stage = 3 OR (VerificationReceived IS NOT NULL AND VerificationReceived = ApprovedEnvelopes))))))');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE INDEX [IX_AuditEntries_BagId_AtUtc] ON [AuditEntries] ([BagId], [AtUtc]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE INDEX [IX_BagReceiptEntries_BagId] ON [BagReceiptEntries] ([BagId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_BagRejections_BagId_RunId_RejectionReasonId] ON [BagRejections] ([BagId], [RunId], [RejectionReasonId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE INDEX [IX_BagRejections_RejectionReasonId] ON [BagRejections] ([RejectionReasonId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE INDEX [IX_MaterialReceipts_ShipmentId] ON [MaterialReceipts] ([ShipmentId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    CREATE UNIQUE INDEX [IX_RejectionReasons_Group_NormalizedName] ON [RejectionReasons] ([Group], [NormalizedName]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    INSERT INTO BagReceiptEntries (BagId,RegularEnvelopes,ExpressEnvelopes,TotalEnvelopes,PoBox,Comment,CreatedById,CreatedAtUtc) SELECT Id,RegularEnvelopes,ExpressEnvelopes,TotalEnvelopes,PoBox,Comment,CreatedById,CreatedAtUtc FROM Bags
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    INSERT INTO MaterialReceipts (ShipmentId,IsUndelivered,Quantity,Comment,CreatedById,CreatedAtUtc) SELECT Id,1,Undelivered,'Preneseno iz prethodne verzije',CreatedById,CreatedAtUtc FROM Shipments WHERE Undelivered > 0
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    INSERT INTO MaterialReceipts (ShipmentId,IsUndelivered,Quantity,Comment,CreatedById,CreatedAtUtc) SELECT Id,0,OtherMaterials,'Preneseno iz prethodne verzije',CreatedById,CreatedAtUtc FROM Shipments WHERE OtherMaterials > 0
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260924070610_BagWorkflowSqlServer'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260924070610_BagWorkflowSqlServer', N'10.0.5');
END;

COMMIT;
GO



