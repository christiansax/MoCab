CREATE TABLE [dbo].[Interaction]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [StartDateTime] DATETIME NULL DEFAULT GETDATE(), 
    [EndDateTime] DATETIME NULL DEFAULT DATEADD(YEAR, 10, GETDATE()), 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [Text] NVARCHAR(MAX) NULL, 
    [Type] BIGINT NOT NULL DEFAULT 1, 
    [CreatorId] BIGINT NOT NULL, 
    [OwnerId] BIGINT NOT NULL, 
    [StateId] BIGINT NOT NULL ,
	[CreatedDateTime] DATETIME NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Interaction_UserCreator] FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Interaction_UserOwner] FOREIGN KEY ([OwnerId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Interaction_InteractionState] FOREIGN KEY ([StateId]) REFERENCES [InteractionState]([Id])
)

GO

CREATE INDEX [IX_Interaction_ModifiedDateTime] ON [dbo].[Interaction] ([ModifiedDateTime])
GO

CREATE INDEX [IX_Interaction_StartDateTime] ON [dbo].[Interaction] ([StartDateTime])
GO

CREATE INDEX [IX_Interaction_EndDateTime] ON [dbo].[Interaction] ([EndDateTime])
GO

CREATE INDEX [IX_Interaction_IsActive] ON [dbo].[Interaction] ([IsActive])
GO

CREATE INDEX [IX_Interaction_Owner] ON [dbo].[Interaction] ([OwnerId])
GO

CREATE INDEX [IX_Interaction_Creator] ON [dbo].[Interaction] ([CreatorId])
GO

CREATE INDEX [IX_Interaction_State] ON [dbo].[Interaction] ([StateId])