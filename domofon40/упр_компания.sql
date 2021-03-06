
--declare  @вид_услуги uniqueidentifier ='93933784-333E-4194-BCFE-72E1E6358E75';
--declare   @дом uniqueidentifier='1352ba38-42fc-4462-958a-48afbd0a60ef';
--declare   @год int = 2018;
-- declare  @месяц int = 9;
--declare   @длина_месяца int =30


declare @год100месяц int = @год*100+@месяц;


declare @MyTable table   
(
клиент  uniqueidentifier ,
услуга  uniqueidentifier ,
договор_с datetime default null,
отключен datetime default null,
повтор datetime default null,
льгота_с  datetime default null,
фио varchar(50) default '',
квартира int default 0,
ввод int default 0,
подъезд int default 0,
телефон varchar(50) default '',
порядок_услуги int default 0,
наимен_услуги varchar(50) default '',
наш bit default 0,
прим varchar(50) default '',
прим0 varchar(50) default '',
дней int default 0,
тариф  int default 0,
уплатил  int default 0,
карта varchar(60)  default '',
дней0 int default 0,
виден bit default 0
);




select клиенты.клиент, клиенты.фио, клиенты.квартира,клиенты.ввод, клиенты.подъезд,клиенты.прим as прим0,клиенты.телефон,
услуги.услуга, услуги.наимен as наимен_услуги, услуги.порядок as порядок_услуги
 into #temp
from клиенты inner join услуги
on услуги.вид_услуги=@вид_услуги
and клиенты.дом=@дом
order by клиенты.квартира,клиенты.ввод, порядок_услуги;


insert into @MyTable (клиент, услуга ,фио, квартира,ввод,подъезд,телефон, порядок_услуги,наимен_услуги,прим0 )
( 
  select клиент, услуга,фио, квартира,ввод,подъезд,телефон,порядок_услуги,наимен_услуги,прим0
   from #temp
  ) ;


   update @MyTable set наш =1, виден=1
   from услуги_клиента
   where [@MyTable].клиент=услуги_клиента.клиент
   and [@MyTable].услуга=услуги_клиента.услуга;
   -- еслиотключили в середине месяца...

    select оплаты.клиент, оплачено.услуга
	into #оплаты
	from оплаты inner join оплачено 
	on оплаты.оплата=оплачено.оплата;

	 update @MyTable set  виден=1
	 from #оплаты
	 where [@MyTable].клиент=#оплаты.клиент
   and [@MyTable].услуга=#оплаты.услуга;

select оплаты.клиент  , оплачено.услуга, оплачено.сумма 
	into #уплатил
	from оплаты inner join оплачено 
	on оплаты.оплата=оплачено.оплата
    inner join клиенты
    on клиенты.клиент=оплаты.клиент
    and клиенты.дом =@дом 
    where оплачено.месяц=@месяц
    and оплачено.год =@год;

update @MyTable set  уплатил =#уплатил.сумма
	 from #уплатил
	 where [@MyTable].клиент=#уплатил.клиент
   and [@MyTable].услуга=#уплатил.услуга;


   --delete from @MyTable
   --where наш=0;

  select клиент , услуга , max(дата_с) as договор_с
  into #подключения
  from подключения
  where YEAR(дата_с)*100+MONTH(дата_с) <=@год100месяц
 group by клиент, услуга;


 update @MyTable set договор_с=#подключения.договор_с, виден =1
 from #подключения
 where #подключения.клиент=[@MyTable].клиент
 and #подключения.услуга=[@MyTable].услуга;


  select клиент , услуга , max(дата_с) as отключен
  into #отключения
  from отключения
  where YEAR(дата_с)*100+MONTH(дата_с) <=@год100месяц
 group by клиент, услуга;


 update @MyTable set отключен =#отключения.отключен, виден  =1
 from #отключения
 where #отключения.клиент=[@MyTable].клиент
 and #отключения.услуга=[@MyTable].услуга;


 select клиент , услуга , max(дата_с) as повтор
  into #повторы
  from повторы
  where YEAR(дата_с)*100+MONTH(дата_с) <=@год100месяц
 group by клиент, услуга;


 update @MyTable set повтор = #повторы.повтор, виден  =1
 from  #повторы
 where  #повторы.клиент=[@MyTable].клиент
 and  #повторы.услуга=[@MyTable].услуга;

 select клиент , услуга , max(дата_с) as льгота
  into #льготы
  from льготы
  where YEAR(дата_с)*100+MONTH(дата_с) <=@год100месяц
 group by клиент, услуга;


 update @MyTable set льгота_с = #льготы.льгота, виден  =1
 from  #льготы 
 where  #льготы.клиент=[@MyTable].клиент
 and  #льготы.услуга=[@MyTable].услуга;

 update @MyTable set прим=a.прим
 from примечания as a
 where  a.клиент=[@MyTable].клиент
 and  a.услуга=[@MyTable].услуга;

 -- надо бы для всех
  update @MyTable set дней =@длина_месяца
  where наш=1 ;

 
 update @MyTable set дней =a.дней
 from раб_дней as a
  where  a.клиент=[@MyTable].клиент
 and  a.услуга=[@MyTable].услуга
  and  a.год= @год
 and  a.месяц=@месяц;


update @MyTable set тариф =a.стоимость
from цены as a
 where   a.услуга=[@MyTable].услуга
  and  a.год= @год
 and  a.месяц=@месяц;

 update @MyTable set повтор= null 
 where повтор < отключен ;


  select * from @MyTable
  where виден=1
  order by квартира, ввод, порядок_услуги;

  




