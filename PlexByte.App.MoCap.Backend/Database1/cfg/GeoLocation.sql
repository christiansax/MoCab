CREATE TABLE [cfg].[GeoLocation] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Latitude] NVARCHAR(20) NOT NULL,
    [Longitude] NVARCHAR(20) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_GeoLocation_LongLatitude] UNIQUE ([Latitude], [Longitude])
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GeoLocation_Latitude] ON [cfg].[GeoLocation] ([Latitude] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GeoLocation_Longitude] ON [cfg].[GeoLocation] ([Longitude] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds geo locations, which are referenced from the GeoTracker and address table', 'SCHEMA', N'cfg', 'TABLE', N'GeoLocation', NULL, NULL