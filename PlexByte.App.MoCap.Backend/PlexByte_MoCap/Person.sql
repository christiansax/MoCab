CREATE TABLE [dbo].[Person]
(
	[Id] BIGINT NOT NULL PRIMARY KEY DEFAULT NEWID() IDENTITY, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [MiddleName] NVARCHAR(MAX) NULL, 
    [EmailAddress] NVARCHAR(MAX) NOT NULL, 
    [Birthdate] DATETIME NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Person_LastFirstBirth] UNIQUE ([LastName], [FirstName], [Birthdate]) 
)

GO

CREATE INDEX [IX_Person_LastName] ON [dbo].[Person] ([LastName])
GO

CREATE INDEX [IX_Person_FirstName] ON [dbo].[Person] ([FirstName])
GO

CREATE INDEX [IX_Person_Birthdate] ON [dbo].[Person] ([Birthdate])
GO

CREATE INDEX [IX_Person_Email] ON [dbo].[Person] ([EmailAddress])
GO

CREATE INDEX [IX_Person_Modified] ON [dbo].[Person] ([ModifiedDateTime])
