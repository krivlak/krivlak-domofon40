USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[задание1монтажникам]    Script Date: 06.08.2016 20:30:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[задание1монтажникам]
(

  @дом uniqueidentifier='1ECCF139-9FA7-E311-9649-4C001076112B',
  @вид_услуги uniqueidentifier='9ECBF139-9FA7-E311-9649-4C001076112B'
)
as
declare @MyTable table 
(
клиент  uniqueidentifier not null,
услуга  uniqueidentifier not null,
год int  not null default 0 ,
месяц int  not null default 0 ,
долг_мес  int not null default 0,
долг_руб int not null default 0,
договор_с datetime null default null,
отключен datetime  null default null,
повтор datetime null default null,
последний_звонок   datetime null default null,
фио varchar(50) not null default '',
подъезд int not null default 0,
квартира int not null default 0,
квартира0 int not null default 0,
ввод int not null default 0,
телефон varchar(50) not null default '',
порядок_услуги int not null default 0,
наимен_услуги varchar(50) not null default '',
строка int not null default 0,
отключить bit not null default 0,
подключить bit not null default 0,
повторно bit not null default 0,
наш bit not null default 0,
должник bit not null default 0,
прим varchar(50) not null default '',
прим0 varchar(50) not null default ''
);


select клиенты.*, услуги.услуга, услуги.обозначение, услуги.порядок as порядок_услуги
into #temp0
from клиенты inner join услуги
on клиенты.дом=@дом
and услуги.вид_услуги=@вид_услуги
order by клиенты.квартира, клиенты.ввод, услуги.порядок

insert into @MyTable (клиент, услуга,фио,подъезд,квартира, квартира0,ввод,телефон, наимен_услуги, прим0, порядок_услуги)
select клиент, услуга,фио,подъезд,квартира, квартира,ввод,телефон, обозначение, прим, порядок_услуги
from #temp0
----------------------
declare @наш bit =0;
declare @долг int  =0;
declare @тек_год int = Year(getdate());
declare @тек_месяц int = Month(getdate());

select оплаты.клиент,оплачено.услуга,
 max(оплачено.год*100+оплачено.месяц) as gm,
@долг as год,
@долг as месяц,
@наш as наш ,
@долг as долг_мес,
@долг as долг_руб,
@долг as порядок_вида,
@долг as порядок_услуги
 into #temp
from оплачено inner join оплаты 
on оплачено.оплата=оплаты.оплата
inner join клиенты
on оплаты.клиент=клиенты.клиент
and клиенты.дом=@дом
group by оплаты.клиент,оплачено.услуга;


--update #temp set долг_мес= (@тек_год*100+@тек_месяц)-#temp.gm-1

update #temp set долг_мес= (@тек_год-ROUND(gm/100,0))*12+@тек_месяц-(gm-ROUND(gm/100,0)*100)-1,
год =ROUND(gm/100,0), месяц =gm-ROUND(gm/100,0)*100;

--update #temp set наш=1
--from услуги_клиента
--where услуги_клиента.клиент=#temp.клиент 
--and услуги_клиента.услуга=#temp.услуга;



select #temp.клиент, #temp.услуга, sum(цены.стоимость) as долг
into #temp2
from цены inner join #temp
on #temp.услуга=цены.услуга
and #temp.долг_мес>1
and (цены.год*100+цены.месяц)>#temp.gm
and (цены.год*100+цены.месяц)<(@тек_год*100+@тек_месяц)
group by #temp.клиент, #temp.услуга;

update #temp set долг_руб=#temp2.долг
from #temp2
where #temp.услуга=#temp2.услуга
and #temp.клиент=#temp2.клиент;

update @MyTable set год=a.год, месяц=a.месяц ,долг_мес=a.долг_мес,долг_руб=a.долг_руб
from #temp as a
where [@MyTable].клиент=a.клиент
and [@MyTable].услуга=a.услуга

update @MyTable  set наш=1
from услуги_клиента
where услуги_клиента.клиент=[@MyTable].клиент 
and услуги_клиента.услуга=[@MyTable].услуга;

select клиент, услуга, max(дата_с) as дата_с
into #temp3
from подключения
group by клиент, услуга

update @MyTable  set договор_с=a.дата_с
from #temp3 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга

select клиент, услуга, max(дата_с) as дата_с
into #temp4
from отключения
group by клиент, услуга

update @MyTable  set отключен=a.дата_с
from #temp4 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга

select клиент, услуга, max(дата_с) as дата_с
into #temp5
from повторы
group by клиент, услуга

update @MyTable  set повтор=a.дата_с
from #temp5 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга


update @MyTable  set прим=a.прим
from примечания as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга

--------------

select * from @MyTable
order by квартира, ввод

GO


