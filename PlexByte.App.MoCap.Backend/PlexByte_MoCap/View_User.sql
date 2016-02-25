CREATE VIEW [dbo].[View_User]
	AS 
	SELECT	p.[FirstName], p.[MiddleName], p.[LastName], p.[EmailAddress], p.[Birthdate],
			u.[Username], u.[Password], u.[ModifiedDateTime]
	FROM	[User] u INNER JOIN [Person] p
	ON		u.PersonId=p.Id