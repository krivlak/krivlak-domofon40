USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[������1�������]    Script Date: 06.08.2016 20:32:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[������1�������]
(
@������ uniqueidentifier ='9AEA7CBB-9D74-E511-BC93-0013465F2146'
)
as
declare @MyTable table 
(
������ uniqueidentifier ,
����� int,
������  uniqueidentifier ,
���� datetime,
���������  uniqueidentifier ,
����� varchar(50) default '',
��� varchar(50) default '',
�������� int  default 0,
��������  varchar(50) default ''
);

insert into @MyTable (������, �����, ������, ����, ���������)
select ������, �����, ������, ����, ���������
from ������ 
where ������ =@������;

update @MyTable set ��������= ����������.���
from ����������
where [@MyTable].���������=����������.���������;

select �������.������,
 ����� =  rtrim(ltrim(�����.������))+' '+rtrim(ltrim(str(����.�����)))+' '+rtrim(ltrim(����.������))+' ��. '+rtrim(ltrim(str(�������.��������))),
 �������.���
 into #temp0
 from ������� inner join ���� on �������.���=����.���
inner join ����� on ����.�����=�����.�����

update  @MyTable set �����=a.����� ,���= a.���
from #temp0 as a
where [@MyTable].������=a.������


update  @MyTable set ����� =  �����+' ���� '+rtrim(ltrim(str(�������.����)))
from ������� 
where [@MyTable].������=�������.������
and �������.���� >0 ;

select ������ , SUM(�����) as �����
into #temp
from �������� group by ������ 

update  @MyTable set �������� = a.�����
from #temp as a
where [@MyTable].������=a.������

select ������ , SUM(��������� ) as �����
into #temp2 
from ���_������ group by ������ 

update  @MyTable set �������� = ��������+a.�����
from #temp2 as a
where [@MyTable].������=a.������

select ������ , SUM(�����) as �����
into #temp3
from ������� group by ������ 

update  @MyTable set �������� = ��������-a.�����
from #temp3 as a
where [@MyTable].������=a.������


select * from  @MyTable
order by ����, ����� ;
GO


