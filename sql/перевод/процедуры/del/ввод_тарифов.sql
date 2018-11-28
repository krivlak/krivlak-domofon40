USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[ввод_тарифов]    Script Date: 06.08.2016 20:28:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ввод_тарифов]
(
  @услуга uniqueidentifier='063A923F-9FA7-E311-9649-4C001076112B'
)
as
declare @MyTable table 
(
год int not null default 0 ,
мес€ц int not null default 0 ,
наимен char(12) not null default '',
тариф  int not null default 0
);

insert into @MyTable (год , мес€ц, наимен)
select годы.год, мес€цы.мес€ц, мес€цы.наимен
from годы inner join мес€цы
on годы.год>0;

--select год, мес€ц, стоимость
--into #temp
--from цены
--where услуга =@услуга;

update @MyTable set тариф=a.стоимость
from цены as a
where услуга =@услуга 
and a.год=[@MyTable].год
and a.мес€ц=[@MyTable].мес€ц;


select * from @MyTable
GO


