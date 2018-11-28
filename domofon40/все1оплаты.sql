-- declare @сотрудник uniqueidentifier ='58C06D14-22DA-4090-BBF0-53B6BB492582'

declare @MyTable table 
(
оплата uniqueidentifier ,
номер int,
клиент  uniqueidentifier ,
дата datetime,
сотрудник  uniqueidentifier ,
вид_оплаты uniqueidentifier ,
адрес varchar(50) default '',
фио varchar(50) default '',
оплатить int  default 0,
менеджер  varchar(50) default '',
наимен_вида  varchar(50) default '',
телефон  varchar(50) default '',
прим0  varchar(50) default '',
звонок datetime null 
);

insert into @MyTable (оплата, номер, клиент, дата, сотрудник, вид_оплаты)
select оплата, номер, клиент, дата, сотрудник,вид_оплаты
from оплаты 
where сотрудник =@сотрудник;

update @MyTable set менеджер= сотрудники.фио
from сотрудники
where [@MyTable].сотрудник=сотрудники.сотрудник;

update @MyTable set наимен_вида= виды_оплат.наимен
from виды_оплат
where [@MyTable].вид_оплаты=виды_оплат.вид_оплаты;

select клиенты.клиент,
 адрес =  rtrim(ltrim(улицы.наимен))+' '+rtrim(ltrim(str(дома.номер)))+' '+rtrim(ltrim(дома.корпус))+' кв. '+rtrim(ltrim(str(клиенты.квартира))),
 клиенты.фио,
 клиенты.телефон,
 клиенты.прим
 into #temp0
 from клиенты inner join дома on клиенты.дом=дома.дом
inner join улицы on дома.улица=улицы.улица

update  @MyTable set адрес=a.адрес ,фио= a.фио, телефон =a.телефон,  прим0=a.прим
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


select оплата , SUM(сумма) as сумма
into #temp4
from воз_работы group by оплата 

update  @MyTable set оплатить = оплатить-a.сумма
from #temp4 as a
where [@MyTable].оплата=a.оплата


select клиент, последний =max(дата)
into #звонки
from звонки 
group by клиент;

update  @MyTable set звонок  = a.последний
from #звонки as a
where [@MyTable].клиент=a.клиент;


select * from  @MyTable
order by дата, номер ;
