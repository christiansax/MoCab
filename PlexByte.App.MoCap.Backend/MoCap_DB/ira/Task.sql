CREATE TABLE [ira].[Task] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(250) NOT NULL,
    [Description] NVARCHAR(MAX),
    [ProjectId] BIGINT,
    [CreatorId] BIGINT NOT NULL,
    [OwnerId] BIGINT NOT NULL,
	[IsCompleted] BIT NOT NULL DEFAULT 0,
    [IsPersonal] BIT NOT NULL,
    [StartDateTime] datetime2(3) NOT NULL,
    [EndDateTime] datetime2(3) NOT NULL,
    [DueDateTime] datetime2(3),
    [Duration] NUMERIC(12,2) NOT NULL,
    [Budget] NUMERIC(18,2),
    [TotalCosts] NUMERIC(18,2),
    [Priority] INTEGER CONSTRAINT [DEF_Task_Priority] DEFAULT 0 NOT NULL,
    [Progress] NUMERIC(5,2) CONSTRAINT [DEF_Task_DegreeCompleted] DEFAULT 0.00 NOT NULL,
    [CreatedDateTime] datetime2(3) CONSTRAINT [DEF_Task_CreatedDateTime] DEFAULT GETDATE() NOT NULL,
    [ModifiedDateTime] datetime2(3) CONSTRAINT [DEF_Task_ModifiedDateTime] DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Task_Priority] CHECK ([Priority] >= 0 AND [Priority] <= 100), 
    CONSTRAINT [CK_Task_Progress] CHECK ([Progress] >= 0 AND [Progress] <= 100), 
    CONSTRAINT [FK_Task_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id])
)
GO
ALTER TABLE [ira].[Task] ADD CONSTRAINT [FK_Task_Creator] 
    FOREIGN KEY ([CreatorId]) REFERENCES [sec].[User] ([Id])
GO
ALTER TABLE [ira].[Task] ADD CONSTRAINT [FK_Task_Owner] 
    FOREIGN KEY ([OwnerId]) REFERENCES [sec].[User] ([Id])
GO

CREATE INDEX [IX_Task_ProjectId] ON [ira].[Task] ([ProjectId])

GO

CREATE INDEX [IX_Task_CreatorId] ON [ira].[Task] ([CreatorId])

GO

CREATE INDEX [IX_Task_OwnerId] ON [ira].[Task] ([OwnerId])

GO

CREATE INDEX [IX_Task_IsCompleted] ON [ira].[Task] ([IsCompleted])

GO

CREATE INDEX [IX_Task_Priority] ON [ira].[Task] ([Priority])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds task related information',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = NULL,
    @level2name = NULL