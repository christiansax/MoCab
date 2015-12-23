CREATE TABLE [dbo].[System_VersionDescription]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[TableId] INT NOT NULL, 
    [Description] TEXT NOT NULL, 
    [ReleaseNotes] TEXT NULL, 
    [SupervisionedBy] NVARCHAR(250) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_SystemVersionDescription_SystemVersionInfo] FOREIGN KEY ([TableId]) REFERENCES [System_VersionInfo]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds version info, such as release notes etc. for each release deployment',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'System_VersionDescription',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_System_VersionDescription_TableId] ON [dbo].[System_VersionDescription] ([TableId])
