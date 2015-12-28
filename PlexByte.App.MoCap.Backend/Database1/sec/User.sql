CREATE TABLE [sec].[User] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [UserId] NVARCHAR(500) NOT NULL,
    [FirstName] NVARCHAR(250) NOT NULL,
    [MiddleName] NVARCHAR(250),
    [LastName] NVARCHAR(250) NOT NULL,
    [EmailWork] NVARCHAR(1000),
    [EmailPersonally] NVARCHAR(1000),
    [HomeAddressId] BIGINT NOT NULL,
    [OfficeAddressId] BIGINT,
    [Birthdate] DATETIME NOT NULL,
    [JobId] BIGINT,
    [CompanyId] BIGINT,
    [Salary] NUMERIC(18,2),
    [WorkingSchemeId] BIGINT,
    [PagerNumber] NVARCHAR(20),
    [Gender] NVARCHAR(20) DEFAULT 'male' NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_User_FirstMiddleLastNameBirthdate] UNIQUE ([FirstName], [MiddleName], [LastName], [Birthdate])
)
 ON [PRIMARY]
GO
ALTER TABLE [sec].[User] ADD CONSTRAINT [FK_User_Address] 
    FOREIGN KEY ([HomeAddressId]) REFERENCES [cfg].[Address] ([Id])
GO
ALTER TABLE [sec].[User] ADD CONSTRAINT [FK_User_AddressOffice] 
    FOREIGN KEY ([OfficeAddressId]) REFERENCES [cfg].[Address] ([Id])
GO
ALTER TABLE [sec].[User] ADD CONSTRAINT [FK_User_Company] 
    FOREIGN KEY ([CompanyId]) REFERENCES [cfg].[Company] ([Id])
GO
ALTER TABLE [sec].[User] ADD CONSTRAINT [FK_User_Job] 
    FOREIGN KEY ([JobId]) REFERENCES [cfg].[Job] ([Id])
GO
ALTER TABLE [sec].[User] ADD CONSTRAINT [FK_User_WorkingScheme] 
    FOREIGN KEY ([WorkingSchemeId]) REFERENCES [cfg].[WorkingScheme] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_User_CompanyId] ON [sec].[User] ([CompanyId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_HomeAddressId] ON [sec].[User] ([HomeAddressId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_JobId] ON [sec].[User] ([JobId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_OfficeAddressId] ON [sec].[User] ([OfficeAddressId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_WorkingSchemeId] ON [sec].[User] ([WorkingSchemeId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table hold user specific data', 'SCHEMA', N'sec', 'TABLE', N'User', NULL, NULL