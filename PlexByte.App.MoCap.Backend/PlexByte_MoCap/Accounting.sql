--	Accounting table holds expenses and timeslices reported
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE TABLE [dbo].[Accounting]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
	[ProjectId] BIGINT NOT NULL,
	[ExpenseId] BIGINT NULL, 
	[TimesliceId] BIGINT NULL,
	[TaskId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Accounting_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
	CONSTRAINT [FK_Accounting_Expense] FOREIGN KEY ([ExpenseId]) REFERENCES [Expense]([Id]),
	CONSTRAINT [FK_Accounting_TimeSlice] FOREIGN KEY ([TimesliceId]) REFERENCES [Timeslice]([Id]),
	CONSTRAINT [FK_Accounting_Task] FOREIGN KEY ([TaskId]) REFERENCES [Task]([Id])  
)
GO


CREATE INDEX [IX_Accounting_ProjectId] ON [dbo].[Accounting] ([ProjectId])

GO

CREATE INDEX [IX_Accounting_ExpenseId] ON [dbo].[Accounting] ([ExpenseId])

GO

CREATE INDEX [IX_Accounting_TimeSliceId] ON [dbo].[Accounting] ([TimesliceId])

GO

CREATE INDEX [IX_Accounting_TaskId] ON [dbo].[Accounting] ([TaskId])

GO

CREATE INDEX [IX_Accounting_CreatedDateTime] ON [dbo].[Accounting] ([CreatedDateTime])
