CREATE TABLE [ira].[_Users_Project]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
	[IsActive] BIT NOT NULL DEFAULT 1, 
    [CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__Users_Project_ProjectUser] UNIQUE ([ProjectId], [UserId]), 
    CONSTRAINT [FK__Users_Project_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id]), 
    CONSTRAINT [FK__Users_Project_UserId] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table maps users to a project',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'_Users_Project',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX__Users_Project_ProjectId] ON [ira].[_Users_Project] ([ProjectId])

GO

CREATE INDEX [IX__Users_Project_UserId] ON [ira].[_Users_Project] ([UserId])
