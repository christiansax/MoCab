--	Sproc_UserDelete deleted the user specified
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE PROCEDURE [dbo].[Sproc_UserDelete]
	@UserId BIGINT = 0,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg='OK';

	IF(EXISTS (
		SELECT	*
		FROM	[User]
		WHERE	[Id] = @UserId))
	BEGIN TRY
		SELECT	@Id	=	(SELECT	[PersonId] FROM [User] WHERE [Id] = @UserId)
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
		RAISERROR ('Error in try block', 16, -1);
	END CATCH
	ELSE
	BEGIN
		SET @ResultMsg = 'OK: User did not exist';
	END
RETURN 0