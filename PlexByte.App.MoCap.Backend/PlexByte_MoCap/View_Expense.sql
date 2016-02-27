CREATE VIEW [dbo].[View_Expense]
	AS 
	SELECT	[e].[Id], [e].Value, [e].Receipt, [t].[Id] AS [TaskId], 
			[u].[Username] AS [Owner], [e].[ModifiedDateTime], [e].[CreatedDateTime]
	FROM	[Expense] e INNER JOIN [Task] t
	ON		[e].[Target]=[t].[Id]
			INNER JOIN [View_User] u
	ON		[u].Id=[e].[Creator]