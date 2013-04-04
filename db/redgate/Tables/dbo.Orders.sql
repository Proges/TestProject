CREATE TABLE [dbo].[Orders]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PersonID] [int] NOT NULL,
[AddressID] [int] NOT NULL,
[CreatedDate] [date] NOT NULL,
[DeliveryTimeFrom] [time] NOT NULL,
[DeliveryTimeTo] [time] NOT NULL,
[DeliveryTypeID] [int] NOT NULL
)
ALTER TABLE [dbo].[Orders] ADD
CONSTRAINT [FK_Orders_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID]) ON DELETE CASCADE
ALTER TABLE [dbo].[Orders] ADD
CONSTRAINT [FK_Orders_Addresses] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([ID])
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_DeliveryTypes] FOREIGN KEY ([DeliveryTypeID]) REFERENCES [dbo].[DeliveryTypes] ([ID])
GO
