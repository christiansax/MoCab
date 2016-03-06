--	SurveyOptions table containng all survey options available
--	Author:	Christian B. Sax
--	Date:	2016/02/21
CREATE TABLE [dbo].[SurveyOption]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [SurveyId] BIGINT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_SurveyOption_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [Survey]([Id])
)

GO

CREATE INDEX [IX_SurveyOption_SurveyId] ON [dbo].[SurveyOption] ([SurveyId])

GO

CREATE INDEX [IX_SurveyOption_CreatedDateTime] ON [dbo].[SurveyOption] ([CreatedDateTime])

GO

CREATE INDEX [IX_SurveyOption_ModifiedDateTime] ON [dbo].[SurveyOption] ([ModifiedDateTime])
