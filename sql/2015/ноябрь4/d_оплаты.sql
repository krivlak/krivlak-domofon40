USE [domofon14]
GO
/****** Object:  Trigger [dbo].[d_оплаты]    Script Date: 24.11.2015 15:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER TRIGGER [dbo].[d_оплаты] 
   ON  [dbo].[оплаты]
   AFTER DELETE
AS 
BEGIN
 
   
   INSERT INTO [del_оплаты]
           ([оплата]
           ,[номер]
           ,[клиент]
           ,[сотрудник]
           ,[дата])
           ( select  оплата ,номер  ,клиент ,сотрудник ,дата from deleted )
           
END
