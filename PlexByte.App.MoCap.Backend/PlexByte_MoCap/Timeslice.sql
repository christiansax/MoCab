CREATE TABLE [dbo].[Timeslice]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Duration] Image NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Timeslice_Account] FOREIGN KEY ([Id]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Timeslice_User] FOREIGN KEY ([Id]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Timeslice_Task] FOREIGN KEY ([Id]) REFERENCES [Task]([Id]), 
)