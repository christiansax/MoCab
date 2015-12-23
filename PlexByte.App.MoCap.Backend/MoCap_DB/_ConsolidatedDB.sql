USE [master]
GO
/****** Object:  Database [MoCap_DB]    Script Date: 23.12.2015 00:58:56 ******/
CREATE DATABASE [MoCap_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoCap_DB', FILENAME = N'D:\SQL\Data\MoCap_DB_Primary.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MoCap_DB_log', FILENAME = N'D:\SQL\Log\MoCap_DB_Primary.ldf' , SIZE = 1792KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MoCap_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoCap_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoCap_DB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MoCap_DB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MoCap_DB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MoCap_DB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MoCap_DB] SET ARITHABORT ON 
GO
ALTER DATABASE [MoCap_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoCap_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoCap_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoCap_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoCap_DB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MoCap_DB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MoCap_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoCap_DB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MoCap_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoCap_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoCap_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoCap_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoCap_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoCap_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoCap_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoCap_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoCap_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoCap_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [MoCap_DB] SET  MULTI_USER 
GO
ALTER DATABASE [MoCap_DB] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [MoCap_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoCap_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoCap_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MoCap_DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MoCap_DB]
GO
/****** Object:  Table [dbo].[Adm_Contact]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adm_Contact](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[EmailAddress] [nvarchar](750) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Adm_Contact_EmailAddress] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Adm_GeoTracker]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adm_GeoTracker](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GeoLocationId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[TrackingDate] [date] NOT NULL,
	[TrackingTime] [time](3) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Adm_GeoTracker_UserIdTrackingDateTime] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[TrackingDate] ASC,
	[TrackingTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Adm_User]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adm_User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](500) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[EmailWork] [nvarchar](1000) NULL,
	[EmailPersonally] [nvarchar](1000) NULL,
	[HomeAddressId] [bigint] NOT NULL,
	[OfficeAddressId] [bigint] NULL,
	[Birthdate] [datetime] NOT NULL,
	[JobId] [bigint] NULL,
	[CompanyId] [bigint] NULL,
	[Salary] [numeric](18, 2) NULL,
	[WorkingSchemeId] [bigint] NULL,
	[PagerNumber] [nvarchar](20) NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Adm_User_FirstMiddleLastNameBirthdate] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC,
	[MiddleName] ASC,
	[LastName] ASC,
	[Birthdate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_Address]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_Address](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AddressTypeId] [bigint] NOT NULL,
	[StreetId] [bigint] NOT NULL,
	[StreetNumberId] [bigint] NOT NULL,
	[AddressAppendixId] [bigint] NULL,
	[StateId] [bigint] NULL,
	[CityId] [bigint] NOT NULL,
	[CountryId] [bigint] NOT NULL,
	[GeoLocationId] [bigint] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_Address_StreetNoCityCountry] UNIQUE NONCLUSTERED 
(
	[CityId] ASC,
	[CountryId] ASC,
	[StreetId] ASC,
	[StreetNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_AddressAppendix]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_AddressAppendix](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HouseName] [nvarchar](250) NULL,
	[County] [nvarchar](250) NULL,
	[POBox] [nvarchar](50) NULL,
	[CustomString1] [nvarchar](250) NULL,
	[CustomString2] [nvarchar](250) NULL,
	[CustomString3] [nvarchar](250) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_AddressType]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_AddressType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_AddressType_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_City]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_City](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ZIP] [nvarchar](10) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_City_NameZIP] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[ZIP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_Company]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_Company](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IndustryType] [nvarchar](250) NULL,
	[LegalForm] [nvarchar](50) NULL,
	[AddressId] [bigint] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_Company_NameAddress] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_Country]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_Country](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ISOCodeA2] [nvarchar](2) NOT NULL,
	[ISOCodeA3] [nvarchar](3) NULL,
	[ISOCodeNumber] [int] NULL,
	[InternationalDialingCode] [nvarchar](5) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_Country_NameISOCodeA2] UNIQUE NONCLUSTERED 
(
	[ISOCodeA2] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_GeoLocation]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_GeoLocation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Latitude] [nvarchar](20) NOT NULL,
	[Longitude] [nvarchar](20) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_GeoLocation_LongLatitude] UNIQUE NONCLUSTERED 
(
	[Latitude] ASC,
	[Longitude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_Job]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_Job](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Department] [nvarchar](250) NULL,
	[Description] [text] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_Job_TitleDepartment] UNIQUE NONCLUSTERED 
(
	[Title] ASC,
	[Department] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_PhoneNumber]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_PhoneNumber](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](20) NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_PhoneNumber_Value] UNIQUE NONCLUSTERED 
(
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_PhoneNumberType]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_PhoneNumberType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_PhoneNumberType_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_State]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_State](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_State_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_Street]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_Street](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_Street_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_StreetNumber]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_StreetNumber](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](10) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_StreetNumber_Value] UNIQUE NONCLUSTERED 
(
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CFG_WorkingScheme]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFG_WorkingScheme](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[WorkingHours] [numeric](18, 2) NOT NULL,
	[PaidLeaveDays] [numeric](5, 2) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CFG_WorkingScheme_NameWorkingHours] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[WorkingHours] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Map_PhoneUserContact]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Map_PhoneUserContact](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[ContactId] [bigint] NULL,
	[PhoneNumberId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Map_PhoneUserContact_UserContactPhone] UNIQUE NONCLUSTERED 
(
	[ContactId] ASC,
	[PhoneNumberId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[System_VersionDescription]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[System_VersionDescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[ReleaseNotes] [text] NULL,
	[SupervisionedBy] [nvarchar](250) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[System_VersionInfo]    Script Date: 23.12.2015 00:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[System_VersionInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[TableVersionMajor] [int] NOT NULL,
	[TableVersionMinor] [int] NOT NULL,
	[TableVersionRevision] [int] NULL,
	[TableVersionBuild] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Adm_Contact_EmailAddress]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_Contact_EmailAddress] ON [dbo].[Adm_Contact]
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_GeoTracker_GeoLocationId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_GeoTracker_GeoLocationId] ON [dbo].[Adm_GeoTracker]
(
	[GeoLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_GeoTracker_TrackDate]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_GeoTracker_TrackDate] ON [dbo].[Adm_GeoTracker]
(
	[TrackingDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_GeoTracker_UserId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_GeoTracker_UserId] ON [dbo].[Adm_GeoTracker]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_User_CompanyId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_User_CompanyId] ON [dbo].[Adm_User]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_User_HomeAddressId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_User_HomeAddressId] ON [dbo].[Adm_User]
(
	[HomeAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_User_JobId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_User_JobId] ON [dbo].[Adm_User]
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_User_OfficeAddressId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_User_OfficeAddressId] ON [dbo].[Adm_User]
(
	[OfficeAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adm_User_WorkingSchemeId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Adm_User_WorkingSchemeId] ON [dbo].[Adm_User]
(
	[WorkingSchemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_AddressAppendixId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_AddressAppendixId] ON [dbo].[CFG_Address]
(
	[AddressAppendixId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_CityId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_CityId] ON [dbo].[CFG_Address]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_CountryId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_CountryId] ON [dbo].[CFG_Address]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_GeoLocationId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_GeoLocationId] ON [dbo].[CFG_Address]
(
	[GeoLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_StateId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_StateId] ON [dbo].[CFG_Address]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_StreetId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_StreetId] ON [dbo].[CFG_Address]
(
	[StreetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_Address_StreetNumberId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Address_StreetNumberId] ON [dbo].[CFG_Address]
(
	[StreetNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_City_Name]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_City_Name] ON [dbo].[CFG_City]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_City_ZIP]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_City_ZIP] ON [dbo].[CFG_City]
(
	[ZIP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_Company_IndustryType]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Company_IndustryType] ON [dbo].[CFG_Company]
(
	[IndustryType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_Company_Name]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Company_Name] ON [dbo].[CFG_Company]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Country_InternationalDialingCode]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Country_InternationalDialingCode] ON [dbo].[CFG_Country]
(
	[InternationalDialingCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Country_ISOCodeA2]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Country_ISOCodeA2] ON [dbo].[CFG_Country]
(
	[ISOCodeA2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_GeoLocation_Latitude]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_GeoLocation_Latitude] ON [dbo].[CFG_GeoLocation]
(
	[Latitude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_GeoLocation_Longitude]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_GeoLocation_Longitude] ON [dbo].[CFG_GeoLocation]
(
	[Longitude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_Job_Title]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Job_Title] ON [dbo].[CFG_Job]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CFG_PhoneNumber_TypeId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_PhoneNumber_TypeId] ON [dbo].[CFG_PhoneNumber]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_PhoneNumber_Value]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_PhoneNumber_Value] ON [dbo].[CFG_PhoneNumber]
(
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_PhoneNumberType_Name]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_PhoneNumberType_Name] ON [dbo].[CFG_PhoneNumberType]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_Street_Name]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_Street_Name] ON [dbo].[CFG_Street]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_StreetNumber_Value]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_StreetNumber_Value] ON [dbo].[CFG_StreetNumber]
(
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CFG_WorkingScheme_Name]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_CFG_WorkingScheme_Name] ON [dbo].[CFG_WorkingScheme]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Map_PhoneUserContact_ContactId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_ContactId] ON [dbo].[Map_PhoneUserContact]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Map_PhoneUserContact_PhoneNumberId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_PhoneNumberId] ON [dbo].[Map_PhoneUserContact]
(
	[PhoneNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Map_PhoneUserContact_UserId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Map_PhoneUserContact_UserId] ON [dbo].[Map_PhoneUserContact]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_System_VersionDescription_TableId]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_System_VersionDescription_TableId] ON [dbo].[System_VersionDescription]
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_System_VersionInfo_VersionMajor]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_System_VersionInfo_VersionMajor] ON [dbo].[System_VersionInfo]
(
	[TableVersionMajor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_System_VersionInfo_VersionMinor]    Script Date: 23.12.2015 00:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_System_VersionInfo_VersionMinor] ON [dbo].[System_VersionInfo]
(
	[TableVersionMinor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adm_Contact] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Adm_Contact] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[Adm_GeoTracker] ADD  DEFAULT (CONVERT([date],getdate())) FOR [TrackingDate]
GO
ALTER TABLE [dbo].[Adm_GeoTracker] ADD  DEFAULT (CONVERT([time],getdate())) FOR [TrackingTime]
GO
ALTER TABLE [dbo].[Adm_GeoTracker] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Adm_GeoTracker] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[Adm_User] ADD  DEFAULT ('male') FOR [Gender]
GO
ALTER TABLE [dbo].[Adm_User] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Adm_User] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_Address] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_Address] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_AddressAppendix] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_AddressAppendix] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_AddressType] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_AddressType] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_City] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_City] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_Company] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_Company] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_Country] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_Country] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_GeoLocation] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_GeoLocation] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_Job] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_Job] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_PhoneNumber] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_PhoneNumber] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_PhoneNumberType] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_PhoneNumberType] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_State] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_State] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_Street] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_Street] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_StreetNumber] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_StreetNumber] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[CFG_WorkingScheme] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CFG_WorkingScheme] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[Map_PhoneUserContact] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Map_PhoneUserContact] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[System_VersionDescription] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[System_VersionDescription] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[System_VersionInfo] ADD  DEFAULT ((0)) FOR [TableVersionRevision]
GO
ALTER TABLE [dbo].[System_VersionInfo] ADD  DEFAULT ((0)) FOR [TableVersionBuild]
GO
ALTER TABLE [dbo].[System_VersionInfo] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[System_VersionInfo] ADD  DEFAULT (getdate()) FOR [ModifiedDateTime]
GO
ALTER TABLE [dbo].[Adm_GeoTracker]  WITH CHECK ADD  CONSTRAINT [FK_Adm_GeoTracker_GoeLocation] FOREIGN KEY([GeoLocationId])
REFERENCES [dbo].[CFG_GeoLocation] ([Id])
GO
ALTER TABLE [dbo].[Adm_GeoTracker] CHECK CONSTRAINT [FK_Adm_GeoTracker_GoeLocation]
GO
ALTER TABLE [dbo].[Adm_GeoTracker]  WITH CHECK ADD  CONSTRAINT [FK_Adm_GeoTracker_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Adm_User] ([Id])
GO
ALTER TABLE [dbo].[Adm_GeoTracker] CHECK CONSTRAINT [FK_Adm_GeoTracker_User]
GO
ALTER TABLE [dbo].[Adm_User]  WITH CHECK ADD  CONSTRAINT [FK_Adm_User_CFG_Address] FOREIGN KEY([HomeAddressId])
REFERENCES [dbo].[CFG_Address] ([Id])
GO
ALTER TABLE [dbo].[Adm_User] CHECK CONSTRAINT [FK_Adm_User_CFG_Address]
GO
ALTER TABLE [dbo].[Adm_User]  WITH CHECK ADD  CONSTRAINT [FK_Adm_User_CFG_AddressOffice] FOREIGN KEY([OfficeAddressId])
REFERENCES [dbo].[CFG_Address] ([Id])
GO
ALTER TABLE [dbo].[Adm_User] CHECK CONSTRAINT [FK_Adm_User_CFG_AddressOffice]
GO
ALTER TABLE [dbo].[Adm_User]  WITH CHECK ADD  CONSTRAINT [FK_Adm_User_CFG_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[CFG_Company] ([Id])
GO
ALTER TABLE [dbo].[Adm_User] CHECK CONSTRAINT [FK_Adm_User_CFG_Company]
GO
ALTER TABLE [dbo].[Adm_User]  WITH CHECK ADD  CONSTRAINT [FK_Adm_User_CFG_Job] FOREIGN KEY([JobId])
REFERENCES [dbo].[CFG_Job] ([Id])
GO
ALTER TABLE [dbo].[Adm_User] CHECK CONSTRAINT [FK_Adm_User_CFG_Job]
GO
ALTER TABLE [dbo].[Adm_User]  WITH CHECK ADD  CONSTRAINT [FK_Adm_User_CFG_WorkingScheme] FOREIGN KEY([WorkingSchemeId])
REFERENCES [dbo].[CFG_WorkingScheme] ([Id])
GO
ALTER TABLE [dbo].[Adm_User] CHECK CONSTRAINT [FK_Adm_User_CFG_WorkingScheme]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_AddressAppendix_Id] FOREIGN KEY([AddressAppendixId])
REFERENCES [dbo].[CFG_AddressAppendix] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_AddressAppendix_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_AddressType_Id] FOREIGN KEY([AddressTypeId])
REFERENCES [dbo].[CFG_AddressType] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_AddressType_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_City_Id] FOREIGN KEY([CityId])
REFERENCES [dbo].[CFG_City] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_City_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_Country_Id] FOREIGN KEY([CountryId])
REFERENCES [dbo].[CFG_Country] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_Country_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_GeoLocation_Id] FOREIGN KEY([GeoLocationId])
REFERENCES [dbo].[CFG_GeoLocation] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_GeoLocation_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_State_Id] FOREIGN KEY([StateId])
REFERENCES [dbo].[CFG_State] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_State_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_Street_Id] FOREIGN KEY([StreetId])
REFERENCES [dbo].[CFG_Street] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_Street_Id]
GO
ALTER TABLE [dbo].[CFG_Address]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Address_StreetNumber_Id] FOREIGN KEY([StreetNumberId])
REFERENCES [dbo].[CFG_StreetNumber] ([Id])
GO
ALTER TABLE [dbo].[CFG_Address] CHECK CONSTRAINT [FK_CFG_Address_StreetNumber_Id]
GO
ALTER TABLE [dbo].[CFG_Company]  WITH CHECK ADD  CONSTRAINT [FK_CFG_Company_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[CFG_Address] ([Id])
GO
ALTER TABLE [dbo].[CFG_Company] CHECK CONSTRAINT [FK_CFG_Company_AddressId]
GO
ALTER TABLE [dbo].[CFG_PhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_CFG_PhoneNumber_CFG_PhoneNumberType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[CFG_PhoneNumberType] ([Id])
GO
ALTER TABLE [dbo].[CFG_PhoneNumber] CHECK CONSTRAINT [FK_CFG_PhoneNumber_CFG_PhoneNumberType]
GO
ALTER TABLE [dbo].[Map_PhoneUserContact]  WITH CHECK ADD  CONSTRAINT [FK_Map_PhoneUserContact_Adm_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Adm_Contact] ([Id])
GO
ALTER TABLE [dbo].[Map_PhoneUserContact] CHECK CONSTRAINT [FK_Map_PhoneUserContact_Adm_Contact]
GO
ALTER TABLE [dbo].[Map_PhoneUserContact]  WITH CHECK ADD  CONSTRAINT [FK_Map_PhoneUserContact_Adm_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Adm_User] ([Id])
GO
ALTER TABLE [dbo].[Map_PhoneUserContact] CHECK CONSTRAINT [FK_Map_PhoneUserContact_Adm_User]
GO
ALTER TABLE [dbo].[Map_PhoneUserContact]  WITH CHECK ADD  CONSTRAINT [FK_Map_PhoneUserContact_CFG_PhoneNumber] FOREIGN KEY([PhoneNumberId])
REFERENCES [dbo].[CFG_PhoneNumber] ([Id])
GO
ALTER TABLE [dbo].[Map_PhoneUserContact] CHECK CONSTRAINT [FK_Map_PhoneUserContact_CFG_PhoneNumber]
GO
ALTER TABLE [dbo].[System_VersionDescription]  WITH CHECK ADD  CONSTRAINT [FK_SystemVersionDescription_SystemVersionInfo] FOREIGN KEY([TableId])
REFERENCES [dbo].[System_VersionInfo] ([Id])
GO
ALTER TABLE [dbo].[System_VersionDescription] CHECK CONSTRAINT [FK_SystemVersionDescription_SystemVersionInfo]
GO
ALTER TABLE [dbo].[CFG_Country]  WITH CHECK ADD  CONSTRAINT [CK_CFG_Country_ISOCodeA2] CHECK  ((len([ISOCodeA2])=(2)))
GO
ALTER TABLE [dbo].[CFG_Country] CHECK CONSTRAINT [CK_CFG_Country_ISOCodeA2]
GO
ALTER TABLE [dbo].[CFG_Country]  WITH CHECK ADD  CONSTRAINT [CK_CFG_Country_ISOCodeA3] CHECK  ((len([ISOCodeA3])=(3)))
GO
ALTER TABLE [dbo].[CFG_Country] CHECK CONSTRAINT [CK_CFG_Country_ISOCodeA3]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table stores user contacts, which may become user at some point' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Adm_Contact'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds location tracking data. The location is derived from either the address or IP address' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Adm_GeoTracker'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table hold user specific data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Adm_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table assembles an address from various other tables, which are referenced' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds additional address qualifies and is referenced by the address table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_AddressAppendix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds possible address types, such as home, office etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_AddressType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds cities and their corresponding ZIP''s and is referenced by the address table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds company data and is referenced by the user table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_Company'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds countries and their iso code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_Country'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds geo locations, which are referenced from the GeoTracker and address table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_GeoLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds job-related data and is referenced by the user table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_Job'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The phone number in E.164 format' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_PhoneNumber', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table contains states, which may be referenced from country table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds street names and is referenced by the address table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_Street'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds street numbers / number ranges and is referenced from the address table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_StreetNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of working hours per day' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_WorkingScheme', @level2type=N'COLUMN',@level2name=N'WorkingHours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds data about working schemes, such as part time etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CFG_WorkingScheme'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds version info, such as release notes etc. for each release deployment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'System_VersionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table holds version information for each table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'System_VersionInfo'
GO
USE [master]
GO
ALTER DATABASE [MoCap_DB] SET  READ_WRITE 
GO
