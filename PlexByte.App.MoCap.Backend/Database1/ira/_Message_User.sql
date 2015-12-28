CREATE TABLE [ira].[_Message_User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [MessageId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [IsReceived] BIT NOT NULL DEFAULT 0, 
    [IsRead] BIT NOT NULL DEFAULT 0, 
    [ReceivedDateTime] DATETIME2(3) NULL, 
    [ReadDateTime] DATETIME2(3) NULL, 
    [CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__Message_User_MessageUser] UNIQUE ([MessageId], [UserId]), 
    CONSTRAINT [FK__Message_User_Message] FOREIGN KEY ([MessageId]) REFERENCES [ira].[Message]([Id]), 
    CONSTRAINT [FK__Message_User_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id])
)

GO

CREATE INDEX [IX__Message_User_MessageId] ON [ira].[_Message_User] ([MessageId])

GO

CREATE INDEX [IX__Message_User_UserId] ON [ira].[_Message_User] ([UserId])

GO

CREATE INDEX [IX__Message_User_IsReceived] ON [ira].[_Message_User] ([IsReceived])

GO

CREATE INDEX [IX__Message_User_IsRead] ON [ira].[_Message_User] ([IsRead])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds each message sent to a user. Note that not all messaged may be displayed based on the message''s time to live counter',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'_Message_User',
    @level2type = NULL,
    @level2name = NULL