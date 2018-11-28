use domofon14
GO
create trigger [dbo].[ti_повторы]
on [dbo].[повторы]
  for INSERT
 as
declare @клиент uniqueidentifier
declare @услуга  uniqueidentifier
 
select @клиент = inserted.клиент,
       @услуга = inserted.услуга
  from inserted

  

delete from услуги_клиента 
where услуга= @услуга and клиент =@клиент



insert into услуги_клиента (клиент, услуга)
values ( @клиент, @услуга)

GO

create  trigger [dbo].[ti_подключения]
on [dbo].[подключения]
  for INSERT
 as


declare @клиент uniqueidentifier
declare @услуга  uniqueidentifier
 
select @клиент = inserted.клиент,
       @услуга = inserted.услуга
  from inserted

delete from услуги_клиента
where услуга =@услуга and клиент=@клиент
  

insert into услуги_клиента (клиент, услуга)
values ( @клиент, @услуга)
GO


CREATE trigger [dbo].[ti_оплачено]
on [dbo].[оплачено]
  for INSERT
  as
 declare  @дом  uniqueidentifier
 
  select  @дом= клиенты.дом 
  from inserted inner join оплаты
  on оплаты.оплата=inserted.оплата
  inner join клиенты
  on оплаты.клиент =клиенты.клиент
  
    update дома    set  изменен=getdate()    
    where дома.дом =@дом
     
	 GO
	

create trigger [dbo].[ti_отключения]
on [dbo].[отключения]
  for INSERT
 as
declare @клиент uniqueidentifier
declare @услуга  uniqueidentifier
 
select @клиент = inserted.клиент,
       @услуга = inserted.услуга
  from inserted

  

delete from услуги_клиента 
where услуга= @услуга and клиент =@клиент


GO


