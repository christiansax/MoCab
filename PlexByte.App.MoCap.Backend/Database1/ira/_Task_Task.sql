CREATE TABLE [ira].[_Task_Task] (
    [Id] BIGINT NOT NULL,
    [ParentTaskId] BIGINT NOT NULL,
    [SubTaskId] BIGINT NOT NULL,
    [CreatedDateTime] datetime2(3) CONSTRAINT [DEF_Task_Task_CreatedDateTime] DEFAULT GETDATE() NOT NULL,
    [ModifiedDateTime] datetime2(3) CONSTRAINT [DEF_Task_Task_ModifiedDateTime] DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Task_Task] PRIMARY KEY ([Id])
)
GO
ALTER TABLE [ira].[_Task_Task] ADD CONSTRAINT [FK_Task_Task_Parent] 
    FOREIGN KEY ([ParentTaskId]) REFERENCES [ira].[Task] ([Id])
GO
ALTER TABLE [ira].[_Task_Task] ADD CONSTRAINT [FK_Tasks_Task_Child] 
    FOREIGN KEY ([SubTaskId]) REFERENCES [ira].[Task] ([Id])
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds child tasks, which are governed by the main tasks (parent)',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'_Task_Task',
    @level2type = NULL,
    @level2name = NULL