--	Sproc_TaskDelete deletes a task including its subtasks if any
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE PROCEDURE [dbo].[Sproc_TaskDelete]
	@TaskId BIGINT = 0,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @InteractionId BIGINT;
	DECLARE @SubTaskId BIGINT;
	SET @ResultMsg='OK';

	IF(@TaskId<1)
	BEGIN
		RAISERROR ('Error: The task Id is invalid', 16, 17);
	END
	ELSE
	BEGIN
		IF(EXISTS (SELECT * FROM [Task] WHERE [Id] = @TaskId))
		BEGIN TRY
			BEGIN TRANSACTION

				DECLARE c CURSOR FOR SELECT DISTINCT Id FROM View_SubTasks
					OPEN c

					FETCH NEXT FROM c INTO @SubTaskId
						WHILE @@Fetch_Status=0
						BEGIN
						
						-- If exists delete task
						IF(EXISTS(SELECT * FROM [Task] WHERE [Id] = @SubTaskId))
						BEGIN
							DELETE	[Task]
							WHERE	[Id]		=	@SubTaskId

							SELECT	@InteractionId	= (SELECT [InteractionId] FROM [Task] WHERE [Id]= @SubTaskId)

							DELETE	[Interaction]
							WHERE	[Id]		=	@InteractionId

							UPDATE	[Accounting]
							SET		[TaskId]	=	NULL
							WHERE	[TaskId]	=	@SubTaskId
						END

						FETCH NEXT FROM c INTO @SubTaskId
						END
				
					CLOSE c
				DEALLOCATE c

				SELECT	@InteractionId	= (SELECT [InteractionId] FROM [Task] WHERE [Id]= @SubTaskId)

				DELETE	[Task]
				WHERE	[Id]		=	@TaskId
				
				DELETE	[Interaction]
				WHERE	[Id]		=	@InteractionId

				UPDATE	[Accounting]
				SET		[TaskId]	=	NULL
				WHERE	[TaskId]	=	@TaskId
			COMMIT TRANSACTION
			SET @ResultMsg = 'OK: Deleted task with Id: ' + Cast(@TaskId as VARCHAR) + ' and subtasks deleted';
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Error in try block', 16, -1);
		END CATCH
		ELSE
		BEGIN
			SET @ResultMsg = 'OK: Task could not be found';
		END
	END
RETURN 0