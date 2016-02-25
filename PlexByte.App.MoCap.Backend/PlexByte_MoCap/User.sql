CREATE TABLE [dbo].[User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [PersonId] BIGINT NOT NULL, 
    [Username] NVARCHAR(MAX) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL,
	[CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_User_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]) 
)

GO

CREATE INDEX [IX_User_Modified] ON [dbo].[User] ([ModifiedDateTime])