USE [domofon14]
GO
/****** Object:  Table [dbo].[виды_оплат]    Script Date: 13.09.2018 10:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[виды_оплат](
	[вид_оплаты] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[наимен] [varchar](50) NOT NULL DEFAULT (' '),
	[порядок] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[вид_оплаты] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[виды_оплат] ([вид_оплаты], [наимен], [порядок]) VALUES (N'3ac44089-9a8f-4c6a-9bce-5114cdd9f914', N'Банк', 3)
GO
INSERT [dbo].[виды_оплат] ([вид_оплаты], [наимен], [порядок]) VALUES (N'4e620413-ebf5-4d69-be40-5627850f5215', N'Наличными', 1)
GO
INSERT [dbo].[виды_оплат] ([вид_оплаты], [наимен], [порядок]) VALUES (N'70a88bef-c36b-4b82-a032-c743456fe2f2', N'Карточка', 2)
GO
