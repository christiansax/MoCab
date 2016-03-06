--	Project Table holding all projects
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE TABLE [dbo].[Project]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
	[Name] NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[InteractionId] BIGINT NOT NULL,
	[IsActive] BIT NOT NULL, 
    [EnableBalance] BIT NOT NULL, 
    [EnableSurvey] BIT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Project_Interaction] FOREIGN KEY ([InteractionId]) REFERENCES [Interaction]([Id]) 
)
GO

CREATE INDEX [IX_Project_InteractionId] ON [dbo].[Project] ([InteractionId])

GO

CREATE INDEX [IX_Project_IsActive] ON [dbo].[Project] ([IsActive])

GO

CREATE INDEX [IX_Project_CreatedDateTime] ON [dbo].[Project] ([CreatedDateTime])
