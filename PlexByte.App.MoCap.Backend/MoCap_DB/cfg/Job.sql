CREATE TABLE [cfg].[Job] (
    [Id] BIGINT IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(250) NOT NULL,
    [Department] NVARCHAR(250),
    [Description] NVARCHAR(MAX),
    [CreatedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    [ModifiedDateTime] datetime2(3) DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [AK_Job_TitleDepartment] UNIQUE ([Title], [Department])
)

GO
CREATE NONCLUSTERED INDEX [IX_Job_Title] ON [cfg].[Job] ([Title] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXECUTE sp_addextendedproperty N'MS_Description', N'This table holds job-related data and is referenced by the user table', 'SCHEMA', N'cfg', 'TABLE', N'Job', NULL, NULL