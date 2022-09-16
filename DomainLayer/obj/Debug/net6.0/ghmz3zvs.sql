IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Students] (
    [studentId] int NOT NULL IDENTITY,
    [firstName] nvarchar(max) NOT NULL,
    [lastName] nvarchar(max) NOT NULL,
    [emailAddress] nvarchar(max) NOT NULL,
    [Id] int NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([studentId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220911021207_InitialCreate', N'7.0.0-preview.7.22376.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Students] DROP CONSTRAINT [PK_Students];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Students] DROP COLUMN [Id];
GO

ALTER TABLE [Students] ADD [Id] int NOT NULL IDENTITY;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[students]') AND [c].[name] = N'studentId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [students] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [students] DROP COLUMN [studentId];
GO

ALTER TABLE [Students] ADD [studentId] int NOT NULL;
GO

ALTER TABLE [Students] ADD CONSTRAINT [PK_Students] PRIMARY KEY ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220911043817_FixId', N'7.0.0-preview.7.22376.2');
GO

COMMIT;
GO

