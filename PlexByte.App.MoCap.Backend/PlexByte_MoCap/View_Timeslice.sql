--	View_Timeslice to view the timeslice details including resolved user details
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_Timeslice]
	AS
	SELECT	[e].*, [a].[ProjectId], [a].[TaskId], [u].[Username]
	FROM	[Timeslice] e INNER JOIN [Accounting] a
			ON [e].[Id] = [a].[TimesliceId]
			INNER JOIN [User] u
			ON [e].[CreatorId] = [u].[Id]
	WHERE	[a].[TimesliceId] IS NOT NULL