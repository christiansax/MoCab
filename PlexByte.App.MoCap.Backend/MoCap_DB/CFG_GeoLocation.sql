CREATE TABLE [dbo].[CFG_GeoLocation]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Latitude] NVARCHAR(20) NOT NULL, 
    [Longitude] NVARCHAR(20) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_GeoLocation_LongLatitude] UNIQUE ([Latitude], [Longitude])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds geo locations, which are referenced from the GeoTracker and address table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_GeoLocation',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_CFG_GeoLocation_Latitude] ON [dbo].[CFG_GeoLocation] ([Latitude])

GO

CREATE INDEX [IX_CFG_GeoLocation_Longitude] ON [dbo].[CFG_GeoLocation] ([Longitude])
