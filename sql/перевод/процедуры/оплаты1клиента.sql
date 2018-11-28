USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[оплаты1клиента]    Script Date: 06.08.2016 20:32:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[оплаты1клиента]
(
@клиент uniqueidentifier ='9AEA7CBB-9D74-E511-BC93-0013465F2146'
)
as
declare @MyTable table 
(
оплата uniqueidentifier ,
номер int,
клиент  uniqueidentifier ,
дата datetime,
сотрудник  uniqueidentifier ,
адрес varchar(50) default '',
фио varchar(50) default '',
оплатить int  default 0,
менеджер  varchar(50) default ''
);

insert into @MyTable (оплата, номер, клиент, дата, сотрудник)
select оплата, номер, клиент, дата, сотрудник
from оплаты 
where клиент =@клиент;

update @MyTable set менеджер= сотрудники.фио
from сотрудники
where [@MyTable].сотрудник=сотрудники.сотрудник;

select клиенты.клиент,
 адрес =  rtrim(ltrim(улицы.наимен))+' '+rtrim(ltrim(str(дома.номер)))+' '+rtrim(ltrim(дома.корпус))+' кв. '+rtrim(ltrim(str(клиенты.квартира))),
 клиенты.фио
 into #temp0
 from клиенты inner join дома on клиенты.дом=дома.дом
inner join улицы on дома.улица=улицы.улица

update  @MyTable set адрес=a.адрес ,фио= a.фио
from #temp0 as a
where [@MyTable].клиент=a.клиент


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


select * from  @MyTable
order by дата, номер ;
GO


