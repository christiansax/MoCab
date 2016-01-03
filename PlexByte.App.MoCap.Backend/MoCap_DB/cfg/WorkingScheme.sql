CREATE TABLE [cfg].[WorkingScheme] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [WorkingHours] NUMERIC(18,2) NOT NULL,
    [PaidLeaveDays] NUMERIC(5,2) NOT NULL,
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_WorkingScheme_NameWorkingHours] UNIQUE ([Name], [WorkingHours]), 
)
 ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_WorkingScheme_Name] ON [cfg].[WorkingScheme] ([Name] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds data about working schemes, such as part time etc', 'SCHEMA', N'cfg', 'TABLE', N'WorkingScheme', NULL, NULL
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'The number of working hours per day', 'SCHEMA', N'cfg', 'TABLE', N'WorkingScheme', 'COLUMN', N'WorkingHours'
GO
