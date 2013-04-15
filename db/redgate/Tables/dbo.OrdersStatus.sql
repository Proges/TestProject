CREATE TABLE [dbo].[OrdersStatus]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[OrderID] [int] NOT NULL,
[StatusID] [int] NOT NULL,
[Date] [datetime] NOT NULL
)
GO
ALTER TABLE [dbo].[OrdersStatus] ADD CONSTRAINT [PK_OrdersStatuses] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[OrdersStatus] ADD CONSTRAINT [FK_OrdersStatuses_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([ID])
GO
