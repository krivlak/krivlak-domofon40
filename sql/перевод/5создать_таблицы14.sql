use domofon14
GO

CREATE TABLE [dbo].[����](
	[���] [int] NOT NULL PRIMARY KEY CLUSTERED
	);

GO

insert into ���� (���) values (2011);
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

print '����';
go

CREATE TABLE [dbo].[������](
	[�����] [int] NOT NULL PRIMARY KEY CLUSTERED ,
	[������] [char](10) NOT NULL
	);
 

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
print '������';

-----------------

CREATE TABLE [dbo].[del_������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[�����] [int] NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	��������� uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�������] [datetime] NOT NULL  DEFAULT (getdate()),
	[����] [date] NOT NULL  DEFAULT (getdate())
	) ;
GO
print 'del_������';
go
---------------

CREATE TABLE [dbo].[del_��������](
	[���] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����] [datetime] NOT NULL DEFAULT (getdate())
	);
 
 print 'del_��������';
 go
----------------
CREATE TABLE [dbo].[����_�����](
	[���_������] [uniqueidentifier] NOT NULL DEFAULT (newid()) PRIMARY KEY,
	[������] [varchar](50) NOT NULL DEFAULT (' '),
	[�������] [int] NOT NULL DEFAULT ((0))
	)


GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[����_�����] ([���_������], [������], [�������]) VALUES (N'3ac44089-9a8f-4c6a-9bce-5114cdd9f914', N'����', 3)
GO
INSERT [dbo].[����_�����] ([���_������], [������], [�������]) VALUES (N'4e620413-ebf5-4d69-be40-5627850f5215', N'���������', 1)
GO
INSERT [dbo].[����_�����] ([���_������], [������], [�������]) VALUES (N'70a88bef-c36b-4b82-a032-c743456fe2f2', N'��������', 2)
GO
print '����_�����';
 go


CREATE TABLE [dbo].[����_�����](
     ���_������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[������] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0
	);
 
print '����_�����';
GO

----------

CREATE TABLE [dbo].[�������](
	[���] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( )
	);
 
print '�������';

GO

CREATE TABLE [dbo].[���_������](
	[���] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[������] [uniqueidentifier] NOT NULL,
	[������] [uniqueidentifier] NOT NULL,
	[�����] [int] NOT NULL default 0)

GO
print '���_������';

-------------


CREATE TABLE [dbo].[����](
��� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	����� uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�����] [int] NOT NULL default 0,
	[������] [char](10) NOT NULL default ' ',
	[�������] [datetime] NOT NULL DEFAULT (getdate())
	);
 
print '����';
GO
-----------

CREATE TABLE [dbo].[������](
	[������] [uniqueidentifier] NOT NULL PRIMARY KEY CLUSTERED ,
	[������] [uniqueidentifier] NOT NULL,
	[����] [datetime] NOT NULL DEFAULT (getdate()),
	[����] [varchar](50) NOT NULL DEFAULT ('')
	);
 

print '������';
GO
----------

CREATE TABLE [dbo].[�������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[�������] [char](30) NOT NULL default ' ',
	[���] [char](30) NOT NULL default ' ',
	[��������] [char](30) NOT NULL default ' ',
    ��� uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[��������] [int] NOT NULL default 0,
	[���]  AS (((((ltrim(rtrim([�������]))+' ')+left(rtrim(ltrim([���])),(1)))+'.')+left(rtrim(ltrim([��������])),(1)))+'.'),
	[����] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0,
	[�������] [varchar](50) NOT NULL default ' ',
	[����] [int] NOT NULL default 0
	);
 
print '�������';
GO

----------

CREATE TABLE [dbo].[������](
    ������  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����_�] [datetime] NOT NULL DEFAULT (getdate()),
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�������] [int] NOT NULL default 100
	);
 
print '������';
GO


-------------

CREATE TABLE [dbo].[������](
	[����] [datetime] NOT NULL PRIMARY KEY CLUSTERED
	);
 
print '������';
GO

------------


CREATE TABLE [dbo].[���_������](
	[������] [uniqueidentifier] NOT NULL,
	[������] [uniqueidentifier] NOT NULL,
	[���������] [int] NOT NULL default 0,
	[������] [uniqueidentifier] NOT NULL,
	[��_����������] [int] NOT NULL default 0,
	[�������] [uniqueidentifier] NOT NULL PRIMARY KEY CLUSTERED,
	[�����] [int] NOT NULL default 0
	);
 
print '���_������';
GO

--ALTER TABLE [dbo].[���_������]  WITH CHECK ADD  CONSTRAINT [FK_���_������_������] FOREIGN KEY([������])
--REFERENCES [dbo].[������] ([������])
--ON DELETE CASCADE
--GO

