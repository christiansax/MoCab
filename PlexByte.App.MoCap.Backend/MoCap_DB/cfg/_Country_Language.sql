CREATE TABLE [cfg].[_Country_Language]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [CountryId] BIGINT NOT NULL, 
    [LanguageId] BIGINT NOT NULL,
	[CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL, 
    CONSTRAINT [AK__Country_Language_CountryLanguage] UNIQUE ([CountryId], [LanguageId]), 
    CONSTRAINT [FK__Country_Language_Country] FOREIGN KEY ([CountryId]) REFERENCES [cfg].[Country]([Id]), 
    CONSTRAINT [FK__Country_Language_Language] FOREIGN KEY ([LanguageId]) REFERENCES [cfg].[Language]([Id]),
)

GO

CREATE INDEX [IX__Country_Language_CountryId] ON [cfg].[_Country_Language] ([CountryId])

GO

CREATE INDEX [IX__Country_Language_LanguageId] ON [cfg].[_Country_Language] ([LanguageId])
