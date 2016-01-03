CREATE TABLE [ira].[Timeslice]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [UserId] BIGINT NOT NULL, 
    [ProjectId] BIGINT NULL, 
    [TaskId] BIGINT NULL, 
    [ChatId] BIGINT NULL, 
    [PollId] BIGINT NULL, 
    [Duration] BIGINT NOT NULL,
	[CreatedDateTime] datetime2(3) CONSTRAINT [DEF_TimeSlice_CreatedDateTime] DEFAULT GETDATE() NOT NULL,
    [ModifiedDateTime] datetime2(3) CONSTRAINT [DEF_TimeSlice_ModifiedDateTime] DEFAULT GETDATE() NOT NULL, 
    CONSTRAINT [CK_Timeslice_ProjectTaskChatPoll] CHECK ([TaskId] <> NULL OR [ChatId] <> NULL OR [ProjectId] <> NULL OR [PollId] <> NULL), 
    CONSTRAINT [FK_Timeslice_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]), 
    CONSTRAINT [FK_Timeslice_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id]),
	CONSTRAINT [FK_Timeslice_Task] FOREIGN KEY ([TaskId]) REFERENCES [ira].[Task]([Id]),
	CONSTRAINT [FK_Timeslice_Chat] FOREIGN KEY ([ChatId]) REFERENCES [ira].[Chat]([Id]),
	CONSTRAINT [FK_Timeslice_Poll] FOREIGN KEY ([PollId]) REFERENCES [ira].[Poll]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds time segments, which are mapped to either a task, project, poll or chat. Any time slice used on a certain object is being written into this table',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Timeslice',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The time spent in seconds',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Timeslice',
    @level2type = N'COLUMN',
    @level2name = N'Duration'
GO

CREATE INDEX [IX_Timeslice_UserId] ON [ira].[Timeslice] ([UserId])

GO

CREATE INDEX [IX_Timeslice_ProjectId] ON [ira].[Timeslice] ([ProjectId])

GO

CREATE INDEX [IX_Timeslice_TaskId] ON [ira].[Timeslice] ([TaskId])

GO

CREATE INDEX [IX_Timeslice_ChatId] ON [ira].[Timeslice] ([ChatId])

GO

CREATE INDEX [IX_Timeslice_PollId] ON [ira].[Timeslice] ([PollId])
