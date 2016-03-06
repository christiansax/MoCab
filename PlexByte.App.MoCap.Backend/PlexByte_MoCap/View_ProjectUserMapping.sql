CREATE VIEW [dbo].[View_ProjectUserMapping]
	AS
	SELECT	[su].[ProjectId], [s].[Name], [su].[UserId], [u].[Username], [su].[CreatedDateTime]
	FROM	[ProjectUserMapping] su INNER JOIN [View_Project] s
			ON [su].[ProjectId]=[s].[Id]
			INNER JOIN [View_User] u
			ON [su].[UserId] = [u].[Id]