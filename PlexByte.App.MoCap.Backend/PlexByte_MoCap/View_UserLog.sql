CREATE VIEW [dbo].[View_UserLog]
	AS
	SELECT	[ud].[Id] as UserId, [ud].[Username], [ud].[FirstName], [ud].[LastName], [ul].[LogDateTime]
	FROM	[UserLog] ul inner join [View_User] ud
			ON ul.UserId = ud.Id
