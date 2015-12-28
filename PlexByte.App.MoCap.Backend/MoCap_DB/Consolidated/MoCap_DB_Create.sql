/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V8.1.2                     */
/* Target DBMS:           MS SQL Server 2012                              */
/* Project file:          MoCap_DBModel.dez                               */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2015-12-27 02:36                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */

GO
CREATE DATABASE MoCap_DB
GO
use MoCap_DB
go

/* ---------------------------------------------------------------------- */
/* Add table "dbo.ADM_Contact"                                            */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[ADM_Contact] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [FirstName] NVARCHAR(250) NOT NULL,
    [MiddleName] NVARCHAR(250),
    [LastName] NVARCHAR(250),
    [EmailAddress] NVARCHAR(750) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Adm_Contact_EmailAddress] UNIQUE ([EmailAddress])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_Contact_EmailAddress] ON [dbo].[ADM_Contact] ([EmailAddress] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table stores user contacts, which may become user at some point', 'SCHEMA', N'dbo', 'TABLE', N'ADM_Contact', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_AddressAppendix"                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_AddressAppendix] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [HouseName] NVARCHAR(250),
    [County] NVARCHAR(250),
    [POBox] NVARCHAR(50),
    [CustomString1] NVARCHAR(250),
    [CustomString2] NVARCHAR(250),
    [CustomString3] NVARCHAR(250),
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id])
)
 ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds additional address qualifies and is referenced by the address table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_AddressAppendix', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_AddressType"                                        */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_AddressType] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_AddressType_Name] UNIQUE ([Name])
)
 ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds possible address types, such as home, office etc.', 'SCHEMA', N'dbo', 'TABLE', N'CFG_AddressType', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_City"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_City] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [ZIP] NVARCHAR(10) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_City_NameZIP] UNIQUE ([Name], [ZIP])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_City_Name] ON [dbo].[CFG_City] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_City_ZIP] ON [dbo].[CFG_City] ([ZIP] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds cities and their corresponding ZIP''s and is referenced by the address table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_City', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_Country"                                            */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_Country] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [ISOCodeA2] NVARCHAR(2) NOT NULL,
    [ISOCodeA3] NVARCHAR(3),
    [ISOCodeNumber] INTEGER,
    [InternationalDialingCode] NVARCHAR(5) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_Country_NameISOCodeA2] UNIQUE ([ISOCodeA2], [Name])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Country_InternationalDialingCode] ON [dbo].[CFG_Country] ([InternationalDialingCode] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Country_ISOCodeA2] ON [dbo].[CFG_Country] ([ISOCodeA2] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


ALTER TABLE [dbo].[CFG_Country] ADD CONSTRAINT [CK_CFG_Country_ISOCodeA2] 
    CHECK (len([ISOCodeA2])=(2))
GO


ALTER TABLE [dbo].[CFG_Country] ADD CONSTRAINT [CK_CFG_Country_ISOCodeA3] 
    CHECK (len([ISOCodeA3])=(3))
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds countries and their iso code', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Country', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_GeoLocation"                                        */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_GeoLocation] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Latitude] NVARCHAR(20) NOT NULL,
    [Longitude] NVARCHAR(20) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_GeoLocation_LongLatitude] UNIQUE ([Latitude], [Longitude])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_GeoLocation_Latitude] ON [dbo].[CFG_GeoLocation] ([Latitude] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_GeoLocation_Longitude] ON [dbo].[CFG_GeoLocation] ([Longitude] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds geo locations, which are referenced from the GeoTracker and address table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_GeoLocation', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_Job"                                                */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_Job] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(250) NOT NULL,
    [Department] NVARCHAR(250),
    [Description] TEXT,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_Job_TitleDepartment] UNIQUE ([Title], [Department])
)
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Job_Title] ON [dbo].[CFG_Job] ([Title] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds job-related data and is referenced by the user table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Job', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_PhoneNumberType"                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_PhoneNumberType] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_PhoneNumberType_Name] UNIQUE ([Name])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_PhoneNumberType_Name] ON [dbo].[CFG_PhoneNumberType] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_State"                                              */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_State] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [Abbreviation] NVARCHAR(10),
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_State_Name] UNIQUE ([Name])
)
 ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table contains states, which may be referenced from country table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_State', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_Street"                                             */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_Street] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_Street_Name] UNIQUE ([Name])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Street_Name] ON [dbo].[CFG_Street] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds street names and is referenced by the address table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Street', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_StreetNumber"                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_StreetNumber] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Value] NVARCHAR(10) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_StreetNumber_Value] UNIQUE ([Value])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_StreetNumber_Value] ON [dbo].[CFG_StreetNumber] ([Value] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds street numbers / number ranges and is referenced from the address table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_StreetNumber', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_WorkingScheme"                                      */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_WorkingScheme] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [WorkingHours] NUMERIC(18,2) NOT NULL,
    [PaidLeaveDays] NUMERIC(5,2) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_WorkingScheme_NameWorkingHours] UNIQUE ([Name], [WorkingHours])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_WorkingScheme_Name] ON [dbo].[CFG_WorkingScheme] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds data about working schemes, such as part time etc', 'SCHEMA', N'dbo', 'TABLE', N'CFG_WorkingScheme', NULL, NULL
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'The number of working hours per day', 'SCHEMA', N'dbo', 'TABLE', N'CFG_WorkingScheme', 'COLUMN', N'WorkingHours'
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.System_VersionInfo"                                     */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[System_VersionInfo] (
    [Id] INTEGER IDENTITY(1,1) NOT NULL,
    [TableName] NVARCHAR(50) NOT NULL,
    [TableVersionMajor] INTEGER NOT NULL,
    [TableVersionMinor] INTEGER NOT NULL,
    [TableVersionRevision] INTEGER DEFAULT 0,
    [TableVersionBuild] INTEGER DEFAULT 0,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_System_VersionInfo_VersionMajor] ON [dbo].[System_VersionInfo] ([TableVersionMajor] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_System_VersionInfo_VersionMinor] ON [dbo].[System_VersionInfo] ([TableVersionMinor] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds version information for each table', 'SCHEMA', N'dbo', 'TABLE', N'System_VersionInfo', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_Address"                                            */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_Address] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [AddressTypeId] BIGINT NOT NULL,
    [StreetId] BIGINT NOT NULL,
    [StreetNumberId] BIGINT NOT NULL,
    [AddressAppendixId] BIGINT,
    [StateId] BIGINT,
    [CityId] BIGINT NOT NULL,
    [CountryId] BIGINT NOT NULL,
    [GeoLocationId] BIGINT,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_Address_StreetNoCityCountry] UNIQUE ([CityId], [CountryId], [StreetId], [StreetNumberId])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_AddressAppendixId] ON [dbo].[CFG_Address] ([AddressAppendixId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_CityId] ON [dbo].[CFG_Address] ([CityId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_CountryId] ON [dbo].[CFG_Address] ([CountryId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_GeoLocationId] ON [dbo].[CFG_Address] ([GeoLocationId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_StateId] ON [dbo].[CFG_Address] ([StateId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_StreetId] ON [dbo].[CFG_Address] ([StreetId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Address_StreetNumberId] ON [dbo].[CFG_Address] ([StreetNumberId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table assembles an address from various other tables, which are referenced', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Address', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_Company"                                            */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_Company] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [IndustryType] NVARCHAR(250),
    [LegalForm] NVARCHAR(50),
    [AddressId] BIGINT,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_Company_NameAddress] UNIQUE ([Name], [AddressId])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Company_IndustryType] ON [dbo].[CFG_Company] ([IndustryType] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_Company_Name] ON [dbo].[CFG_Company] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds company data and is referenced by the user table', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Company', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.CFG_PhoneNumber"                                        */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[CFG_PhoneNumber] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Value] NVARCHAR(20) NOT NULL,
    [TypeId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_CFG_PhoneNumber_Value] UNIQUE ([Value])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_PhoneNumber_TypeId] ON [dbo].[CFG_PhoneNumber] ([TypeId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CFG_PhoneNumber_Value] ON [dbo].[CFG_PhoneNumber] ([Value] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'The phone number in E.164 format', 'SCHEMA', N'dbo', 'TABLE', N'CFG_PhoneNumber', 'COLUMN', N'Value'
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.System_VersionDescription"                              */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[System_VersionDescription] (
    [Id] INTEGER IDENTITY(1,1) NOT NULL,
    [TableId] INTEGER NOT NULL,
    [Description] TEXT NOT NULL,
    [ReleaseNotes] TEXT,
    [SupervisionedBy] NVARCHAR(250) NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id])
)
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_System_VersionDescription_TableId] ON [dbo].[System_VersionDescription] ([TableId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds version info, such as release notes etc. for each release deployment', 'SCHEMA', N'dbo', 'TABLE', N'System_VersionDescription', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.ADM_User"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[ADM_User] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [UserId] NVARCHAR(500) NOT NULL,
    [FirstName] NVARCHAR(250) NOT NULL,
    [MiddleName] NVARCHAR(250),
    [LastName] NVARCHAR(250) NOT NULL,
    [EmailWork] NVARCHAR(1000),
    [EmailPersonally] NVARCHAR(1000),
    [HomeAddressId] BIGINT NOT NULL,
    [OfficeAddressId] BIGINT,
    [Birthdate] DATETIME NOT NULL,
    [JobId] BIGINT,
    [CompanyId] BIGINT,
    [Salary] NUMERIC(18,2),
    [WorkingSchemeId] BIGINT,
    [PagerNumber] NVARCHAR(20),
    [Gender] NVARCHAR(20) DEFAULT 'male' NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Adm_User_FirstMiddleLastNameBirthdate] UNIQUE ([FirstName], [MiddleName], [LastName], [Birthdate])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_User_CompanyId] ON [dbo].[ADM_User] ([CompanyId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_User_HomeAddressId] ON [dbo].[ADM_User] ([HomeAddressId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_User_JobId] ON [dbo].[ADM_User] ([JobId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_User_OfficeAddressId] ON [dbo].[ADM_User] ([OfficeAddressId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_User_WorkingSchemeId] ON [dbo].[ADM_User] ([WorkingSchemeId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table hold user specific data', 'SCHEMA', N'dbo', 'TABLE', N'ADM_User', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.MAP_PhoneNumbers"                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[MAP_PhoneNumbers] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [UserId] BIGINT,
    [ContactId] BIGINT,
    [CompanyId] BIGINT,
    [PhoneNumberId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Map_PhoneUserContact_UserContactPhone] UNIQUE ([ContactId], [PhoneNumberId], [UserId])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_ContactId] ON [dbo].[MAP_PhoneNumbers] ([ContactId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_PhoneNumberId] ON [dbo].[MAP_PhoneNumbers] ([PhoneNumberId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_UserId] ON [dbo].[MAP_PhoneNumbers] ([UserId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_CompanyId] ON [dbo].[MAP_PhoneNumbers] ([CompanyId])
GO


/* ---------------------------------------------------------------------- */
/* Add table "ITN_Task"                                                   */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [ITN_Task] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(250) NOT NULL,
    [Description] TEXT,
    [ProjectId] BIGINT,
    [CreatorId] BIGINT NOT NULL,
    [OwnerId] BIGINT NOT NULL,
    [IsPersonal] BIT NOT NULL,
    [StartDateTime] DATETIME NOT NULL,
    [EndDateTime] DATETIME NOT NULL,
    [DueDateTime] DATETIME,
    [Duration] NUMERIC(12,2) NOT NULL,
    [Budget] NUMERIC(18,2),
    [TotalCosts] NUMERIC(18,2),
    [Priority] INTEGER CONSTRAINT [DEF_ITN_Task_Priority] DEFAULT 0 NOT NULL,
    [DegreeCompleted] NUMERIC(5,2) CONSTRAINT [DEF_ITN_Task_DegreeCompleted] DEFAULT 0.00 NOT NULL,
    [CreatedDateTime] DATETIME CONSTRAINT [DEF_ITN_Task_CreatedDateTime] DEFAULT GETDATE() NOT NULL,
    [ModifiedDateTime] DATETIME CONSTRAINT [DEF_ITN_Task_ModifiedDateTime] DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_ITN_Task] PRIMARY KEY ([Id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "MAP_SubTasks"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [MAP_SubTasks] (
    [Id] BIGINT NOT NULL,
    [ParentTaskId] BIGINT NOT NULL,
    [SubTaskId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME CONSTRAINT [DEF_MAP_SubTasks_CreatedDateTime] DEFAULT GETDATE() NOT NULL,
    [ModifiedDateTime] DATETIME CONSTRAINT [DEF_MAP_SubTasks_ModifiedDateTime] DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_MAP_SubTasks] PRIMARY KEY ([Id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.ADM_GeoTracker"                                         */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[ADM_GeoTracker] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [GeoLocationId] BIGINT NOT NULL,
    [UserId] BIGINT NOT NULL,
    [TrackingDate] DATE DEFAULT 'CONVERT([date],getdate())' NOT NULL,
    [TrackingTime] TIME DEFAULT 'CONVERT([time],getdate())' NOT NULL,
    [CreatedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Adm_GeoTracker_UserIdTrackingDateTime] UNIQUE ([UserId], [TrackingDate], [TrackingTime])
)
 ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_GeoTracker_GeoLocationId] ON [dbo].[ADM_GeoTracker] ([GeoLocationId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_GeoTracker_TrackDate] ON [dbo].[ADM_GeoTracker] ([TrackingDate] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Adm_GeoTracker_UserId] ON [dbo].[ADM_GeoTracker] ([UserId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds location tracking data. The location is derived from either the address or IP address', 'SCHEMA', N'dbo', 'TABLE', N'ADM_GeoTracker', NULL, NULL
GO


/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [dbo].[ADM_GeoTracker] ADD CONSTRAINT [FK_Adm_GeoTracker_GoeLocation] 
    FOREIGN KEY ([GeoLocationId]) REFERENCES [dbo].[CFG_GeoLocation] ([Id])
GO


ALTER TABLE [dbo].[ADM_GeoTracker] ADD CONSTRAINT [FK_Adm_GeoTracker_User] 
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[ADM_User] ([Id])
GO


ALTER TABLE [dbo].[ADM_User] ADD CONSTRAINT [FK_Adm_User_CFG_Address] 
    FOREIGN KEY ([HomeAddressId]) REFERENCES [dbo].[CFG_Address] ([Id])
GO


ALTER TABLE [dbo].[ADM_User] ADD CONSTRAINT [FK_Adm_User_CFG_AddressOffice] 
    FOREIGN KEY ([OfficeAddressId]) REFERENCES [dbo].[CFG_Address] ([Id])
GO


ALTER TABLE [dbo].[ADM_User] ADD CONSTRAINT [FK_Adm_User_CFG_Company] 
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CFG_Company] ([Id])
GO


ALTER TABLE [dbo].[ADM_User] ADD CONSTRAINT [FK_Adm_User_CFG_Job] 
    FOREIGN KEY ([JobId]) REFERENCES [dbo].[CFG_Job] ([Id])
GO


ALTER TABLE [dbo].[ADM_User] ADD CONSTRAINT [FK_Adm_User_CFG_WorkingScheme] 
    FOREIGN KEY ([WorkingSchemeId]) REFERENCES [dbo].[CFG_WorkingScheme] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_AddressAppendix_Id] 
    FOREIGN KEY ([AddressAppendixId]) REFERENCES [dbo].[CFG_AddressAppendix] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_AddressType_Id] 
    FOREIGN KEY ([AddressTypeId]) REFERENCES [dbo].[CFG_AddressType] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_City_Id] 
    FOREIGN KEY ([CityId]) REFERENCES [dbo].[CFG_City] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_Country_Id] 
    FOREIGN KEY ([CountryId]) REFERENCES [dbo].[CFG_Country] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_GeoLocation_Id] 
    FOREIGN KEY ([GeoLocationId]) REFERENCES [dbo].[CFG_GeoLocation] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_State_Id] 
    FOREIGN KEY ([StateId]) REFERENCES [dbo].[CFG_State] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_Street_Id] 
    FOREIGN KEY ([StreetId]) REFERENCES [dbo].[CFG_Street] ([Id])
GO


ALTER TABLE [dbo].[CFG_Address] ADD CONSTRAINT [FK_CFG_Address_StreetNumber_Id] 
    FOREIGN KEY ([StreetNumberId]) REFERENCES [dbo].[CFG_StreetNumber] ([Id])
GO


ALTER TABLE [dbo].[CFG_Company] ADD CONSTRAINT [FK_CFG_Company_AddressId] 
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[CFG_Address] ([Id])
GO


ALTER TABLE [dbo].[CFG_PhoneNumber] ADD CONSTRAINT [FK_CFG_PhoneNumber_CFG_PhoneNumberType] 
    FOREIGN KEY ([TypeId]) REFERENCES [dbo].[CFG_PhoneNumberType] ([Id])
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] ADD CONSTRAINT [FK_Map_PhoneUserContact_Adm_Contact] 
    FOREIGN KEY ([ContactId]) REFERENCES [dbo].[ADM_Contact] ([Id])
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] ADD CONSTRAINT [FK_Map_PhoneUserContact_Adm_User] 
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[ADM_User] ([Id])
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] ADD CONSTRAINT [FK_Map_PhoneUserContact_CFG_PhoneNumber] 
    FOREIGN KEY ([PhoneNumberId]) REFERENCES [dbo].[CFG_PhoneNumber] ([Id])
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] ADD CONSTRAINT [CFG_Company_MAP_PhoneNumbers] 
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CFG_Company] ([Id])
GO


ALTER TABLE [dbo].[System_VersionDescription] ADD CONSTRAINT [FK_SystemVersionDescription_SystemVersionInfo] 
    FOREIGN KEY ([TableId]) REFERENCES [dbo].[System_VersionInfo] ([Id])
GO


ALTER TABLE [ITN_Task] ADD CONSTRAINT [ADM_User_ITN_Task] 
    FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[ADM_User] ([Id])
GO


ALTER TABLE [ITN_Task] ADD CONSTRAINT [ADM_User_ITN_Task_Owner] 
    FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[ADM_User] ([Id])
GO


ALTER TABLE [MAP_SubTasks] ADD CONSTRAINT [ITN_Task_MAP_SubTasks_Parent] 
    FOREIGN KEY ([ParentTaskId]) REFERENCES [ITN_Task] ([Id])
GO


ALTER TABLE [MAP_SubTasks] ADD CONSTRAINT [ITN_Task_MAP_SubTasks_Child] 
    FOREIGN KEY ([SubTaskId]) REFERENCES [ITN_Task] ([Id])
GO

