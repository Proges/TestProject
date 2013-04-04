CREATE TABLE [dbo].[DeliveryTypes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE Ukrainian_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD CONSTRAINT [PK_DeliveryTypes] PRIMARY KEY CLUSTERED  ([ID])
GO
