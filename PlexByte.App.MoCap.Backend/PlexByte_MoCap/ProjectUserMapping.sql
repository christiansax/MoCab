--	ProjectUserMapping associated users to a project
--	Author:	Christian B. Sax
--	Date:	2016/03/06
CREATE TABLE [dbo].[ProjectUserMapping]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ProjectId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL, 
    [ModifiedDateTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_ProjectUserMapping_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_ProjectUserMapping_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)

GO

CREATE INDEX [IX_ProjectUserMapping_ProjectId] ON [dbo].[ProjectUserMapping] ([ProjectId])

GO

CREATE INDEX [IX_ProjectUserMapping_UserId] ON [dbo].[ProjectUserMapping] ([UserId])
