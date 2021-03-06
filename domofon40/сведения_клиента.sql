
--declare 	@клиент uniqueidentifier ='6BB3DBB4-9D74-E511-BC93-0013465F2146'


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
прим varchar(50) default '',
порядок_вида int default 0,
порядок int default 0
);

insert into @MyTable (услуга, наимен, порядок_вида , порядок)
select услуги.услуга, услуги.наимен, виды_услуг.порядок, услуги.порядок
from услуги inner join виды_услуг
on услуги.вид_услуги=виды_услуг.вид_услуги ;

--order by виды_услуг.порядок, услуги.порядок ; неработает


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
where [@MyTable].услуга =a.услуга;

update @MyTable set договор_с =a.договор_с
from
(select услуга, договор_с = MAX(дата_с)
from подключения
where клиент=@клиент
group by услуга) as a
where [@MyTable].услуга =a.услуга;

update @MyTable set отключен =a.дата_с
from
(select услуга, дата_с = MAX(дата_с)
from отключения
where клиент=@клиент
group by услуга) as a
where [@MyTable].услуга =a.услуга;

update @MyTable set повторно =a.дата_с
from
(select услуга, дата_с = MAX(дата_с)
from повторы
where клиент=@клиент
group by услуга) as a
where [@MyTable].услуга =a.услуга;


update @MyTable set наш =1
from
(select услуга
from услуги_клиента
where клиент=@клиент) as a
where [@MyTable].услуга =a.услуга;

select * from @MyTable
order by порядок_вида, порядок;

