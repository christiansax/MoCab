CREATE TABLE [dbo].[CFG_WorkingScheme]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [WorkingHours] NUMERIC(18, 2) NOT NULL, 
    [PaidLeaveDays] NUMERIC(5, 2) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_WorkingScheme_NameWorkingHours] UNIQUE ([Name], [WorkingHours])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds data about working schemes, such as part time etc',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_WorkingScheme',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The number of working hours per day',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_WorkingScheme',
    @level2type = N'COLUMN',
    @level2name = N'WorkingHours'
GO

CREATE INDEX [IX_CFG_WorkingScheme_Name] ON [dbo].[CFG_WorkingScheme] ([Name])
