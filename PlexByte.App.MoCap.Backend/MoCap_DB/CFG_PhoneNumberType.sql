CREATE TABLE [dbo].[CFG_PhoneNumberType]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_CFG_PhoneNumberType_Name] UNIQUE ([Name])
)

GO

CREATE INDEX [IX_CFG_PhoneNumberType_Name] ON [dbo].[CFG_PhoneNumberType] ([Name])
