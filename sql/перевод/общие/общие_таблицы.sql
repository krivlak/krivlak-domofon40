

CREATE TABLE [dbo].[����5](
	[���] [int] NOT NULL PRIMARY KEY
);
GO

insert into ����5 (���) values (2011);
insert into ����5 (���) values (2012);
insert into ����5 (���) values (2013);
insert into ����5 (���) values (2014);
insert into ����5 (���) values (2015);
insert into ����5 (���) values (2016);
insert into ����5 (���) values (2017);
insert into ����5 (���) values (2018);
insert into ����5 (���) values (2019);
insert into ����5 (���) values (2020);
insert into ����5 (���) values (2021);
insert into ����5 (���) values (2022);

go

print '����5';
go

CREATE TABLE [dbo].[������5](
	[�����] [int] NOT NULL PRIMARY KEY CLUSTERED ,
	[������] [char](10) NOT NULL
	);
 

GO

insert into ������5 (�����, ������)
values (1, '������');

insert into ������5 (�����, ������)
values (2, '�������');

insert into ������5 (�����, ������)
values (3, '����');

insert into ������5 (�����, ������)
values (4, '������');

insert into ������5 (�����, ������)
values (5, '���');

insert into ������5 (�����, ������)
values (6, '����');

insert into ������5 (�����, ������)
values (7, '����');


insert into ������5 (�����, ������)
values (8, '������');

insert into ������5 (�����, ������)
values (9, '��������');


insert into ������5 (�����, ������)
values (10, '�������');

insert into ������5 (�����, ������)
values (11, '������');

insert into ������5 (�����, ������)
values (12, '�������');

GO
print '������5';

go
CREATE TABLE [dbo].[����_�����5](
	[���_������] [uniqueidentifier] NOT NULL DEFAULT (newid()) PRIMARY KEY,
	[������] [varchar](50) NOT NULL DEFAULT (' '),
	[�������] [int] NOT NULL DEFAULT ((0))
	)


GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[����_�����5] ([���_������], [������], [�������]) VALUES (N'3ac44089-9a8f-4c6a-9bce-5114cdd9f914', N'����', 3)
GO
INSERT [dbo].[����_�����5] ([���_������], [������], [�������]) VALUES (N'4e620413-ebf5-4d69-be40-5627850f5215', N'���������', 1)
GO
INSERT [dbo].[����_�����5] ([���_������], [������], [�������]) VALUES (N'70a88bef-c36b-4b82-a032-c743456fe2f2', N'��������', 2)
GO
print '����_�����5';
 go

 CREATE TABLE [dbo].[����_�����5](
     ���_������ uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[������] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0
	);
INSERT [dbo].[����_�����5] ([���_������], [������], [�������]) VALUES (N'0142F249-72C9-413C-9BEA-26584C4F1F84', N'�������', 2)
GO
INSERT [dbo].[����_�����5] ([���_������], [������], [�������]) VALUES (N'51900933-2903-4346-A96E-EF1675331573', N'��������� �����������', 1)
GO
 
print '����_�����5';
GO

CREATE TABLE [dbo].[�������5](
    ������� uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[������] [varchar](50) NOT NULL default ' ',
	[�������] [int] NOT NULL default 0
	);

GO

INSERT �������5 (�������, ������, �������) VALUES (N'9396726F-DFDF-48A1-879B-C65C9A68FA54', N'�����������', 1);
INSERT �������5 (�������, ������, �������) VALUES (N'5151D388-D446-4F8D-9BB4-3C871EC8C11C', N'���������', 2);
INSERT �������5 (�������, ������, �������) VALUES (N'517148BF-B864-40AB-89DE-379FAE875EEB', N'���������������', 3);
INSERT �������5 (�������, ������, �������) VALUES (N'C1BE3B08-D345-433B-8A08-F080B8AE2E99', N'��������', 4);
INSERT �������5 (�������, ������, �������) VALUES (N'C999717D-72D5-462A-9CA5-03744461237F', N'��������', 5);
INSERT �������5 (�������, ������, �������) VALUES (N'C292BF6E-DA13-486C-AF57-3FF40705582D', N'�������', 6);

GO
 
print '�������';
GO