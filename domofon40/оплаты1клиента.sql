
-- declare @������ uniqueidentifier ='3e31a719-1b81-4900-a3e6-59caf817380b'

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
��������  varchar(50) default '',
���_������ uniqueidentifier ,
������_���� varchar(50) default ''
);

insert into @MyTable (������, �����, ������, ����, ���������, ���_������)
select ������, �����, ������, ����, ���������, ���_������
from ������ 
where ������ =@������;

update @MyTable set ��������= ����������.���
from ����������
where [@MyTable].���������=����������.���������;

update @MyTable set ������_����= ����_�����.������
from ����_�����
where [@MyTable].���_������ =����_�����.���_������;

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



