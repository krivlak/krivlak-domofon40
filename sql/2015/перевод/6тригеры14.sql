use domofon14
GO
create trigger [dbo].[ti_�������]
on [dbo].[�������]
  for INSERT
 as
declare @������ uniqueidentifier
declare @������  uniqueidentifier
 
select @������ = inserted.������,
       @������ = inserted.������
  from inserted

  

delete from ������_������� 
where ������= @������ and ������ =@������



insert into ������_������� (������, ������)
values ( @������, @������)

GO

create  trigger [dbo].[ti_�����������]
on [dbo].[�����������]
  for INSERT
 as


declare @������ uniqueidentifier
declare @������  uniqueidentifier
 
select @������ = inserted.������,
       @������ = inserted.������
  from inserted

delete from ������_�������
where ������ =@������ and ������=@������
  

insert into ������_������� (������, ������)
values ( @������, @������)
GO


CREATE trigger [dbo].[ti_��������]
on [dbo].[��������]
  for INSERT
  as
 declare  @���  uniqueidentifier
 
  select  @���= �������.��� 
  from inserted inner join ������
  on ������.������=inserted.������
  inner join �������
  on ������.������ =�������.������
  
    update ����    set  �������=getdate()    
    where ����.��� =@���
     
	 GO
	

create trigger [dbo].[ti_����������]
on [dbo].[����������]
  for INSERT
 as
declare @������ uniqueidentifier
declare @������  uniqueidentifier
 
select @������ = inserted.������,
       @������ = inserted.������
  from inserted

  

delete from ������_������� 
where ������= @������ and ������ =@������


GO


