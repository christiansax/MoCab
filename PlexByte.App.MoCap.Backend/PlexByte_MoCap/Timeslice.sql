--	Timeslice Table holding all time efforts logged
--	Author:	Christian B. Sax
--	Date:	2016/03/05
CREATE TABLE [dbo].[Timeslice]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
	[Description] NVARCHAR(MAX) NULL,
    [Duration] DECIMAL(18,2) NOT NULL, 
	[CreatorId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Timeslice_User] FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]) 
)

GO

CREATE INDEX [IX_Timeslice_User] ON [dbo].[Timeslice] ([CreatorId])

GO