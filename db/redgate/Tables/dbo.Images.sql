CREATE TABLE [dbo].[Images]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[URL] [nvarchar] (500) COLLATE Ukrainian_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Images] ADD CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED  ([ID])
GO
