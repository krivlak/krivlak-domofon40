USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[��������1����]    Script Date: 06.08.2016 20:29:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create   procedure [dbo].[��������1����]
(

  @��� uniqueidentifier='1ECCF139-9FA7-E311-9649-4C001076112B'
)
as
declare @MyTable table 
(
������  uniqueidentifier ,
������  uniqueidentifier ,
��� int  default 0 ,
����� int  default 0 ,
����_��� int default 0,
����_��� int default 0,
�������_� datetime default null,
�������� datetime default null,
������ datetime default null,
������  datetime default null,
��� varchar(50) default '',
�������� int default 0,
��������0 int default 0,
���� int default 0,
������� varchar(50) default '',
�������_���� int default 0,
�������_������ int default 0,
������_������ varchar(50) default '',
������ int default 0,
��� bit default 1,
��� bit default 0,
������� bit default 0,
���� varchar(50) default '',
����0 varchar(50) default '',
id_���������  varchar(50) default ''

);

declare @��� bit =0;
declare @���� int  =0;
declare @���_��� int = Year(getdate());
declare @���_����� int = Month(getdate());

select ������.������,��������.������,
 max(��������.���*100+��������.�����) as gm,
@��� as ��� ,
@���� as ����_���,
@���� as ����_���,
@���� as �������_����,
@���� as �������_������
 into #temp
from �������� inner join ������ 
on ��������.������=������.������
inner join �������
on ������.������=�������.������
and �������.���=@���
group by ������.������,��������.������;


--update #temp set ����_���= (@���_���*100+@���_�����)-#temp.gm-1
update #temp set ����_���= (@���_���-ROUND(gm/100,0))*12+@���_�����-(gm-ROUND(gm/100,0)*100)-1;

update #temp set ���=1
from ������_�������
where ������_�������.������=#temp.������ 
and ������_�������.������=#temp.������;



select #temp.������, #temp.������, sum(����.���������) as ����
into #temp2
from ���� inner join #temp
on #temp.������=����.������
and #temp.����_���>1
and (����.���*100+����.�����)>#temp.gm
and (����.���*100+����.�����)<(@���_���*100+@���_�����)
group by #temp.������, #temp.������;

update #temp set ����_���=#temp2.����
from #temp2
where #temp.������=#temp2.������
and #temp.������=#temp2.������;


insert into @MyTable (������, ������,���, �����,����_���, ����_���,���)
(
   select ������, 
   ������,
    ROUND(gm/100,0),
	 gm-ROUND(gm/100,0)*100,
	 ����_���,
	����_���,
	���
   from #temp
   where ���=1
   and ����_���>0
--   order by �������_����, �������_������
) ; 

update @MyTable set �������_����=����_�����.�������, �������_������= ������.�������,������_������=������.�����������
from ������ inner join ����_�����
on ������.���_������=����_�����.���_������
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

select ������, min(�������_����*100+�������_������) as �������
into #temp7
from @MyTable
group by ������

update @MyTable  set ������ =1
from #temp7 as a
where [@MyTable].�������_����*100+[@MyTable].�������_������=a.�������


update @MyTable  set ��������0=�������.��������
from �������
where �������.������= [@MyTable].������;


update @MyTable  set ���= �������.���, ��������=�������.��������, 
����=�������.����, �������=�������.�������, ���� =�������.����
from �������
where �������.������= [@MyTable].������
and [@MyTable].������=1;



select ������ , max(����) as ���� 
into #temp6
from ������ 
group by ������

update @MyTable  set ������=a.����
from #temp6 as a
where a.������=[@MyTable].������;

update @MyTable  set ����=a.����
from ���������� as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������;

--update @MyTable  set ����0=a.����
--from ������ as a
--where a.������=[@MyTable].������
--and [@MyTable].������=1;


select * from @MyTable
order by ��������0, �������_����, �������_������
GO


