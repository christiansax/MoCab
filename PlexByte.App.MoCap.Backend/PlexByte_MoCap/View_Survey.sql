CREATE VIEW [dbo].[View_Survey]
	AS 
	SELECT	[t].[Id], [i].[Text], [i].[StartDateTime], [i].[EndDateTime], [t].[DueDateTime], [i].[StateId], [s].[Text] AS StateName, 
			[i].[IsActive], [i].[CreatorId], [u].[Username] AS Creator, [i].[OwnerId], [o].[Username] AS [Owner], [t].[ModifiedDateTime], 
			[t].[CreatedDateTime], [i].[Type]
	FROM	[Survey] t INNER JOIN [Interaction] i
	ON		[t].[InteractionId]=[i].[Id]
			INNER JOIN [InteractionState] s
	ON		[i].[StateId]=[s].[Id]
			INNER JOIN [View_User] u
	ON		[i].[CreatorId]=[u].[Id]
			INNER JOIN [View_User] o
	ON		[o].[Id]=[i].[OwnerId]
			INNER JOIN [InteractionState] st
	ON		[i].[StateId]=[st].[Id]