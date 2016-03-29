--	View_ProjectUserMapping displays the list of users by project
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_ProjectUserMapping]
	AS
	SELECT	[su].[ProjectId], [s].[Name], [su].[UserId], [u].[Username], [su].[CreatedDateTime], [s].[IsActive]
	FROM	[ProjectUserMapping] su INNER JOIN [View_Project] s
			ON [su].[ProjectId]=[s].[Id]
			INNER JOIN [View_User] u
			ON [su].[UserId] = [u].[Id]