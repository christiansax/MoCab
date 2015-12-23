CREATE TABLE [dbo].[CFG_Address]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[AddressTypeId] BIGINT NOT NULL, 
    [StreetId] BIGINT NOT NULL, 
    [StreetNumberId] BIGINT NOT NULL, 
    [AddressAppendixId] BIGINT NULL, 
    [StateId] BIGINT NULL, 
    [CityId] BIGINT NOT NULL, 
    [CountryId] BIGINT NOT NULL, 
	[GeoLocationId] BIGINT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_Address_StreetNoCityCountry] UNIQUE ([CityId], [CountryId], [StreetId], [StreetNumberId]), 
    CONSTRAINT [FK_CFG_Address_AddressType_Id] FOREIGN KEY ([AddressTypeId]) REFERENCES [CFG_AddressType]([Id]),
	CONSTRAINT [FK_CFG_Address_Street_Id] FOREIGN KEY ([StreetId]) REFERENCES [CFG_Street]([Id]),
	CONSTRAINT [FK_CFG_Address_StreetNumber_Id] FOREIGN KEY ([StreetNumberId]) REFERENCES [CFG_StreetNumber]([Id]),
	CONSTRAINT [FK_CFG_Address_AddressAppendix_Id] FOREIGN KEY ([AddressAppendixId]) REFERENCES [CFG_AddressAppendix]([Id]),
	CONSTRAINT [FK_CFG_Address_State_Id] FOREIGN KEY ([StateId]) REFERENCES [CFG_State]([Id]),
	CONSTRAINT [FK_CFG_Address_City_Id] FOREIGN KEY ([CityId]) REFERENCES [CFG_City]([Id]),
	CONSTRAINT [FK_CFG_Address_Country_Id] FOREIGN KEY ([CountryId]) REFERENCES [CFG_Country]([Id]),
	CONSTRAINT [FK_CFG_Address_GeoLocation_Id] FOREIGN KEY ([GeoLocationId]) REFERENCES [CFG_GeoLocation]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table assembles an address from various other tables, which are referenced',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_Address',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_CFG_Address_StreetId] ON [dbo].[CFG_Address] ([StreetId])

GO

CREATE INDEX [IX_CFG_Address_StreetNumberId] ON [dbo].[CFG_Address] ([StreetNumberId])

GO

CREATE INDEX [IX_CFG_Address_AddressAppendixId] ON [dbo].[CFG_Address] ([AddressAppendixId])

GO

CREATE INDEX [IX_CFG_Address_StateId] ON [dbo].[CFG_Address] ([StateId])

GO

CREATE INDEX [IX_CFG_Address_CityId] ON [dbo].[CFG_Address] ([CityId])

GO

CREATE INDEX [IX_CFG_Address_CountryId] ON [dbo].[CFG_Address] ([CountryId])

GO

CREATE INDEX [IX_CFG_Address_GeoLocationId] ON [dbo].[CFG_Address] ([GeoLocationId])