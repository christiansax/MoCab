--	Sproc_AccountRemoveMapping adds either an expense or timeslice to a project, based on the ObjectType
-- 1 = Expense 2 = Timeslice
--	Author:	Christian B. Sax
--	Date:	2016/03/07
CREATE PROCEDURE [dbo].[Sproc_AccountRemoveMapping]
	@ProjectId AS BIGINT,
	@ObjectId AS BIGINT,
	@ObjectType AS INT,
	@TaskId AS BIGINT = NULL,
	@ResultMsg NVARCHAR(250) OUTPUT
AS
	DECLARE @Id BIGINT;
	SET @ResultMsg = 'OK';

	IF(@ObjectType = 1)
	BEGIN
		IF (EXISTS (SELECT * FROM [View_Accounting] WHERE [ExpenseId] = @ObjectId AND [ProjectId] = @ProjectId))
		BEGIN
			DELETE	[Accounting]
			WHERE	[ExpenseId] = @ObjectId AND [ProjectId] = @ProjectId;
			SET @ResultMsg = 'OK: Expense removed from project [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [ExpenseId=' 
				+ CAST(@ObjectId AS VARCHAR) + ']';
		END
		ELSE
		BEGIN
			SET @ResultMsg = 'OK: Expense project mapping was not found [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [ExpenseId=' 
				+ CAST(@ObjectId AS VARCHAR) + ']';
		END
	END
	ELSE IF(@ObjectType = 2)
	BEGIN
		IF (EXISTS (SELECT * FROM [View_Accounting] WHERE [TimesliceId] = @ObjectId AND [ProjectId] = @ProjectId))
		BEGIN
			DELETE	[Accounting]
			WHERE	[TimesliceId] = @ObjectId AND [ProjectId] = @ProjectId;
			SET @ResultMsg = 'OK: Timeslice removed from project [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [TimesliceId=' 
				+ CAST(@ObjectId AS VARCHAR) + ']';
		END
		ELSE
		BEGIN
			SET @ResultMsg = 'OK: Timeslice project mapping was not found [ProjectId=' + CAST(@ProjectId AS VARCHAR) + '] [TimesliceId=' 
				+ CAST(@ObjectId AS VARCHAR) + ']';
		END
	END
	ELSE
	BEGIN
		RAISERROR ('Error: Object type specified is not valid [ObjectType=%d]', 12, 11, @ObjectType);
	END
RETURN 0