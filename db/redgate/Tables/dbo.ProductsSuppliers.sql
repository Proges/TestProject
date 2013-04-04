CREATE TABLE [dbo].[ProductsSuppliers]
(
[ProductID] [int] NOT NULL,
[SupplierID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[ProductsSuppliers] ADD CONSTRAINT [PK_ProductsSuppliers] PRIMARY KEY CLUSTERED  ([ProductID], [SupplierID])
GO
ALTER TABLE [dbo].[ProductsSuppliers] ADD CONSTRAINT [FK_ProductsSuppliers_ProductsSuppliers] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductsSuppliers] ADD CONSTRAINT [FK_ProductsSuppliers_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([ID]) ON DELETE CASCADE
GO
