CREATE TABLE [cfg].[AddressAppendix] (
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
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds additional address qualifies and is referenced by the address table', 'SCHEMA', N'cfg', 'TABLE', N'AddressAppendix', NULL, NULL