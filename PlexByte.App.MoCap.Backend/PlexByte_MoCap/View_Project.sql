--	This view shows all projects, their state and details
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE VIEW [dbo].[View_Project]
	AS 
	SELECT	[p].[Id], [p].[Name], [i].[StartDateTime], [i].[EndDateTime], [p].[EnableBalance], [i].[StateId], [i].[IsActive], 
			[p].[EnableSurvey], [i].[CreatorId], [c].[Username] AS Creator, [i].[OwnerId], [u].[Username] AS [Owner], 
			[p].[ModifiedDateTime], [p].[CreatedDateTime], [i].[Type], [su].[Id] AS SurveyId, [p].[InteractionId]
	FROM	[Project] p INNER JOIN [Interaction] i
	ON		[p].[Id]=[i].[Id]
			INNER JOIN [View_User] u
	ON		[u].Id=[i].[OwnerId]
			INNER JOIN [View_User] c
	ON		[c].Id=[i].[CreatorId]
			INNER JOIN [InteractionState] s
	ON		[s].[Id]=[i].[StateId]
			INNER JOIN [ProjectTaskMapping] ptm
	ON		[p].[Id]=[ptm].[ProjectId]
			INNER JOIN [ProjectSurveyMapping] psm
	ON		[p].[Id]=[psm].[ProjectId]
			INNER JOIN [Survey] su
	ON		[psm].[SurveyId]=[su].[Id]