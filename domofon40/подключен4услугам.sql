declare  @клиент uniqueidentifier='B4218A51-76B5-4AF8-9EFC-54EC392182BE'

declare @MyTable table 
(
услуга uniqueidentifier not null ,
наимен varchar(50) not null default '',
год int not null default 0 ,
месяц int not null default 0 ,
долг int not null default 0 ,
подключена bit not null default 0,
номер_пп int not null default 0 ,
от datetime null,
договор_с varchar(50) not null default '',
прим varchar(50) not null default '',
откл datetime  null ,
подк datetime  null ,
порядок_вида  int not null default 0,
порядок_услуги  int not null default 0
);

insert into @MyTable (услуга, наимен, порядок_услуги, порядок_вида)
select услуги.услуга,услуги.наимен, услуги.порядок, виды_услуг.порядок
from услуги inner join виды_услуг
on услуги.вид_услуги = виды_услуг.вид_услуги

update @MyTable set подключена=1
from услуги_клиента a
where a.услуга =[@MyTable].услуга 
and a.клиент=@клиент;



update @MyTable set прим=a.прим
from примечания a
where a.услуга =[@MyTable].услуга 
and a.клиент=@клиент;


IF OBJECT_ID(N'tempdb..#отключения') IS NOT NULL
  DROP TABLE #отключения

select услуга , max(дата_с) as дата
into #отключения
from отключения
where клиент=@клиент
group by услуга ;

update @MyTable set откл=a.дата
from #отключения a
where a.услуга =[@MyTable].услуга ;

IF OBJECT_ID(N'tempdb..#повторы') IS NOT NULL
  DROP TABLE #повторы

select услуга , max(дата_с) as дата
into #повторы
from повторы
where клиент=@клиент
group by услуга ;

update @MyTable set подк=a.дата
from #повторы a
where a.услуга =[@MyTable].услуга ;

IF OBJECT_ID(N'tempdb..#договора') IS NOT NULL
  DROP TABLE #договора

select услуга , max(дата_с) as дата, max(номер_пп) as номер_пп
into #договора
from подключения
where клиент=@клиент
group by услуга ;

update @MyTable set от=a.дата, номер_пп =a.номер_пп
from #договора a
where a.услуга =[@MyTable].услуга ;

--------  не доделано

select * from @MyTable
order by порядок_вида, порядок_услуги;
GO