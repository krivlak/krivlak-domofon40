create   procedure [dbo].[монтажники1вид]
(

  @вид uniqueidentifier
)
as
declare @MyTable table 
(
адрес varchar(100),
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
наимен_поселка varchar(50) default '',
порядок_поселка int default 0,
наимен_улицы varchar(50) default '',
номер_дома int default 0,
корпус varchar(50),
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
inner join услуги
on оплачено.услуга=услуги.услуга
and услуги.вид_услуги=@вид
group by оплаты.клиент,оплачено.услуга;


update #temp set долг_мес= (@тек_год*12+@тек_месяц)-#temp.gm12-1

update #temp set долг_мес=0
where долг_мес<0




update #temp set наш=1
from услуги_клиента
where услуги_клиента.клиент=#temp.клиент 
and услуги_клиента.услуга=#temp.услуга;



insert into @MyTable (клиент, услуга,наш)
(
   select услуги_клиента.клиент, 
   услуги_клиента.услуга,
    1 
   from услуги_клиента 
   inner join услуги
   on услуги_клиента.услуга=услуги.услуга
   and услуги.вид_услуги=@вид
) ; 




update @MyTable set год =  ROUND(#temp.gm/100,0), 
     месяц= #temp.gm-ROUND(#temp.gm/100,0)*100,
	долг_мес= #temp.долг_мес
	 from #temp
	 where #temp.клиент=[@MyTable].клиент
	 and #temp.услуга=[@MyTable].услуга

update @MyTable set должник=1
where долг_мес>1;


update @MyTable set  порядок_услуги= услуги.порядок,
наимен_услуги=услуги.обозначение
from услуги 
where услуги.услуга=[@MyTable].услуга



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
group by клиент, услуга;

update @MyTable  set повтор=a.дата_с
from #temp5 as a
where a.клиент=[@MyTable].клиент
and a.услуга=[@MyTable].услуга;



select клиенты.клиент, клиенты.фио, клиенты.прим, клиенты.телефон, клиенты.подъезд, клиенты.квартира,
дома.номер, дома.корпус, улицы.наимен as наимен_улицы, поселки.наимен as наимен_поселка, поселки.порядок as порядок_поселка,
клиенты.имя, клиенты.отчество
into #temp7
from клиенты inner join дома on клиенты.дом =дома.дом
inner join улицы on дома.улица=улицы.улица
inner join поселки on улицы.поселок=поселки.поселок;


update  @MyTable  set  фио= k.фио,  прим0 = k.прим, телефон=k.телефон , подъезд=k.подъезд,
квартира = k.квартира, номер_дома =k.номер, корпус=k.корпус, наимен_улицы= k.наимен_улицы,
наимен_поселка =k.наимен_поселка, порядок_поселка= k.порядок_поселка,
имя = k.имя, отчество =k.отчество
from #temp7 as k
where k.клиент= [@MyTable].клиент;

--update  @MyTable  set адрес = Rtrim(наимен_поселка) +' '+RTRIM(наимен_улицы)+' '
--+str( номер_дома)+ ' '+RTRIM(корпус)+ ' ввод '+STR(ввод)



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
where наш=1
order by порядок_поселка,наимен_улицы, номер_дома,корпус, квартира, ввод,  порядок_услуги;
