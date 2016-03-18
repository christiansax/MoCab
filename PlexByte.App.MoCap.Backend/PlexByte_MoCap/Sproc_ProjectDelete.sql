--	Sproc_ProjectDelete deletes a project and its associated objects
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE PROCEDURE [dbo].[Sproc_ProjectDelete]
	@ProjectId AS BIGINT,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	BEGIN
		IF (EXISTS (
		SELECT	*
		FROM	View_Project
		WHERE	[Id] = @ProjectId))
		BEGIN TRY
			-- Project exists, lets start to delete
			BEGIN TRANSACTION
				-- TODO: Complete this part
			COMMIT TRANSACTION
			SET @ResultMsg = @ResultMsg + ': Inserted';
		END TRY
		BEGIN CATCH
			SET @ResultMsg = 'Error in delete try block: ' + ERROR_MESSAGE();
			IF @@TRANCOUNT > 0
			ROLLBACK
			RAISERROR ('Caught exception %s', 16, -1, @ResultMsg);
		END CATCH
		ELSE
			SET @ResultMsg = @ResultMsg + ': No project with Id: ' + CAST(@ProjectId AS VARCHAR);
	END
RETURN 0