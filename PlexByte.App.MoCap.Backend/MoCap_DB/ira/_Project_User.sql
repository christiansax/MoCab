CREATE TABLE [ira].[_Project_User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
	[IsActive] BIT NOT NULL DEFAULT 1, 
    [CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__Project_User_ProjectUser] UNIQUE ([ProjectId], [UserId]), 
    CONSTRAINT [FK__Project_User_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id]), 
    CONSTRAINT [FK__Project_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table maps users to a project',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'_Project_User',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX__Project_User_ProjectId] ON [ira].[_Project_User] ([ProjectId])

GO

CREATE INDEX [IX__Project_User_UserId] ON [ira].[_Project_User] ([UserId])
