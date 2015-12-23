CREATE TABLE [dbo].[CFG_AddressType]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_AddressType_Name] UNIQUE ([Name])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds possible address types, such as home, office etc.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_AddressType',
    @level2type = NULL,
    @level2name = NULL