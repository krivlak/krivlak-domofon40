use domofon8
GO

CREATE TABLE [dbo].[����](
	[���] [int] NOT NULL,
 CONSTRAINT [PK_���] PRIMARY KEY CLUSTERED 
(
	[���] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into ���� (���) values (2012);
insert into ���� (���) values (2013);
insert into ���� (���) values (2014);
insert into ���� (���) values (2015);
insert into ���� (���) values (2016);
insert into ���� (���) values (2017);
insert into ���� (���) values (2018);
insert into ���� (���) values (2019);
insert into ���� (���) values (2020);
insert into ���� (���) values (2021);
insert into ���� (���) values (2022);

go
print '����'
go

CREATE TABLE [dbo].[������](
	[�����] [int] NOT NULL,
	[������] [char](10) NOT NULL,
 CONSTRAINT [PK_�����] PRIMARY KEY CLUSTERED 
(
	[�����] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into ������ (�����, ������)
values (1, '������');

insert into ������ (�����, ������)
values (2, '�������');

insert into ������ (�����, ������)
values (3, '����');

insert into ������ (�����, ������)
values (4, '������');

insert into ������ (�����, ������)
values (5, '���');

insert into ������ (�����, ������)
values (6, '����');

insert into ������ (�����, ������)
values (7, '����');


insert into ������ (�����, ������)
values (8, '������');

insert into ������ (�����, ������)
values (9, '��������');


insert into ������ (�����, ������)
values (10, '�������');

insert into ������ (�����, ������)
values (11, '������');

insert into ������ (�����, ������)
values (12, '�������');

GO

print '������'
go

-----------------

CREATE TABLE [dbo].[del_������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	��������� uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[���������10] [char](10) NOT NULL,
	[�������] [datetime] NOT NULL,
	[����] [date] NOT NULL,
 CONSTRAINT [PK__del_����__DB7F733B1699586C] PRIMARY KEY CLUSTERED 
(
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[del_������] ADD   DEFAULT ((0)) FOR [�����]
GO


ALTER TABLE [dbo].[del_������] ADD    DEFAULT (getdate()) FOR [�������]
GO


print 'del_������'
go

---------------

CREATE TABLE [dbo].[del_��������](
	[���] [int] IDENTITY(1,1) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[���] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[del_��������] ADD  DEFAULT ((0)) FOR [�����]
GO

ALTER TABLE [dbo].[del_��������] ADD    DEFAULT (getdate()) FOR [����]
GO

print 'del_��������'
go

----------------


CREATE TABLE [dbo].[����_�����](
     ���_������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[���_������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL,
	[�������] [int] NOT NULL,
 CONSTRAINT [PK_���_������] PRIMARY KEY CLUSTERED 
(
	[���_������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[����_�����] ADD  CONSTRAINT [DF_����_�����_������]  DEFAULT (' ') FOR [������]
GO

ALTER TABLE [dbo].[����_�����] ADD  CONSTRAINT [DF_����_�����_�������]  DEFAULT ((0)) FOR [�������]
GO



create trigger [dbo].[ti_����_�����]
on [dbo].[����_�����]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from ����_�����
    update ����_�����    set  �������=@maxPor+1      from ����_�����, inserted
          where  ����_�����.���_������=inserted.���_������
          and inserted.�������<1



GO


CREATE  trigger [dbo].[tu_����_�����]
on [dbo].[����_�����]
  for update
  as

if update (������)
begin
      declare @������ varchar(50)
      select  @������ =������ from inserted
if rtrim(lTrim(@������))=''
      goto error
end
  return
error:
  
    rollback transaction



GO
print '����_�����'
go
----------

CREATE TABLE [dbo].[�������](
	[���] [int] IDENTITY(1,1) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[���] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[�������] ADD  DEFAULT ((0)) FOR [�����]
GO
print '�������'
go
-------------


CREATE TABLE [dbo].[����](
��� uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[���10] [char](10) NOT NULL,
	[������] [char](10) NOT NULL,
	[�������] [int] NOT NULL,
	����� uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[�����10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	[������] [char](10) NOT NULL,
	[�������] [datetime] NOT NULL,
 CONSTRAINT [PK_����] PRIMARY KEY CLUSTERED 
(
	[���] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[����] ADD    DEFAULT (' ') FOR [������]
GO

ALTER TABLE [dbo].[����] ADD   DEFAULT ((0)) FOR [�������]
GO

ALTER TABLE [dbo].[����] ADD   DEFAULT ((0)) FOR [�����]
GO

ALTER TABLE [dbo].[����] ADD   DEFAULT (' ') FOR [������]
GO

ALTER TABLE [dbo].[����] ADD   DEFAULT (getdate()) FOR [�������]
GO
print '����'
go
-----------

CREATE TABLE [dbo].[������](
������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����] [datetime] NOT NULL  default getdate()
 CONSTRAINT [PK_������] PRIMARY KEY CLUSTERED 
(
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
print '������'
go
----------

CREATE TABLE [dbo].[�������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�������] [char](30) NOT NULL,
	[���] [char](30) NOT NULL,
	[��������] [char](30) NOT NULL,
    ��� uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[���10] [char](10) NOT NULL,
	[��������] [int] NOT NULL,
	[���]  AS (((((ltrim(rtrim([�������]))+' ')+left(rtrim(ltrim([���])),(1)))+'.')+left(rtrim(ltrim([��������])),(1)))+'.'),
	[����] [varchar](50) NOT NULL,
	[�������] [int] NOT NULL,
	[�������] [varchar](50) NOT NULL,
	[����] [int] NOT NULL,
 CONSTRAINT [PK_�������] PRIMARY KEY CLUSTERED 
(
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_�������]  DEFAULT (' ') FOR [�������]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_���]  DEFAULT (' ') FOR [���]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_��������]  DEFAULT (' ') FOR [��������]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_��������]  DEFAULT ((0)) FOR [��������]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_����]  DEFAULT (' ') FOR [����]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_�������]  DEFAULT ((0)) FOR [�������]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_�������]  DEFAULT (' ') FOR [�������]
GO

ALTER TABLE [dbo].[�������] ADD  CONSTRAINT [DF_�������_����]  DEFAULT ((0)) FOR [����]
GO


create  trigger [dbo].[tu_�������]
on [dbo].[�������]
  for update
  as

if update (�������)
begin
      declare @������� varchar(30)
      select  @������� =������� from inserted
if rtrim(lTrim(@�������))=''
      goto error
end
  return
error:
  
    rollback transaction



GO

print '�������'
go
----------

CREATE TABLE [dbo].[������](
    ������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL,
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�������] [int] NOT NULL,
 CONSTRAINT [PK_������] PRIMARY KEY CLUSTERED 
(
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[������] ADD  CONSTRAINT [DF_������_����_�]  DEFAULT (getdate()) FOR [����_�]
GO

ALTER TABLE [dbo].[������] ADD  CONSTRAINT [DF_������_�������]  DEFAULT ((100)) FOR [�������]
GO

print '������'
go
-------------

CREATE TABLE [dbo].[������](
	[������] [datetime] NOT NULL,
 CONSTRAINT [PK_������_1] PRIMARY KEY CLUSTERED 
(
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[������] ADD  CONSTRAINT [DF_������_������]  DEFAULT (getdate()) FOR [������]
GO
print '������'
go
------------


CREATE TABLE [dbo].[���_������](
	--[���] [int] NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[���������] [decimal](10, 2) NOT NULL,
	[��������] [decimal](10, 2) NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[��_����������] [decimal](10, 2) NOT NULL,
	�������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[�������10] [char](10) NOT NULL,
 CONSTRAINT [PK_���_������_1] PRIMARY KEY CLUSTERED 
(
	[�������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[���_������] ADD  CONSTRAINT [DF_���_������_���������]  DEFAULT ((0)) FOR [���������]
GO

ALTER TABLE [dbo].[���_������] ADD  CONSTRAINT [DF_���_������_��������]  DEFAULT ((0)) FOR [��������]
GO


ALTER TABLE [dbo].[���_������] ADD  CONSTRAINT [DF_���_������_��_����������]  DEFAULT ((0)) FOR [��_����������]
GO
print '���_������'
go
---------------


CREATE TABLE [dbo].[������](
    ������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����] [date] NOT NULL,
	���������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[���������10] [char](10) NOT NULL,
 CONSTRAINT [PK_������] PRIMARY KEY CLUSTERED 
(
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[������] ADD  CONSTRAINT [DF_������_�����]  DEFAULT ((0)) FOR [�����]
GO

ALTER TABLE [dbo].[������] ADD  CONSTRAINT [DF_������_����]  DEFAULT (getdate()) FOR [����]
GO



CREATE TRIGGER [dbo].[d_������] 
   ON  [dbo].[������]
   AFTER DELETE
AS 
BEGIN
 
   
   INSERT INTO [domofon12].[dbo].[del_������]
           ([������]
           ,[�����]
           ,[������]
           ,[���������]
           ,[����])
           ( select  ������ ,�����  ,������ ,��������� ,���� from deleted )
           
END
GO

print '������'
go
---------------

CREATE TABLE [dbo].[��������](
	[���] [int] IDENTITY(1,1) NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����] [int] NOT NULL,
	[�����_���] [int] NOT NULL,
	[����] [int] NOT NULL,
 CONSTRAINT [PK_��������] PRIMARY KEY CLUSTERED 
(
	[���] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[��������] ADD  CONSTRAINT [DF_��������_�����]  DEFAULT ((0)) FOR [�����]
GO

ALTER TABLE [dbo].[��������] ADD  CONSTRAINT [DF_��������_���]  DEFAULT ((0)) FOR [���]
GO

ALTER TABLE [dbo].[��������] ADD  CONSTRAINT [DF_��������_�����]  DEFAULT ((0)) FOR [�����]
GO


ALTER TABLE [dbo].[��������] ADD  CONSTRAINT [DF_��������_����]  DEFAULT ((0)) FOR [����]
GO

ALTER TABLE [dbo].[��������] ADD  CONSTRAINT [DF_��������_��]  DEFAULT ((0)) FOR [�����_���]
GO

ALTER TABLE [dbo].[��������] ADD  CONSTRAINT [DF_��������_����]  DEFAULT ((0)) FOR [����]
GO

CREATE  TRIGGER [dbo].[d_��������] 
   ON  [dbo].[��������]
   AFTER DELETE
AS 
BEGIN
 
           
     INSERT INTO [domofon].[dbo].[del_��������]
           ([������]
           ,[�����]
           ,[���]
           ,[������]
           ,[�����])
           (select ������ ,�����, ���, ������,����� from deleted )
END
GO

print '��������'
go

--CREATE trigger [dbo].[ti_��������]
--on [dbo].[��������]
--  for INSERT
--  as
-- declare  @���  uniqueidentifier
 
--  select  @���= �������.��� 
--  from inserted inner join ������
--  on ������.������=inserted.������
--  inner join �������
--  on ������.������ =�������.������
  
--    update ����    set  �������=getdate()    
--    where ����.��� =@���
     
--	 GO


------------------


CREATE TABLE [dbo].[����������](
    ���������� uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[����������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[����_�] [datetime] NOT NULL,
	[����_��] [datetime] NULL,
	[����] [varchar](50) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
 CONSTRAINT [PK_����������] PRIMARY KEY CLUSTERED 
(
	[����������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[����������] ADD  CONSTRAINT [DF_����������_����_�]  DEFAULT (getdate()) FOR [����_�]
GO

ALTER TABLE [dbo].[����������] ADD  CONSTRAINT [DF_����������_����]  DEFAULT (' ') FOR [����]
GO

print '����������'
go
----------------


CREATE TABLE [dbo].[�������](
	����������� uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[�����������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL,
	[����] [varchar](50) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[�����������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[�������] ADD  DEFAULT (getdate()) FOR [����_�]
GO

ALTER TABLE [dbo].[�������] ADD  DEFAULT (' ') FOR [����]
GO
print '�������'
go
---------------

CREATE TABLE [dbo].[�����������](
    ����������� uniqueidentifier NOT NULL DEFAULT newsequentialid()  PRIMARY KEY CLUSTERED,
	[���10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL,
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL,
	[�����_���] [char](20) NOT NULL,
	[����_���] [datetime] NOT NULL,
	[�����_��] [int] NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[������10] [char](10) NOT NULL
 )

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[�����������] ADD    DEFAULT (getdate()) FOR [����_�]
GO


ALTER TABLE [dbo].[�����������] ADD    DEFAULT (' ') FOR [�����_���]
GO

ALTER TABLE [dbo].[�����������] ADD    DEFAULT (getdate()) FOR [����_���]
GO

ALTER TABLE [dbo].[�����������] ADD   DEFAULT ((0)) FOR [�����_��]
GO
print '������������'
go
-----------------

CREATE TABLE [dbo].[�������](
    ������� uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[�������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL,
	[�������] [int] NOT NULL
	)

GO


ALTER TABLE [dbo].[�������] ADD    DEFAULT (' ') FOR [������]
GO

ALTER TABLE [dbo].[�������] ADD    DEFAULT ((0)) FOR [�������]
GO


create trigger [dbo].[ti_�������]
on [dbo].[�������]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from �������
    update �������    set  �������=@maxPor+1      from �������, inserted
          where  �������.�������=inserted.�������
          and inserted.�������<1


GO

CREATE  trigger [dbo].[tu_�������]
on [dbo].[�������]
  for update
  as

if update (������)
begin
      declare @������ varchar(50)
      select  @������ =������ from inserted
if rtrim(lTrim(@������))=''
      goto error
end
  return
error:
  
    rollback transaction


GO
print '�������'
go
---------------------

CREATE TABLE [dbo].[��������������](
    �������������� uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[��������������10] [char](10) NOT NULL,
	[����] [datetime] NOT NULL DEFAULT getdate(),
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL)
GO
print '��������������'
go
--------------

CREATE TABLE [dbo].[����������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	[����] [varchar](50) NOT NULL DEFAULT (' ') ,
 CONSTRAINT [PK_����������] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
print '����������'
go
------------------------------

CREATE TABLE [dbo].[�������](
    ������� uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[�������10] [char](10) NOT NULL ,
	[������] [varchar](50) NOT NULL default '',
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL DEFAULT getdate(),
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL)

	print '�������'
go
--------------

CREATE TABLE [dbo].[���_����](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	[����] [int] NOT NULL default 0,
	[����] [varchar](50) NOT NULL default '',
 CONSTRAINT [PK_���_����] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC,
	[���] ASC,
	[�����] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
print '���_����'
go
------------------

CREATE TABLE [dbo].[������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[���������] int NOT NULL default 0,
	[��_����������] int  NOT NULL  default 0,
	[�����������] [varchar](50) NOT NULL default '')

GO

create trigger [dbo].[ti_������]
on [dbo].[������]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from ������
    update ������    set  �������=@maxPor+1      from ������, inserted
          where  ������.������=inserted.������
          and inserted.�������<1

GO

CREATE  trigger [dbo].[tu_������]
on [dbo].[������]
  for update
  as

if update (������)
begin
      declare @������ varchar(50)
      select  @������ =������ from inserted
if rtrim(lTrim(@������))=''
      goto error
end
  return
error:
  
    rollback transaction

GO
print '������'
go
---------------

CREATE TABLE [dbo].[����������](
    ��������� uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[���������10] [char](10) NOT NULL,
	[�������] [varchar](50) NOT NULL default '',
	[���] [varchar](50) NOT NULL default '',
	[��������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[����] [varchar](50) NOT NULL default '',
	[�����] [varchar](50) NOT NULL default '',
	[�������] [varchar](50) NOT NULL default '',
	[����] [varchar](50) NOT NULL default '',
	[����_���] [datetime] NULL,
	[���]  AS (((((ltrim(rtrim([�������]))+' ')+left(rtrim(ltrim([���])),(1)))+'.')+left(rtrim(ltrim([��������])),(1)))+'.'),
	[������] [datetime] NULL,
	[������] [datetime] NULL,
	[���������] [varchar](50) NOT NULL default '',
	[������] [bit] NOT NULL default 1)
GO

create trigger [dbo].[ti_����������]
on [dbo].[����������]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from ����������
    update ����������    set  �������=@maxPor+1      from ����������, inserted
          where  ����������.���������=inserted.���������
          and inserted.�������<1
GO


CREATE  trigger [dbo].[tu_����������]
on [dbo].[����������]
  for update
  as

if update (�������)
begin
      declare @������� varchar(50)
      select  @������� =������� from inserted
if rtrim(lTrim(@�������))=''
      goto error
end
  return
error:
  
    rollback transaction

GO
print '����������'
go
-----------------

CREATE TABLE [dbo].[�����](
    ����� uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[�����10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	������� uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[�������10] [char](10) NOT NULL)
GO

create trigger [dbo].[ti_�����]
on [dbo].[�����]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from �����
    update �����    set  �������=@maxPor+1      from �����, inserted
          where  �����.�����=inserted.�����
          and inserted.�������<1
GO

CREATE  trigger [dbo].[tu_�����]
on [dbo].[�����]
  for update
  as

if update (������)
begin
      declare @������ varchar(50)
      select  @������ =������ from inserted
if rtrim(lTrim(@������))=''
      goto error
end
  return
error:
  
    rollback transaction
GO
print '�����'
go
------------


CREATE TABLE [dbo].[������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	���_������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[���_������10] [char](10) NOT NULL,
	[�����������] [char](10) NOT NULL default '')
GO

create trigger [dbo].[ti_������]
on [dbo].[������]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from ������
    update ������    set  �������=@maxPor+1      from ������, inserted
          where  ������.������=inserted.������
          and inserted.�������<1

GO

CREATE  trigger [dbo].[tu_������]
on [dbo].[������]
  for update
  as

if update (������)
begin
      declare @������ varchar(50)
      select  @������ =������ from inserted
if rtrim(lTrim(@������))=''
      goto error
end
  return
error:
  
    rollback transaction

GO
print '������'
go
--------------

CREATE TABLE [dbo].[������_�������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
	 ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
 CONSTRAINT [PK_������_�������] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
print '������_�������'
go
---------------

CREATE TABLE [dbo].[�������](
    ������ uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�����] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[�������] [varchar](50) NOT NULL default '')
GO

create trigger [dbo].[ti_�������]
on [dbo].[�������]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from �������
    update �������    set  �������=@maxPor+1      from �������, inserted
          where  �������.������=inserted.������
          and inserted.�������<1

GO

CREATE  trigger [dbo].[tu_�������]
on [dbo].[�������]
  for update
  as

if update (������)
begin
      declare @������ varchar(50)
      select  @������ =������ from inserted
if rtrim(lTrim(@������))=''
      goto error
end
  return
error:
  
    rollback transaction



GO
print '�������'
go
--------------------

CREATE TABLE [dbo].[�����](
    ����� uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[�����10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[��������] [varchar](50) NOT NULL default '',
	[�����] [varchar](80) NOT NULL default '',
	[����_�����] [varchar](80) NOT NULL default '',
	[�������] [varchar](30) NOT NULL default '',
	[�_����] [char](20) NOT NULL default '',
	[�_����] [char](20) NOT NULL default '',
	[����] [varchar](80) NOT NULL default '',
	[�����] [varchar](30) NOT NULL default '',
	[���] [char](10) NOT NULL default '',
	[���] [char](10) NOT NULL default '',
	[���] [char](12) NOT NULL default '',
	[����] [char](8) NOT NULL default '',
	[�����] [char](5) NOT NULL default '',
	[����_���] [varchar](60) NOT NULL default '')

	GO
	
create trigger [dbo].[ti_�����]
on [dbo].[�����]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(�������) from �����
    update �����    set  �������=@maxPor+1      from �����, inserted
          where  �����.�����=inserted.�����
          and inserted.�������<1

GO
print '�����'
go
-----------

CREATE TABLE [dbo].[����](
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	[���������] int  NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[������10] [char](10) NOT NULL,
 CONSTRAINT [PK_����_1] PRIMARY KEY CLUSTERED 
(
	[���] ASC,
	[�����] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
----------
GO
print '����'
go

CREATE TABLE [dbo].[�������](
	[������] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[������] [varchar](50) NOT NULL default '',
	[����] [varchar](50) NOT NULL default '')

--------------
GO
print '�������'
go


--create trigger [dbo].[ti_�������]
--on [dbo].[�������]
--  for INSERT
-- as
--declare @������ uniqueidentifier
--declare @������  uniqueidentifier
 
--select @������ = inserted.������,
--       @������ = inserted.������
--  from inserted

  

--delete from ������_������� 
--where ������= @������ and ������ =@������



--insert into ������_������� (������, ������)
--values ( @������, @������)

--GO

--create  trigger [dbo].[ti_�����������]
--on [dbo].[�����������]
--  for INSERT
-- as


--declare @������ uniqueidentifier
--declare @������  uniqueidentifier
 
--select @������ = inserted.������,
--       @������ = inserted.������
--  from inserted

--delete from ������_�������
--where ������ =@������ and ������=@������
  

--insert into ������_������� (������, ������)
--values ( @������, @������)
--GO
