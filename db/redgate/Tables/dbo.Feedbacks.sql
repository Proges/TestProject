CREATE TABLE [dbo].[Feedbacks]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[UserID] [int] NOT NULL,
[Topic] [nchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Text] [nvarchar] (500) COLLATE Ukrainian_CI_AS NOT NULL,
[Date] [datetime] NOT NULL
)
ALTER TABLE [dbo].[Feedbacks] ADD
CONSTRAINT [FK_Feedbacks_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])

GO
ALTER TABLE [dbo].[Feedbacks] ADD CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED  ([ID])
GO
