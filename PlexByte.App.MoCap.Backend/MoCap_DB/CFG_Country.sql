CREATE TABLE [dbo].[CFG_Country]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [ISOCodeA2] NVARCHAR(2) NOT NULL, 
    [ISOCodeA3] NVARCHAR(3) NULL, 
    [ISOCodeNumber] INT NULL, 
    [InternationalDialingCode] NVARCHAR(5) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_Country_NameISOCodeA2] UNIQUE ([ISOCodeA2], [Name]), 
    CONSTRAINT [CK_CFG_Country_ISOCodeA2] CHECK (LEN([ISOCodeA2]) = 2),
	CONSTRAINT [CK_CFG_Country_ISOCodeA3] CHECK (LEN([ISOCodeA3]) = 3)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds countries and their iso code',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_Country',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Country_ISOCodeA2] ON [dbo].[CFG_Country] ([ISOCodeA2])

GO

CREATE INDEX [IX_Country_InternationalDialingCode] ON [dbo].[CFG_Country] ([InternationalDialingCode])
