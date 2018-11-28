USE [domofon14]
GO
/****** Object:  StoredProcedure [dbo].[сведения_клиента]    Script Date: 16.11.2015 18:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================

ALTER PROCEDURE [dbo].[сведения_клиента]
	
	@клиент uniqueidentifier ='6BB3DBB4-9D74-E511-BC93-0013465F2146'
AS
BEGIN

declare @MyTable table 
(
услуга  uniqueidentifier ,
год int  default 0 ,
месяц int  default 0 ,
договор_с datetime default null,
отключен datetime default null,
повторно datetime default null,
наимен varchar(50) default '',
наш bit default 0,
прим varchar(50) default ''
);

insert into @MyTable (услуга, наимен)
select услуги.услуга, услуги.наимен
from услуги inner join виды_услуг
on услуги.вид_услуги=виды_услуг.вид_услуги
order by виды_услуг.порядок, услуги.порядок ;


declare @целое int =0;

select оплачено.услуга,
 max(оплачено.год*100+оплачено.месяц) as gm,
 год =@целое,
 месяц =@целое
 into #temp
from оплачено inner join оплаты 
on оплачено.оплата=оплаты.оплата
where оплаты.клиент=@клиент
group by оплачено.услуга;



update #temp set год= ROUND(gm/100,0);

update #temp set месяц=gm-год*100;


update @MyTable set год =a.год, месяц =a.месяц
from #temp as a
where [@MyTable].услуга =a.услуга;


update @MyTable set прим =a.прим
from
(select услуга, прим
from примечания 
where клиент=@клиент) as a
where [@MyTable].услуга =a.услуга

update @MyTable set договор_с =a.договор_с
from
(select услуга, договор_с = MAX(дата_с)
from подключения
where клиент=@клиент
group by услуга) as a
where [@MyTable].услуга =a.услуга

update @MyTable set отключен =a.дата_с
from
(select услуга, дата_с = MAX(дата_с)
from отключения
where клиент=@клиент
group by услуга) as a
where [@MyTable].услуга =a.услуга

update @MyTable set повторно =a.дата_с
from
(select услуга, дата_с = MAX(дата_с)
from повторы
where клиент=@клиент
group by услуга) as a
where [@MyTable].услуга =a.услуга


update @MyTable set наш =1
from
(select услуга
from услуги_клиента
where клиент=@клиент) as a
where [@MyTable].услуга =a.услуга

select * from @MyTable

END
