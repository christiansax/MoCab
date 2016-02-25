CREATE VIEW [dbo].[View_VoteCount]
	AS
	SELECT	[s].[Text] as Survey, [so].[Text] as SurveyOption, [v].[UserId], COUNT([v].[Id]) as Total
	FROM	[Vote] v INNER JOIN [SurveyOption] so
	ON		[v].[SurveyOptionId]=[so].[Id]
			INNER JOIN [View_Survey] s
	ON		[so].[SurveyId]=[s].[Id]
	GROUP BY ROLLUP ([s].[Text], [so].[Text], [v].[UserId])