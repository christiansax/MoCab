CREATE TABLE [dbo].[InteractionState]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE()
)

GO

CREATE INDEX [IX_InteractionState_CreatedDateTime] ON [dbo].[InteractionState] ([CreatedDateTime])

GO

CREATE INDEX [IX_InteractionState_ModifiedDateTime] ON [dbo].[InteractionState] ([ModifiedDateTime])
