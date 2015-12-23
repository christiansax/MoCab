CREATE TABLE [dbo].[Map_PhoneUserContact]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NULL, 
    [ContactId] BIGINT NULL, 
    [PhoneNumberId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Map_PhoneUserContact_UserContactPhone] UNIQUE ([ContactId], [PhoneNumberId], [UserId]), 
    CONSTRAINT [FK_Map_PhoneUserContact_CFG_PhoneNumber] FOREIGN KEY ([PhoneNumberId]) REFERENCES [CFG_PhoneNumber]([Id]), 
    CONSTRAINT [FK_Map_PhoneUserContact_Adm_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Adm_Contact]([Id]), 
    CONSTRAINT [FK_Map_PhoneUserContact_Adm_User] FOREIGN KEY ([UserId]) REFERENCES [Adm_User]([Id])
)

GO

CREATE INDEX [IX_Map_PhoneUserContact_ContactId] ON [dbo].[Map_PhoneUserContact] ([ContactId])

GO

CREATE INDEX [IX_Map_PhoneUserContact_UserId] ON [dbo].[Map_PhoneUserContact] ([UserId])

GO

CREATE INDEX [IX_Map_PhoneUserContact_PhoneNumberId] ON [dbo].[Map_PhoneUserContact] ([PhoneNumberId])
