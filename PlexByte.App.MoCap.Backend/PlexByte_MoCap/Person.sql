CREATE TABLE [dbo].[Person]
(
	[Id] BIGINT NOT NULL PRIMARY KEY  IDENTITY, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [MiddleName] NVARCHAR(MAX) NULL, 
    [EmailAddress] NVARCHAR(MAX) NOT NULL, 
    [Birthdate] DATETIME NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE()
)

GO

CREATE INDEX [IX_Person_Birthdate] ON [dbo].[Person] ([Birthdate])
GO

CREATE INDEX [IX_Person_Modified] ON [dbo].[Person] ([ModifiedDateTime])
