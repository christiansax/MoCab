CREATE TABLE [sec].[Directory]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
	[Description] NVARCHAR(MAX) NULL, 
    [UserId] BIGINT NOT NULL,
	[CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE()
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table contains directories for each user',
    @level0type = N'SCHEMA',
    @level0name = N'sec',
    @level1type = N'TABLE',
    @level1name = N'Directory',
    @level2type = NULL,
    @level2name = NULL