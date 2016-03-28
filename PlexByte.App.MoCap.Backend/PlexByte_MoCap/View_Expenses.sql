--	View_Expenses returns a list of expenses with their corresponding projectId
--	Author:	Christian B. Sax
--	Date:	2016/03/28
CREATE VIEW [dbo].[View_Expenses]
	AS
	SELECT	[e].*, [a].ProjectId, [a].[TaskId], [u].[Username]
	FROM	[Expense] e INNER JOIN [Accounting] a
			ON [e].[Id] = [a].[ExpenseId]
			INNER JOIN [User] u
			ON [e].[CreatorId] = [u].[Id]
	WHERE	[a].[ExpenseId] IS NOT NULL
