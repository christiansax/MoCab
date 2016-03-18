--	View_User displays a list of users
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE VIEW [dbo].[View_User]
	AS 
	SELECT	p.[FirstName], p.[MiddleName], p.[LastName], p.[EmailAddress], p.[Birthdate],
			u.[Username], u.[Password], u.[ModifiedDateTime], [u].[Id], [p].[Id] as PersonId, [u].[CreatedDateTime]
	FROM	[User] u INNER JOIN [Person] p
	ON		u.PersonId=p.Id