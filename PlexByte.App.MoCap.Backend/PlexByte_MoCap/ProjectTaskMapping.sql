CREATE TABLE [dbo].[ProjectTaskMapping]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ProjectId] BIGINT NOT NULL, 
    [TaskId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_ProjectTaskMapping_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]),  
    CONSTRAINT [FK_ProjectTaskMapping_Task] FOREIGN KEY ([TaskId]) REFERENCES [Task]([Id])
    )

GO

CREATE INDEX [IX_ProjectTaskMapping_Project] ON [dbo].[ProjectTaskMapping] ([ProjectId])

GO

CREATE INDEX [IX_ProjectTaskMapping_Task] ON [dbo].[ProjectTaskMapping] ([TaskId])
GO

CREATE INDEX [IX_ProjectTaskMapping_ModifiedDateTime] ON [dbo].[ProjectTaskMapping] ([ModifiedDateTime])

GO

CREATE INDEX [IX_ProjectTaskMapping_CreatedDateTime] ON [dbo].[ProjectTaskMapping] ([CreatedDateTime])
