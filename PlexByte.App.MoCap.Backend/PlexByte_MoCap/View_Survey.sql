CREATE VIEW [dbo].[View_Survey]
	AS 
	SELECT	[t].[Id], [i].[Text], [i].[StartDateTime], [i].[EndDateTime], [t].[DueDateTime], [i].[State], [i].[IsActive],
			[i].[CreatorId], [i].[OwnerId], [t].[ModifiedDateTime], 
			[t].[CreatedDateTime], [i].[Type]
	FROM	[Survey] t INNER JOIN [Interaction] i
	ON		[t].[Id]=[i].[Id]