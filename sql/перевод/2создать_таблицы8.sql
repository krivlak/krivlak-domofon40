use domofon8
GO

--CREATE TABLE [dbo].[����](
--	[���] [int] NOT NULL PRIMARY KEY
-- )
--GO

--insert into ���� (���) values (2011),(2012),(2013),(2014),(2015),(2016),(2017),(2018),(2019),(2020),(2021),(2022);




--print '����';
--go

--CREATE TABLE [dbo].[������](
--	[�����] [int] NOT NULL PRIMARY KEY ,
--	[������] [char](10) NOT NULL)


--GO

--insert into ������ (�����, ������) values (1, '������'), (2, '�������'), (3, '����'),(4, '������'),(5, '���'),(6, '����'),(7, '����'),(8, '������'),(9, '��������'),(10, '�������'),(11, '������'),(12, '�������');

--GO
--print '������';






-------------------

CREATE TABLE [dbo].[del_������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( )  PRIMARY KEY CLUSTERED ,
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	��������� uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[���������10] [char](10) NOT NULL,
	[�������] [datetime] NOT NULL DEFAULT getdate(),
	[����] [date] NOT NULL
	)
GO

print 'del_������';
---------------


CREATE TABLE [dbo].[del_��������](
	[���] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����] [datetime] NOT NULL DEFAULT getdate()
	)
 
GO
print 'del_��������';
----------------


CREATE TABLE [dbo].[����_�����](
     ���_������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[���_������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0,
	)
GO

print '����_�����';

----------

CREATE TABLE [dbo].[�������](
	[���] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL,
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL
	)
GO
print '�������';
-------------

CREATE TABLE [dbo].[���_������](
	[���] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[������] [uniqueidentifier] NOT NULL,
	[������10] [char](10) NOT NULL,
	[������] [uniqueidentifier] NOT NULL,
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL default 0)

GO
print '���_������';
-------------

CREATE TABLE [dbo].[����](
��� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[���10] [char](10) NOT NULL,
	����� uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[�����10] [char](10) NOT NULL,
	[�����] [int] NOT NULL default 0,
	[������] [char](10) NOT NULL default ' ',
	[�������] [datetime] NOT NULL DEFAULT (getdate())
	)
GO
print '����';
-----------

CREATE TABLE [dbo].[������](
	[������] [uniqueidentifier] NOT NULL default NEWID ( ) PRIMARY KEY  ,
	[������10] [char](10) NOT NULL,
	[������] [uniqueidentifier] NOT NULL default NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����] [datetime] NOT NULL DEFAULT (getdate()),
	[����] [varchar](50) NOT NULL DEFAULT ('')
	)
 
GO
print '������';
----------

CREATE TABLE [dbo].[�������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[������10] [char](10) NOT NULL,
	[�������] [char](30) NOT NULL default ' ',
	[���] [char](30) NOT NULL default ' ',
	[��������] [char](30) NOT NULL default ' ',
    ��� uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[���10] [char](10) NOT NULL,
	[��������] [int] NOT NULL default 0,
	[���]  AS (((((ltrim(rtrim([�������]))+' ')+left(rtrim(ltrim([���])),(1)))+'.')+left(rtrim(ltrim([��������])),(1)))+'.'),
	[����] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0,
	[�������] [varchar](50) NOT NULL default ' ',
	[����] [int] NOT NULL default 0
	)
GO
print '�������';

GO
----------

CREATE TABLE [dbo].[������](
    ������  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL DEFAULT (getdate()),
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL
	
	)
GO

print '������';
-------------

CREATE TABLE [dbo].[������](
	[����] [datetime] NOT NULL PRIMARY KEY CLUSTERED
	)
 
GO
print '������';
--------------


CREATE TABLE [dbo].[���_������](
	�������  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[�������10] [char](10) NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[���������] [decimal](10, 2) NOT NULL default 0,
	[��������] [decimal](10, 2) NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[��_����������] [decimal](10, 2) NOT NULL default 0,
	����� int not null  default 0
	)
 
GO
print '���_������';
---------------


CREATE TABLE [dbo].[������](
    ������  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����] [date] NOT NULL DEFAULT getdate(),
	���������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[���������10] [char](10) NOT NULL,
	���_������ uniqueidentifier NOT NULL DEFAULT '4E620413-EBF5-4D69-BE40-5627850F5215'
	)
 
