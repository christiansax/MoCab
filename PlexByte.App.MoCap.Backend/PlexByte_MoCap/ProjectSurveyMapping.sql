CREATE TABLE [dbo].[ProjectSurveyMapping]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ProjectId] BIGINT NOT NULL, 
    [SurveyId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_ProjectSurveyMapping_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]),  
    CONSTRAINT [FK_ProjectSurveyMapping_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [Survey]([Id])
    )

GO

CREATE INDEX [IX_ProjectSurveyMapping_Project] ON [dbo].[ProjectSurveyMapping] ([ProjectId])

GO

CREATE INDEX [IX_ProjectSurveyMapping_Task] ON [dbo].[ProjectSurveyMapping] ([SurveyId])
GO

CREATE INDEX [IX_ProjectSurveyMapping_ModifiedDateTime] ON [dbo].[ProjectSurveyMapping] ([ModifiedDateTime])

GO

CREATE INDEX [IX_ProjectSurveyMapping_CreatedDateTime] ON [dbo].[ProjectSurveyMapping] ([CreatedDateTime])
