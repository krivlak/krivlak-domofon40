


declare @MyTable table 
(
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
and �������.���=@���
inner join ������
on ��������.������=������.������
and ������.���_������=@���
group by ������.������,��������.������;


update #temp set ����_���= (@���_���*12+@���_�����)-#temp.gm12-1

update #temp set ����_���=0
where ����_���<0


--update #temp set ����_���= (@���_���-ROUND(gm/100,0))*12+@���_�����-(gm-ROUND(gm/100,0)*100)-1;

update #temp set ���=1
from ������_�������
where ������_�������.������=#temp.������ 
and ������_�������.������=#temp.������;

--update #temp set �������=1
--where ����_���>1
--and ���=1;

--select #temp.������, #temp.������, sum(����.���������) as ����
--into #temp2
--from ���� inner join #temp
--on #temp.������=����.������
--and #temp.����_���>1
--and (����.���*100+����.�����)>#temp.gm
--and (����.���*100+����.�����)<(@���_���*100+@���_�����)
--group by #temp.������, #temp.������;

--update #temp set ����_���=#temp2.����
--from #temp2
--where #temp.������=#temp2.������
--and #temp.������=#temp2.������;

insert into @MyTable (������, ������,���)
(
   select ������_�������.������, 
   ������_�������.������,
    1 
   from ������_������� inner join �������
   on ������_�������.������=�������.������
   and �������.���=@���
   inner join ������
   on ������_�������.������=������.������
   and ������.���_������=@���
) ; 


--insert into @MyTable (������, ������,���, �����,����_���,���)
--(
--   select ������, 
--   ������,
--    ROUND(gm/100,0),
--	 gm-ROUND(gm/100,0)*100,
--	 ����_���,
--	���
--   from #temp
--   --where ���=1
--) ; 

update @MyTable set ��� =  ROUND(#temp.gm/100,0), 
     �����= #temp.gm-ROUND(#temp.gm/100,0)*100,
	����_���= #temp.����_���
	 from #temp
	 where #temp.������=[@MyTable].������
	 and #temp.������=[@MyTable].������

update @MyTable set �������=1
where ����_���>2;
--and ���=1;

update @MyTable set  �������_������= ������.�������,
������_������=������.�����������
from ������
where ������.������=[@MyTable].������

--update @MyTable set ������_������=������.�����������
--from ������
--where ������.������=[@MyTable].������


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
group by ������, ������

update @MyTable  set ������=a.����_�
from #temp5 as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������

--select ������, min(�������_������) as �������
--into #temp7
--from @MyTable
--group by ������

--update @MyTable  set ������ =1
--from #temp7 as a
--where [@MyTable].�������_������=a.�������
--and [@MyTable].������= a.������;


update @MyTable  set ��������0=�������.��������
from �������
where �������.������= [@MyTable].������;


update @MyTable  set ���= �������.���,���=�������.���, ��������=�������.��������, ��������=�������.��������, ����=�������.����, 
�������=�������.�������, ������� =�������.�������, ����0= �������.����
from �������
where �������.������= [@MyTable].������;
--and [@MyTable].������=1;



--select *
--into #temp8
--from ����������
--order by ����_�

--update @MyTable set �������=a.�������,
-- ��_�����=a.��_�����,
-- ���������� =a.����������,
-- ����_����������=a.����_�,
-- �����_����������=a.�����
--from #temp8 as a
--where a.������= [@MyTable].������
--and [@MyTable].������=1;

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

update @MyTable  set ����0=a.����
from ������� as a
where a.������=[@MyTable].������
and [@MyTable].������=1;


select * from @MyTable
where ���=1
order by ��������0,  �������_������;

--GO


