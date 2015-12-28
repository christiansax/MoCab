CREATE TABLE [ira].[_Poll_Options]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [PollId] BIGINT NOT NULL, 
    [OptionId] BIGINT NOT NULL, 
    [Votes] INT NOT NULL DEFAULT 0, 
    [CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK__Poll_Options_PollOption] UNIQUE ([PollId], [OptionId]), 
    CONSTRAINT [FK__Poll_Options_Poll] FOREIGN KEY ([PollId]) REFERENCES [ira].[Poll]([Id]),
	CONSTRAINT [FK__Poll_Options_Option] FOREIGN KEY ([OptionId]) REFERENCES [ira].[PollOption]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table maps possible options for a poll',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'_Poll_Options',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX__Poll_Options_PollId] ON [ira].[_Poll_Options] ([PollId])

GO

CREATE INDEX [IX__Poll_Options_OptionId] ON [ira].[_Poll_Options] ([OptionId])
