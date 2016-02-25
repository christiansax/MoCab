CREATE VIEW [dbo].[View_MainTasks]
	AS
	SELECT	*
	FROM	[View_Task]
	WHERE	[Id] IN (SELECT DISTINCT [MainTaskId] FROM [TaskMapping])