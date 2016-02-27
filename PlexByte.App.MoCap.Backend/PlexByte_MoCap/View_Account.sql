CREATE VIEW [dbo].[View_Account]
	AS 
	SELECT	[a].[Id], [i].[Text], [i].[StartDateTime], [i].[EndDateTime], [i].[StateId], [i].[IsActive],
			[i].[CreatorId], [c].[Username] AS Creator, [i].[OwnerId], [u].[Username] AS [Owner], [a].[ModifiedDateTime], [a].[CreatedDateTime], [i].[Type]
	FROM	[Account] a INNER JOIN [Interaction] i
	ON		[a].[Id]=[i].[Id]
			INNER JOIN [Project] p
	ON		[a].[Id]=[p].[Id]
			INNER JOIN [View_User] u
	ON		[u].Id=[i].[OwnerId]
			INNER JOIN [View_User] c
	ON		[c].Id=[i].[CreatorId]
			INNER JOIN [InteractionState] s
	ON		[s].[Id]=[i].[StateId]