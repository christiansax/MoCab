--	View_SurveyUserMapping displays survey available for users
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_SurveyUserMapping]
	AS
	SELECT	[su].[SurveyId], [s].[Text], [su].[UserId], [u].[Username], [su].[CreatedDateTime]
	FROM	[SurveyUserMapping] su INNER JOIN [View_Survey] s
			ON [su].[SurveyId]=[s].[Id]
			INNER JOIN [View_User] u
			ON [su].[UserId] = [u].[Id]