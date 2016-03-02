CREATE TABLE [dbo].[Expense]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Receipt] Image NULL, 
    [Value] DECIMAL NULL, 
	[Target] BIGINT NOT NULL,
	[Creator] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [AccountId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Expense_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Expense_User] FOREIGN KEY ([Creator]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Expense_Task] FOREIGN KEY ([Target]) REFERENCES [Task]([Id]), 
)
GO

CREATE INDEX [IX_Expense_TaskId] ON [dbo].[Expense] ([Target])

GO

CREATE INDEX [IX_Expense_User] ON [dbo].[Expense] ([Creator])

GO