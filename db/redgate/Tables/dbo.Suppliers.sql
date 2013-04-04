CREATE TABLE [dbo].[Suppliers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Email] [nvarchar] (150) COLLATE Ukrainian_CI_AS NOT NULL,
[Phone] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL
)
GO
ALTER TABLE [dbo].[Suppliers] ADD CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED  ([ID])
GO
