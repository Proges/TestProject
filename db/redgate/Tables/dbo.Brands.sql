CREATE TABLE [dbo].[Brands]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[LogoID] [int] NULL
)
GO
ALTER TABLE [dbo].[Brands] ADD CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Brands] ADD CONSTRAINT [FK_Brands_Images] FOREIGN KEY ([LogoID]) REFERENCES [dbo].[Images] ([ID])
GO
