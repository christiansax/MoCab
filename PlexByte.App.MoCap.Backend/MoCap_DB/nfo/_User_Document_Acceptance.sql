CREATE TABLE [nfo].[_User_Document_Acceptance]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] BIGINT NOT NULL, 
    [DocumentId] BIGINT NOT NULL, 
    [AcceptanceDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
	[CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL, 
    CONSTRAINT [FK__User_Document_Acceptance_User] FOREIGN KEY ([UserId]) REFERENCES [sec].[User]([Id]), 
    CONSTRAINT [FK__User_Document_Acceptance_Document] FOREIGN KEY ([DocumentId]) REFERENCES [nfo].[Document]([Id])
)

GO

CREATE INDEX [IX__User_Document_Acceptance_UserId] ON [nfo].[_User_Document_Acceptance] ([UserId])

GO

CREATE INDEX [IX__User_Document_Acceptance_DocumentId] ON [nfo].[_User_Document_Acceptance] ([DocumentId])

GO

CREATE INDEX [IX__User_Document_Acceptance_AcceptanceDateTime] ON [nfo].[_User_Document_Acceptance] ([AcceptanceDateTime])
