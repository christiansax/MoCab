﻿CREATE TABLE [dbo].[InteractionType]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(250) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE()
)
