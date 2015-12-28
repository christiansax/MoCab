CREATE TABLE [ira].[Message]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Label] NVARCHAR(250) NOT NULL, 
    [Text] NVARCHAR(MAX) NULL, 
    [Picture] VARBINARY(MAX) NULL, 
    [Audio] VARBINARY(MAX) NULL, 
    [Object] VARBINARY(MAX) NULL, 
	[SenderId] BIGINT NOT NULL, 
	[ReadReceipt] BIT NOT NULL DEFAULT 0, 
    [TimeToLive] INT NOT NULL DEFAULT 0, 
	[DateTimeOfDeath] DATETIME2(3) NULL,
    [SentDateTime] DATETIME2(3) NULL, 
    [CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(),
	[ModifedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [CK_Message_TimeOfDeath] CHECK ([DateTimeOfDeath] = (case when ([TimeToLive] > 0) then DATEADD(ss,[TimeToLive],[SentDateTime]) else DATEADD(yyyy,900,[SentDateTime]) end)), 
    CONSTRAINT [AK_Message_LabelSentDateTime] UNIQUE ([Label], [SentDateTime]), 
    CONSTRAINT [FK_User_Message] FOREIGN KEY ([SenderId]) REFERENCES [sec].[User]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The number of seconds for the message to be readable. If zero (0) is specified, the message does not destruct itself',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Message',
    @level2type = N'COLUMN',
    @level2name = N'TimeToLive'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Specifies in which date time range this message will appear',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Message',
    @level2type = N'COLUMN',
    @level2name = 'DateTimeOfDeath'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table contains the chat messages',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Message',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Message_SenderId] ON [ira].[Message] ([SenderId])

GO

CREATE INDEX [IX_Message_ReadReceipt] ON [ira].[Message] ([ReadReceipt])

GO

CREATE INDEX [IX_Message_DateTimeOfDeath] ON [ira].[Message] ([DateTimeOfDeath])

GO

CREATE INDEX [IX_Message_SentDateTime] ON [ira].[Message] ([SentDateTime])
