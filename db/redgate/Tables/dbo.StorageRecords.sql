CREATE TABLE [dbo].[StorageRecords]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ProductID] [int] NOT NULL,
[UserID] [int] NOT NULL,
[SupplierID] [int] NULL,
[Debit] [int] NOT NULL,
[Credit] [int] NOT NULL,
[Date] [datetime] NOT NULL
)
ALTER TABLE [dbo].[StorageRecords] ADD
CONSTRAINT [FK_StorageRecords_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[StorageRecords] ADD CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[StorageRecords] ADD CONSTRAINT [FK_Storage_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[StorageRecords] ADD CONSTRAINT [FK_Storage_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
GO
