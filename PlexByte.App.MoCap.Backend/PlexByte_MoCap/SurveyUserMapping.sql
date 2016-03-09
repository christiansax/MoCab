--	SurveyUserMapping table referencing surveys to users
--	Author:	Christian B. Sax
--	Date:	2016/02/21
CREATE TABLE [dbo].[SurveyUserMapping]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [SurveyId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_SurveyUserMapping_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [Survey]([Id]), 
    CONSTRAINT [FK_SurveyUserMapping_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
)

GO

CREATE INDEX [IX_SurveyUserMapping_SurveyId] ON [dbo].[SurveyUserMapping] ([SurveyId])
