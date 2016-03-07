--	Sproc_ProjectAddMapping adds a project mapping based on the objectType
-- 1 = UserMapping, 2 = TaskMapping, 3 = SurveyMapping
--	Author:	Christian B. Sax
--	Date:	2016/03/07
CREATE PROCEDURE [dbo].[Sproce_ProjectAddMapping]
	@ProjectId AS BIGINT,
	@ObjectId AS BIGINT,
	@ObjectType AS INT,
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
			IF (EXISTS (SELECT * FROM [View_User] WHERE [Id] = @ObjectId))
			BEGIN
				INSERT INTO [ProjectUserMapping]	([Id], [ProjectId], [UserId], [CreatedDateTime], [ModifiedDateTime])
				VALUES								(@Id, @ProjectId, @ObjectId, GETDATE(), GETDATE());
				SET @ResultMsg = 'OK: ProjectUserMapping created [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [UserId=' + CAST(@ObjectId AS VARCHAR) + ']';
			END
			ELSE
			BEGIN
				RAISERROR ('Error: User specified does not exists [UserId=%d]', 12, 11, @ObjectId);
			END
		END
		ELSE IF(@ObjectType = 2)
		BEGIN
			IF (EXISTS (SELECT * FROM [View_Task] WHERE [Id] = @ObjectId))
			BEGIN
				INSERT INTO [ProjectTaskMapping]	([Id], [ProjectId], [TaskId], [CreatedDateTime], [ModifiedDateTime])
				VALUES								(@Id, @ProjectId, @ObjectId, GETDATE(), GETDATE());
				SET @ResultMsg = 'OK: ProjectTaskMapping created [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [TaskId=' + CAST(@ObjectId AS VARCHAR) + ']';
			END
			ELSE
			BEGIN
				RAISERROR ('Error: Task specified does not exists [TaskId=%d]', 12, 11, @ObjectId);
			END
		END
		ELSE IF(@ObjectType = 3)
		BEGIN
			IF (EXISTS (SELECT * FROM [View_Survey] WHERE [Id] = @ObjectId))
			BEGIN
				INSERT INTO [ProjectSurveyMapping]	([Id], [ProjectId], [SurveyId], [CreatedDateTime], [ModifiedDateTime])
				VALUES								(@Id, @ProjectId, @ObjectId, GETDATE(), GETDATE());
				SET @ResultMsg = 'OK: ProjectSurveyMapping created [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [SurveyId=' + CAST(@ObjectId AS VARCHAR) + ']';
			END
			ELSE
			BEGIN
				RAISERROR ('Error: Survey specified does not exists [SurveyId=%d]', 12, 11, @ObjectId);
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