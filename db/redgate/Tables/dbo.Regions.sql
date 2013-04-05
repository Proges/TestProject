CREATE TABLE [dbo].[Regions]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Regions] ADD CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED  ([ID])
GO
