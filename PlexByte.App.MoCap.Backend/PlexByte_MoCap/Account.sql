CREATE TABLE [dbo].[Account]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Account_Interaction] FOREIGN KEY ([Id]) REFERENCES [Interaction]([Id]), 
    CONSTRAINT [FK_Account_Project] FOREIGN KEY ([Id]) REFERENCES [Project]([Id]), 
)
GO

CREATE INDEX [IX_Account_Project] ON [dbo].[Project] ([id])

GO