CREATE TABLE [dbo].[ProductsImages]
(
[ProductID] [int] NOT NULL,
[ImageID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[ProductsImages] ADD CONSTRAINT [PK_ProductsImages] PRIMARY KEY CLUSTERED  ([ProductID], [ImageID])
GO
ALTER TABLE [dbo].[ProductsImages] ADD CONSTRAINT [FK_ProductsImages_Images] FOREIGN KEY ([ImageID]) REFERENCES [dbo].[Images] ([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductsImages] ADD CONSTRAINT [FK_ProductsImages_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID]) ON DELETE CASCADE
GO
