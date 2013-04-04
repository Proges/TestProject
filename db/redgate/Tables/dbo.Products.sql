CREATE TABLE [dbo].[Products]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Price] [int] NOT NULL,
[BrandID] [int] NOT NULL
)
ALTER TABLE [dbo].[Products] ADD
CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([ID])
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED  ([ID])
GO
