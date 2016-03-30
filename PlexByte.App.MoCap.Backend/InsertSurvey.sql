USE [csax2277_MoCap_Prod]
GO

INSERT INTO [dbo].[Interaction]
           ([Id]
		   ,[StartDateTime]
           ,[EndDateTime]
           ,[IsActive]
           ,[Text]
           ,[Type]
           ,[CreatorId]
           ,[OwnerId]
           ,[StateId])
     VALUES
		   (20160225324053987
		   ,'2016/02/25'
           ,'2016/02/25'
           ,1
           ,'Which option would you go for?'
           ,'Task'
           ,1
           ,1
           ,'1'),

		   (20160225324053988
		   ,'2016/02/25'
           ,'2016/02/25'
           ,1
           ,'What animal do you like most'
           ,'Task'
           ,1
           ,1
           ,'1')
go

INSERT INTO [dbo].[Survey]
           ([Id]
		   ,[InteractionId]
           ,[MaxVotePerUser]
           ,[DueDateTime]
           ,[TaskId])
     VALUES
           (20160225225053154
		   ,20160225324053987
           ,2
           ,'2016/09/01'
           ,null),

		   (20160225225053190
		   ,20160225324053988
           ,1
           ,'2016/09/01'
           ,null)
GO

select *
from SurveyOption

INSERT INTO [dbo].[SurveyOption]
           ([Id]
           ,[SurveyId]
           ,[Text])
     VALUES
           (20160225225057154
           ,20160225225053154
           ,'Choose option one'),

		   (20160225225057155
           ,20160225225053154
           ,'Choose option two'),

		   (20160225225057156
           ,20160225225053154
           ,'Choose option three'),

		   (20160225225057159
           ,20160225225053190
           ,'Jump on option one'),

		   (20160225225057157
           ,20160225225053190
           ,'Jump on option two'),

		   (20160225225057158
           ,20160225225053190
           ,'Jump on option three')
GO

INSERT INTO [dbo].[Vote]
           ([Id]
		   ,[UserId]
		   ,[SurveyId]
           ,[SurveyOptionId])
     VALUES
           (20160225225058000
		   ,1
           ,20160225225053154
           ,20160225225057154),

		   (20160225225058001
		   ,1
           ,20160225225053154
           ,20160225225057154),

		   (20160225225058002
		   ,1
           ,20160225225053190
           ,20160225225057158)
GO

select *
from View_Survey

select *
from View_VoteCount


	SELECT	[s].[Id] AS SurveyId, [s].[Text] as Survey, [so].[Id] AS OptionId, [so].[Text] as SurveyOption, [v].[UserId], [u].[Username], COUNT([v].[Id]) as Total
	FROM	[Vote] v INNER JOIN [SurveyOption] so
	ON		[v].[SurveyOptionId]=[so].[Id]
			INNER JOIN [View_Survey] s
	ON		[so].[SurveyId]=[s].[Id]
			INNER JOIN [User] u
	ON		[u].[Id]=[v].[UserId]
	GROUP BY ROLLUP ([s].[Id], [s].[Text], [so].[Id], [so].[Text], [v].[UserId], [u].[Username])

	select * from View_Task where CreatorId = 1 OR OwnerId = 1