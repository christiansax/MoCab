--	This view shows all projects, their state and details
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE VIEW [dbo].[View_Project]
	AS 
	SELECT	[p].[Id], [p].[Name], [p].[EnableBalance], [p].[EnableSurvey], [p].[InteractionId], [i].[Text] AS ProjectDescription,
			[i].[StartDateTime], [i].[EndDateTime], [i].[StateId], [s].[Text] AS StateName, [i].[CreatorId], [c].[Username] 
			AS Creator, [i].[OwnerId], [u].[Username] AS [Owner], [i].[IsActive]
	FROM	[Project] p INNER JOIN [Interaction] i
			ON [p].[Id]=[i].[Id]
			INNER JOIN [View_User] u
			ON [u].Id=[i].[OwnerId]
			INNER JOIN [View_User] c
			ON [c].Id=[i].[CreatorId]
			INNER JOIN [InteractionState] s
			ON [s].[Id]=[i].[StateId]