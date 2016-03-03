CREATE TABLE [dbo].[Task]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [DueDateTime] DATETIME NULL, 
    [Budget] DECIMAL(18, 2) NULL, 
    [Duration] INT NULL, 
    [Priority] INT NULL DEFAULT 1, 
    [Progress] INT NULL, 
    [DurationUsed] INT NULL, 
    [BudgetUsed] DECIMAL(18, 2) NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Task_Interaction] FOREIGN KEY ([Id]) REFERENCES [Interaction]([Id]), 
)

GO

CREATE INDEX [IX_Task_ModifiedDateTime] ON [dbo].[Task] ([ModifiedDateTime])
GO

CREATE INDEX [IX_Task_StartDateTime] ON [dbo].[Task] ([DueDateTime])
GO

CREATE INDEX [IX_Task_Priority] ON [dbo].[Task] ([Priority])