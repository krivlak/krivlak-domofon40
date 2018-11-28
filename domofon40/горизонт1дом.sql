--declare @дом uniqueidentifier='C1EFE550-E716-4ED1-973D-68877615B1B9';

declare @MyTable table 
(
клиент  uniqueidentifier ,
вид_услуги  uniqueidentifier ,
услуга  uniqueidentifier ,
mГод int  default 0 ,
mМесяц int  default 0 ,
долг_мес int default 0,
mПодключено datetime default null,
mОтключено datetime default null,
mПереключено datetime default null,
mПовторно datetime default null,
звонок  datetime default null,
фио varchar(50) default '',
имя varchar(50) default '',
отчество varchar(50) default '',
квартира int default 0,
квартира0 int default 0,
ввод int default 0,
подъезд int default 0,
телефон varchar(50) default '',
порядок_вида int default 0,
порядок_услуги int default 0,
наимен_услуги varchar(50) default '',
строка int default 0,
наш bit default 0,
виден bit default 0,
должник bit default 0,
прим varchar(50) default '',
прим0 varchar(50) default ''
);

declare @наш bit =0;
declare @долг int  =0;
declare @тек_год int = Year(getdate());
declare @тек_месяц int = Month(getdate());

select клиенты.клиент, клиенты.фио, клиенты.имя, клиенты.отчество, клиенты.прим, клиенты.квартира, клиенты.ввод,клиенты.телефон,
услуги.услуга,услуги.обозначение,услуги.вид_услуги,виды_услуг.порядок as порядок_вида, услуги.порядок as порядок_услуги
into #клиенты
from клиенты   inner join услуги 
on клиенты.дом =@дом
inner join виды_услуг
on виды_услуг.вид_услуги =услуги.вид_услуги
order by клиенты.квартира, клиенты.ввод, виды_услуг.порядок, услуги.порядок;


insert into @MyTable (клиент, фио, имя, отчество, прим0, квартира, ввод,телефон,услуга,наимен_услуги, вид_услуги, порядок_вида, порядок_услуги)
              select  клиент, фио, имя, отчество, прим,  квартира, ввод,телефон,услуга,обозначение, вид_услуги, порядок_вида, порядок_услуги
from #клиенты;

update @MyTable set наш=1, виден=1
from услуги_клиента
where услуги_клиента.клиент=[@MyTable].клиент 
and услуги_клиента.услуга=[@MyTable].услуга;

update @MyTable set  виден=1
from оплачено inner join  оплаты
on оплачено.оплата=оплаты.оплата
where [@MyTable].услуга=оплачено.услуга
and [@MyTable].клиент=оплаты.клиент ;


select оплаты.клиент,оплачено.услуга,
 max(оплачено.год*100+оплачено.месяц) as gm,
 max(оплачено.год*12+оплачено.месяц) as gm12,
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
group by оплаты.клиент,оплачено.услуга;


update #temp set долг_мес= (@тек_год*12+@тек_месяц)-#temp.gm12-1

update #temp set долг_мес=0
where долг_мес<0

update @MyTable set mГод =  ROUND(#temp.gm/100,0), 
     mМесяц= #temp.gm-ROUND(#temp.gm/100,0)*100,
	долг_мес= #temp.долг_мес
	 from #temp
	 where #temp.клиент=[@MyTable].клиент
	 and #temp.услуга=[@MyTable].услуга

update @MyTable set должник=1
where долг_мес>2;

select клиент, услуга, max(дата_с) as дата_с
into #temp3
from подключения
group by клиент, услуга;

update @MyTable  set mПодключено=a.дата_с
from #temp3 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга;

select подключения.клиент, подключения.услуга,услуги.вид_услуги, max(дата_с) as дата_с
into #перекл
from подключения inner join услуги
on подключения.услуга=услуги.услуга
group by подключения.клиент,подключения.услуга, услуги.вид_услуги;

update @MyTable  set mПереключено=a.дата_с
from #перекл as a
where a.клиент=[@MyTable].клиент
and a.услуга<>[@MyTable].услуга
and a.вид_услуги=[@MyTable].вид_услуги;

select клиент, услуга, max(дата_с) as дата_с
into #temp4
from отключения
group by клиент, услуга;

update @MyTable  set mОтключено=a.дата_с
from #temp4 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга;



select клиент, услуга, max(дата_с) as дата_с
into #temp5
from повторы
group by клиент, услуга;

update @MyTable  set mПовторно=a.дата_с
from #temp5 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга;

update @MyTable  set mПовторно=null 
where mПовторно  < mОтключено ;

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

select * from @MyTable
where виден=1
order by квартира, ввод, порядок_вида, порядок_услуги ;