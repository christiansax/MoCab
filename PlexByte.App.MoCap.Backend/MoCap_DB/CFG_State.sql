CREATE TABLE [dbo].[CFG_State]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Abbreviation] NVARCHAR(10) NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_State_Name] UNIQUE ([Name])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table contains states, which may be referenced from country table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_State',
    @level2type = NULL,
    @level2name = NULL