CREATE TABLE [sec].[_User_Contact]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [ContactId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__User_Contact_UserContact] UNIQUE ([UserId], [ContactId]), 
    CONSTRAINT [FK__User_Contact_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]), 
    CONSTRAINT [FK__User_Contact_Contact] FOREIGN KEY ([ContactId]) REFERENCES [sec].[Contact]([Id])
)

GO

CREATE INDEX [IX__User_Contact_UserId] ON [sec].[_User_Contact] ([UserId])

GO

CREATE INDEX [IX__User_Contact_ContactId] ON [sec].[_User_Contact] ([ContactId])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is a list of contacts for a user. A contact may become a user at some point. This is when the contact will disappear and the user_User table is updated',
    @level0type = N'SCHEMA',
    @level0name = N'sec',
    @level1type = N'TABLE',
    @level1name = N'_User_Contact',
    @level2type = NULL,
    @level2name = NULL