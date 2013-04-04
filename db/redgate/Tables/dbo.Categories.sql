CREATE TABLE [dbo].[Categories]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ParentCategoryID] [int] NULL,
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Description] [nvarchar] (300) COLLATE Ukrainian_CI_AS NULL
)
GO
ALTER TABLE [dbo].[Categories] ADD CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Categories] ADD CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryID]) REFERENCES [dbo].[Categories] ([ID])
GO
