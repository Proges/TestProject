CREATE TABLE [dbo].[BannersImages]
(
[BannerID] [int] NOT NULL,
[ImageID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[BannersImages] ADD CONSTRAINT [PK_BannersImages] PRIMARY KEY CLUSTERED  ([BannerID], [ImageID])
GO
ALTER TABLE [dbo].[BannersImages] ADD CONSTRAINT [FK_BannersImages_Banners] FOREIGN KEY ([BannerID]) REFERENCES [dbo].[Banners] ([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BannersImages] ADD CONSTRAINT [FK_BannersImages_Images] FOREIGN KEY ([ImageID]) REFERENCES [dbo].[Images] ([ID]) ON DELETE CASCADE
GO
