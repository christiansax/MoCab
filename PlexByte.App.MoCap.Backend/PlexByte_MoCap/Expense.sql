--	Expense table holding all expenses logged
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE TABLE [dbo].[Expense]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Receipt] Image NULL, 
    [Value] DECIMAL(18, 2) NOT NULL, 
	[Description] NVARCHAR(MAX),
	[CreatorId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Expense_User] FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]), 
)
GO

CREATE INDEX [IX_Expense_User] ON [dbo].[Expense] ([CreatorId])

GO

CREATE INDEX [IX_Expense_CreatedDateTime] ON [dbo].[Expense] ([CreatedDateTime])