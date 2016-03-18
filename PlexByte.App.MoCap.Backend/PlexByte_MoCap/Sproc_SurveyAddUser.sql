--	Sproc_SurveyAddUser adds a user to a survey
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE PROCEDURE [dbo].[Sproc_SurveyAddUser]
	@SurveyId AS BIGINT,
	@UserId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	IF (NOT EXISTS (
			SELECT	[SurveyId]
			FROM	[View_SurveyUserMapping]
			WHERE	[SurveyId] = @SurveyId AND [UserId] = @UserId))
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT	@Id	=	format(getdate(), 'yyyyMMddHHmmssfff')
			INSERT INTO [dbo].[SurveyUserMapping]	([Id], [SurveyId], [UserId], [CreatedDateTime], [ModifiedDateTime])
				VALUES								(@Id, @SurveyId, @UserId, GETDATE(), GETDATE())
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
	BEGIN
		SET @ResultMsg = @ResultMsg + ': Mapping already present';
	END
RETURN 0