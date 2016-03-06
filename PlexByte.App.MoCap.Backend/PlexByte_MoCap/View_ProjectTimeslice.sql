--	View_ProjectTimeslice displays an overview of timeslices reported against projects in a grouped view
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_ProjectTimeslice]
	AS
	SELECT	[a].[ProjectId], [e].[Username], [e].[CreatedDateTime], COUNT([a].[Id]) as RecordCount, SUM([e].[Duration]) AS TotalValue
	FROM	[Accounting] a INNER JOIN [View_Timeslice] e
			ON [a].[ExpenseId] = [e].[Id]
	GROUP BY ROLLUP ([a].[ProjectId], [e].[Username])