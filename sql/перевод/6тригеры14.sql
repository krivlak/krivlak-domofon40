use domofon14
GO
--create trigger [dbo].[ti_виды_услуг]
--on [dbo].[виды_услуг]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from виды_услуг
--    update виды_услуг    set  порядок=@maxPor+1      from виды_услуг, inserted
--          where  виды_услуг.вид_услуги=inserted.вид_услуги
--          and inserted.порядок<1



--GO


--CREATE  trigger [dbo].[tu_виды_услуг]
--on [dbo].[виды_услуг]
--  for update
--  as

--if update (наимен)
--begin
--      declare @наимен varchar(50)
--      select  @наимен =наимен from inserted
--if rtrim(lTrim(@наимен))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction



--GO
--create trigger [dbo].[ti_поселки]
--on [dbo].[поселки]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from поселки
--    update поселки    set  порядок=@maxPor+1      from поселки, inserted
--          where  поселки.поселок=inserted.поселок
--          and inserted.порядок<1


--GO
--create trigger [dbo].[ti_работы]
--on [dbo].[работы]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from работы
--    update работы    set  порядок=@maxPor+1      from работы, inserted
--          where  работы.работа=inserted.работа
--          and inserted.порядок<1

--GO

--create trigger [dbo].[ti_сотрудники]
--on [dbo].[сотрудники]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from сотрудники
--    update сотрудники    set  порядок=@maxPor+1      from сотрудники, inserted
--          where  сотрудники.сотрудник=inserted.сотрудник
--          and inserted.порядок<1
--GO
--create trigger [dbo].[ti_улицы]
--on [dbo].[улицы]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from улицы
--    update улицы    set  порядок=@maxPor+1      from улицы, inserted
--          where  улицы.улица=inserted.улица
--          and inserted.порядок<1
--GO

--create trigger [dbo].[ti_услуги]
--on [dbo].[услуги]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from услуги
--    update услуги    set  порядок=@maxPor+1      from услуги, inserted
--          where  услуги.услуга=inserted.услуга
--          and inserted.порядок<1

--GO

--create trigger [dbo].[ti_филиалы]
--on [dbo].[филиалы]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from филиалы
--    update филиалы    set  порядок=@maxPor+1      from филиалы, inserted
--          where  филиалы.филиал=inserted.филиал
--          and inserted.порядок<1

--GO

--create trigger [dbo].[ti_фирмы]
--on [dbo].[фирмы]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(порядок) from фирмы
--    update фирмы    set  порядок=@maxPor+1      from фирмы, inserted
--          where  фирмы.фирма=inserted.фирма
--          and inserted.порядок<1

--GO


--CREATE  trigger [dbo].[tu_филиалы]
--on [dbo].[филиалы]
--  for update
--  as

--if update (наимен)
--begin
--      declare @наимен varchar(50)
--      select  @наимен =наимен from inserted
--if rtrim(lTrim(@наимен))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction



--GO


--CREATE  trigger [dbo].[tu_услуги]
--on [dbo].[услуги]
--  for update
--  as

--if update (наимен)
--begin
--      declare @наимен varchar(50)
--      select  @наимен =наимен from inserted
--if rtrim(lTrim(@наимен))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction

--GO



--CREATE  trigger [dbo].[tu_улицы]
--on [dbo].[улицы]
--  for update
--  as

--if update (наимен)
--begin
--      declare @наимен varchar(50)
--      select  @наимен =наимен from inserted
--if rtrim(lTrim(@наимен))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction
--GO


--CREATE  trigger [dbo].[tu_сотрудники]
--on [dbo].[сотрудники]
--  for update
--  as

--if update (фамилия)
--begin
--      declare @фамилия varchar(50)
--      select  @фамилия =фамилия from inserted
--if rtrim(lTrim(@фамилия))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction

--GO


--CREATE  trigger [dbo].[tu_работы]
--on [dbo].[работы]
--  for update
--  as

--if update (наимен)
--begin
--      declare @наимен varchar(50)
--      select  @наимен =наимен from inserted
--if rtrim(lTrim(@наимен))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction

--GO


--CREATE  trigger [dbo].[tu_поселки]
--on [dbo].[поселки]
--  for update
--  as

--if update (наимен)
--begin
--      declare @наимен varchar(50)
--      select  @наимен =наимен from inserted
--if rtrim(lTrim(@наимен))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction


--GO



CREATE  TRIGGER [dbo].[d_оплачено] 
   ON  [dbo].[оплачено]
   AFTER DELETE
AS 
BEGIN
 
           
     INSERT INTO [dbo].[del_оплачено]
           ([оплата]
           ,[месяц]
           ,[год]
           ,[услуга]
           ,[сумма])
           (select оплата ,месяц, год, услуга,сумма from deleted )
END
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



--create  trigger [dbo].[tu_клиенты]
--on [dbo].[клиенты]
--  for update
--  as

--if update (фамилия)
--begin
--      declare @фамилия varchar(30)
--      select  @фамилия =фамилия from inserted
--if rtrim(lTrim(@фамилия))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction



--GO


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
---------------
CREATE TRIGGER [dbo].[d_оплаты] 
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


