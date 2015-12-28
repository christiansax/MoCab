CREATE TABLE [sec].[_GeoLocation_User] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [GeoLocationId] BIGINT NOT NULL,
    [UserId] BIGINT NOT NULL,
    [TrackingDate] DATE DEFAULT 'CONVERT([date],getdate())' NOT NULL,
    [TrackingTime] TIME DEFAULT 'CONVERT([time],getdate())' NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK__GeoLocation_User_UserIdTrackingDateTime] UNIQUE ([UserId], [TrackingDate], [TrackingTime])
)
 ON [PRIMARY]
GO
ALTER TABLE [sec].[_GeoLocation_User] ADD CONSTRAINT [FK__GeoLocation_User_GeoLocation] 
    FOREIGN KEY ([GeoLocationId]) REFERENCES [cfg].[GeoLocation] ([Id])
GO
ALTER TABLE [sec].[_GeoLocation_User] ADD CONSTRAINT [FK__GeoLocation_User_User] 
    FOREIGN KEY ([UserId]) REFERENCES [sec].[User] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX__GeoLocation_User_GeoLocationId] ON [sec].[_GeoLocation_User] ([GeoLocationId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX__GeoLocation_User_TrackDate] ON [sec].[_GeoLocation_User] ([TrackingDate] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX__GeoLocation_User_UserId] ON [sec].[_GeoLocation_User] ([UserId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds location tracking data. The location is derived from either the address or IP address', 'SCHEMA', N'sec', 'TABLE', N'_GeoLocation_User', NULL, NULL