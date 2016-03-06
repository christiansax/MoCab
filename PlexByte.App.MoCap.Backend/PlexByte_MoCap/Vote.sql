--	Vote Table holding the votes, which maps user to an option and survey
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE TABLE [dbo].[Vote]
(
	[Id] BIGINT NOT NULL PRIMARY KEY , 
    [UserId] BIGINT NOT NULL, 
	[SurveyId] BIGINT NOT NULL, 
    [SurveyOptionId] BIGINT NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Vote_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Vote_SurveyOption] FOREIGN KEY ([SurveyOptionId]) REFERENCES [SurveyOption]([Id]), 
    CONSTRAINT [FK_Vote_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [Survey]([Id])
)

GO

CREATE INDEX [IX_Vote_UserId] ON [dbo].[Vote] ([UserId])

GO

CREATE INDEX [IX_Vote_SurveyOptionId] ON [dbo].[Vote] ([SurveyOptionId])

GO

CREATE INDEX [IX_Vote_CreatedDateTime] ON [dbo].[Vote] ([CreatedDateTime])

GO

CREATE INDEX [IX_Vote_ModifiedDateTime] ON [dbo].[Vote] ([ModifiedDateTime])
