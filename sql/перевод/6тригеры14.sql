use domofon14
GO
--create trigger [dbo].[ti_����_�����]
--on [dbo].[����_�����]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from ����_�����
--    update ����_�����    set  �������=@maxPor+1      from ����_�����, inserted
--          where  ����_�����.���_������=inserted.���_������
--          and inserted.�������<1



--GO


--CREATE  trigger [dbo].[tu_����_�����]
--on [dbo].[����_�����]
--  for update
--  as

--if update (������)
--begin
--      declare @������ varchar(50)
--      select  @������ =������ from inserted
--if rtrim(lTrim(@������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction



--GO
--create trigger [dbo].[ti_�������]
--on [dbo].[�������]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from �������
--    update �������    set  �������=@maxPor+1      from �������, inserted
--          where  �������.�������=inserted.�������
--          and inserted.�������<1


--GO
--create trigger [dbo].[ti_������]
--on [dbo].[������]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from ������
--    update ������    set  �������=@maxPor+1      from ������, inserted
--          where  ������.������=inserted.������
--          and inserted.�������<1

--GO

--create trigger [dbo].[ti_����������]
--on [dbo].[����������]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from ����������
--    update ����������    set  �������=@maxPor+1      from ����������, inserted
--          where  ����������.���������=inserted.���������
--          and inserted.�������<1
--GO
--create trigger [dbo].[ti_�����]
--on [dbo].[�����]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from �����
--    update �����    set  �������=@maxPor+1      from �����, inserted
--          where  �����.�����=inserted.�����
--          and inserted.�������<1
--GO

--create trigger [dbo].[ti_������]
--on [dbo].[������]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from ������
--    update ������    set  �������=@maxPor+1      from ������, inserted
--          where  ������.������=inserted.������
--          and inserted.�������<1

--GO

--create trigger [dbo].[ti_�������]
--on [dbo].[�������]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from �������
--    update �������    set  �������=@maxPor+1      from �������, inserted
--          where  �������.������=inserted.������
--          and inserted.�������<1

--GO

--create trigger [dbo].[ti_�����]
--on [dbo].[�����]
--  for INSERT
--  as
-- declare  @maxPor  int
--  select  @maxPor=max(�������) from �����
--    update �����    set  �������=@maxPor+1      from �����, inserted
--          where  �����.�����=inserted.�����
--          and inserted.�������<1

--GO


--CREATE  trigger [dbo].[tu_�������]
--on [dbo].[�������]
--  for update
--  as

--if update (������)
--begin
--      declare @������ varchar(50)
--      select  @������ =������ from inserted
--if rtrim(lTrim(@������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction



--GO


--CREATE  trigger [dbo].[tu_������]
--on [dbo].[������]
--  for update
--  as

--if update (������)
--begin
--      declare @������ varchar(50)
--      select  @������ =������ from inserted
--if rtrim(lTrim(@������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction

--GO



--CREATE  trigger [dbo].[tu_�����]
--on [dbo].[�����]
--  for update
--  as

--if update (������)
--begin
--      declare @������ varchar(50)
--      select  @������ =������ from inserted
--if rtrim(lTrim(@������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction
--GO


--CREATE  trigger [dbo].[tu_����������]
--on [dbo].[����������]
--  for update
--  as

--if update (�������)
--begin
--      declare @������� varchar(50)
--      select  @������� =������� from inserted
--if rtrim(lTrim(@�������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction

--GO


--CREATE  trigger [dbo].[tu_������]
--on [dbo].[������]
--  for update
--  as

--if update (������)
--begin
--      declare @������ varchar(50)
--      select  @������ =������ from inserted
--if rtrim(lTrim(@������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction

--GO


--CREATE  trigger [dbo].[tu_�������]
--on [dbo].[�������]
--  for update
--  as

--if update (������)
--begin
--      declare @������ varchar(50)
--      select  @������ =������ from inserted
--if rtrim(lTrim(@������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction


--GO



CREATE  TRIGGER [dbo].[d_��������] 
   ON  [dbo].[��������]
   AFTER DELETE
AS 
BEGIN
 
           
     INSERT INTO [dbo].[del_��������]
           ([������]
           ,[�����]
           ,[���]
           ,[������]
           ,[�����])
           (select ������ ,�����, ���, ������,����� from deleted )
END
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



--create  trigger [dbo].[tu_�������]
--on [dbo].[�������]
--  for update
--  as

--if update (�������)
--begin
--      declare @������� varchar(30)
--      select  @������� =������� from inserted
--if rtrim(lTrim(@�������))=''
--      goto error
--end
--  return
--error:
  
--    rollback transaction



--GO


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
---------------
CREATE TRIGGER [dbo].[d_������] 
   ON  [dbo].[������]
   AFTER DELETE
AS 
BEGIN
 
   
   INSERT INTO [del_������]
           ([������]
           ,[�����]
           ,[������]
           ,[���������]
           ,[����])
           ( select  ������ ,�����  ,������ ,��������� ,���� from deleted )
           
END
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


