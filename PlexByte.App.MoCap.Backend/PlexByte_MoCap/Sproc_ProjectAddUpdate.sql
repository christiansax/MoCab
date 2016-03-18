--	Sproc_ProjectAddUpdate inserts or updates a project and the corresponding Interaction.
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE PROCEDURE [dbo].[Sproc_ProjectAddUpdate]
	@ProjectId AS BIGINT,
	@Name AS NVARCHAR(250),
    @Description AS NVARCHAR(MAX),
    @EnableBalance AS BIT,
    @EnableSurvey AS BIT,
	@StartDateTime AS DATETIME,
	@EndDateTime AS DATETIME,
    @IsActive AS BIT,
    @CreatorId AS BIGINT,
    @OwnerId AS BIGINT,
    @StateId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	BEGIN
		IF (NOT EXISTS (
		SELECT	*
		FROM	View_Project
		WHERE	[Id] = @ProjectId))
		BEGIN TRY
			-- This is a new project, insert...
			BEGIN TRANSACTION
				SELECT	@Id	=	FORMAT(GETDATE(), 'yyyyMMddHHmmssfff')
				INSERT INTO [dbo].[Interaction] ([Id], [StartDateTime], [EndDateTime], [IsActive], [Text], [Type], [CreatorId],
												[OwnerId], [StateId], [CreatedDateTime], [ModifiedDateTime])
						VALUES					(@Id, @StartDateTime, @EndDateTime, @IsActive, @Description, 1, @CreatorId, 
												@OwnerId, @StateId, GETDATE(), GETDATE())

				INSERT INTO [dbo].[Project]		([Id], [Name], [EnableBalance], [EnableSurvey], [CreatedDateTime], [ModifiedDateTime])
						VALUES					(@ProjectId, @Name, @EnableBalance, @EnableSurvey, GETDATE(), GETDATE())
			COMMIT TRANSACTION
			SET @ResultMsg = @ResultMsg + ': Inserted';
		END TRY
		BEGIN CATCH
			SET @ResultMsg = 'Error in insert try block: ' + ERROR_MESSAGE();
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Caught exception %s', 16, -1, @ResultMsg);
		END CATCH
		ELSE
		BEGIN TRY
			-- This is an update
			BEGIN TRANSACTION
				UPDATE [dbo].[Interaction]
				   SET [StartDateTime]		=	@StartDateTime,
					   [EndDateTime]		=	@EndDateTime,
					   [IsActive]			=	@IsActive,
					   [Text]				=	@Description,
					   [CreatorId]			=	@CreatorId,
					   [OwnerId]			=	@OwnerId,
					   [StateId]			=	@StateId,
					   [ModifiedDateTime]	=	GETDATE()
				 WHERE [Id] = (SELECT [InteractionId] FROM [dbo].[Project] WHERE [Id] = @ProjectId)

				UPDATE [dbo].[Project]
				   SET [Name]				=	@Name,
					   [EnableBalance]		=	@EnableBalance,
					   [EnableSurvey]		=	@EnableSurvey,
					   [ModifiedDateTime]	=	GETDATE()
				 WHERE [Id] = @ProjectId
			COMMIT TRANSACTION
			SET @ResultMsg = @ResultMsg + ': Updated';
		END TRY
		BEGIN CATCH
			SET @ResultMsg = 'Error in update try block: ' + ERROR_MESSAGE();
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Caught exception %s', 16, -1, @ResultMsg);
		END CATCH
	END
RETURN 0