--select a.��� ,����� =
--(select  Count(������) from ������  where ��������� = a.���������)
--from ���������� as a
--where a.������=1;

--select *
--into  newMez
-- from ������

--select ����������.���������, ����������.���, ����� = Count(������.������)
--from ���������� inner join ������
--on ����������.��������� =������.���������
--where ����������.������=1
--group by all ����������.���������, ����������.���;

--select ����������.���������, ����������.���, ����� = Count(������.������)
--from ���������� inner join ������
--on ����������.��������� =������.���������
--where ����������.������=1
--group by all ����������.���������, ����������.���
--having Count(������.������) > -1
--order by ���;


--select ��������� as ���, ��� as ������� 
--from ����������
--union
--select ������, ������
--from ������
--order by ������� 

--select ��������� as ���, ��� as ������� 
--from ����������
--union all
--select ���������, ���
--from ����������
--order by ������� 

--select ��������� as ���, ��� as ������� 
--from ����������
--except
--select ���������, ���
--from ����������
--order by ������� ;

--select ntile(7000) over( order by ����) as dt, ����  from ������ 
--order by dt;

--select count(*) from ������;

--select dense_rank() over( order by ����) as dt, ����  from ������ 


with cte1 (��������, ����)
as 
(
select ntile(7000) over( order by ����) as ��������, ����  from ������ 
)

select * from cte1
where �������� =1;