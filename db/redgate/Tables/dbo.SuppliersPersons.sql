CREATE TABLE [dbo].[SuppliersPersons]
(
[PersonID] [int] NOT NULL,
[SupplierID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[SuppliersPersons] ADD CONSTRAINT [PK_SuppliersPersons] PRIMARY KEY CLUSTERED  ([PersonID])
GO
ALTER TABLE [dbo].[SuppliersPersons] ADD CONSTRAINT [FK_SuppliersPersons_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[SuppliersPersons] ADD CONSTRAINT [FK_SuppliersPersons_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([ID])
GO
