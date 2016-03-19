CREATE TABLE [dbo].[UserLog]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [LogDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_UserLog_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)

GO

CREATE INDEX [IX_UserLog_UserId] ON [dbo].[UserLog] ([UserId])

GO

CREATE INDEX [IX_UserLog_LogDateTime] ON [dbo].[UserLog] ([LogDateTime])
