CREATE TABLE [dbo].[Adm_Contact]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(250) NOT NULL, 
    [MiddleName] NVARCHAR(250) NULL, 
    [LastName] NVARCHAR(250) NULL, 
    [EmailAddress] NVARCHAR(750) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Adm_Contact_EmailAddress] UNIQUE ([EmailAddress])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table stores user contacts, which may become user at some point',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Adm_Contact',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Adm_Contact_EmailAddress] ON [dbo].[Adm_Contact] ([EmailAddress])
