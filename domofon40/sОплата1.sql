--declare @������ uniqueidentifier;

declare @MyTable table 
(
������ uniqueidentifier,
�������� int default 0
);


insert into @MyTable (������) 
select ������ from ������ 
where ������ =@������;

select ������.������ , ����� =COALESCE(SUM(��������.�����),0)
into #temp
from ������ inner join ��������
on ������.������ = ��������.������
and ������.������ =@������
 GROUP BY dbo.������.������;

update @MyTable set �������� =a.�����
from #temp as a
where [@MyTable].������= a.������ ;

select ������.������ , ����� =COALESCE(SUM(���_������.���������),0)
into #temp2
from ������ inner join ���_������
on ������.������ = ���_������.������
and ������.������ =@������
 GROUP BY dbo.������.������;

update @MyTable set �������� =��������+a.�����
from #temp2 as a
where [@MyTable].������= a.������ ;


select ������.������ , ����� =COALESCE(SUM(�������.�����),0)
into #temp3
from ������ inner join �������
on ������.������ = �������.������
and ������.������ =@������
 GROUP BY dbo.������.������;

update @MyTable set �������� =��������-a.�����
from #temp3 as a
where [@MyTable].������= a.������ ;

select ������.������ , ����� =COALESCE(SUM(���_������.�����),0)
into #temp4
from ������ inner join ���_������
on ������.������ = ���_������.������
and ������.������ =@������
 GROUP BY dbo.������.������;

update @MyTable set ��������= ��������-a.�����
from #temp4 as a
where [@MyTable].������= a.������ ;

select * from  @MyTable;


--SELECT a.������, a.�����1 + b.�����2 - c.�����3 AS ��������
--FROM     (SELECT dbo.������.������, COALESCE (SUM(dbo.��������.�����), 0) AS �����1
--                  FROM      dbo.������ LEFT OUTER JOIN
--                                    dbo.�������� ON dbo.������.������ = dbo.��������.������
--                  GROUP BY dbo.������.������) AS a INNER JOIN
--                      (SELECT ������_2.������, COALESCE (SUM(ROUND(dbo.���_������.���������, 0)), 0) AS �����2
--                       FROM      dbo.������ AS ������_2 LEFT OUTER JOIN
--                                         dbo.���_������ ON ������_2.������ = dbo.���_������.������
--                       GROUP BY ������_2.������) AS b ON a.������ = b.������ INNER JOIN
--                      (SELECT ������_1.������, COALESCE (SUM(ROUND(dbo.�������.�����, 0)), 0) AS �����3
--                       FROM      dbo.������ AS ������_1 LEFT OUTER JOIN
--                                         dbo.������� ON ������_1.������ = dbo.�������.������
--                       GROUP BY ������_1.������) AS c ON a.������ = c.������


