--	View_ProjectSurveyMapping returns the surveys mapped to their corresponding projects
--	Author:	Christian B. Sax
--	Date:	2016/03/28
CREATE VIEW [dbo].[View_ProjectSurveyMapping]
	AS
	SELECT	[s].*, [psm].ProjectId
	FROM	[View_Survey] [s] inner join [ProjectSurveyMapping] [psm]
			ON [psm].[SurveyId] = [s].[Id]