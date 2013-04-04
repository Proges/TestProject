CREATE TABLE [dbo].[Roles]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Roles] ADD CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED  ([ID])
GO
