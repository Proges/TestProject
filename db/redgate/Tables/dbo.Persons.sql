CREATE TABLE [dbo].[Persons]
(
[ID] [int] NOT NULL,
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Login] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Password] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Email] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Phone] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[RoleID] [int] NOT NULL,
[RegistrationDate] [date] NOT NULL
)
GO
ALTER TABLE [dbo].[Persons] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Persons] ADD CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([ID])
GO
