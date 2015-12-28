CREATE TABLE [nfo].[VersionInfo] (
    [Id] INTEGER IDENTITY(1,1) NOT NULL,
    [ObjectName] NVARCHAR(50) NOT NULL,
	[TypeId] BIGINT NOT NULL,
    [VersionMajor] INTEGER NOT NULL,
    [VersionMinor] INTEGER NOT NULL,
    [VersionRevision] INTEGER DEFAULT 0,
    [VersionBuild] INTEGER DEFAULT 0,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]), 
    CONSTRAINT [AK_VersionInfo_ObjTypeComponent] UNIQUE ([ObjectName], [TypeId]), 
    CONSTRAINT [FK_VersionInfo_ToTable] FOREIGN KEY ([TypeId]) REFERENCES [cfg].[Type]([Id])
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_VersionInfo_VersionMajor] ON [nfo].[VersionInfo] ([VersionMajor] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_VersionInfo_VersionMinor] ON [nfo].[VersionInfo] ([VersionMinor] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds version information for each object', 'SCHEMA', N'nfo', 'TABLE', N'VersionInfo', NULL, NULL
GO

CREATE INDEX [IX_VersionInfo_ObjectName] ON [nfo].[VersionInfo] ([ObjectName])

GO

CREATE INDEX [IX_VersionInfo_TypeId] ON [nfo].[VersionInfo] ([TypeId])

GO
