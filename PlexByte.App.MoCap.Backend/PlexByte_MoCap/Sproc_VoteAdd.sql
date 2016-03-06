--	Sproc_VoteAdd adds a vote associated with a survey
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE PROCEDURE [dbo].[Sproc_VoteAdd]
	@SurveyId AS BIGINT,
	@UserId BIGINT,
    @SurveyOptionId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	BEGIN
		IF (NOT EXISTS (
		SELECT	*
		FROM	View_VoteCount
		WHERE	[SurveyId] = @SurveyId AND [UserId] = @UserId AND [OptionId] = @SurveyOptionId))
		BEGIN TRY
			-- This is a new user, insert...
			BEGIN TRANSACTION
				select	@Id	=	format(getdate(), 'yyyyMMddHHmmssfff')
				INSERT INTO [dbo].[Vote]	([Id], [SurveyId], [UserId], [SurveyOptionId], [CreatedDateTime], [ModifiedDateTime])
						VALUES				(@Id, @SurveyId, @UserId, @SurveyOptionId, GETDATE(), GETDATE())
			COMMIT TRANSACTION
			SET @ResultMsg = @ResultMsg + ': Inserted';
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Error in try block', 11, -1);
		END CATCH
		ELSE
			-- This is an update
				-- Do nothing as update does not make sense here
			SET @ResultMsg = @ResultMsg + ': Updated';
	END
RETURN 0