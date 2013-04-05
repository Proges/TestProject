CREATE TABLE [dbo].[Banners]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[SupplierID] [int] NOT NULL
)
ALTER TABLE [dbo].[Banners] ADD
CONSTRAINT [FK_Banners_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[Banners] ADD CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED  ([ID])
GO
