CREATE TABLE [dbo].[CFG_AddressAppendix]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [HouseName] NVARCHAR(250) NULL, 
    [County] NVARCHAR(250) NULL, 
    [POBox] NVARCHAR(50) NULL, 
    [CustomString1] NVARCHAR(250) NULL, 
    [CustomString2] NVARCHAR(250) NULL, 
    [CustomString3] NVARCHAR(250) NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE()
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds additional address qualifies and is referenced by the address table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_AddressAppendix',
    @level2type = NULL,
    @level2name = NULL