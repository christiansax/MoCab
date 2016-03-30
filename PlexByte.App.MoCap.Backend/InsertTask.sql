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
		   (20160225224053987
		   ,'2016/02/25'
           ,'2016/02/25'
           ,1
           ,'Go Shopping'
           ,'Task'
           ,1
           ,1
           ,'1'),

		   (20160225224053988
		   ,'2016/02/25'
           ,'2016/02/25'
           ,1
           ,'Buy Milk'
           ,'Task'
           ,1
           ,1
           ,'1'),

		   (20160225224053989
		   ,'2016/02/25'
           ,'2016/02/25'
           ,1
           ,'Buy Honey'
           ,'Task'
           ,1
           ,1
           ,'1'),

		   (20160225224053990
		   ,'2016/02/25'
           ,'2016/02/25'
           ,1
           ,'Buy Turky'
           ,'Task'
           ,1
           ,1
           ,'1'),

		   (20160225224053991
		   ,'2016/03/29'
           ,'2016/04/25'
           ,1
           ,'Go to a message parlor'
           ,'Task'
           ,1
           ,1
           ,'1')
GO

INSERT INTO [dbo].[Task]
           ([Id]
		   ,[DueDateTime]
           ,[Budget]
           ,[Duration]
           ,[Priority]
           ,[Progress]
           ,[DurationUsed]
           ,[BudgetUsed])
     VALUES
           (20160225224053987
		   ,'2016/09/01'
           ,100.50
           ,3600
           ,10
           ,0
           ,0
           ,0.00),

		   (20160225224053988
		   ,'2016/09/01'
           ,60.50
           ,3600
           ,10
           ,0
           ,0
           ,0.00),

		   (20160225224053989
		   ,'2016/09/01'
           ,15.00
           ,3600
           ,10
           ,0
           ,0
           ,0.00),

		   (20160225224053990
		   ,'2016/09/01'
           ,25.50
           ,3600
           ,10
           ,0
           ,0
           ,0.00),

		   (20160225224053991
		   ,'2016/09/01'
           ,550.50
           ,3600
           ,10
           ,0
           ,0
           ,0.00)
GO

INSERT INTO [dbo].[TaskMapping]
           ([Id]
           ,[TaskId]
           ,[MainTaskId])
     VALUES
           (20160225224063987
           ,20160225224053987
           ,20160225224053987),

		   (20160225224063988
           ,20160225224053988
           ,20160225224053987),

		   (20160225224063989
           ,20160225224053989
           ,20160225224053987),

		   (20160225224063930
           ,20160225224053990
           ,20160225224053987),

		   (20160225224063991
           ,20160225224053991
           ,20160225224053991)
GO

--delete all tables
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
GO
alter table [Interaction] NOCHECK CONSTRAINT ALL
drop table [dbo].[Interaction]
alter table [Survey] NOCHECK CONSTRAINT ALL
drop table [dbo].[Survey]
alter table [SurveyOption] NOCHECK CONSTRAINT ALL
drop table [dbo].[SurveyOption]
alter table [Task] NOCHECK CONSTRAINT ALL
drop table [dbo].[Task]
alter table [TaskMapping] NOCHECK CONSTRAINT ALL
drop table [dbo].[TaskMapping]
alter table [User] NOCHECK CONSTRAINT ALL
drop table [dbo].[User]
alter table [Person] NOCHECK CONSTRAINT ALL
drop table [dbo].[Person]
alter table [Vote] NOCHECK CONSTRAINT ALL
drop table [dbo].[Vote]
go

INSERT INTO [dbo].[InteractionState]([Id], [Text], [Description])
	values	(1, 'Active', 'This state indicates that the object is ready to be processed'),
			(0, 'Queued', 'This state indicates that the object is available but due to its start date not ready yet'),
			(2, 'Finished', 'This state indicates that the object is finished and cannot be processed any further'),
			(3, 'Expired', 'This state indicates that the object has expired due to its due date but is not completed yet'),
			(4, 'Cancelled', 'This state indicates that the object was cancelled and therefore cannot be processed any further')

select *
from [dbo].[InteractionState]

select * from View_Task where CreatorId = 1 OR OwnerId = 1

select * from View_Project

select * from [dbo].[View_SubTasks]--[dbo].[View_MainTasks]--View_VoteCount

select * from View_Survey

select * from View_SurveyOptions