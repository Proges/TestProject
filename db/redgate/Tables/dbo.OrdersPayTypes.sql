CREATE TABLE [dbo].[OrdersPayTypes]
(
[ID] [int] NOT NULL,
[OrderID] [int] NOT NULL,
[PayTypeID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[OrdersPayTypes] ADD CONSTRAINT [PK_OrdersPayTypes_1] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[OrdersPayTypes] ADD CONSTRAINT [FK_OrdersPayTypes_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID])
GO
