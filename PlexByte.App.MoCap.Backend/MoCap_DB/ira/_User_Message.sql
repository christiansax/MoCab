CREATE TABLE [ira].[_User_Message]
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
    CONSTRAINT [AK__User_Message_MessageUser] UNIQUE ([MessageId], [UserId]), 
    CONSTRAINT [FK__User_Message_Message] FOREIGN KEY ([MessageId]) REFERENCES [ira].[Message]([Id]), 
    CONSTRAINT [FK__User_User_Message] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id])
)

GO

CREATE INDEX [IX__User_Message_MessageId] ON [ira].[_User_Message] ([MessageId])

GO

CREATE INDEX [IX__User_User_MessageId] ON [ira].[_User_Message] ([UserId])

GO

CREATE INDEX [IX__User_Message_IsReceived] ON [ira].[_User_Message] ([IsReceived])

GO

CREATE INDEX [IX__User_Message_IsRead] ON [ira].[_User_Message] ([IsRead])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds each message sent to a user. Note that not all messaged may be displayed based on the message''s time to live counter',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'_User_Message',
    @level2type = NULL,
    @level2name = NULL