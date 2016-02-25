CREATE VIEW [dbo].[View_Task]
	AS 
	SELECT	[t].[Id], [i].[Text], [i].[StartDateTime], [i].[EndDateTime], [t].[DueDateTime], [i].[State], [i].[IsActive], [t].[Priority], [t].[Progress], 
			[t].[Duration], [t].[Budget], [t].[DurationUsed], [t].[BudgetUsed], [i].[CreatorId], [i].[OwnerId], [t].[ModifiedDateTime], 
			[t].[CreatedDateTime], [i].[Type]
	FROM	[Task] t INNER JOIN [Interaction] i
	ON		[t].[Id]=[i].[Id]