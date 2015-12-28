CREATE TABLE [ira].[Poll]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Label] NVARCHAR(250) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
	[ProjectId] BIGINT NULL,
    [StartDateTime] datetime2(3) NOT NULL, 
    [EndDateTime] datetime2(3) NOT NULL, 
    [DueDateTime] datetime2(3) NULL, 
    [VotesPerUser] INT NOT NULL DEFAULT 1, 
    [VotesChangeable] BIT NOT NULL DEFAULT 0, 
	[AllowCustomOption] BIT NOT NULL DEFAULT 0, 
    [CompleteOnMajority] BIT NOT NULL DEFAULT 0, 
	[CreatedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(),
    [ModifiedDateTime] datetime2(3) NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [CK_Poll_Startdatetime2(3)] CHECK ([StartDateTime] > GETDATE()), 
    CONSTRAINT [CK_Poll_Enddatetime2(3)] CHECK ([EndDateTime] > GETDATE()),
	CONSTRAINT [CK_Poll_Duedatetime2(3)] CHECK ([DueDateTime] > GETDATE()), 
    CONSTRAINT [FK_Poll_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id]), 
)

GO

CREATE INDEX [IX_Poll_Startdatetime2(3)] ON [ira].[Poll] ([StartDateTime])

GO

CREATE INDEX [IX_Poll_Enddatetime2(3)] ON [ira].[Poll] ([EndDateTime])

GO

CREATE INDEX [IX_Poll_Duedatetime2(3)] ON [ira].[Poll] ([DueDateTime])

GO

CREATE INDEX [IX_Poll_Project] ON [ira].[Poll] ([ProjectId])
