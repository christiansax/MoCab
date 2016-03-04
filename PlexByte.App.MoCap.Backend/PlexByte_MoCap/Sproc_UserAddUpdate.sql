CREATE PROCEDURE [dbo].[Sproc_UserAddUpdate]
	@UserId BIGINT,
	@FirstName NVARCHAR(MAX) = '',
	@LastName NVARCHAR(MAX) = '',
	@MiddleName NVARCHAR(MAX) = '',
	@EmailAddress NVARCHAR(MAX) = '',
	@BirthDate DATETIME,
	@UserName NVARCHAR(MAX) = '',
	@Password NVARCHAR(MAX) = '',
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	DECLARE @ReturnCode INT = 0;
	SET @ResultMsg='OK';

	IF (NOT EXISTS (
		SELECT	*
		FROM	[Person]
		WHERE	[FirstName]	=	@FirstName AND [LastName]=@LastName AND [Birthdate]=@BirthDate))
	BEGIN TRY
		-- This is a new user, insert...
		BEGIN TRANSACTION
			select	@Id	=	format(getdate(), 'yyyyMMddHHmmssfff')
			INSERT	INTO [Person]	([Id], [LastName], [MiddleName], [EmailAddress], [Birthdate])
					VALUES			(@Id, @LastName, @FirstName, @EmailAddress, @BirthDate)
			INSERT	INTO [User]		([Id], [PersonId], [Username], [Password])
					VALUES			(@UserId, @Id, @UserName, @Password)
		COMMIT TRANSACTION
		SET @ResultMsg = @ResultMsg + ': Inserted';
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
        ROLLBACK
		SET	@ReturnCode = 1;
		SET @ResultMsg = 'Error while processing insert. Rolled back transaction...';
	END CATCH
	ELSE
	BEGIN TRY
		-- This is an update
		BEGIN TRANSACTION
			UPDATE	[Person]
			SET		[FirstName]			=	@FirstName,
					[LastName]			=	@LastName,
					[MiddleName]		=	@MiddleName,
					[EmailAddress]		=	@EmailAddress,
					[Birthdate]			=	@BirthDate,
					[ModifiedDateTime]	=	GETDATE()
			WHERE	[Id]				=	(SELECT PersonId FROM [User] WHERE [Id] = @UserId)
			
			UPDATE	[User]
			SET		[Username]			=	@UserName,
					[Password]			=	@Password,
					[ModifiedDateTime]	=	GETDATE()
			WHERE	[Id]				=	@UserId
		COMMIT TRANSACTION
		SET @ResultMsg = @ResultMsg + ': Updated';
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
        ROLLBACK
		SET	@ReturnCode = 1;
		SET @ResultMsg = 'Error while processing update. Rolled back transaction...';
	END CATCH
RETURN @ReturnCode