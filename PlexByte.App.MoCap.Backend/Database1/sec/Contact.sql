CREATE TABLE [sec].[Contact] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [FirstName] NVARCHAR(250) NOT NULL,
    [MiddleName] NVARCHAR(250),
    [LastName] NVARCHAR(250),
    [EmailAddress] NVARCHAR(750) NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Contact_EmailAddress] UNIQUE ([EmailAddress])
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Contact_EmailAddress] ON [sec].[Contact] ([EmailAddress] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table stores user contacts, which may become user at some point', 'SCHEMA', N'sec', 'TABLE', N'Contact', NULL, NULL