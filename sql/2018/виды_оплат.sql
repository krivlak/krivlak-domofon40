USE [domofon14]
GO



CREATE TABLE [dbo].[����_�����](
	[���_������] [uniqueidentifier] NOT NULL DEFAULT (newid()) primary key,
	[������] [varchar](50) NOT NULL DEFAULT (' '),
	[�������] [int] NOT NULL DEFAULT ((0))
);

