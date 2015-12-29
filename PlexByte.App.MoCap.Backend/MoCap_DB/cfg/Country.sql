CREATE TABLE [cfg].[Country] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [ISOCodeA2] NVARCHAR(2) NOT NULL,
    [ISOCodeA3] NVARCHAR(3),
    [ISOCodeNumber] INTEGER,
    [InternationalDialingCode] NVARCHAR(5) NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Country_NameISOCodeA2] UNIQUE ([ISOCodeA2], [Name])
)
 ON [PRIMARY]
GO
ALTER TABLE [cfg].[Country] ADD CONSTRAINT [CK_Country_ISOCodeA2] 
    CHECK (len([ISOCodeA2])=(2))
GO
ALTER TABLE [cfg].[Country] ADD CONSTRAINT [CK_Country_ISOCodeA3] 
    CHECK (len([ISOCodeA3])=(3))
GO
CREATE NONCLUSTERED INDEX [IX_Country_InternationalDialingCode] ON [cfg].[Country] ([InternationalDialingCode] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Country_ISOCodeA2] ON [cfg].[Country] ([ISOCodeA2] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds countries and their iso code', 'SCHEMA', N'cfg', 'TABLE', N'Country', NULL, NULL