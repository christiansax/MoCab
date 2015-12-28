CREATE TABLE [cfg].[Company] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [IndustryType] NVARCHAR(250),
    [LegalForm] NVARCHAR(50),
    [AddressId] BIGINT,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Company_NameAddress] UNIQUE ([Name], [AddressId])
)
 ON [PRIMARY]
GO
ALTER TABLE [cfg].[Company] ADD CONSTRAINT [FK_Company_AddressId] 
    FOREIGN KEY ([AddressId]) REFERENCES [cfg].[Address] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_Company_IndustryType] ON [cfg].[Company] ([IndustryType] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Company_Name] ON [cfg].[Company] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds company data and is referenced by the user table', 'SCHEMA', N'cfg', 'TABLE', N'Company', NULL, NULL