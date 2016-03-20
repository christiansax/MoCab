--	Sproc_AddUserLog add a log record everytime a user logs in
--	Author:	Christian B. Sax
--	Date:	2016/03/19
CREATE PROCEDURE [dbo].[Sproc_AddUserLog]
	@UserId BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg='OK';

	IF (EXISTS (
		SELECT	*
		FROM	[View_User]
		WHERE	[Id] = @UserId))
	BEGIN TRY
		-- This is a new user, insert...
		BEGIN TRANSACTION
			INSERT	INTO [UserLog]	([UserId], [LogDateTime])
					VALUES			(@UserId, GETDATE())
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
		RAISERROR ('Error: No such user %s', 16, -1, @UserId);
	END
RETURN 0