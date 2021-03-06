USE [domofon14]
GO
/****** Object:  StoredProcedure [dbo].[ввод_тарифов]    Script Date: 15.08.2014 21:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[ввод_тарифов]
(
  @услуга uniqueidentifier='063A923F-9FA7-E311-9649-4C001076112B'
)
as
declare @MyTable table 
(
год int not null default 0 ,
месяц int not null default 0 ,
наимен char(12) not null default '',
тариф  int not null default 0
);

insert into @MyTable (год , месяц, наимен)
select годы.год, месяцы.месяц, месяцы.наимен
from годы inner join месяцы
on годы.год>0;

--select год, месяц, стоимость
--into #temp
--from цены
--where услуга =@услуга;

update @MyTable set тариф=a.стоимость
from цены as a
where услуга =@услуга 
and a.год=[@MyTable].год
and a.месяц=[@MyTable].месяц;


select * from @MyTable