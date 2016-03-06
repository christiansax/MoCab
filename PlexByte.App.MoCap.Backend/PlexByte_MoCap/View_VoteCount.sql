--	View_VoteCount displays a list of votes grouped by Survey, Option and user
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_VoteCount]
	AS
	SELECT	[s].[Id] AS SurveyId, [s].[Text] as Survey, [so].[Id] AS OptionId, [so].[Text] as SurveyOption, [v].[UserId], [u].[Username], COUNT([v].[Id]) as Total
	FROM	[Vote] v INNER JOIN [SurveyOption] so
	ON		[v].[SurveyOptionId]=[so].[Id]
			INNER JOIN [View_Survey] s
	ON		[so].[SurveyId]=[s].[Id]
			INNER JOIN [User] u
	ON		[u].[Id]=[v].[UserId]
	GROUP BY ROLLUP ([s].[Id], [s].[Text], [so].[Id], [so].[Text], [v].[UserId], [u].[Username])