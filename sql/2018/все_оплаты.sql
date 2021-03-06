USE [domofon14]
GO
/****** Object:  StoredProcedure [dbo].[все_оплаты]    Script Date: 14.09.2018 14:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[все_оплаты]

as
declare @MyTable table 
(
оплата uniqueidentifier ,
номер int,
клиент  uniqueidentifier ,
дата datetime,
сотрудник  uniqueidentifier ,
вид_оплаты  uniqueidentifier ,
адрес varchar(50) default '',
фио varchar(50) default '',
оплатить int  default 0,
менеджер  varchar(50) default '',
наимен_вида  varchar(50) default ''
);

insert into @MyTable (оплата, номер, клиент, дата, сотрудник, вид_оплаты)
select оплата, номер, клиент, дата, сотрудник,вид_оплаты
from оплаты ;

update @MyTable set менеджер= сотрудники.фио
from сотрудники
where [@MyTable].сотрудник=сотрудники.сотрудник;

update @MyTable set наимен_вида= виды_оплат.наимен
from виды_оплат
where [@MyTable].вид_оплаты=виды_оплат.вид_оплаты;

select клиенты.клиент,
 адрес =  rtrim(ltrim(улицы.наимен))+' '+rtrim(ltrim(str(дома.номер)))+' '+rtrim(ltrim(дома.корпус))+' кв. '+rtrim(ltrim(str(клиенты.квартира))),
 клиенты.фио
 into #temp0
 from клиенты inner join дома on клиенты.дом=дома.дом
inner join улицы on дома.улица=улицы.улица

update  @MyTable set адрес=a.адрес ,фио= a.фио
from #temp0 as a
where [@MyTable].клиент=a.клиент

--update  @MyTable set адрес =  rtrim(ltrim(улицы.наимен))+' '+rtrim(ltrim(str(дома.номер)))+' '+rtrim(ltrim(дома.корпус))+' кв. '+rtrim(ltrim(str(клиенты.квартира))),
-- фио =клиенты.фио
--from клиенты inner join дома on клиенты.дом=дома.дом
--inner join улицы on дома.улица=улицы.улица
--where [@MyTable].клиент=клиенты.клиент ;
--and клиенты.ввод=0 ;


--update  @MyTable set адрес =  rtrim(ltrim(улицы.наимен))+'  '+rtrim(ltrim(str(дома.номер)))+' '+rtrim(ltrim(дома.корпус))+' кв. '+rtrim(ltrim(str(клиенты.квартира))) +' ввод '+rtrim(ltrim(str(клиенты.ввод))),
--фио =клиенты.фио
--from клиенты inner join дома on клиенты.дом=дома.дом
--inner join улицы on дома.улица=улицы.улица
--where [@MyTable].клиент=клиенты.клиент
--and клиенты.ввод >0 ;

update  @MyTable set адрес =  адрес+' ввод '+rtrim(ltrim(str(клиенты.ввод)))
from клиенты 
where [@MyTable].клиент=клиенты.клиент
and клиенты.ввод >0 ;

select оплата , SUM(сумма) as сумма
into #temp
from оплачено group by оплата 

update  @MyTable set оплатить = a.сумма
from #temp as a
where [@MyTable].оплата=a.оплата

select оплата , SUM(стоимость ) as сумма
into #temp2 
from опл_работы group by оплата 

update  @MyTable set оплатить = оплатить+a.сумма
from #temp2 as a
where [@MyTable].оплата=a.оплата

select оплата , SUM(сумма) as сумма
into #temp3
from возврат group by оплата 

update  @MyTable set оплатить = оплатить-a.сумма
from #temp3 as a
where [@MyTable].оплата=a.оплата


--update  @MyTable set оплатить = a.сумма
--from 
--(select оплата , SUM(сумма) as сумма
--from оплачено group by оплата ) as a
--where [@MyTable].оплата=a.оплата

--update  @MyTable set оплатить = sОплата.оплатить
--from sОплата
--where sОплата.оплата=[@MyTable].оплата ;

select * from  @MyTable
order by дата, номер ;
