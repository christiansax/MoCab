CREATE TABLE [dbo].[CFG_City]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [ZIP] NVARCHAR(10) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_City_NameZIP] UNIQUE ([Name], [ZIP])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds cities and their corresponding ZIP''s and is referenced by the address table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_City',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_CFG_City_Name] ON [dbo].[CFG_City] ([Name])

GO

CREATE INDEX [IX_CFG_City_ZIP] ON [dbo].[CFG_City] ([ZIP])
