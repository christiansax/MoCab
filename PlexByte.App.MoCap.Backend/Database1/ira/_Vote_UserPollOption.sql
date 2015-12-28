CREATE TABLE [ira].[_Vote_UserPollOption]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [PollId] BIGINT NOT NULL, 
    [OptionId] BIGINT NOT NULL, 
    [CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK__Vote_UserPollOption_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]),
	CONSTRAINT [FK__Vote_UserPollOption_Poll] FOREIGN KEY ([PollId]) REFERENCES [ira].[Poll]([Id]),
	CONSTRAINT [FK__Vote_UserPollOption_PollOption] FOREIGN KEY ([OptionId]) REFERENCES [ira].[PollOption]([Id])
)

GO

CREATE INDEX [IX__Vote_UserPollOption_UserId] ON [ira].[_Vote_UserPollOption] ([UserId])

GO

CREATE INDEX [IX__Vote_UserPollOption_PollId] ON [ira].[_Vote_UserPollOption] ([PollId])

GO

CREATE INDEX [IX__Vote_UserPollOption_OptionId] ON [ira].[_Vote_UserPollOption] ([OptionId])
