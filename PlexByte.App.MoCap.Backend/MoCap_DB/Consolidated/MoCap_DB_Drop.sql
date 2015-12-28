/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V8.1.2                     */
/* Target DBMS:           MS SQL Server 2012                              */
/* Project file:          MoCap_DBModel.dez                               */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database drop script                            */
/* Created on:            2015-12-27 02:36                                */
/* ---------------------------------------------------------------------- */

use MoCap_DB
GO
/* ---------------------------------------------------------------------- */
/* Drop foreign key constraints                                           */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT [FK_Adm_GeoTracker_GoeLocation]
GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT [FK_Adm_GeoTracker_User]
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT [FK_Adm_User_CFG_Address]
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT [FK_Adm_User_CFG_AddressOffice]
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT [FK_Adm_User_CFG_Company]
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT [FK_Adm_User_CFG_Job]
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT [FK_Adm_User_CFG_WorkingScheme]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_AddressAppendix_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_AddressType_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_City_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_Country_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_GeoLocation_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_State_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_Street_Id]
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [FK_CFG_Address_StreetNumber_Id]
GO


ALTER TABLE [dbo].[CFG_Company] DROP CONSTRAINT [FK_CFG_Company_AddressId]
GO


ALTER TABLE [dbo].[CFG_PhoneNumber] DROP CONSTRAINT [FK_CFG_PhoneNumber_CFG_PhoneNumberType]
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT [FK_Map_PhoneUserContact_Adm_Contact]
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT [FK_Map_PhoneUserContact_Adm_User]
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT [FK_Map_PhoneUserContact_CFG_PhoneNumber]
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT [CFG_Company_MAP_PhoneNumbers]
GO


ALTER TABLE [dbo].[System_VersionDescription] DROP CONSTRAINT [FK_SystemVersionDescription_SystemVersionInfo]
GO


ALTER TABLE [ITN_Task] DROP CONSTRAINT [ADM_User_ITN_Task]
GO


ALTER TABLE [ITN_Task] DROP CONSTRAINT [ADM_User_ITN_Task_Owner]
GO


ALTER TABLE [MAP_SubTasks] DROP CONSTRAINT [ITN_Task_MAP_SubTasks_Parent]
GO


ALTER TABLE [MAP_SubTasks] DROP CONSTRAINT [ITN_Task_MAP_SubTasks_Child]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.ADM_GeoTracker"                                        */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_GeoTracker] DROP CONSTRAINT [AK_Adm_GeoTracker_UserIdTrackingDateTime]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'ADM_GeoTracker', NULL, NULL
GO


DROP TABLE [dbo].[ADM_GeoTracker]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "MAP_SubTasks"                                              */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [MAP_SubTasks] DROP CONSTRAINT [DEF_MAP_SubTasks_CreatedDateTime]
GO


ALTER TABLE [MAP_SubTasks] DROP CONSTRAINT [DEF_MAP_SubTasks_ModifiedDateTime]
GO


ALTER TABLE [MAP_SubTasks] DROP CONSTRAINT [PK_MAP_SubTasks]
GO


DROP TABLE [MAP_SubTasks]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "ITN_Task"                                                  */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [ITN_Task] DROP CONSTRAINT [DEF_ITN_Task_Priority]
GO


ALTER TABLE [ITN_Task] DROP CONSTRAINT [DEF_ITN_Task_DegreeCompleted]
GO


ALTER TABLE [ITN_Task] DROP CONSTRAINT [DEF_ITN_Task_CreatedDateTime]
GO


ALTER TABLE [ITN_Task] DROP CONSTRAINT [DEF_ITN_Task_ModifiedDateTime]
GO


ALTER TABLE [ITN_Task] DROP CONSTRAINT [PK_ITN_Task]
GO


DROP TABLE [ITN_Task]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.MAP_PhoneNumbers"                                      */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[MAP_PhoneNumbers] DROP CONSTRAINT [AK_Map_PhoneUserContact_UserContactPhone]
GO


DROP TABLE [dbo].[MAP_PhoneNumbers]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.ADM_User"                                              */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_User] DROP CONSTRAINT [AK_Adm_User_FirstMiddleLastNameBirthdate]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'ADM_User', NULL, NULL
GO


DROP TABLE [dbo].[ADM_User]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.System_VersionDescription"                             */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[System_VersionDescription] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[System_VersionDescription] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[System_VersionDescription] DROP CONSTRAINT 
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'System_VersionDescription', NULL, NULL
GO


DROP TABLE [dbo].[System_VersionDescription]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_PhoneNumber"                                       */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_PhoneNumber] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_PhoneNumber] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_PhoneNumber] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_PhoneNumber] DROP CONSTRAINT [AK_CFG_PhoneNumber_Value]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_PhoneNumber', 'COLUMN', N'Value'
GO


