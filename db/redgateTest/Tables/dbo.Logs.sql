CREATE TABLE [dbo].[Logs]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Date] [datetime] NOT NULL,
[Location] [nvarchar] (200) COLLATE Ukrainian_CI_AS NOT NULL,
[Type] [nvarchar] (50) COLLATE Ukrainian_CI_AS NOT NULL,
[Message] [nvarchar] (300) COLLATE Ukrainian_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Logs] ADD CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED  ([ID])
GO
