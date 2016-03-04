CREATE PROCEDURE [dbo].[Sproc_UserDelete]
	@UserId BIGINT = 0,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	DECLARE @ReturnCode INT = 0;
	SET @ResultMsg='OK';

	IF(EXISTS (
		SELECT	*
		FROM	[User]
		WHERE	@UserId=[Id]))
	BEGIN TRY
		SELECT	@Id	=	(SELECT	[PersonId] FROM [User] WHERE @UserId=[Id])
		BEGIN TRANSACTION
			DELETE	[User]
			WHERE	[Id]		=	(SELECT [PersonId] FROM [User] WHERE [Id]=@UserId)
			DELETE	[Person]
			WHERE	[Id]		=	@Id
		COMMIT TRANSACTION
		SET @ResultMsg = 'OK: Deleted User with ID: ' + Cast(@UserId as VARCHAR) + ' and Person with ID: ' + Cast(@Id as VARCHAR) ;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
        ROLLBACK
		SET	@ReturnCode = 1;
		SET @ResultMsg = 'Error while processing deletion. Rolled back transaction...';
	END CATCH
	ELSE
	BEGIN
		SET @ResultMsg = 'OK: User did not exist';
	END
RETURN @ReturnCode