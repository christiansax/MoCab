CREATE TABLE [ira].[PollOption]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Value] NVARCHAR(250) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_PollOption_Value] UNIQUE ([Value])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table contains options for which one can vote in a poll',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'PollOption',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_PollOption_Value] ON [ira].[PollOption] ([Value])

GO

CREATE INDEX [IX_PollOption_IsActive] ON [ira].[PollOption] ([IsActive])
