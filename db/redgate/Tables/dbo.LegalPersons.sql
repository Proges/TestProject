CREATE TABLE [dbo].[LegalPersons]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PersonID] [int] NOT NULL,
[OrganizationName] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL,
[Fax] [nvarchar] (50) COLLATE Ukrainian_CI_AS NULL,
[TIN] [int] NOT NULL,
[RCR] [int] NOT NULL,
[LegalAddress] [nvarchar] (200) COLLATE Ukrainian_CI_AS NOT NULL,
[NCEO] [int] NULL,
[UCSE] [int] NULL,
[Account] [int] NULL,
[CorespondentAccount] [nvarchar] (100) COLLATE Ukrainian_CI_AS NULL,
[BIC] [nvarchar] (100) COLLATE Ukrainian_CI_AS NULL
)
ALTER TABLE [dbo].[LegalPersons] ADD
CONSTRAINT [FK_LegalPersons_Persons] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[LegalPersons] ADD CONSTRAINT [PK_LegalPersons] PRIMARY KEY CLUSTERED  ([ID])
GO
