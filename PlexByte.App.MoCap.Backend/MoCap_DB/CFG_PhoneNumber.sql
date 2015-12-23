CREATE TABLE [dbo].[CFG_PhoneNumber]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Value] NVARCHAR(20) NOT NULL, 
    [TypeId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_PhoneNumber_Value] UNIQUE ([Value]), 
    CONSTRAINT [FK_CFG_PhoneNumber_CFG_PhoneNumberType] FOREIGN KEY ([TypeId]) REFERENCES [CFG_PhoneNumberType]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The phone number in E.164 format',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CFG_PhoneNumber',
    @level2type = N'COLUMN',
    @level2name = N'Value'
GO

CREATE INDEX [IX_CFG_PhoneNumber_Value] ON [dbo].[CFG_PhoneNumber] ([Value])

GO

CREATE INDEX [IX_CFG_PhoneNumber_TypeId] ON [dbo].[CFG_PhoneNumber] ([TypeId])
