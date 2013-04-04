CREATE TABLE [dbo].[Banners]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ProducerID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[Banners] ADD CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED  ([ID])
GO
