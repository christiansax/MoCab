CREATE TABLE [dbo].[Adm_User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[UserId] NVARCHAR(500) NOT NULL, 
    [FirstName] NVARCHAR(250) NOT NULL, 
    [MiddleName] NVARCHAR(250) NULL, 
    [LastName] NVARCHAR(250) NOT NULL, 
    [EmailWork] NVARCHAR(1000) NULL, 
    [EmailPersonally] NVARCHAR(1000) NULL, 
    [HomeAddressId] BIGINT NOT NULL, 
	[OfficeAddressId] BIGINT NULL, 
    [Birthdate] DATETIME NOT NULL, 
    [JobId] BIGINT NULL, 
    [CompanyId] BIGINT NULL, 
    [Salary] NUMERIC(18, 2) NULL, 
    [WorkingSchemeId] BIGINT NULL, 
	[PagerNumber] NVARCHAR(20) NULL, 
    [Gender] NVARCHAR(20) NOT NULL DEFAULT 'male', 
    [CreatedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedDateTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Adm_User_FirstMiddleLastNameBirthdate] UNIQUE ([FirstName], [MiddleName], [LastName], [Birthdate]), 
    CONSTRAINT [FK_Adm_User_CFG_Address] FOREIGN KEY ([HomeAddressId]) REFERENCES [CFG_Address]([Id]),
	CONSTRAINT [FK_Adm_User_CFG_AddressOffice] FOREIGN KEY ([OfficeAddressId]) REFERENCES [CFG_Address]([Id]),
	CONSTRAINT [FK_Adm_User_CFG_Job] FOREIGN KEY ([JobId]) REFERENCES [CFG_Job]([Id]),
	CONSTRAINT [FK_Adm_User_CFG_Company] FOREIGN KEY ([CompanyId]) REFERENCES [CFG_Company]([Id]),
	CONSTRAINT [FK_Adm_User_CFG_WorkingScheme] FOREIGN KEY ([WorkingSchemeId]) REFERENCES [CFG_WorkingScheme]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table hold user specific data',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Adm_User',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Adm_User_HomeAddressId] ON [dbo].[Adm_User] ([HomeAddressId])

GO

CREATE INDEX [IX_Adm_User_OfficeAddressId] ON [dbo].[Adm_User] ([OfficeAddressId])

GO

CREATE INDEX [IX_Adm_User_JobId] ON [dbo].[Adm_User] ([JobId])

GO

CREATE INDEX [IX_Adm_User_CompanyId] ON [dbo].[Adm_User] ([CompanyId])

GO

CREATE INDEX [IX_Adm_User_WorkingSchemeId] ON [dbo].[Adm_User] ([WorkingSchemeId])