--ALTER TABLE [dbo].[���_������] CHECK CONSTRAINT [FK_���_������_������]
--GO

--ALTER TABLE [dbo].[���_������]  WITH CHECK ADD  CONSTRAINT [FK_���_������_������] FOREIGN KEY([������])
--REFERENCES [dbo].[������] ([������])
--GO

--ALTER TABLE [dbo].[���_������] CHECK CONSTRAINT [FK_���_������_������]
--GO

--ALTER TABLE [dbo].[���_������]  WITH CHECK ADD  CONSTRAINT [FK_���_������_����������] FOREIGN KEY([������])
--REFERENCES [dbo].[����������] ([���������])
--GO

--ALTER TABLE [dbo].[���_������] CHECK CONSTRAINT [FK_���_������_����������]
--GO



---------------


CREATE TABLE [dbo].[������](
    ������  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[�����] [int] NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����] [date] NOT NULL DEFAULT (getdate()),
	���������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	���_������  uniqueidentifier NOT NULL default '4e620413-ebf5-4d69-be40-5627850f5215'
	);
 
print '������';
GO




---------------

CREATE TABLE [dbo].[��������](
	[���] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����] [int] NOT NULL default 0,
	[�����_���] [int] NOT NULL default 0,
	[����] [int] NOT NULL default 0
	);
print '��������';
GO



------------------


CREATE TABLE [dbo].[����������](
    ���������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����_�] [datetime] NOT NULL DEFAULT (getdate()),
	[����_��] [datetime] NULL,
	[����] [varchar](50) NOT NULL default ' ',
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( )
	);
 
print '����������';
GO
----------------


CREATE TABLE [dbo].[�������](
	����������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����_�] [datetime] NOT NULL DEFAULT (getdate()),
	[����] [varchar](50) NOT NULL default ' ',
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( )
	);

print '�������';
GO
---------------

CREATE TABLE [dbo].[�����������](
    ����������� uniqueidentifier NOT NULL DEFAULT NEWID ( )  PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����_�] [datetime] NOT NULL DEFAULT (getdate()),
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�����_���] [char](20) NOT NULL default ' ',
	[����_���] [datetime] NOT NULL DEFAULT (getdate()),
	[�����_��] [int] NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( )
 );

GO

print '�����������';
GO

-----------------

CREATE TABLE [dbo].[�������](
    ������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0
	);

GO





---------------------

CREATE TABLE [dbo].[��������������](
    �������������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[����] [datetime] NOT NULL DEFAULT getdate(),
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) 
	)
	print '��������������';
GO
--------------

CREATE TABLE [dbo].[����������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[����] [varchar](50) NOT NULL DEFAULT (' ') ,
 CONSTRAINT [PK_����������] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
go
print '����������';
go
------------------------------

CREATE TABLE [dbo].[�������](
    ������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default '',
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[����_�] [datetime] NOT NULL DEFAULT getdate(),
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) 
)
print '�������';
--------------

CREATE TABLE [dbo].[���_����](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
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
) ON [PRIMARY];
go
print '���_����';
GO
------------------

CREATE TABLE [dbo].[������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[���������] int NOT NULL default 0,
	[��_����������] int  NOT NULL  default 0,
	[�����������] [varchar](50) NOT NULL default '')

	print '������';
GO

---------------

CREATE TABLE [dbo].[����������](
    ��������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
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
	[������] [bit] NOT NULL default 1);
	go

	print '����������';
GO

-----------------

CREATE TABLE [dbo].[�����](
    ����� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default '',
	������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) 
)
print '�����';
GO


------------


CREATE TABLE [dbo].[������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	���_������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[�����������] [char](10) NOT NULL default '');

	print '������';
GO

--------------

CREATE TABLE [dbo].[������_�������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	 ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
 CONSTRAINT [PK_������_�������] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

print '������_�������';

GO
---------------

CREATE TABLE [dbo].[�������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default '',
	[�����] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[�������] [varchar](50) NOT NULL default '');

	print '�������';
GO


--------------------

CREATE TABLE [dbo].[�����](
    ����� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
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
	[����_���] [varchar](60) NOT NULL default '');
	go 

	print '�����';

	GO
	
-----------

CREATE TABLE [dbo].[����](
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	[���������] int  NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
 CONSTRAINT [PK_����_1] PRIMARY KEY CLUSTERED 
(
	[���] ASC,
	[�����] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

print '����';
----------
GO

CREATE TABLE [dbo].[�������](
	[������] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[������] [varchar](50) NOT NULL default '',
	[����] [varchar](50) NOT NULL default '');

	print '�������';

--------------
GO
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
