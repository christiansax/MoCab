--	View_ProjectTimesliceMapping displays an overview of timeslices reported against projects in a grouped view
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_ProjectTimesliceMapping]
	AS
	SELECT	[a].[ProjectId], [e].[Username], [e].[CreatedDateTime], [e].[Duration], [e].[Description], [s].[IsActive]
	FROM	[Accounting] a INNER JOIN [View_Timeslice] e
			ON [a].[TimesliceId] = [e].[Id]
			INNER JOIN [View_Project] s
			ON [a].[ProjectId]=[s].[Id]