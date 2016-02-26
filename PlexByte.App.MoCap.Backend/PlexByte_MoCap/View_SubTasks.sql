CREATE VIEW [dbo].[View_SubTasks]
	AS
	SELECT	[t].*, [tm].[MainTaskId]
	FROM	[View_Task] t INNER JOIN [TaskMapping] tm
	ON		[t].[Id]=[tm].[TaskId]
	WHERE	[t].[Id] IN (SELECT [TaskId] FROM [TaskMapping])
			AND [t].[Id]!=[tm].[MainTaskId]