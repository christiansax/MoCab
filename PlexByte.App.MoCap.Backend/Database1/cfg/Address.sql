CREATE TABLE [cfg].[Address] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [AddressTypeId] BIGINT NOT NULL,
    [StreetId] BIGINT NOT NULL,
    [StreetNumberId] BIGINT NOT NULL,
    [AddressAppendixId] BIGINT,
    [StateId] BIGINT,
    [CityId] BIGINT NOT NULL,
    [CountryId] BIGINT NOT NULL,
    [GeoLocationId] BIGINT,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Address_StreetNoCityCountry] UNIQUE ([CityId], [CountryId], [StreetId], [StreetNumberId])
)
 ON [PRIMARY]
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_AddressAppendix_Id] 
    FOREIGN KEY ([AddressAppendixId]) REFERENCES [cfg].[AddressAppendix] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_Property_Id] 
    FOREIGN KEY ([AddressTypeId]) REFERENCES [cfg].[Property] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_City_Id] 
    FOREIGN KEY ([CityId]) REFERENCES [cfg].[City] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_Country_Id] 
    FOREIGN KEY ([CountryId]) REFERENCES [cfg].[Country] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_GeoLocation_Id] 
    FOREIGN KEY ([GeoLocationId]) REFERENCES [cfg].[GeoLocation] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_State_Id] 
    FOREIGN KEY ([StateId]) REFERENCES [cfg].[State] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_Street_Id] 
    FOREIGN KEY ([StreetId]) REFERENCES [cfg].[Street] ([Id])
GO
ALTER TABLE [cfg].[Address] ADD CONSTRAINT [FK_Address_StreetNumber_Id] 
    FOREIGN KEY ([StreetNumberId]) REFERENCES [cfg].[StreetNumber] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_Address_AddressAppendixId] ON [cfg].[Address] ([AddressAppendixId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Address_CityId] ON [cfg].[Address] ([CityId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Address_CountryId] ON [cfg].[Address] ([CountryId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Address_GeoLocationId] ON [cfg].[Address] ([GeoLocationId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Address_StateId] ON [cfg].[Address] ([StateId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Address_StreetId] ON [cfg].[Address] ([StreetId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Address_StreetNumberId] ON [cfg].[Address] ([StreetNumberId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table assembles an address from various other tables, which are referenced', 'SCHEMA', N'cfg', 'TABLE', N'Address', NULL, NULL