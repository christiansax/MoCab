--	View_ProjectAccountSummary displays financial and time related summary for each project
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE VIEW [dbo].[View_ProjectAccountSummary]
	AS 
	SELECT	[p].[Id] AS ProjectId, [p].[Name], [u].[Id] AS UserId, [u].[Username], SUM([t].[Duration]) AS TotalTime, 
			SUM([e].[Value]) AS TotalValue
	FROM	[View_Project] p INNER JOIN [Accounting] a
			ON [a].[ProjectId] = [p].[Id]
			INNER JOIN [Expense] e
			ON [a].[ExpenseId] = [e].[Id]
			INNER JOIN [Timeslice] t
			ON [a].[TimesliceId] = [t].[Id]
			INNER JOIN [View_User] u
			ON [e].[CreatorId] = [u].[Id] OR [t].[CreatorId] = [u].[Id]
	GROUP BY ROLLUP([p].[Id], [p].[Name], [u].[Id], [u].[Username])