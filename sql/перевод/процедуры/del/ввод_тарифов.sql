USE [domofon14]
GO

/****** Object:  StoredProcedure [dbo].[����_�������]    Script Date: 06.08.2016 20:28:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[����_�������]
(
  @������ uniqueidentifier='063A923F-9FA7-E311-9649-4C001076112B'
)
as
declare @MyTable table 
(
��� int not null default 0 ,
����� int not null default 0 ,
������ char(12) not null default '',
�����  int not null default 0
);

insert into @MyTable (��� , �����, ������)
select ����.���, ������.�����, ������.������
from ���� inner join ������
on ����.���>0;

--select ���, �����, ���������
--into #temp
--from ����
--where ������ =@������;

update @MyTable set �����=a.���������
from ���� as a
where ������ =@������ 
and a.���=[@MyTable].���
and a.�����=[@MyTable].�����;


select * from @MyTable
GO


