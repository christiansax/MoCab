CREATE TABLE [nfo].[Document]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeId] BIGINT NOT NULL, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL,
	[Object] VARBINARY(MAX) NULL, 
    [CreatedBy] NVARCHAR(250) NOT NULL, 
    [RevisionedBy] NVARCHAR(250) NOT NULL,
	[ActivationDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
	[CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL, 
    CONSTRAINT [AK_Document_TypeName] UNIQUE ([TypeId], [Name]), 
    CONSTRAINT [FK_Document_Type] FOREIGN KEY ([TypeId]) REFERENCES [cfg].[Type]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table hold documents, respectively their text',
    @level0type = N'SCHEMA',
    @level0name = N'nfo',
    @level1type = N'TABLE',
    @level1name = N'Document',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Document_TypeId] ON [nfo].[Document] ([TypeId])

GO

CREATE INDEX [IX_Document_Name] ON [nfo].[Document] ([Name])

GO

CREATE INDEX [IX_Document_ActivationDateTime] ON [nfo].[Document] ([ActivationDateTime])
