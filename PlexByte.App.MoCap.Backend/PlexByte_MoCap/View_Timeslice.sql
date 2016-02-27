CREATE VIEW [dbo].[View_Timeslice]
	AS 
	SELECT	[ts].[Id], [ts].Duration, [t].Id AS [TaskId],
			[u].[Username] AS [Owner], [ts].[ModifiedDateTime], [ts].[CreatedDateTime]
	FROM	[Timeslice] ts INNER JOIN [Task] t
	ON		[ts].[Target]=[t].[Id]
			INNER JOIN [View_User] u
	ON		[u].Id=[ts].[User]