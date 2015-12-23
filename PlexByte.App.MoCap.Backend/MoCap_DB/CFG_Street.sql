CREATE TABLE [dbo].[CFG_Street]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_Street_Name] UNIQUE ([Name])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds street names and is referenced by the address table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_Street',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_CFG_Street_Name] ON [dbo].[CFG_Street] ([Name])
