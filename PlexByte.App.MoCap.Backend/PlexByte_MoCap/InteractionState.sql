--	InteractionState table specifying all states that are available
--	Author:	Christian B. Sax
--	Date:	2016/02/21
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
