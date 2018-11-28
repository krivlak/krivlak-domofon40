
/****** Object:  StoredProcedure [dbo].[статистика1дата]    Script Date: 30.03.2015 21:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[статистика44]

as

declare @дата datetime

set @дата=getdate()

declare @MyTable table 
(
услуга  uniqueidentifier ,
наимен varchar(50),
договоров int default 0,
учтено int default 0,
плательщиков int default 0,
льгот int default 0,
отключено int default 0
);

insert into @MyTable (услуга , наимен)
select услуга, наимен 
from услуги;

--select * 
--into #temp0
--from подключения


select услуга, договоров =Count(клиент)
into #temp
from подключения
group by услуга;


update @MyTable set договоров = #temp.договоров
from #temp
where [@MyTable].услуга = #temp.услуга;


select услуга, галочек = Count(клиент)
into #галочки
from услуги_клиента
group by услуга;

update @MyTable set учтено  = #галочки.галочек
from #галочки
where [@MyTable].услуга = #галочки.услуга;


select оплачено.услуга ,оплаты.клиент
into #оплаты
from оплачено inner join оплаты
on оплаты.оплата=оплачено.оплата


select услуга, клиент, оплат=Count(клиент)
into #оплаты1
from #оплаты
group by клиент,услуга;

select услуга, плательщиков = Count(клиент)
into #оплаты2
from #оплаты1
group by услуга;

update @MyTable set плательщиков = #оплаты2.плательщиков
from #оплаты2
where [@MyTable].услуга = #оплаты2.услуга;


--select * 
--into #льготы0
--from льгота


select услуга , льгот =count(клиент)
into #льготы
from льготы
group by услуга;

update @MyTable set льгот  = #льготы.льгот
from #льготы
where [@MyTable].услуга = #льготы.услуга;

--- число отключеных
declare @отключеные table 
(
услуга  uniqueidentifier ,
клиент uniqueidentifier,
дата_от datetime,
дата_подк datetime default null,
отключен bit default 1
);

select * 
into #откл0
from отключения



select услуга, клиент, дата_от =Max(дата_с)
into #откл
from #откл0
group by услуга, клиент;

insert  @отключеные (услуга, клиент, дата_от)
select услуга, клиент, дата_от
from #откл;

select * 
into #повтор0
from повторы


select услуга, клиент, дата_подк =max(дата_с)
into #повтор
from #повтор0
group by услуга, клиент;



update @отключеные set дата_подк=#повтор.дата_подк
from #повтор
where [@отключеные].клиент=#повтор.клиент
and [@отключеные].услуга=#повтор.услуга

update @отключеные set отключен=0
where  дата_от<=дата_подк;


--select * from @отключеные;

select * 
into #повтор2
from @отключеные
where отключен=1;

select услуга, оключеных =Count(клиент)
into #повтор3
from  #повтор2
group by услуга;

update @MyTable set отключено  = #повтор3.оключеных
from #повтор3
where [@MyTable].услуга = #повтор3.услуга;


select * from @MyTable;