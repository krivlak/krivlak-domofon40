
--declare  @������ uniqueidentifier='B4218A51-76B5-4AF8-9EFC-54EC392182BE'

declare @MyTable table 
(
��� int not null default 0 ,
����� int not null default 0 ,
������ char(12) not null default '',
�����  int not null default 0
);

insert into @MyTable (��� , �����, ������)
select ����.���, ������.�����, ������.������
from ���� inner join ������
on ����.���>0;



update @MyTable set �����=a.���������
from ���� as a
where ������ =@������ 
and a.���=[@MyTable].���
and a.�����=[@MyTable].�����;


select * from @MyTable
GO


