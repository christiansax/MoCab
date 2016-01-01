CREATE TABLE [cfg].[Settings]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
	[Category] NVARCHAR(50) NOT NULL, 
	[UserId] BIGINT NOT NULL,
    [StringValue] NVARCHAR(50) NULL, 
    [IntegerValue] INT NULL, 
    [NumericValue] NUMERIC(18, 3) NULL, 
    [DateTimeValue] DATETIME2(3) NULL, 
    [BooleanValue] BIT NULL,
	[CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Settings_NameCategoryUser] UNIQUE ([Name], [Category], [UserId]), 
    CONSTRAINT [FK_Settings_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is the mocap settings table, holding each users preferences',
    @level0type = N'SCHEMA',
    @level0name = N'cfg',
    @level1type = N'TABLE',
    @level1name = N'Settings',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Settings_Category] ON [cfg].[Settings] ([Category])

GO

CREATE INDEX [IX_Settings_Name] ON [cfg].[Settings] ([Name])

GO

CREATE INDEX [IX_Settings_UserId] ON [cfg].[Settings] ([UserId])
