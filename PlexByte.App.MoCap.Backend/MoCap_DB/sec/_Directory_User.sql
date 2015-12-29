CREATE TABLE [dbo].[_Directory_User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [DirectoryId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
	[ProjectId] BIGINT NULL, 
    [CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__Directory_User_DirectoryUserProject] UNIQUE ([DirectoryId], [UserId], [ProjectId]), 
    CONSTRAINT [FK__Directory_User_Directory] FOREIGN KEY ([DirectoryId]) REFERENCES [sec].[Directory]([Id]), 
    CONSTRAINT [FK__Directory_User_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]), 
    CONSTRAINT [FK__Directory_User_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is a directory listing, which contains users found in the _User_User table. By default each project creates a directory containig the project members',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'_Directory_User',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX__Directory_User_DirectoryId] ON [dbo].[_Directory_User] ([DirectoryId])

GO

CREATE INDEX [IX__Directory_User_UserId] ON [dbo].[_Directory_User] ([UserId])

GO

CREATE INDEX [IX__Directory_User_ProjectId] ON [dbo].[_Directory_User] ([ProjectId])
