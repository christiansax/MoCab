CREATE PROCEDURE [dbo].[Sproc_TaskAddUpdate]
	@TaskId AS BIGINT,
	@InteractionId BIGINT,
    @DueDateTime AS DATETIME,
    @Budget AS DECIMAL,
    @Duration AS INT,
    @Priority AS INT,
    @Progress AS INT,
    @DurationUsed AS INT,
    @BudgetUsed AS DECIMAL,
	@StartDateTime AS DATETIME,
	@EndDateTime AS DATETIME,
    @IsActive AS BIT,
    @Text AS NVARCHAR(MAX),
    @Type AS BIGINT,
    @CreatorId AS BIGINT,
    @OwnerId AS BIGINT,
    @StateId AS BIGINT,
	@ProjectId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	DECLARE @ReturnCode INT = 0;
	SET @ResultMsg = 'OK';

	IF (NOT EXISTS (
		SELECT	*
		FROM	View_Task
		WHERE	[Id] = @TaskId AND [InteractionId]	= @InteractionId AND [StartDateTime] = @StartDateTime AND [EndDateTime] = @EndDateTime))
	BEGIN TRY
		-- This is a new user, insert...
		BEGIN TRANSACTION
			select	@Id	=	format(getdate(), 'yyyyMMddHHmmssfff')
			INSERT INTO [dbo].[Interaction] ([Id], [StartDateTime], [EndDateTime], [IsActive], [Text], [Type], [CreatorId],
											[OwnerId], [StateId], [CreatedDateTime], [ModifiedDateTime])
					VALUES					(@Id, @StartDateTime, @EndDateTime, @IsActive, @Text, @Type, @CreatorId, 
											@OwnerId, @StateId, GETDATE(), GETDATE())

			INSERT INTO [dbo].[Task]		([Id], [DueDateTime], [Budget], [Duration], [Priority], [Progress], [DurationUsed],
											[BudgetUsed], [CreatedDateTime], [ModifiedDateTime])
					VALUES					(@TaskId, @DueDateTime, @Budget, @Duration, @Priority, @Progress, @DurationUsed,
											@BudgetUsed, GETDATE(), GETDATE())
		COMMIT TRANSACTION
		SET @ResultMsg = @ResultMsg + ': Inserted';
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
        ROLLBACK
		SET @ReturnCode = 1;
		SET @ResultMsg = 'Error while processing insert. Rolled back transaction...';
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
				   [Type] = @Type,
				   [CreatorId] = @CreatorId,
				   [OwnerId] = @OwnerId,
				   [StateId] = @StateId,
				   [ModifiedDateTime] = GETDATE()
			 WHERE [Id] = @InteractionId
			
			UPDATE [dbo].[Task]
			   SET [DueDateTime] = @DueDateTime,
				   [Budget] = @Budget,
				   [Duration] = @Duration,
				   [Priority] = @Priority,
				   [Progress] = @Progress,
				   [DurationUsed] = @Duration,
				   [BudgetUsed] = @BudgetUsed,
				   [ModifiedDateTime] = GETDATE()
			 WHERE [Id] = @TaskId
		COMMIT TRANSACTION
		SET @ResultMsg = @ResultMsg + ': Updated';
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
        ROLLBACK
		SET @ReturnCode = 1;
		SET @ResultMsg = 'Error while processing update. Rolled back transaction...';
	END CATCH
RETURN @ReturnCode