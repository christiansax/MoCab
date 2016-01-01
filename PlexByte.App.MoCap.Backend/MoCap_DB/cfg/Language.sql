CREATE TABLE [cfg].[Language]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [LocalizedName] NVARCHAR(250) NULL, 
    [ISO639-1] NVARCHAR(2) NOT NULL, 
    [ISO639-2] NVARCHAR(3) NULL,
	[CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL, 
    CONSTRAINT [AK_Language_Name] UNIQUE ([Name]), 
    CONSTRAINT [AK_Language_ISO639-1] UNIQUE ([ISO639-1]),
)

GO

CREATE INDEX [IX_Language_Name] ON [cfg].[Language] ([Name])

GO

CREATE INDEX [IX_Language_ISO639-1] ON [cfg].[Language] ([ISO639-1])
