CREATE TABLE [dbo].[Timeslice]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Duration] Image NOT NULL, 
	[Target] BIGINT NOT NULL,
	[User] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Timeslice_Account] FOREIGN KEY ([Id]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Timeslice_User] FOREIGN KEY ([User]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Timeslice_Task] FOREIGN KEY ([Target]) REFERENCES [Task]([Id]), 
)

GO

CREATE INDEX [IX_Timeslice_TaskId] ON [dbo].[Timeslice] ([Target])

GO

CREATE INDEX [IX_Timeslice_User] ON [dbo].[Timeslice] ([User])

GO