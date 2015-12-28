CREATE TABLE [sec].[_User_User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [DirectoryUserId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__User_User_UserDirUser] UNIQUE ([UserId], [DirectoryUserId]), 
    CONSTRAINT [FK__User_User_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]),
	CONSTRAINT [FK__User_User_DirUser] FOREIGN KEY ([DirectoryUserId]) REFERENCES [sec].[User]([Id]) 
)

GO

CREATE INDEX [IX__User_User_UserId] ON [sec].[_User_User] ([UserId])

GO

CREATE INDEX [IX__User_User_DirectoryUserId] ON [sec].[_User_User] ([DirectoryUserId])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table contains the users individual "Global Directory". It contains all users, the current user has added to his global directory',
    @level0type = N'SCHEMA',
    @level0name = N'sec',
    @level1type = N'TABLE',
    @level1name = N'_User_User',
    @level2type = NULL,
    @level2name = NULL