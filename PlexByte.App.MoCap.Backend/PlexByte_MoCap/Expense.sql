CREATE TABLE [dbo].[Expense]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Receipt] Image NOT NULL, 
    [Value] DECIMAL NOT NULL, 
	[Target] BIGINT NOT NULL,
	[Creator] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Expense_Account] FOREIGN KEY ([Id]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Expense_User] FOREIGN KEY ([Id]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Expense_Task] FOREIGN KEY ([Id]) REFERENCES [Task]([Id]), 
)