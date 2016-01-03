CREATE TABLE [cfg].[City] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
	[LocalizedName] NVARCHAR(250) NULL,
    [ZIP] NVARCHAR(10) NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_City_NameZIP] UNIQUE ([Name], [ZIP])
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_City_Name] ON [cfg].[City] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_City_ZIP] ON [cfg].[City] ([ZIP] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds cities and their corresponding ZIP''s and is referenced by the address table', 'SCHEMA', N'cfg', 'TABLE', N'City', NULL, NULL