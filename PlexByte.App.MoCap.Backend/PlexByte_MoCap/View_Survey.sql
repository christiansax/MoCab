--	View_Survey displays an overview of surveys configured
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_Survey]
	AS 
	SELECT	[t].[Id], [i].[Text], [t].[InteractionId],  [i].[StartDateTime], [i].[EndDateTime], [t].[DueDateTime], [i].[StateId], [s].[Text] AS StateName, 
			[i].[IsActive], [i].[CreatorId], [u].[Username] AS Creator, [i].[OwnerId], [o].[Username] AS [Owner], [t].[ModifiedDateTime], 
			[t].[CreatedDateTime], [i].[Type], [t].[MaxVotePerUser], [t].[Title]
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