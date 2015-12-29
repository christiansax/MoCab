CREATE TABLE [cfg].[PhoneNumber] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Value] NVARCHAR(20) NOT NULL,
    [PhoneTypeId] BIGINT NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_PhoneNumber_Value] UNIQUE ([Value])
)
 ON [PRIMARY]
GO
ALTER TABLE [cfg].[PhoneNumber] ADD CONSTRAINT [FK_PhoneNumber_Property_Id] 
    FOREIGN KEY ([PhoneTypeId]) REFERENCES [cfg].[Property] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_PhoneNumber_TypeId] ON [cfg].[PhoneNumber] ([PhoneTypeId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PhoneNumber_Value] ON [cfg].[PhoneNumber] ([Value] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'The phone number in E.164 format', 'SCHEMA', N'cfg', 'TABLE', N'PhoneNumber', 'COLUMN', N'Value'