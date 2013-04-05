CREATE TABLE [dbo].[OrderLines]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ProductID] [int] NOT NULL,
[OrderID] [int] NOT NULL,
[Count] [int] NOT NULL,
[UnitPrice] [int] NOT NULL,
[SupplierID] [int] NOT NULL
)
ALTER TABLE [dbo].[OrderLines] ADD
CONSTRAINT [FK_OrderLines_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[OrderLines] ADD CONSTRAINT [PK_OrdersProducts] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[OrderLines] ADD CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[OrderLines] ADD CONSTRAINT [FK_OrderLines_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID]) ON DELETE CASCADE
GO
