--select a.фио ,оплат =
--(select  Count(оплата) from оплаты  where сотрудник = a.сотрудник)
--from сотрудники as a
--where a.кассир=1;

--select *
--into  newMez
-- from месяцы

--select сотрудники.сотрудник, сотрудники.фио, оплат = Count(оплаты.оплата)
--from сотрудники inner join оплаты
--on сотрудники.сотрудник =оплаты.сотрудник
--where сотрудники.кассир=1
--group by all сотрудники.сотрудник, сотрудники.фио;

--select сотрудники.сотрудник, сотрудники.фио, оплат = Count(оплаты.оплата)
--from сотрудники inner join оплаты
--on сотрудники.сотрудник =оплаты.сотрудник
--where сотрудники.кассир=1
--group by all сотрудники.сотрудник, сотрудники.фио
--having Count(оплаты.оплата) > -1
--order by фио;


--select сотрудник as код, фио as фамилия 
--from сотрудники
--union
--select работа, наимен
--from работы
--order by фамилия 

--select сотрудник as код, фио as фамилия 
--from сотрудники
--union all
--select сотрудник, фио
--from сотрудники
--order by фамилия 

--select сотрудник as код, фио as фамилия 
--from сотрудники
--except
--select сотрудник, фио
--from сотрудники
--order by фамилия ;

--select ntile(7000) over( order by дата) as dt, дата  from оплаты 
--order by dt;

--select count(*) from оплаты;

--select dense_rank() over( order by дата) as dt, дата  from оплаты 


with cte1 (страница, дата)
as 
(
select ntile(7000) over( order by дата) as страница, дата  from оплаты 
)

select * from cte1
where страница =1;