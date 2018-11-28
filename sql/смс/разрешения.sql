

CREATE TABLE [dbo].[����������](
	[����������] [uniqueidentifier] NOT NULL,
	[������] [uniqueidentifier] NOT NULL,
	[����_�] [datetime] NOT NULL,
	[�����] [int] NOT NULL,
	[����_��] [datetime] NULL,
	[�������] [char](10) NOT NULL,
	[��_�����] [varchar](50) NOT NULL,
 CONSTRAINT [PK_����������] PRIMARY KEY CLUSTERED 
(
	[����������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[����������] ADD  CONSTRAINT [DF_����������_����]  DEFAULT (getdate()) FOR [����_�]
GO

ALTER TABLE [dbo].[����������] ADD  CONSTRAINT [DF_����������_�����]  DEFAULT ((0)) FOR [�����]
GO

ALTER TABLE [dbo].[����������] ADD  CONSTRAINT [DF_����������_�������]  DEFAULT (' ') FOR [�������]
GO

ALTER TABLE [dbo].[����������] ADD  CONSTRAINT [DF_����������_��_�����]  DEFAULT (' ') FOR [��_�����]
GO

ALTER TABLE [dbo].[����������]  WITH CHECK ADD  CONSTRAINT [FK_����������_�������] FOREIGN KEY([������])
REFERENCES [dbo].[�������] ([������])
GO

ALTER TABLE [dbo].[����������] CHECK CONSTRAINT [FK_����������_�������]
GO


