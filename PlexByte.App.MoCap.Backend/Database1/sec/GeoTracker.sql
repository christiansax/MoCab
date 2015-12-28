CREATE TABLE [sec].[GeoTracker] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [GeoLocationId] BIGINT NOT NULL,
    [UserId] BIGINT NOT NULL,
    [TrackingDate] DATE DEFAULT 'CONVERT([date],getdate())' NOT NULL,
    [TrackingTime] TIME DEFAULT 'CONVERT([time],getdate())' NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_GeoTracker_UserIdTrackingDateTime] UNIQUE ([UserId], [TrackingDate], [TrackingTime])
)
 ON [PRIMARY]
GO
ALTER TABLE [sec].[GeoTracker] ADD CONSTRAINT [FK_GeoTracker_GoeLocation] 
    FOREIGN KEY ([GeoLocationId]) REFERENCES [cfg].[GeoLocation] ([Id])
GO
ALTER TABLE [sec].[GeoTracker] ADD CONSTRAINT [FK_GeoTracker_User] 
    FOREIGN KEY ([UserId]) REFERENCES [sec].[User] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_GeoTracker_GeoLocationId] ON [sec].[GeoTracker] ([GeoLocationId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GeoTracker_TrackDate] ON [sec].[GeoTracker] ([TrackingDate] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GeoTracker_UserId] ON [sec].[GeoTracker] ([UserId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds location tracking data. The location is derived from either the address or IP address', 'SCHEMA', N'sec', 'TABLE', N'GeoTracker', NULL, NULL