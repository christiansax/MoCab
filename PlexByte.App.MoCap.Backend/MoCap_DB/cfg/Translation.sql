CREATE TABLE [cfg].[Translation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TypeId] BIGINT NOT NULL, 
    [LanguageId] BIGINT NOT NULL, 
    [StringValue] NVARCHAR(MAX) NOT NULL, 
	[CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Translation_Type] FOREIGN KEY ([TypeId]) REFERENCES [cfg].[Type]([Id]), 
    CONSTRAINT [FK_Translation_Language] FOREIGN KEY ([LanguageId]) REFERENCES [cfg].[Language]([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds string values of any kind, which are referenced from either a type or translation',
    @level0type = N'SCHEMA',
    @level0name = N'cfg',
    @level1type = N'TABLE',
    @level1name = N'Translation',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Translation_TypeId] ON [cfg].[Translation] ([TypeId])

GO

CREATE INDEX [IX_Translation_LanguageId] ON [cfg].[Translation] ([LanguageId])
