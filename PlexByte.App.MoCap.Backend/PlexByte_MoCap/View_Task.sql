--	View_Task displays a list of tasks
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_Task]
	AS 
	SELECT	[t].[Id], [t].[Title], [i].[Text] AS TaskDescription, [t].[InteractionId], [i].[StartDateTime], [i].[EndDateTime], 
			[t].[DueDateTime], [i].[StateId], [s].[Text] AS StateName, [i].[IsActive], [t].[Priority], 
			[t].[Progress], [t].[Duration], [t].[Budget], [t].[DurationUsed], [t].[BudgetUsed], [i].[CreatorId], [c].[Username] AS Creator,
			[i].[OwnerId], [u].[Username] AS [Owner], [t].[ModifiedDateTime], [t].[CreatedDateTime], [i].[Type]
	FROM	[Task] t INNER JOIN [Interaction] i
	ON		[t].[Id]=[i].[Id]
			INNER JOIN [View_User] u
	ON		[u].Id=[i].[OwnerId]
			INNER JOIN [View_User] c
	ON		[c].Id=[i].[CreatorId]
			INNER JOIN [InteractionState] s
	ON		[s].[Id]=[i].[StateId]