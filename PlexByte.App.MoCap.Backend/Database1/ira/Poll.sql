CREATE TABLE [ira].[Poll]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Label] NVARCHAR(250) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
	[ProjectId] BIGINT NULL,
    [StartDateTime] DATETIME NOT NULL, 
    [EndDateTime] DATETIME NOT NULL, 
    [DueDateTime] DATETIME NULL, 
    [VotesPerUser] INT NOT NULL DEFAULT 1, 
    [VotesChangeable] BIT NOT NULL DEFAULT 0, 
	[AllowCustomOption] BIT NOT NULL DEFAULT 0, 
    [CompleteOnMajority] BIT NOT NULL DEFAULT 0, 
	[CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(),
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [CK_Poll_StartDateTime] CHECK ([StartDateTime] > GETDATE()), 
    CONSTRAINT [CK_Poll_EndDateTime] CHECK ([EndDateTime] > GETDATE()),
	CONSTRAINT [CK_Poll_DueDateTime] CHECK ([DueDateTime] > GETDATE()), 
    CONSTRAINT [FK_Poll_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id]), 
)

GO

CREATE INDEX [IX_Poll_StartDateTime] ON [ira].[Poll] ([StartDateTime])

GO

CREATE INDEX [IX_Poll_EndDateTime] ON [ira].[Poll] ([EndDateTime])

GO

CREATE INDEX [IX_Poll_DueDateTime] ON [ira].[Poll] ([DueDateTime])

GO

CREATE INDEX [IX_Poll_Project] ON [ira].[Poll] ([ProjectId])
