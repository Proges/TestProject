CREATE TABLE [dbo].[Users]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Login] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Password] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[RoleID] [int] NOT NULL,
[PersonID] [int] NOT NULL,
[RegistrationDate] [date] NOT NULL
)
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([ID])
GO
