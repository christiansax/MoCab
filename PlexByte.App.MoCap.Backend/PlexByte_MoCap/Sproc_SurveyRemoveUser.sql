--	Sproc_SurveyRemoveUser removes a user from a survey
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE PROCEDURE [dbo].[Sproc_SurveyRemoveUser]
	@SurveyId AS BIGINT,
	@UserId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	IF (EXISTS (
			SELECT	[SurveyId]
			FROM	[View_SurveyUserMapping]
			WHERE	[SurveyId] = @SurveyId AND [UserId] = @UserId))
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE	[dbo].[SurveyUserMapping]
			WHERE	[SurveyId] = @SurveyId AND [UserId] = @UserId
		COMMIT TRANSACTION
			SET @ResultMsg = @ResultMsg + ': Record deleted';
	END TRY
	BEGIN CATCH
		SET @ResultMsg = 'Error in delete try block: ' + ERROR_MESSAGE();
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Caught exception %s', 16, -1, @ResultMsg);
	END CATCH
	ELSE
	BEGIN
		SET @ResultMsg = @ResultMsg + ': No Record to delete..';
	END
RETURN 0