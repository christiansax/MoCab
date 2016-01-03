CREATE TABLE [ira].[BinaryObject]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Object] VARBINARY(MAX) NOT NULL, 
    [TypeId] BIGINT NOT NULL,
	[Size] int NOT NULL, 
	[IsActive] BIT NOT NULL default 1,
	[CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_BinaryObject_Type] FOREIGN KEY ([TypeId]) REFERENCES [cfg].[Type]([Id])
)

GO

CREATE INDEX [IX_BinaryObject_TypeId] ON [ira].[BinaryObject] ([TypeId])

GO

CREATE INDEX [IX_BinaryObject_IsActive] ON [ira].[BinaryObject] ([IsActive])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table contains binary objects, which are stored in the database',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'BinaryObject',
    @level2type = NULL,
    @level2name = NULL