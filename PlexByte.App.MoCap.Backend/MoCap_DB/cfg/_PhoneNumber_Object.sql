CREATE TABLE [cfg].[_PhoneNumber_Object] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [UserId] BIGINT,
    [ContactId] BIGINT,
    [CompanyId] BIGINT,
    [PhoneNumberId] BIGINT NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_PhoneNumber_Object_UserContactPhone] UNIQUE ([ContactId], [PhoneNumberId], [UserId])
)
 ON [PRIMARY]
GO
ALTER TABLE [cfg].[_PhoneNumber_Object] ADD CONSTRAINT [FK_PhoneNumber_Object_Contact] 
    FOREIGN KEY ([ContactId]) REFERENCES [sec].[Contact] ([Id])
GO
ALTER TABLE [cfg].[_PhoneNumber_Object] ADD CONSTRAINT [FK_PhoneNumber_Object_User] 
    FOREIGN KEY ([UserId]) REFERENCES [sec].[User] ([Id])
GO
ALTER TABLE [cfg].[_PhoneNumber_Object] ADD CONSTRAINT [FK_PhoneNumber_Object_PhoneNumber] 
    FOREIGN KEY ([PhoneNumberId]) REFERENCES [cfg].[PhoneNumber] ([Id])
GO
ALTER TABLE [cfg].[_PhoneNumber_Object] ADD CONSTRAINT [FK_PhoneNumber_Object_CompanyId] 
    FOREIGN KEY ([CompanyId]) REFERENCES [cfg].[Company] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_PhoneNumber_Object_ContactId] ON [cfg].[_PhoneNumber_Object] ([ContactId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PhoneNumber_Object_PhoneNumberId] ON [cfg].[_PhoneNumber_Object] ([PhoneNumberId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PhoneNumber_Object_UserId] ON [cfg].[_PhoneNumber_Object] ([UserId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PhoneNumber_Object_CompanyId] ON [cfg].[_PhoneNumber_Object] ([CompanyId])
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table maps phonenumbers to objects such as contacts or users etc.',
    @level0type = N'SCHEMA',
    @level0name = N'cfg',
    @level1type = N'TABLE',
    @level1name = N'_PhoneNumber_Object',
    @level2type = NULL,
    @level2name = NULL