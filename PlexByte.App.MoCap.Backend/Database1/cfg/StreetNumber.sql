CREATE TABLE [cfg].[StreetNumber] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Value] NVARCHAR(10) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_StreetNumber_Value] UNIQUE ([Value])
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StreetNumber_Value] ON [cfg].[StreetNumber] ([Value] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds street numbers / number ranges and is referenced from the address table', 'SCHEMA', N'cfg', 'TABLE', N'StreetNumber', NULL, NULL