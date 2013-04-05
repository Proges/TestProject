CREATE TABLE [dbo].[News]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Text] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[URL] [nvarchar] (300) COLLATE Ukrainian_CI_AS NULL,
[Date] [date] NOT NULL,
[UserID] [int] NOT NULL
)
ALTER TABLE [dbo].[News] ADD
CONSTRAINT [FK_News_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[News] ADD CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED  ([ID])
GO
