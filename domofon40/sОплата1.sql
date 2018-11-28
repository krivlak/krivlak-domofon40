--declare @клиент uniqueidentifier;

declare @MyTable table 
(
оплата uniqueidentifier,
оплатить int default 0
);


insert into @MyTable (оплата) 
select оплата from оплаты 
where клиент =@клиент;

select оплаты.оплата , сумма =COALESCE(SUM(оплачено.сумма),0)
into #temp
from оплаты inner join оплачено
on оплаты.оплата = оплачено.оплата
and оплаты.клиент =@клиент
 GROUP BY dbo.оплаты.оплата;

update @MyTable set оплатить =a.сумма
from #temp as a
where [@MyTable].оплата= a.оплата ;

select оплаты.оплата , сумма =COALESCE(SUM(опл_работы.стоимость),0)
into #temp2
from оплаты inner join опл_работы
on оплаты.оплата = опл_работы.оплата
and оплаты.клиент =@клиент
 GROUP BY dbo.оплаты.оплата;

update @MyTable set оплатить =оплатить+a.сумма
from #temp2 as a
where [@MyTable].оплата= a.оплата ;


select оплаты.оплата , сумма =COALESCE(SUM(возврат.сумма),0)
into #temp3
from оплаты inner join возврат
on оплаты.оплата = возврат.оплата
and оплаты.клиент =@клиент
 GROUP BY dbo.оплаты.оплата;

update @MyTable set оплатить =оплатить-a.сумма
from #temp3 as a
where [@MyTable].оплата= a.оплата ;

select оплаты.оплата , сумма =COALESCE(SUM(воз_работы.сумма),0)
into #temp4
from оплаты inner join воз_работы
on оплаты.оплата = воз_работы.оплата
and оплаты.клиент =@клиент
 GROUP BY dbo.оплаты.оплата;

update @MyTable set оплатить= оплатить-a.сумма
from #temp4 as a
where [@MyTable].оплата= a.оплата ;

select * from  @MyTable;


--SELECT a.оплата, a.стоим1 + b.стоим2 - c.стоим3 AS оплатить
--FROM     (SELECT dbo.оплаты.оплата, COALESCE (SUM(dbo.оплачено.сумма), 0) AS стоим1
--                  FROM      dbo.оплаты LEFT OUTER JOIN
--                                    dbo.оплачено ON dbo.оплаты.оплата = dbo.оплачено.оплата
--                  GROUP BY dbo.оплаты.оплата) AS a INNER JOIN
--                      (SELECT оплаты_2.оплата, COALESCE (SUM(ROUND(dbo.опл_работы.стоимость, 0)), 0) AS стоим2
--                       FROM      dbo.оплаты AS оплаты_2 LEFT OUTER JOIN
--                                         dbo.опл_работы ON оплаты_2.оплата = dbo.опл_работы.оплата
--                       GROUP BY оплаты_2.оплата) AS b ON a.оплата = b.оплата INNER JOIN
--                      (SELECT оплаты_1.оплата, COALESCE (SUM(ROUND(dbo.возврат.сумма, 0)), 0) AS стоим3
--                       FROM      dbo.оплаты AS оплаты_1 LEFT OUTER JOIN
--                                         dbo.возврат ON оплаты_1.оплата = dbo.возврат.оплата
--                       GROUP BY оплаты_1.оплата) AS c ON a.оплата = c.оплата


