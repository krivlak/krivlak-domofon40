create   procedure [dbo].[����������1���]
(

  @��� uniqueidentifier
)
as
declare @MyTable table 
(
����� varchar(100),
������  uniqueidentifier ,
������  uniqueidentifier ,
��� int  default 0 ,
����� int  default 0 ,
����_��� int default 0,
�������_� datetime default null,
�������� datetime default null,
������ datetime default null,
������  datetime default null,
��� varchar(50) default '',
��� varchar(50) default '',
�������� varchar(50) default '',
������_������� varchar(50) default '',
�������_������� int default 0,
������_����� varchar(50) default '',
�����_���� int default 0,
������ varchar(50),
�������� int default 0,
��������0 int default 0,
���� int default 0,
������� int default 0,
������� varchar(50) default '',
�������_������ int default 0,
������_������ varchar(50) default '',
������ int default 0,
��� bit default 0,
������� bit default 0,
���� varchar(50) default '',
����0 varchar(50) default ''
);

declare @��� bit =0;
declare @���� int  =0;
declare @���_��� int = Year(getdate());
declare @���_����� int = Month(getdate());

select ������.������,��������.������,
 max(��������.���*100+��������.�����) as gm,
 max(��������.���*12+��������.�����) as gm12,
@��� as ��� ,
@���� as ����_���,
@���� as �������_������
 into #temp
from �������� inner join ������ 
on ��������.������=������.������
inner join �������
on ������.������=�������.������
inner join ������
on ��������.������=������.������
and ������.���_������=@���
group by ������.������,��������.������;


update #temp set ����_���= (@���_���*12+@���_�����)-#temp.gm12-1

update #temp set ����_���=0
where ����_���<0




update #temp set ���=1
from ������_�������
where ������_�������.������=#temp.������ 
and ������_�������.������=#temp.������;



insert into @MyTable (������, ������,���)
(
   select ������_�������.������, 
   ������_�������.������,
    1 
   from ������_������� 
   inner join ������
   on ������_�������.������=������.������
   and ������.���_������=@���
) ; 




update @MyTable set ��� =  ROUND(#temp.gm/100,0), 
     �����= #temp.gm-ROUND(#temp.gm/100,0)*100,
	����_���= #temp.����_���
	 from #temp
	 where #temp.������=[@MyTable].������
	 and #temp.������=[@MyTable].������

update @MyTable set �������=1
where ����_���>1;


update @MyTable set  �������_������= ������.�������,
������_������=������.�����������
from ������ 
where ������.������=[@MyTable].������



select ������, ������, max(����_�) as ����_�
into #temp3
from �����������
group by ������, ������

update @MyTable  set �������_�=a.����_�
from #temp3 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������


select ������, ������, max(����_�) as ����_�
into #temp4
from ����������
group by ������, ������

update @MyTable  set ��������=a.����_�
from #temp4 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������

select ������, ������, max(����_�) as ����_�
into #temp5
from �������
group by ������, ������;

update @MyTable  set ������=a.����_�
from #temp5 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������;



select �������.������, �������.���, �������.����, �������.�������, �������.�������, �������.��������,
����.�����, ����.������, �����.������ as ������_�����, �������.������ as ������_�������, �������.������� as �������_�������,
�������.���, �������.��������
into #temp7
from ������� inner join ���� on �������.��� =����.���
inner join ����� on ����.�����=�����.�����
inner join ������� on �����.�������=�������.�������;


update  @MyTable  set  ���= k.���,  ����0 = k.����, �������=k.������� , �������=k.�������,
�������� = k.��������, �����_���� =k.�����, ������=k.������, ������_�����= k.������_�����,
������_������� =k.������_�������, �������_�������= k.�������_�������,
��� = k.���, �������� =k.��������
from #temp7 as k
where k.������= [@MyTable].������;

--update  @MyTable  set ����� = Rtrim(������_�������) +' '+RTRIM(������_�����)+' '
--+str( �����_����)+ ' '+RTRIM(������)+ ' ���� '+STR(����)



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
where ���=1
order by �������_�������,������_�����, �����_����,������, ��������, ����,  �������_������;
