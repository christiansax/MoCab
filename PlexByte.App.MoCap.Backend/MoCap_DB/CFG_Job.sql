CREATE TABLE [dbo].[CFG_Job]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(250) NOT NULL, 
    [Department] NVARCHAR(250) NULL, 
    [Description] TEXT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_Job_TitleDepartment] UNIQUE ([Title], [Department])
)

GO

CREATE INDEX [IX_CFG_Job_Title] ON [dbo].[CFG_Job] ([Title])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds job-related data and is referenced by the user table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_Job',
    @level2type = NULL,
    @level2name = NULL