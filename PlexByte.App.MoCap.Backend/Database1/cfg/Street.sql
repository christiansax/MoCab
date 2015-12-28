CREATE TABLE [cfg].[Street] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Street_Name] UNIQUE ([Name])
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Street_Name] ON [cfg].[Street] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds street names and is referenced by the address table', 'SCHEMA', N'cfg', 'TABLE', N'Street', NULL, NULL