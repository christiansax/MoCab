--	TaskMapping table referencing subtasks of a task
--	Author:	Christian B. Sax
--	Date:	2016/02/21
CREATE TABLE [dbo].[TaskMapping]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [TaskId] BIGINT NOT NULL, 
    [MainTaskId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_TaskMapping_Task] FOREIGN KEY ([MainTaskId]) REFERENCES [Task]([Id]), 
    CONSTRAINT [FK_TaskMapping_TaskId] FOREIGN KEY ([TaskId]) REFERENCES [Task]([Id])
)

GO

CREATE INDEX [IX_TaskMapping_TaskId] ON [dbo].[TaskMapping] ([TaskId])

GO

CREATE INDEX [IX_TaskMapping_MainTaskId] ON [dbo].[TaskMapping] ([MainTaskId])
GO

CREATE INDEX [IX_TaskMapping_ModifiedDateTime] ON [dbo].[TaskMapping] ([ModifiedDateTime])

GO

CREATE INDEX [IX_TaskMapping_CreatedDateTime] ON [dbo].[TaskMapping] ([CreatedDateTime])
