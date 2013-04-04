CREATE TABLE [dbo].[News]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Text] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[URL] [nvarchar] (300) COLLATE Ukrainian_CI_AS NULL,
[Date] [date] NOT NULL
)
GO
ALTER TABLE [dbo].[News] ADD CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED  ([ID])
GO
