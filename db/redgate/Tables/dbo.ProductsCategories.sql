CREATE TABLE [dbo].[ProductsCategories]
(
[ProductID] [int] NOT NULL,
[CategoryID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[ProductsCategories] ADD CONSTRAINT [PK_ProductsCategories] PRIMARY KEY CLUSTERED  ([ProductID], [CategoryID])
GO
ALTER TABLE [dbo].[ProductsCategories] ADD CONSTRAINT [FK_ProductsCategories_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductsCategories] ADD CONSTRAINT [FK_ProductsCategories_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID]) ON DELETE CASCADE
GO
