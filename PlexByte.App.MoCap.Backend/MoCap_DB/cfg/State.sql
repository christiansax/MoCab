CREATE TABLE [cfg].[State] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [Abbreviation] NVARCHAR(10),
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_State_Name] UNIQUE ([Name])
)
 ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table contains states, which may be referenced from country table', 'SCHEMA', N'cfg', 'TABLE', N'State', NULL, NULL