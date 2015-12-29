CREATE TABLE [ira].[_User_Poll_Option]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [PollId] BIGINT NOT NULL, 
    [OptionId] BIGINT NOT NULL, 
    [CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK__User_Poll_Option_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]),
	CONSTRAINT [FK__User_Poll_Option_Poll] FOREIGN KEY ([PollId]) REFERENCES [ira].[Poll]([Id]),
	CONSTRAINT [FK__User_Poll_Option_PollOption] FOREIGN KEY ([OptionId]) REFERENCES [ira].[PollOption]([Id])
)

GO

CREATE INDEX [IX__User_Poll_Option_UserId] ON [ira].[_User_Poll_Option] ([UserId])

GO

CREATE INDEX [IX__User_Poll_Option_PollId] ON [ira].[_User_Poll_Option] ([PollId])

GO

CREATE INDEX [IX__User_Poll_Option_OptionId] ON [ira].[_User_Poll_Option] ([OptionId])
