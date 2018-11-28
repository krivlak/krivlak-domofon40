
--declare  @услуга uniqueidentifier='B4218A51-76B5-4AF8-9EFC-54EC392182BE'

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



update @MyTable set тариф=a.стоимость
from цены as a
where услуга =@услуга 
and a.год=[@MyTable].год
and a.мес€ц=[@MyTable].мес€ц;


select * from @MyTable
GO


