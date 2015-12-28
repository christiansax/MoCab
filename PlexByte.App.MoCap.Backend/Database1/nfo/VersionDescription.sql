CREATE TABLE [nfo].[VersionDescription] (
    [Id] INTEGER IDENTITY(1,1) NOT NULL,
    [ObjectId] INTEGER NOT NULL,
    [Description] TEXT NOT NULL,
    [ReleaseNotes] TEXT,
    [SupervisionedBy] NVARCHAR(250) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id])
)
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [nfo].[VersionDescription] ADD CONSTRAINT [FK_VersionDescription_VersionInfo] 
    FOREIGN KEY ([ObjectId]) REFERENCES [nfo].[VersionInfo] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_VersionDescription_TableId] ON [nfo].[VersionDescription] ([ObjectId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds version info, such as release notes etc. for each release deployment', 'SCHEMA', N'nfo', 'TABLE', N'VersionDescription', NULL, NULL