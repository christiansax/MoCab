CREATE TABLE [dbo].[Survey]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [MaxVotePerUser] INT NOT NULL DEFAULT 1, 
	[DueDateTime] DATETIME NULL,
    [TaskId] BIGINT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Survey_Task] FOREIGN KEY ([TaskId]) REFERENCES [Task]([Id]), 
    CONSTRAINT [FK_Survey_Interaction] FOREIGN KEY ([Id]) REFERENCES [Interaction]([Id]) 
)

GO

CREATE INDEX [IX_Survey_TaskId] ON [dbo].[Survey] ([TaskId])

GO

CREATE INDEX [IX_Survey_CreatedDateTime] ON [dbo].[Survey] ([CreatedDateTime])

GO

CREATE INDEX [IX_Survey_ModifiedDateTime] ON [dbo].[Survey] ([ModifiedDateTime])
