
/****** Object:  StoredProcedure [dbo].[����������1����]    Script Date: 30.03.2015 21:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[����������44]

as

declare @���� datetime

set @����=getdate()

declare @MyTable table 
(
������  uniqueidentifier ,
������ varchar(50),
��������� int default 0,
������ int default 0,
������������ int default 0,
����� int default 0,
��������� int default 0
);

insert into @MyTable (������ , ������)
select ������, ������ 
from ������;

--select * 
--into #temp0
--from �����������


select ������, ��������� =Count(������)
into #temp
from �����������
group by ������;


update @MyTable set ��������� = #temp.���������
from #temp
where [@MyTable].������ = #temp.������;


select ������, ������� = Count(������)
into #�������
from ������_�������
group by ������;

update @MyTable set ������  = #�������.�������
from #�������
where [@MyTable].������ = #�������.������;


select ��������.������ ,������.������
into #������
from �������� inner join ������
on ������.������=��������.������


select ������, ������, �����=Count(������)
into #������1
from #������
group by ������,������;

select ������, ������������ = Count(������)
into #������2
from #������1
group by ������;

update @MyTable set ������������ = #������2.������������
from #������2
where [@MyTable].������ = #������2.������;


--select * 
--into #������0
--from ������


select ������ , ����� =count(������)
into #������
from ������
group by ������;

update @MyTable set �����  = #������.�����
from #������
where [@MyTable].������ = #������.������;

--- ����� ����������
declare @���������� table 
(
������  uniqueidentifier ,
������ uniqueidentifier,
����_�� datetime,
����_���� datetime default null,
�������� bit default 1
);

select * 
into #����0
from ����������



select ������, ������, ����_�� =Max(����_�)
into #����
from #����0
group by ������, ������;

insert  @���������� (������, ������, ����_��)
select ������, ������, ����_��
from #����;

select * 
into #������0
from �������


select ������, ������, ����_���� =max(����_�)
into #������
from #������0
group by ������, ������;



update @���������� set ����_����=#������.����_����
from #������
where [@����������].������=#������.������
and [@����������].������=#������.������

update @���������� set ��������=0
where  ����_��<=����_����;


--select * from @����������;

select * 
into #������2
from @����������
where ��������=1;

select ������, ��������� =Count(������)
into #������3
from  #������2
group by ������;

update @MyTable set ���������  = #������3.���������
from #������3
where [@MyTable].������ = #������3.������;


select * from @MyTable;