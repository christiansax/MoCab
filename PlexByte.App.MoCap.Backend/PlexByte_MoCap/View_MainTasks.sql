--	View_MainTasks] shows a list of main tasks
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_MainTasks]
	AS
	SELECT	*
	FROM	[View_Task]
	WHERE	[Id] IN (SELECT DISTINCT [MainTaskId] FROM [TaskMapping])