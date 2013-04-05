CREATE TABLE [dbo].[Addresses]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[CityID] [int] NOT NULL,
[Street] [nvarchar] (200) COLLATE Ukrainian_CI_AS NOT NULL,
[House] [nvarchar] (50) COLLATE Ukrainian_CI_AS NOT NULL,
[Housing] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[Building] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[Porch] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[IntercomeCode] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[Floor] [int] NULL,
[IsOffice] [bit] NULL
)
ALTER TABLE [dbo].[Addresses] ADD
CONSTRAINT [FK_Addresses_Cities] FOREIGN KEY ([CityID]) REFERENCES [dbo].[Cities] ([ID])

GO
ALTER TABLE [dbo].[Addresses] ADD CONSTRAINT [PK_Individuals] PRIMARY KEY CLUSTERED  ([ID])
GO
