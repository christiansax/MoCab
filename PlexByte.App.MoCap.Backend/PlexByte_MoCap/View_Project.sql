CREATE VIEW [dbo].[View_Project]
	AS 
	SELECT	[p].[Id], [i].[Text], [i].[StartDateTime], [i].[EndDateTime], [p].[EnableBalance], [i].[StateId], [i].[IsActive], [p].[EnableSurvey], 
			[i].[CreatorId], [c].[Username] AS Creator, [i].[OwnerId], [u].[Username] AS [Owner], [p].[ModifiedDateTime], [p].[CreatedDateTime], [i].[Type],
			[a].[Id] AS AccountId, [t].[Id] AS TaskId, [su].[Id] AS SurveyId
	FROM	[Project] p INNER JOIN [Interaction] i
	ON		[p].[Id]=[i].[Id]
			INNER JOIN [View_User] u
	ON		[u].Id=[i].[OwnerId]
			INNER JOIN [View_User] c
	ON		[c].Id=[i].[CreatorId]
			INNER JOIN [InteractionState] s
	ON		[s].[Id]=[i].[StateId]
			INNER JOIN [Account] a
	ON		[p].[Id]=[a].[ProjectId]
			INNER JOIN [ProjectTaskMapping] ptm
	ON		[p].[Id]=[ptm].[ProjectId]
			INNER JOIN [Task] t
	ON		[ptm].[TaskId]=[t].[Id]
			INNER JOIN [ProjectSurveyMapping] psm
	ON		[p].[Id]=[psm].[ProjectId]
			INNER JOIN [Survey] su
	ON		[psm].[SurveyId]=[su].[Id]