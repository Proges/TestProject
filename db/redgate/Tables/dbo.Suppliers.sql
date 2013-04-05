CREATE TABLE [dbo].[Suppliers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[PersonID] [int] NOT NULL,
[AddressID] [int] NOT NULL
)
ALTER TABLE [dbo].[Suppliers] ADD
CONSTRAINT [FK_Suppliers_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID])
ALTER TABLE [dbo].[Suppliers] ADD
CONSTRAINT [FK_Suppliers_Addresses] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([ID])
GO
ALTER TABLE [dbo].[Suppliers] ADD CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED  ([ID])
GO
