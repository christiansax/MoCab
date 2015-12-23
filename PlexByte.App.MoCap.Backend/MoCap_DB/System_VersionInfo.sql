CREATE TABLE [dbo].[System_VersionInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TableName] NVARCHAR(50) NOT NULL, 
    [TableVersionMajor] INT NOT NULL, 
    [TableVersionMinor] INT NOT NULL, 
    [TableVersionRevision] INT NULL DEFAULT 0, 
    [TableVersionBuild] INT NULL DEFAULT 0, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE()
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds version information for each table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'System_VersionInfo',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_System_VersionInfo_VersionMajor] ON [dbo].[System_VersionInfo] ([TableVersionMajor])

GO

CREATE INDEX [IX_System_VersionInfo_VersionMinor] ON [dbo].[System_VersionInfo] ([TableVersionMinor])
