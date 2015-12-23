CREATE TABLE [dbo].[CFG_Company]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [IndustryType] NVARCHAR(250) NULL, 
    [LegalForm] NVARCHAR(50) NULL, 
    [AddressId] BIGINT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_Company_NameAddress] UNIQUE ([Name], [AddressId]), 
    CONSTRAINT [FK_CFG_Company_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [CFG_Address]([Id])
)

GO

CREATE INDEX [IX_CFG_Company_Name] ON [dbo].[CFG_Company] ([Name])

GO

CREATE INDEX [IX_CFG_Company_IndustryType] ON [dbo].[CFG_Company] ([IndustryType])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds company data and is referenced by the user table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_Company',
    @level2type = NULL,
    @level2name = NULL