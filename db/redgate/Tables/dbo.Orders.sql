CREATE TABLE [dbo].[Orders]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[UserID] [int] NOT NULL,
[AddressID] [int] NOT NULL,
[CreatedDate] [date] NOT NULL,
[DeliveryTimeFrom] [time] NOT NULL,
[DeliveryTimeTo] [time] NOT NULL,
[DeliveredDate] [date] NOT NULL,
[DeliveryTypeID] [int] NOT NULL,
[PayTypeID] [int] NOT NULL
)
ALTER TABLE [dbo].[Orders] ADD
CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])

ALTER TABLE [dbo].[Orders] ADD
CONSTRAINT [FK_Orders_Addresses] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([ID])
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED  ([ID])
GO
