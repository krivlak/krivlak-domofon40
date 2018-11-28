USE [domofon14]
GO
/****** Object:  StoredProcedure [dbo].[заполнить_услуги]    Script Date: 12.10.2018 9:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[заполнить_услуги]
(
  @оплата uniqueidentifier='130E25FA-476B-E611-AA2B-4C001076112B'
)
as
declare @клиент uniqueidentifier;

declare @пусто varchar(50) =' ';

select @клиент =клиент 
from оплаты
where оплаты.оплата=@оплата;

declare @MyTable table 
(
услуга uniqueidentifier,
наимен varchar(50) default '',
месяцев int default 0,
сумма int default 0,
договор varchar(50) default ''
);


select оплачено.услуга, наимен = Max(услуги.наимен), месяцев= COUNT(оплачено.услуга), сумма =SUM(оплачено.сумма), договор =@пусто
into #оплачено
from оплачено inner join услуги
on  оплачено.услуга = услуги.услуга
and оплачено.оплата=@оплата
group by оплачено.услуга ;

select услуга , номер = MAX(номер_пп), договор =@пусто, дата_с= Max( дата_с)
into #договор
from подключения
where клиент =@клиент and номер_пп>0
group by услуга;


--begin try

   update #договор set договор = format(номер, '0')+' от '+ FORMAT( дата_с, 'dd.MM.yyyy' )
   where номер>0;

--end try
--begin catch
--     print 'ffffffff';
--end catch

update #оплачено set договор = a.договор
from #договор as a
where #оплачено.услуга=a.услуга;


insert into @MyTable (услуга, наимен, месяцев, сумма, договор)
select услуга, наимен, месяцев, сумма, договор
from #оплачено;

select опл_работы.работа, работы.наимен, сумма=опл_работы.стоимость, исполнитель = сотрудники.фио
into #работы
from опл_работы inner join работы
on  опл_работы.работа=работы.работа
and опл_работы.оплата=@оплата
inner join сотрудники 
on сотрудники.сотрудник = опл_работы.мастер
order by работы.порядок;

insert into @MyTable (услуга, наимен,  сумма, договор)
select работа, наимен,  сумма, исполнитель
from #работы;


select возврат.услуга, наимен =  @пусто, месяцев =COUNT(возврат.услуга) , сумма= - SUM(возврат.сумма)
into #возврат
from возврат 
where возврат.оплата = @оплата
group by возврат.услуга ;

update #возврат set наимен = 'Возврат '+услуги.наимен
from услуги 
where #возврат.услуга=услуги.услуга;

insert into @MyTable (услуга, наимен, месяцев,  сумма)
select услуга, наимен, месяцев, сумма
from #возврат ;

select воз_работы.работа, наимен='Возврат '+работы.наимен, сумма= - воз_работы.сумма
into #воз_работы
from воз_работы inner join работы
on воз_работы.работа=работы.работа 
and воз_работы.оплата = @оплата;


--update #воз_работы set наимен = 'Возврат '+работы.наимен
--from работы
--where #воз_работы.работа= работы.работа ;

insert into @MyTable (услуга, наимен, месяцев,  сумма)
select работа, наимен, 0, сумма
from #воз_работы ;

select * from @MyTable;