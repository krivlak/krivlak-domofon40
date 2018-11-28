


declare @MyTable table 
(
клиент  uniqueidentifier ,
услуга  uniqueidentifier ,
год int  default 0 ,
месяц int  default 0 ,
долг_мес int default 0,
договор_с datetime default null,
отключен datetime default null,
повтор datetime default null,
звонок  datetime default null,
фио varchar(50) default '',
имя varchar(50) default '',
отчество varchar(50) default '',
квартира int default 0,
квартира0 int default 0,
ввод int default 0,
подъезд int default 0,
телефон varchar(50) default '',
порядок_услуги int default 0,
наимен_услуги varchar(50) default '',
строка int default 0,
наш bit default 0,
должник bit default 0,
прим varchar(50) default '',
прим0 varchar(50) default ''
);

declare @наш bit =0;
declare @долг int  =0;
declare @тек_год int = Year(getdate());
declare @тек_месяц int = Month(getdate());

select оплаты.клиент,оплачено.услуга,
 max(оплачено.год*100+оплачено.месяц) as gm,
 max(оплачено.год*12+оплачено.месяц) as gm12,
@наш as наш ,
@долг as долг_мес,
@долг as порядок_услуги
 into #temp
from оплачено inner join оплаты 
on оплачено.оплата=оплаты.оплата
inner join клиенты
on оплаты.клиент=клиенты.клиент
and клиенты.дом=@дом
inner join услуги
on оплачено.услуга=услуги.услуга
and услуги.вид_услуги=@вид
group by оплаты.клиент,оплачено.услуга;


update #temp set долг_мес= (@тек_год*12+@тек_месяц)-#temp.gm12-1

update #temp set долг_мес=0
where долг_мес<0


--update #temp set долг_мес= (@тек_год-ROUND(gm/100,0))*12+@тек_месяц-(gm-ROUND(gm/100,0)*100)-1;

update #temp set наш=1
from услуги_клиента
where услуги_клиента.клиент=#temp.клиент 
and услуги_клиента.услуга=#temp.услуга;

--update #temp set должник=1
--where долг_мес>1
--and наш=1;

--select #temp.клиент, #temp.услуга, sum(цены.стоимость) as долг
--into #temp2
--from цены inner join #temp
--on #temp.услуга=цены.услуга
--and #temp.долг_мес>1
--and (цены.год*100+цены.месяц)>#temp.gm
--and (цены.год*100+цены.месяц)<(@тек_год*100+@тек_месяц)
--group by #temp.клиент, #temp.услуга;

--update #temp set долг_руб=#temp2.долг
--from #temp2
--where #temp.услуга=#temp2.услуга
--and #temp.клиент=#temp2.клиент;

insert into @MyTable (клиент, услуга,наш)
(
   select услуги_клиента.клиент, 
   услуги_клиента.услуга,
    1 
   from услуги_клиента inner join клиенты
   on услуги_клиента.клиент=клиенты.клиент
   and клиенты.дом=@дом
   inner join услуги
   on услуги_клиента.услуга=услуги.услуга
   and услуги.вид_услуги=@вид
) ; 


--insert into @MyTable (клиент, услуга,год, месяц,долг_мес,наш)
--(
--   select клиент, 
--   услуга,
--    ROUND(gm/100,0),
--	 gm-ROUND(gm/100,0)*100,
--	 долг_мес,
--	наш
--   from #temp
--   --where наш=1
--) ; 

update @MyTable set год =  ROUND(#temp.gm/100,0), 
     месяц= #temp.gm-ROUND(#temp.gm/100,0)*100,
	долг_мес= #temp.долг_мес
	 from #temp
	 where #temp.клиент=[@MyTable].клиент
	 and #temp.услуга=[@MyTable].услуга

update @MyTable set должник=1
where долг_мес>2;
--and наш=1;

update @MyTable set  порядок_услуги= услуги.порядок,
наимен_услуги=услуги.обозначение
from услуги
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

--select клиент, min(порядок_услуги) as порядок
--into #temp7
--from @MyTable
--group by клиент

--update @MyTable  set строка =1
--from #temp7 as a
--where [@MyTable].порядок_услуги=a.порядок
--and [@MyTable].клиент= a.клиент;


update @MyTable  set квартира0=клиенты.квартира
from клиенты
where клиенты.клиент= [@MyTable].клиент;


update @MyTable  set фио= клиенты.фио,имя=клиенты.имя, отчество=клиенты.отчество, квартира=клиенты.квартира, ввод=клиенты.ввод, 
телефон=клиенты.телефон, подъезд =клиенты.подъезд, прим0= клиенты.прим
from клиенты
where клиенты.клиент= [@MyTable].клиент;
--and [@MyTable].строка=1;



--select *
--into #temp8
--from разрешения
--order by дата_с

--update @MyTable set сотовый=a.телефон,
-- эл_почта=a.эл_почта,
-- разрешение =a.разрешение,
-- дата_разрешения=a.дата_с,
-- номер_разрешения=a.номер
--from #temp8 as a
--where a.клиент= [@MyTable].клиент
--and [@MyTable].строка=1;

select клиент , max(дата) as дата 
into #temp6
from звонки 
group by клиент

update @MyTable  set звонок=a.дата
from #temp6 as a
where a.клиент=[@MyTable].клиент

update @MyTable  set прим=a.прим
from примечания as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга

update @MyTable  set прим0=a.прим
from клиенты as a
where a.клиент=[@MyTable].клиент
and [@MyTable].строка=1;


select * from @MyTable
where наш=1
order by квартира0,  порядок_услуги;

--GO


