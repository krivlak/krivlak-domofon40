--declare @��� uniqueidentifier='C1EFE550-E716-4ED1-973D-68877615B1B9';

declare @MyTable table 
(
������  uniqueidentifier ,
���_������  uniqueidentifier ,
������  uniqueidentifier ,
m��� int  default 0 ,
m����� int  default 0 ,
����_��� int default 0,
m���������� datetime default null,
m��������� datetime default null,
m����������� datetime default null,
m�������� datetime default null,
������  datetime default null,
��� varchar(50) default '',
��� varchar(50) default '',
�������� varchar(50) default '',
�������� int default 0,
��������0 int default 0,
���� int default 0,
������� int default 0,
������� varchar(50) default '',
�������_���� int default 0,
�������_������ int default 0,
������_������ varchar(50) default '',
������ int default 0,
��� bit default 0,
����� bit default 0,
������� bit default 0,
���� varchar(50) default '',
����0 varchar(50) default ''
);

declare @��� bit =0;
declare @���� int  =0;
declare @���_��� int = Year(getdate());
declare @���_����� int = Month(getdate());

select �������.������, �������.���, �������.���, �������.��������, �������.����, �������.��������, �������.����,�������.�������,
������.������,������.�����������,������.���_������,����_�����.������� as �������_����, ������.������� as �������_������
into #�������
from �������   inner join ������ 
on �������.��� =@���
inner join ����_�����
on ����_�����.���_������ =������.���_������
order by �������.��������, �������.����, ����_�����.�������, ������.�������;


insert into @MyTable (������, ���, ���, ��������, ����0, ��������, ����,�������,������,������_������, ���_������, �������_����, �������_������)
              select  ������, ���, ���, ��������, ����,  ��������, ����,�������,������,�����������, ���_������, �������_����, �������_������
from #�������;

update @MyTable set ���=1, �����=1
from ������_�������
where ������_�������.������=[@MyTable].������ 
and ������_�������.������=[@MyTable].������;

update @MyTable set  �����=1
from �������� inner join  ������
on ��������.������=������.������
where [@MyTable].������=��������.������
and [@MyTable].������=������.������ ;


select ������.������,��������.������,
 max(��������.���*100+��������.�����) as gm,
 max(��������.���*12+��������.�����) as gm12,
@���� as ����_���,
@���� as �������_������
 into #temp
from �������� inner join ������ 
on ��������.������=������.������
inner join �������
on ������.������=�������.������
and �������.���=@���
inner join ������
on ��������.������=������.������
group by ������.������,��������.������;


update #temp set ����_���= (@���_���*12+@���_�����)-#temp.gm12-1

update #temp set ����_���=0
where ����_���<0

update @MyTable set m��� =  ROUND(#temp.gm/100,0), 
     m�����= #temp.gm-ROUND(#temp.gm/100,0)*100,
	����_���= #temp.����_���
	 from #temp
	 where #temp.������=[@MyTable].������
	 and #temp.������=[@MyTable].������

update @MyTable set �������=1
where ����_���>2;

select ������, ������, max(����_�) as ����_�
into #temp3
from �����������
group by ������, ������;

update @MyTable  set m����������=a.����_�
from #temp3 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������;

select �����������.������, �����������.������,������.���_������, max(����_�) as ����_�
into #������
from ����������� inner join ������
on �����������.������=������.������
group by �����������.������,�����������.������, ������.���_������;

update @MyTable  set m�����������=a.����_�
from #������ as a
where a.������=[@MyTable].������
and a.������<>[@MyTable].������
and a.���_������=[@MyTable].���_������;

select ������, ������, max(����_�) as ����_�
into #temp4
from ����������
group by ������, ������;

update @MyTable  set m���������=a.����_�
from #temp4 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������;



select ������, ������, max(����_�) as ����_�
into #temp5
from �������
group by ������, ������;

update @MyTable  set m��������=a.����_�
from #temp5 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������;

update @MyTable  set m��������=null 
where m��������  < m��������� ;

select ������ , max(����) as ���� 
into #temp6
from ������ 
group by ������

update @MyTable  set ������=a.����
from #temp6 as a
where a.������=[@MyTable].������

update @MyTable  set ����=a.����
from ���������� as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������

select * from @MyTable
where �����=1
order by ��������, ����, �������_����, �������_������ ;