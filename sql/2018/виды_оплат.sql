USE [domofon14]
GO



CREATE TABLE [dbo].[виды_оплат](
	[вид_оплаты] [uniqueidentifier] NOT NULL DEFAULT (newid()) primary key,
	[наимен] [varchar](50) NOT NULL DEFAULT (' '),
	[порядок] [int] NOT NULL DEFAULT ((0))
);

