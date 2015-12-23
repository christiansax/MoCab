CREATE TABLE [dbo].[CFG_StreetNumber]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Value] NVARCHAR(10) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_StreetNumber_Value] UNIQUE ([Value])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds street numbers / number ranges and is referenced from the address table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_StreetNumber',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_CFG_StreetNumber_Value] ON [dbo].[CFG_StreetNumber] ([Value])
