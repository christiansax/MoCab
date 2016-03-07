--	Sproc_AccountAddMapping adds either an expense or timeslice to a project, based on the ObjectType
-- 1 = Expense 2 = Timeslice
--	Author:	Christian B. Sax
--	Date:	2016/03/07
CREATE PROCEDURE [dbo].[Sproc_AccountAddMapping]
	@ProjectId AS BIGINT,
	@ObjectId AS BIGINT,
	@ObjectType AS INT,
	@TaskId AS BIGINT = NULL,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	-- Check if project exists
	IF (EXISTS (SELECT * FROM [View_Project] WHERE [Id] = @ProjectId))
	BEGIN
		SELECT	@Id	= FORMAT(GETDATE(), 'yyyyMMddHHmmssfff')
		IF(@ObjectType = 1)
		BEGIN
			-- Check if expense exists
			IF (EXISTS (SELECT * FROM [View_Expense] WHERE [Id] = @ObjectId))
			BEGIN
				-- Check if taskId was specified and it exists
				IF (@TaskId <> NULL AND @TaskId > 0)
				BEGIN
					IF (EXISTS (SELECT * FROM [View_Task] WHERE [Id] = @TaskId))
					BEGIN
						INSERT INTO [Accounting]	([Id], [ProjectId], [ExpenseId], [TimesliceId], [TaskId], [CreatedDateTime], [ModifiedDateTime])
						VALUES						(@Id, @ProjectId, @ObjectId, NULL, @TaskId, GETDATE(), GETDATE());
						SET @ResultMsg = 'OK: Expense added to project and associated with task [ProjectId=' 
							+ CAST(@ProjectId AS VARCHAR) + '] [ExpenseId=' + CAST(@ObjectId AS VARCHAR) + '] [TaskId=' + CAST(@TaskId AS VARCHAR) +']';
					END
					ELSE
					BEGIN
						RAISERROR ('Error: Task to which the outlay was associated does not exist [TaskId=%d]', 12, 11, @TaskId);
					END
				END
				ELSE
				BEGIN
					INSERT INTO [Accounting]	([Id], [ProjectId], [ExpenseId], [TimesliceId], [TaskId], [CreatedDateTime], [ModifiedDateTime])
					VALUES						(@Id, @ProjectId, @ObjectId, NULL, NULL, GETDATE(), GETDATE());
					SET @ResultMsg = 'OK: Expense added to project accout [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [ExpenseId=' + CAST(@ObjectId AS VARCHAR) + ']';
				END
			END
			ELSE
			BEGIN
				RAISERROR ('Error: Expense specified does not exists [ExpenseId=%d]', 12, 11, @ObjectId);
			END
		END
		ELSE IF(@ObjectType = 2)
		BEGIN
			-- Check if timeslice exists
			IF (EXISTS (SELECT * FROM [View_Timeslice] WHERE [Id] = @ObjectId))
			BEGIN
				-- Check if timesliceId was specified and it exists
				IF (@TaskId <> NULL AND @TaskId > 0)
				BEGIN
					IF (EXISTS (SELECT * FROM [View_Task] WHERE [Id] = @TaskId))
					BEGIN
						INSERT INTO [Accounting]	([Id], [ProjectId], [ExpenseId], [TimesliceId], [TaskId], [CreatedDateTime], [ModifiedDateTime])
						VALUES						(@Id, @ProjectId, NULL, @ObjectId, @TaskId, GETDATE(), GETDATE());
						SET @ResultMsg = 'OK: Timeslice added to project and associated with task [ProjectId=' 
							+ CAST(@ProjectId AS VARCHAR) + '] [TimesliceId=' + CAST(@ObjectId AS VARCHAR) + '] [TaskId=' 
							+ CAST(@TaskId AS VARCHAR) +']';
					END
					ELSE
					BEGIN
						RAISERROR ('Error: Task to which the outlay was associated does not exist [TaskId=%d]', 12, 11, @TaskId);
					END
				END
				ELSE
				BEGIN
					INSERT INTO [Accounting]	([Id], [ProjectId], [ExpenseId], [TimesliceId], [TaskId], [CreatedDateTime], [ModifiedDateTime])
					VALUES						(@Id, @ProjectId, NULL, @ObjectId, NULL, GETDATE(), GETDATE());
					SET @ResultMsg = 'OK: Timeslice added to project accout [ProjectId=' + CAST(@ProjectId AS VARCHAR) 
						+ '] [TimesliceId=' + CAST(@ObjectId AS VARCHAR) + ']';
				END
			END
			ELSE
			BEGIN
				RAISERROR ('Error: Timeslice specified does not exists [TimesliceId=%d]', 12, 11, @ObjectId);
			END
		END
		ELSE
		BEGIN
			RAISERROR ('Error: Object type specified is not valid [ObjectType=%d]', 12, 11, @ObjectType);
		END
	END
	ELSE
	BEGIN
		RAISERROR ('Error: Project does not exist [ProjectId=%d]', 12, 11, @ProjectId);
	END
RETURN 0