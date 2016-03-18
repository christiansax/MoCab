--	Sproc_SurveyAddUpdate adds or updated the survey
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE PROCEDURE [dbo].[Sproc_SurveyAddUpdate]
	@SurveyId AS BIGINT,
	@InteractionId BIGINT,
    @MaxVotePerUser AS INT,
    @DueDateTime AS DATETIME,
    @TaskId AS BIGINT,
	@StartDateTime AS DATETIME,
	@EndDateTime AS DATETIME,
    @IsActive AS BIT,
    @Text AS NVARCHAR(MAX),
    @CreatorId AS BIGINT,
    @OwnerId AS BIGINT,
    @StateId AS BIGINT,
	@ProjectId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	IF (EXISTS (
			SELECT	[Id]
			FROM	[View_Survey]
			WHERE	[Id] = @SurveyId))
	BEGIN
		IF (NOT EXISTS (
		SELECT	*
		FROM	View_Survey
		WHERE	[Id] = @SurveyId AND [InteractionId] = @InteractionId AND [StartDateTime] = @StartDateTime AND [EndDateTime] = @EndDateTime))
		BEGIN TRY
			-- This is a new user, insert...
			BEGIN TRANSACTION
				select	@Id	=	format(getdate(), 'yyyyMMddHHmmssfff')
				INSERT INTO [dbo].[Interaction] ([Id], [StartDateTime], [EndDateTime], [IsActive], [Text], [Type], [CreatorId],
												[OwnerId], [StateId], [CreatedDateTime], [ModifiedDateTime])
						VALUES					(@Id, @StartDateTime, @EndDateTime, @IsActive, @Text, 3, @CreatorId, 
												@OwnerId, @StateId, GETDATE(), GETDATE())
				
				INSERT INTO [ProjectSurveyMapping]([ProjectId], [SurveyId], [CreatedDateTime], [ModifiedDateTime])
						VALUES					(@ProjectId, @SurveyId, GETDATE(), GETDATE())

				INSERT INTO [dbo].[Survey]		([Id], [DueDateTime], [TaskId], [CreatedDateTime], [ModifiedDateTime])
						VALUES					(@TaskId, @DueDateTime, @TaskId, GETDATE(), GETDATE())
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
				   SET [StartDateTime] = @StartDateTime,
					   [EndDateTime] = @EndDateTime,
					   [IsActive] = @IsActive,
					   [Text] = @Text,
					   [CreatorId] = @CreatorId,
					   [OwnerId] = @OwnerId,
					   [StateId] = @StateId,
					   [ModifiedDateTime] = GETDATE()
				 WHERE [Id] = @InteractionId
				
				SELECT @Id = [ProjectId] FROM [ProjectSurveyMapping] WHERE [SurveyId] = @SurveyId;
				IF(@Id <> @ProjectId)
				BEGIN
					-- Survey has changed project
					UPDATE	[dbo].[ProjectTaskMapping]
					SET		[ProjectId] = @ProjectId
					WHERE	[Id] = @SurveyId
				END

				UPDATE [dbo].[Survey]
				   SET [DueDateTime] = @DueDateTime,
					   [TaskId] = @TaskId,
					   [ModifiedDateTime] = GETDATE()
				 WHERE [Id] = @SurveyId
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
	ELSE
	BEGIN
		RAISERROR ('Error: Project with Id: %d does not exist', 16, 11, @ProjectId);
	END
RETURN 0