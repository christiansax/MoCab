CREATE TABLE [dbo].[Project]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [EnableBalance] BIT NOT NULL, 
    [EnableSurvey] BIT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Project_Interaction] FOREIGN KEY ([Id]) REFERENCES [Interaction]([Id]), 
)