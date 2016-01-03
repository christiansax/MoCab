CREATE TABLE [sec].[_User_Chat]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [ChatId] BIGINT NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(),
	[ModifedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__User_Chat_UserChat] UNIQUE ([UserId], [ChatId]), 
    CONSTRAINT [FK__User_Chat_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]), 
    CONSTRAINT [FK__User_Chat_Chat] FOREIGN KEY ([ChatId]) REFERENCES [ira].[Chat]([Id])
)

GO

CREATE INDEX [IX__User_Chat_UserId] ON [sec].[_User_Chat] ([UserId])

GO

CREATE INDEX [IX__User_Chat_ChatId] ON [sec].[_User_Chat] ([ChatId])

GO

CREATE INDEX [IX__User_Chat_IsActive] ON [sec].[_User_Chat] ([IsActive])
