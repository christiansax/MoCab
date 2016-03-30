--	View_ProjectTaskMapping displays a list of tasks and the corresponding project id
--	Author:	Christian B. Sax
--	Date:	2016/03/16
CREATE VIEW [dbo].[View_ProjectTaskMapping]
	AS
	SELECT	[t].*, [ptm].[ProjectId], [s].[IsActive] AS IsActiveProject
	FROM	[View_Task] [t] inner join [ProjectTaskMapping] [ptm]
			ON [t].Id = [ptm].TaskId
			INNER JOIN [View_Project] s
			ON [ptm].[ProjectId]=[s].[Id]