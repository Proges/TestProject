CREATE TABLE [dbo].[Cities]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[RegionID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[Cities] ADD CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Cities] ADD CONSTRAINT [FK_Cities_Regions] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Regions] ([ID])
GO
