--	This view shows all expenses or timeslices reported on this project or one of its tasks
--	Author:	Christian B. Sax
--	Date:	2016/03/08
CREATE VIEW [dbo].[View_Accounting]
	AS
	SELECT	[a].[ExpenseId], [e].[Value], [e].[Username] AS ExpUserName, [e].[Description] AS ExpDescription, [a].[TimesliceId], 
			[ts].[Duration], [ts].[Username] AS TsUserName, [ts].[Description] AS TsDescription, [a].[ProjectId], [p].[Name],
			[p].[Owner] AS ProjectOwner, [a].[TaskId], [t].[Title], [t].[Owner], [a].[CreatedDateTime]
	FROM	[Accounting] a INNER JOIN [View_Expense] e
			ON [a].[ExpenseId] = [e].[Id]
			INNER JOIN [View_Timeslice] ts
			ON [a].[TimesliceId] = [ts].[Id]
			INNER JOIN [View_Task] t
			ON [a].[TaskId] = [t].[Id]
			INNER JOIN [View_Project] p
			ON [a].[ProjectId] = [p].[Id]