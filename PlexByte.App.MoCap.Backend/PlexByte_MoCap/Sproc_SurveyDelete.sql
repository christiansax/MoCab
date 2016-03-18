--	Sproc_SurveyDelete deletes the survey, its options, votes  and usermapping
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE PROCEDURE [dbo].[Sproc_SurveyDelete]
	@SurveyId BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	BEGIN
		IF (EXISTS (
		SELECT	*
		FROM	View_Survey
		WHERE	[Id] = @SurveyId))
		BEGIN TRY
			-- Delete Survey, option, votes and usermapping
			BEGIN TRANSACTION
				DELETE	[dbo].[Vote]
				WHERE	[SurveyId] = @SurveyId

				DELETE	[dbo].[SurveyUserMapping]
				WHERE	[SurveyId] = @SurveyId

				DELETE	[dbo].[SurveyOption]
				WHERE	[SurveyId] = @SurveyId

				DELETE	[dbo].[Survey]
				WHERE	[Id] = @SurveyId
			COMMIT TRANSACTION
			SET @ResultMsg = @ResultMsg + ': All corresponding objects deleted for Survey with Id: ' + CAST(@SurveyId AS VARCHAR);
		END TRY
		BEGIN CATCH
			SET @ResultMsg = 'Error in delete try block: ' + ERROR_MESSAGE();
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Caught exception %s', 16, -1, @ResultMsg);
		END CATCH
		ELSE
			-- This is an update
				-- Do nothing as update does not make sense here
			SET @ResultMsg = @ResultMsg + ': No Survey with Id: ' + CAST(@SurveyId AS VARCHAR) + ' found';
	END
RETURN 0