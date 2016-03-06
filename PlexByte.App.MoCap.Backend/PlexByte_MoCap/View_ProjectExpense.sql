--	View_ProjectExpense displays an overview of Expenses reported against projects in a grouped view
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_ProjectExpense]
	AS
	SELECT	[a].[ProjectId], [e].[Username], [e].[CreatedDateTime], COUNT([a].[Id]) as RecordCount, SUM([e].[Value]) AS TotalValue
	FROM	[Accounting] a INNER JOIN [View_Expense] e
			ON [a].[ExpenseId] = [e].[Id]
	GROUP BY ROLLUP ([a].[ProjectId], [e].[Username])