DROP TABLE [dbo].[CFG_PhoneNumber]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_Company"                                           */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_Company] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Company] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Company] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Company] DROP CONSTRAINT [AK_CFG_Company_NameAddress]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Company', NULL, NULL
GO


DROP TABLE [dbo].[CFG_Company]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_Address"                                           */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Address] DROP CONSTRAINT [AK_CFG_Address_StreetNoCityCountry]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Address', NULL, NULL
GO


DROP TABLE [dbo].[CFG_Address]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.System_VersionInfo"                                    */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[System_VersionInfo] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[System_VersionInfo] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[System_VersionInfo] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[System_VersionInfo] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[System_VersionInfo] DROP CONSTRAINT 
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'System_VersionInfo', NULL, NULL
GO


DROP TABLE [dbo].[System_VersionInfo]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_WorkingScheme"                                     */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_WorkingScheme] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_WorkingScheme] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_WorkingScheme] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_WorkingScheme] DROP CONSTRAINT [AK_CFG_WorkingScheme_NameWorkingHours]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_WorkingScheme', 'COLUMN', N'WorkingHours'
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_WorkingScheme', NULL, NULL
GO


DROP TABLE [dbo].[CFG_WorkingScheme]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_StreetNumber"                                      */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_StreetNumber] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_StreetNumber] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_StreetNumber] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_StreetNumber] DROP CONSTRAINT [AK_CFG_StreetNumber_Value]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_StreetNumber', NULL, NULL
GO


DROP TABLE [dbo].[CFG_StreetNumber]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_Street"                                            */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_Street] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Street] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Street] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Street] DROP CONSTRAINT [AK_CFG_Street_Name]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Street', NULL, NULL
GO


DROP TABLE [dbo].[CFG_Street]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_State"                                             */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_State] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_State] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_State] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_State] DROP CONSTRAINT [AK_CFG_State_Name]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_State', NULL, NULL
GO


DROP TABLE [dbo].[CFG_State]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_PhoneNumberType"                                   */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_PhoneNumberType] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_PhoneNumberType] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_PhoneNumberType] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_PhoneNumberType] DROP CONSTRAINT [AK_CFG_PhoneNumberType_Name]
GO


DROP TABLE [dbo].[CFG_PhoneNumberType]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_Job"                                               */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_Job] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Job] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Job] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Job] DROP CONSTRAINT [AK_CFG_Job_TitleDepartment]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Job', NULL, NULL
GO


DROP TABLE [dbo].[CFG_Job]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_GeoLocation"                                       */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_GeoLocation] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_GeoLocation] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_GeoLocation] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_GeoLocation] DROP CONSTRAINT [AK_CFG_GeoLocation_LongLatitude]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_GeoLocation', NULL, NULL
GO


DROP TABLE [dbo].[CFG_GeoLocation]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_Country"                                           */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_Country] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Country] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Country] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_Country] DROP CONSTRAINT [AK_CFG_Country_NameISOCodeA2]
GO


ALTER TABLE [dbo].[CFG_Country] DROP CONSTRAINT [CK_CFG_Country_ISOCodeA2]
GO


ALTER TABLE [dbo].[CFG_Country] DROP CONSTRAINT [CK_CFG_Country_ISOCodeA3]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_Country', NULL, NULL
GO


DROP TABLE [dbo].[CFG_Country]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_City"                                              */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_City] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_City] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_City] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_City] DROP CONSTRAINT [AK_CFG_City_NameZIP]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_City', NULL, NULL
GO


DROP TABLE [dbo].[CFG_City]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_AddressType"                                       */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_AddressType] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_AddressType] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_AddressType] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_AddressType] DROP CONSTRAINT [AK_CFG_AddressType_Name]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_AddressType', NULL, NULL
GO


DROP TABLE [dbo].[CFG_AddressType]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.CFG_AddressAppendix"                                   */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[CFG_AddressAppendix] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_AddressAppendix] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[CFG_AddressAppendix] DROP CONSTRAINT 
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'CFG_AddressAppendix', NULL, NULL
GO


DROP TABLE [dbo].[CFG_AddressAppendix]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "dbo.ADM_Contact"                                           */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [dbo].[ADM_Contact] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_Contact] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_Contact] DROP CONSTRAINT 
GO


ALTER TABLE [dbo].[ADM_Contact] DROP CONSTRAINT [AK_Adm_Contact_EmailAddress]
GO


EXECUTE sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'ADM_Contact', NULL, NULL
GO


DROP TABLE [dbo].[ADM_Contact]
GO

DROP DATABASE MoCap_DB
GO

