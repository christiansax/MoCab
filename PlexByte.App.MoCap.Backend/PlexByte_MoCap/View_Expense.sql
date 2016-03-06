--	View_Expense to view the expense details including resolved user details
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_Expense]
	AS 
	SELECT	[e].[Id], [e].[Value], [e].[Receipt], [e].[Description], [e].[CreatorId], [u].[Username], 
			[e].[ModifiedDateTime], [e].[CreatedDateTime]
	FROM	[Expense] e INNER JOIN [View_User] u
	ON		[u].Id = [e].[CreatorId]