GO

print '������';

---------------

CREATE TABLE [dbo].[��������](
	[���] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[�����] [int] NOT NULL default 0,
	[���] [int] NOT NULL default 0,
	[�����] [int] NOT NULL default 0,
	������  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����] [int] NOT NULL default 0,
	[�����_���] [int] NOT NULL default 0,
	[����] [int] NOT NULL default 0
	)

 GO

print '��������';

------------------


CREATE TABLE [dbo].[����������](
    ���������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[����������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[����_�] [datetime] NOT NULL  DEFAULT getdate(),
	[����_��] [datetime] NULL,
	[����] [varchar](50) NOT NULL default ' ',
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL
	)

 GO
print '����������';
----------------


CREATE TABLE [dbo].[�������](
	����������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[�����������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL DEFAULT getdate(),
	[����] [varchar](50) NOT NULL default ' ',
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL
	)
 
GO
print '�������';
---------------

CREATE TABLE [dbo].[�����������](
    ����������� uniqueidentifier NOT NULL DEFAULT NEWID ( )  PRIMARY KEY CLUSTERED,
	[���10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL  DEFAULT getdate() ,
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL,
	[�����_���] [char](20) NOT NULL default ' ',
	[����_���] [datetime] NOT NULL  DEFAULT getdate(),
	[�����_��] [int] NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[������10] [char](10) NOT NULL
 )

GO

print '�����������';
-----------------

CREATE TABLE [dbo].[�������](
    ������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[�������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0
	)

GO


print '�������';

GO
---------------------

CREATE TABLE [dbo].[��������������](
    �������������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[��������������10] [char](10) NOT NULL,
	[����] [datetime] NOT NULL DEFAULT getdate(),
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL)
GO
print '��������������';
--------------

CREATE TABLE [dbo].[����������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
	[����] [varchar](50) NOT NULL DEFAULT (' ') ,
 CONSTRAINT [PK_����������] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

------------------------------

CREATE TABLE [dbo].[�������](
    ������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[�������10] [char](10) NOT NULL ,
	[������] [varchar](50) NOT NULL default '',
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
	[����_�] [datetime] NOT NULL DEFAULT getdate(),
	[����_��] [datetime] NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL)

print '�������';
--------------

CREATE TABLE [dbo].[���_����](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
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
print '���_����';
------------------

CREATE TABLE [dbo].[������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[���������] int NOT NULL default 0,
	[��_����������] int  NOT NULL  default 0,
	[�����������] [varchar](50) NOT NULL default '')

GO



print '������';
GO


---------------

CREATE TABLE [dbo].[����������](
    ��������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
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

print '����������';
-----------------

CREATE TABLE [dbo].[�����](
    ����� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[�����10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[�������10] [char](10) NOT NULL)
GO

print '�����';

------------


CREATE TABLE [dbo].[������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	���_������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[���_������10] [char](10) NOT NULL,
	[�����������] [char](10) NOT NULL default '')
GO

print '������';
--------------

CREATE TABLE [dbo].[������_�������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
	 ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
 CONSTRAINT [PK_������_�������] PRIMARY KEY CLUSTERED 
(
	[������] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
print '������_�������';
---------------

CREATE TABLE [dbo].[�������](
    ������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������10] [char](10) NOT NULL,
	[������] [varchar](50) NOT NULL default '',
	[�����] [varchar](50) NOT NULL default '',
	[�������] [int] NOT NULL default 0,
	[�������] [varchar](50) NOT NULL default '')
GO

print '�������';

--------------------

CREATE TABLE [dbo].[�����](
    ����� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
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
	
	print '�����';
-----------

CREATE TABLE [dbo].[����](
	[���] [int] NOT NULL,
	[�����] [int] NOT NULL,
	[���������] int  NOT NULL default 0,
	������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[������10] [char](10) NOT NULL,
 CONSTRAINT [PK_����_1] PRIMARY KEY CLUSTERED 
(
	[���] ASC,
	[�����] ASC,
	[������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

print '����';
----------
GO

CREATE TABLE [dbo].[�������](
	[������] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[������] [varchar](50) NOT NULL default '',
	[����] [varchar](50) NOT NULL default '')

--------------
GO
print '�������';