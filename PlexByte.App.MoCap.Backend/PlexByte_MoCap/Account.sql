﻿CREATE TABLE [dbo].[Account]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Account_Project] FOREIGN KEY ([Id]) REFERENCES [Project]([Id]), 
)