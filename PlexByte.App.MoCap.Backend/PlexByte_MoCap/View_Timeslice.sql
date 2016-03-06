--	View_Timeslice to view the timeslice details including resolved user details
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_Timeslice]
	AS 
	SELECT	[t].[Id], [t].[Duration], [t].[Description], [t].[CreatorId], [u].[Username], [t].[ModifiedDateTime], 
			[t].[CreatedDateTime]
	FROM	[Timeslice] t INNER JOIN [View_User] u
	ON		[u].Id = [t].[CreatorId]