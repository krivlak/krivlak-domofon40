USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[�������1�����������]    Script Date: 06.08.2016 20:30:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[�������1�����������]
(

  @��� uniqueidentifier='1ECCF139-9FA7-E311-9649-4C001076112B',
  @���_������ uniqueidentifier='9ECBF139-9FA7-E311-9649-4C001076112B'
)
as
declare @MyTable table 
(
������  uniqueidentifier not null,
������  uniqueidentifier not null,
��� int  not null default 0 ,
����� int  not null default 0 ,
����_���  int not null default 0,
����_��� int not null default 0,
�������_� datetime null default null,
�������� datetime  null default null,
������ datetime null default null,
���������_������   datetime null default null,
��� varchar(50) not null default '',
������� int not null default 0,
�������� int not null default 0,
��������0 int not null default 0,
���� int not null default 0,
������� varchar(50) not null default '',
�������_������ int not null default 0,
������_������ varchar(50) not null default '',
������ int not null default 0,
��������� bit not null default 0,
���������� bit not null default 0,
�������� bit not null default 0,
��� bit not null default 0,
������� bit not null default 0,
���� varchar(50) not null default '',
����0 varchar(50) not null default ''
);


select �������.*, ������.������, ������.�����������, ������.������� as �������_������
into #temp0
from ������� inner join ������
on �������.���=@���
and ������.���_������=@���_������
order by �������.��������, �������.����, ������.�������

insert into @MyTable (������, ������,���,�������,��������, ��������0,����,�������, ������_������, ����0, �������_������)
select ������, ������,���,�������,��������, ��������,����,�������, �����������, ����, �������_������
from #temp0
----------------------
declare @��� bit =0;
declare @���� int  =0;
declare @���_��� int = Year(getdate());
declare @���_����� int = Month(getdate());

select ������.������,��������.������,
 max(��������.���*100+��������.�����) as gm,
@���� as ���,
@���� as �����,
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

update #temp set ����_���= (@���_���-ROUND(gm/100,0))*12+@���_�����-(gm-ROUND(gm/100,0)*100)-1,
��� =ROUND(gm/100,0), ����� =gm-ROUND(gm/100,0)*100;

--update #temp set ���=1
--from ������_�������
--where ������_�������.������=#temp.������ 
--and ������_�������.������=#temp.������;



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

update @MyTable set ���=a.���, �����=a.����� ,����_���=a.����_���,����_���=a.����_���
from #temp as a
where [@MyTable].������=a.������
and [@MyTable].������=a.������

update @MyTable  set ���=1
from ������_�������
where ������_�������.������=[@MyTable].������ 
and ������_�������.������=[@MyTable].������;

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


update @MyTable  set ����=a.����
from ���������� as a
where a.������=[@MyTable].������
and a.������=[@MyTable].������

--------------

select * from @MyTable
order by ��������, ����

GO


