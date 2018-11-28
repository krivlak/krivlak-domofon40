

CREATE TABLE [dbo].[разрешения](
	[разрешение] [uniqueidentifier] NOT NULL,
	[клиент] [uniqueidentifier] NOT NULL,
	[дата_с] [datetime] NOT NULL,
	[номер] [int] NOT NULL,
	[дата_по] [datetime] NULL,
	[телефон] [char](10) NOT NULL,
	[эл_почта] [varchar](50) NOT NULL,
 CONSTRAINT [PK_разрешения] PRIMARY KEY CLUSTERED 
(
	[разрешение] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[разрешения] ADD  CONSTRAINT [DF_разрешения_дата]  DEFAULT (getdate()) FOR [дата_с]
GO

ALTER TABLE [dbo].[разрешения] ADD  CONSTRAINT [DF_разрешения_номер]  DEFAULT ((0)) FOR [номер]
GO

ALTER TABLE [dbo].[разрешения] ADD  CONSTRAINT [DF_разрешения_телефон]  DEFAULT (' ') FOR [телефон]
GO

ALTER TABLE [dbo].[разрешения] ADD  CONSTRAINT [DF_разрешения_эл_почта]  DEFAULT (' ') FOR [эл_почта]
GO

ALTER TABLE [dbo].[разрешения]  WITH CHECK ADD  CONSTRAINT [FK_разрешения_клиенты] FOREIGN KEY([клиент])
REFERENCES [dbo].[клиенты] ([клиент])
GO

ALTER TABLE [dbo].[разрешения] CHECK CONSTRAINT [FK_разрешения_клиенты]
GO


