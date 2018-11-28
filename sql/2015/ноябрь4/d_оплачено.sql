USE [domofon14]
GO
/****** Object:  Trigger [dbo].[d_оплачено]    Script Date: 24.11.2015 15:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  TRIGGER [dbo].[d_оплачено] 
   ON  [dbo].[оплачено]
   AFTER DELETE
AS 
BEGIN
 
           
     INSERT INTO [del_оплачено]
           ([оплата]
           ,[месяц]
           ,[год]
           ,[услуга]
           ,[сумма])
           (select оплата ,месяц, год, услуга,сумма from deleted )
END
