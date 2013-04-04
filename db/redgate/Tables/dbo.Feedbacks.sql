CREATE TABLE [dbo].[Feedbacks]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PersonID] [int] NOT NULL,
[Topic] [nchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Text] [nvarchar] (500) COLLATE Ukrainian_CI_AS NOT NULL,
[Date] [datetime] NOT NULL
)
ALTER TABLE [dbo].[Feedbacks] ADD
CONSTRAINT [FK_Feedbacks_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[Feedbacks] ADD CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED  ([ID])
GO
