CREATE TABLE [cfg].[Property]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Value] NVARCHAR(250) NOT NULL, 
    [TypeId] BIGINT NOT NULL, 
	[InfoString1] NVARCHAR(MAX) NULL, 
    [InfoString2] NVARCHAR(MAX) NULL, 
    [InfoString3] NVARCHAR(MAX) NULL, 
    [InfoNum1] NUMERIC(18, 4) NULL, 
    [InfoNum2] NUMERIC(18, 4) NULL, 
    [InfoNum3] NUMERIC(18, 4) NULL, 
    [CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Property_ValueType] UNIQUE ([Value], [TypeId]), 
    CONSTRAINT [FK_Property_Type] FOREIGN KEY ([TypeId]) REFERENCES [cfg].[Type]([Id])
)

GO

CREATE INDEX [IX_Property_Value] ON [cfg].[Property] ([Value])

GO

CREATE INDEX [IX_Property_TypeId] ON [cfg].[Property] ([TypeId])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds properties that are either mapped to types and components',
    @level0type = N'SCHEMA',
    @level0name = N'cfg',
    @level1type = N'TABLE',
    @level1name = N'Property',
    @level2type = NULL,
    @level2name = NULL