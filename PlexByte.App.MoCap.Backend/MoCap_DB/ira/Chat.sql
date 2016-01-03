CREATE TABLE [ira].[Chat]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(250) NULL,
	[ProjectId] BIGINT NULL, 
	[StartDateTime] datetime2(3) NOT NULL, 
    [EndDateTime] datetime2(3) NOT NULL, 
    [Priority] INT NOT NULL DEFAULT 0, 
	[CreatedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(),
	[ModifedDateTime] DATETIME2(3) NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Chat_Project] FOREIGN KEY ([ProjectId]) REFERENCES [ira].[Project]([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds chat related date. Each chat created will add a record to this table. A project assigned chat typically contains all project members. However, members can be excluded from a chat, which is reflected _User_Chat table',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Chat',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Chat_ProjectId] ON [ira].[Chat] ([ProjectId])
