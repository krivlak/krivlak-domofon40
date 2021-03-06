USE [domofon14]
GO
/****** Object:  StoredProcedure [dbo].[звонки_на_сотовый]    Script Date: 15.08.2014 21:09:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use domofon;

ALTER   procedure [dbo].[звонки_на_сотовый]
as
declare @MyTable table 
(
клиент  uniqueidentifier not null ,
услуга  uniqueidentifier not null,
год int not null default 0 ,
месяц int not null default 0 ,
долг_мес int default 0,
долг_руб int not null default 0,
договор_с datetime default null,
отключен datetime default null,
повтор datetime default null,
дата_звонка  datetime default null,
фио varchar(50) not null default '',
квартира int not null default 0,
квартира0 int not null default 0,
ввод int not null default 0,
телефон varchar(50) not null default '',
порядок_вида int not null default 0,
порядок_услуги int not null default 0,
наимен_услуги varchar(50) not null default '',
строка int not null default 0,
смс bit not null default 1,
наш bit not null default 0,
должник bit not null default 0,
прим varchar(50) not null default '',
прим0 varchar(50) not null default '',
id_сообщения  varchar(50) not null default '',
номер_дома int not null default 0,
корпус char(10) default '',
наимен_улицы varchar(50) not null default '',
звонок uniqueidentifier not null,
сотовый char(10) not null default ' ' ,
эл_почта varchar(50) not null default ' ',
разрешение  uniqueidentifier  null,
номер_разрешения int not null default 0,
дата_разрешения DateTime null
);

insert into @MyTable (клиент,услуга,звонок, дата_звонка)
select клиент , услуга, звонок,дата
from звонки ;

update @MyTable set фио =клиенты.фио, квартира =клиенты.квартира, 
ввод =клиенты.ввод, телефон =клиенты.телефон, прим0=клиенты.прим,
номер_дома = дома.номер, корпус =дома.корпус, наимен_улицы=улицы.наимен
from клиенты inner join дома
on клиенты.дом=дома.дом
inner join улицы
on дома.улица=улицы.улица
where [@MyTable].клиент=клиенты.клиент;

update @MyTable set прим = примечания.прим
from примечания
where [@MyTable].клиент=примечания.клиент
and [@MyTable].услуга=примечания.услуга;




declare @наш bit =0;
declare @долг int  =0;
declare @тек_год int = Year(getdate());
declare @тек_месяц int = Month(getdate());

select оплаты.клиент,оплачено.услуга,
 max(оплачено.год*100+оплачено.месяц) as gm,
  max(оплачено.год*12+оплачено.месяц) as gm12,
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
group by оплаты.клиент,оплачено.услуга;


update #temp set долг_мес= (@тек_год*12+@тек_месяц)-#temp.gm12-1;

update #temp set долг_мес=0
where долг_мес<0;

--update #temp set долг_мес= (@тек_год-ROUND(gm/100,0))*12+@тек_месяц-(gm-ROUND(gm/100,0)*100)-1;

update #temp set наш=1
from услуги_клиента
where услуги_клиента.клиент=#temp.клиент 
and услуги_клиента.услуга=#temp.услуга;



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

update @MyTable set год=ROUND(a.gm/100,0), месяц =a.gm-ROUND(a.gm/100,0)*100,
долг_мес=a.долг_мес, долг_руб=a.долг_руб
from #temp as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга;



--insert into @MyTable (клиент, услуга,год, месяц,долг_мес, долг_руб,наш)
--(
--   select клиент, 
--   услуга,
--    ROUND(gm/100,0),
--	 gm-ROUND(gm/100,0)*100,
--	 долг_мес,
--	долг_руб,
--	наш
--   from #temp
--   where наш=1
--   and долг_руб>0
----   order by порядок_вида, порядок_услуги
--) ; 

update @MyTable set порядок_вида=виды_услуг.порядок, порядок_услуги= услуги.порядок,
наимен_услуги= услуги.обозначение
from услуги inner join виды_услуг
on услуги.вид_услуги=виды_услуг.вид_услуги
where услуги.услуга=[@MyTable].услуга

--update @MyTable set наимен_услуги=услуга.обозначение
--from услуга
--where услуга.услуга=[@MyTable].услуга


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

select *
into #temp8
from разрешения
order by дата_с

update @MyTable set сотовый=a.телефон,
 эл_почта=a.эл_почта,
 разрешение =a.разрешение,
 дата_разрешения=a.дата_с,
 номер_разрешения=a.номер
from #temp8 as a
where a.клиент= [@MyTable].клиент

--select клиент, min(порядок_вида*100+порядок_услуги) as порядок
--into #temp7
--from @MyTable
--group by клиент

--update @MyTable  set строка =1
--from #temp7 as a
--where [@MyTable].порядок_вида*100+[@MyTable].порядок_услуги=a.порядок


--update @MyTable  set квартира0=клиент.квартира
--from клиент
--where клиент.клиент= [@MyTable].клиент;


--update @MyTable  set фио= клиент.фио, квартира=клиент.квартира, ввод=клиент.ввод, телефон=клиент.телефон
--from клиент
--where клиент.клиент= [@MyTable].клиент
--and [@MyTable].строка=1;



--select клиент, услуга , max(дата) as дата 
--into #temp6
--from звонки 
--group by клиент, услуга

--update @MyTable  set звонок=a.дата
--from #temp6 as a
--where a.клиент=[@MyTable].клиент
--and a.услуга=[@MyTable].услуга

--update @MyTable  set прим=a.прим
--from примечания as a
--where a.клиент=[@MyTable].клиент
--and a.услуга=[@MyTable].услуга

--update @MyTable  set прим0=a.прим
--from клиент as a
--where a.клиент=[@MyTable].клиент
--and [@MyTable].строка=1;


select * from @MyTable
order by дата_звонка 