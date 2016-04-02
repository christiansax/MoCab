--	Sproc_SurveyAddOption adds an option to a survey
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE PROCEDURE [dbo].[Sproc_SurveyAddOption]
	@SurveyOptionId AS BIGINT,
	@SurveyId BIGINT,
    @Text AS NVARCHAR(250),
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	BEGIN
		IF (NOT EXISTS (
		SELECT	*
		FROM	View_SurveyOptions
		WHERE	[SurveyId] = @SurveyId AND [Id] = @SurveyOptionId))
		BEGIN TRY
			-- This is a new option, insert...
			BEGIN TRANSACTION
				INSERT INTO [dbo].[SurveyOption]	([Id], [SurveyId], [Text], [CreatedDateTime], [ModifiedDateTime])
						VALUES						(@SurveyOptionId, @SurveyId, @Text, GETDATE(), GETDATE())
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
			UPDATE	[dbo].[SurveyOption]
			SET		[SurveyId] = @SurveyId,
					[Text] = @Text,
					[ModifiedDateTime] = GETDATE()
			WHERE	[Id] = @SurveyOptionId;
			COMMIT;
			SET @ResultMsg = @ResultMsg + ': Updated';
		END
	END
RETURN 0