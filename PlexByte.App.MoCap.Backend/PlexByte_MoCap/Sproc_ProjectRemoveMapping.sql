--	Sproc_ProjectRemoveMapping removes a project mapping based on the objectType
-- 1 = UserMapping, 2 = TaskMapping, 3 = SurveyMapping
--	Author:	Christian B. Sax
--	Date:	2016/03/07
CREATE PROCEDURE [dbo].[Sproc_ProjectRemoveMapping]
	@ProjectId AS BIGINT,
	@ObjectId AS BIGINT,
	@ObjectType AS INT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	-- Check if project exists
	IF(@ObjectType = 1)
	BEGIN
		IF (EXISTS (SELECT * FROM [View_ProjectUserMapping] WHERE [ProjectId] = @ProjectId AND [UserId] = @ObjectId))
		BEGIN
			DELETE	[ProjectUserMapping]
			WHERE	[ProjectId] = @ProjectId AND [UserId] = @ObjectId;
			SET @ResultMsg = 'OK: ProjectUserMapping removed [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [UserId=' + CAST(@ObjectId AS VARCHAR) + ']';
		END
		ELSE
		BEGIN
			SET @ResultMsg = 'OK: ProjectUserMapping did not exist';
		END
	END
	IF(@ObjectType = 2)
	BEGIN
		IF (EXISTS (SELECT * FROM [ProjectTaskMapping] WHERE [ProjectId] = @ProjectId AND [TaskId] = @ObjectId))
		BEGIN
			DELETE	[ProjectTaskMapping]
			WHERE	[ProjectId] = @ProjectId AND [TaskId] = @ObjectId;
			SET @ResultMsg = 'OK: ProjectTaskMapping removed [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [TaskId=' + CAST(@ObjectId AS VARCHAR) + ']';
		END
		ELSE
		BEGIN
			SET @ResultMsg = 'OK: ProjectTaskMapping did not exist';
		END
	END
	IF(@ObjectType = 3)
	BEGIN
		IF (EXISTS (SELECT * FROM [ProjectSurveyMapping] WHERE [ProjectId] = @ProjectId AND [SurveyId] = @ObjectId))
		BEGIN
			DELETE	[ProjectSurveyMapping]
			WHERE	[ProjectId] = @ProjectId AND [SurveyId] = @ObjectId;
			SET @ResultMsg = 'OK: ProjectSurveyMapping removed [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [SurveyId=' + CAST(@ObjectId AS VARCHAR) + ']';
		END
		ELSE
		BEGIN
			SET @ResultMsg = 'OK: ProjectSurveyMapping did not exist';
		END
	END
	ELSE
	BEGIN
		RAISERROR ('Error: Object type specified is not valid [ObjectType=%d]', 12, 11, @ObjectType);
	END
RETURN 0