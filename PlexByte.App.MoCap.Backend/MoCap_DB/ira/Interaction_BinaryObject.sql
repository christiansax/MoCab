CREATE TABLE [ira].[Interaction_BinaryObject]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ChatId] BIGINT NULL, 
    [MessageId] BIGINT NULL, 
    [TaskId] BIGINT NULL, 
    [PollId] BIGINT NULL, 
    [VoteId] BIGINT NULL, 
    [BinaryId] BIGINT NOT NULL,
	[IsActive] BIT NOT NULL default 1,
	[CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Interaction_BinaryObject_BinaryAllObject] UNIQUE ([BinaryId], [ChatId], [PollId], [TaskId], [VoteId], [MessageId]), 
    CONSTRAINT [FK_Interaction_BinaryObject_Chat] FOREIGN KEY ([ChatId]) REFERENCES [ira].[Chat]([Id]), 
	CONSTRAINT [FK_Interaction_BinaryObject_Message] FOREIGN KEY ([MessageId]) REFERENCES [ira].[Message]([Id]), 
	CONSTRAINT [FK_Interaction_BinaryObject_Task] FOREIGN KEY ([TaskId]) REFERENCES [ira].[Task]([Id]), 
	CONSTRAINT [FK_Interaction_BinaryObject_Poll] FOREIGN KEY ([PollId]) REFERENCES [ira].[Poll]([Id]), 
	CONSTRAINT [FK_Interaction_BinaryObject_Binary] FOREIGN KEY ([BinaryId]) REFERENCES [ira].[BinaryObject]([Id]), 
	CONSTRAINT [FK_Interaction_BinaryObject_User_Poll_Option] FOREIGN KEY ([VoteId]) REFERENCES [sec].[_User_Poll_Option]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table mapps binary objects to the corresponding interaction Object',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Interaction_BinaryObject',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Interaction_BinaryObject_ChatId] ON [ira].[Interaction_BinaryObject] ([ChatId])

GO

CREATE INDEX [IX_Interaction_BinaryObject_MessageId] ON [ira].[Interaction_BinaryObject] ([MessageId])

GO

CREATE INDEX [IX_Interaction_BinaryObject_TaskId] ON [ira].[Interaction_BinaryObject] ([TaskId])

GO

CREATE INDEX [IX_Interaction_BinaryObject_PollId] ON [ira].[Interaction_BinaryObject] ([PollId])

GO

CREATE INDEX [IX_Interaction_BinaryObject_VoteId] ON [ira].[Interaction_BinaryObject] ([VoteId])

GO

CREATE INDEX [IX_Interaction_BinaryObject_BinaryId] ON [ira].[Interaction_BinaryObject] ([BinaryId])
