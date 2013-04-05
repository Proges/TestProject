CREATE TABLE [dbo].[Persons]
(
[ID] [int] NOT NULL,
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[SecondName] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Patronymic] [nvarchar] (100) COLLATE Ukrainian_CI_AS NULL,
[BirthDate] [date] NOT NULL,
[Email] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Phone] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[AddressID] [int] NOT NULL
)
ALTER TABLE [dbo].[Persons] ADD
CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([ID])
GO
ALTER TABLE [dbo].[Persons] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([ID])
GO
