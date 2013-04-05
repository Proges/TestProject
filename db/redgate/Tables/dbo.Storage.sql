CREATE TABLE [dbo].[Storage]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ProductID] [int] NOT NULL,
[UserID] [int] NOT NULL,
[Debit] [int] NULL,
[Credit] [int] NULL,
[Date] [datetime] NOT NULL
)
ALTER TABLE [dbo].[Storage] ADD
CONSTRAINT [FK_Storage_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Storage] ADD CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Storage] ADD CONSTRAINT [FK_Storage_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
GO
