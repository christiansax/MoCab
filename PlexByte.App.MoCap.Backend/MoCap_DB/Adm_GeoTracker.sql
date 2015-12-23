CREATE TABLE [dbo].[Adm_GeoTracker]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [GeoLocationId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [TrackingDate] DATE NOT NULL DEFAULT cast(getdate() as date), 
    [TrackingTime] TIME(3) NOT NULL DEFAULT cast(getdate() as time), 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Adm_GeoTracker_UserIdTrackingDateTime] UNIQUE ([UserId], [TrackingDate], [TrackingTime]), 
    CONSTRAINT [FK_Adm_GeoTracker_User] FOREIGN KEY ([UserId]) REFERENCES [Adm_User]([Id]),
	CONSTRAINT [FK_Adm_GeoTracker_GoeLocation] FOREIGN KEY ([GeoLocationId]) REFERENCES [CFG_GeoLocation]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds location tracking data. The location is derived from either the address or IP address',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Adm_GeoTracker',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Adm_GeoTracker_GeoLocationId] ON [dbo].[Adm_GeoTracker] ([GeoLocationId])

GO

CREATE INDEX [IX_Adm_GeoTracker_UserId] ON [dbo].[Adm_GeoTracker] ([UserId])

GO

CREATE INDEX [IX_Adm_GeoTracker_TrackDate] ON [dbo].[Adm_GeoTracker] ([TrackingDate])

GO
