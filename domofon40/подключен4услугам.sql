declare  @������ uniqueidentifier='B4218A51-76B5-4AF8-9EFC-54EC392182BE'

declare @MyTable table 
(
������ uniqueidentifier not null ,
������ varchar(50) not null default '',
��� int not null default 0 ,
����� int not null default 0 ,
���� int not null default 0 ,
���������� bit not null default 0,
�����_�� int not null default 0 ,
�� datetime null,
�������_� varchar(50) not null default '',
���� varchar(50) not null default '',
���� datetime  null ,
���� datetime  null ,
�������_����  int not null default 0,
�������_������  int not null default 0
);

insert into @MyTable (������, ������, �������_������, �������_����)
select ������.������,������.������, ������.�������, ����_�����.�������
from ������ inner join ����_�����
on ������.���_������ = ����_�����.���_������

update @MyTable set ����������=1
from ������_������� a
where a.������ =[@MyTable].������ 
and a.������=@������;



update @MyTable set ����=a.����
from ���������� a
where a.������ =[@MyTable].������ 
and a.������=@������;


IF OBJECT_ID(N'tempdb..#����������') IS NOT NULL
  DROP TABLE #����������

select ������ , max(����_�) as ����
into #����������
from ����������
where ������=@������
group by ������ ;

update @MyTable set ����=a.����
from #���������� a
where a.������ =[@MyTable].������ ;

IF OBJECT_ID(N'tempdb..#�������') IS NOT NULL
  DROP TABLE #�������

select ������ , max(����_�) as ����
into #�������
from �������
where ������=@������
group by ������ ;

update @MyTable set ����=a.����
from #������� a
where a.������ =[@MyTable].������ ;

IF OBJECT_ID(N'tempdb..#��������') IS NOT NULL
  DROP TABLE #��������

select ������ , max(����_�) as ����, max(�����_��) as �����_��
into #��������
from �����������
where ������=@������
group by ������ ;

update @MyTable set ��=a.����, �����_�� =a.�����_��
from #�������� a
where a.������ =[@MyTable].������ ;

--------  �� ��������

select * from @MyTable
order by �������_����, �������_������;
GO