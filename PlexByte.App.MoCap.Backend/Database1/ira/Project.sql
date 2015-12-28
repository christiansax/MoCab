﻿CREATE TABLE [ira].[Project]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
	[Category] NVARCHAR(250) NULL, 
    [OwnerId] BIGINT NOT NULL, 
	[DeputyId] BIGINT NOT NULL, 
    [StartDateTime] DATETIME NOT NULL, 
    [EndDateTime] DATETIME NOT NULL, 
	[DueDateTime] DATETIME NULL, 
	[Priority] INT NOT NULL DEFAULT 0, 
    [Progress] NUMERIC(5, 2) NOT NULL DEFAULT 0.00, 
	[IsCompleted] BIT NOT NULL DEFAULT 0,
    [Budget] NUMERIC(18, 2) NULL DEFAULT 0.00, 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Project_NameCatOwner] UNIQUE ([Name], [Category], [OwnerId]), 
    CONSTRAINT [CK_Project_StartDateTime] CHECK ([StartDateTime] > GETDATE()), 
    CONSTRAINT [CK_Project_EndDateTime] CHECK ([EndDateTime] > GETDATE()), 
    CONSTRAINT [CK_Project_Priority] CHECK ([Priority] >=0 AND [Priority] <= 100), 
    CONSTRAINT [CK_Project_Progress] CHECK ([Progress] >= 0 AND [Progress] <= 100), 
    CONSTRAINT [CK_Project_DueDateTime] CHECK ([DueDateTime] > GETDATE()), 
    CONSTRAINT [FK_Project_User] FOREIGN KEY ([OwnerId]) REFERENCES [sec].[User]([Id]), 
    CONSTRAINT [FK_Project_User_Deputy] FOREIGN KEY ([DeputyId]) REFERENCES [sec].[User]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table hold project related data',
    @level0type = N'SCHEMA',
    @level0name = N'ira',
    @level1type = N'TABLE',
    @level1name = N'Project',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Project_Name] ON [ira].[Project] ([Name])

GO

CREATE INDEX [IX_Project_Category] ON [ira].[Project] ([Category])

GO

CREATE INDEX [IX_Project_StartDateTime] ON [ira].[Project] ([StartDateTime])

GO

CREATE INDEX [IX_Project_EndDateTime] ON [ira].[Project] ([EndDateTime])

GO

CREATE INDEX [IX_Project_DueDateTime] ON [ira].[Project] ([DueDateTime])

GO

CREATE INDEX [IX_Project_IsCompleted] ON [ira].[Project] ([IsCompleted])

GO

CREATE INDEX [IX_Project_DeputyId] ON [ira].[Project] ([DeputyId])

GO

CREATE INDEX [IX_Project_OwnerId] ON [ira].[Project] ([OwnerId])
