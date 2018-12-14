

CREATE TABLE [dbo].[годы5](
	[год] [int] NOT NULL PRIMARY KEY
);
GO

insert into годы5 (год) values (2011);
insert into годы5 (год) values (2012);
insert into годы5 (год) values (2013);
insert into годы5 (год) values (2014);
insert into годы5 (год) values (2015);
insert into годы5 (год) values (2016);
insert into годы5 (год) values (2017);
insert into годы5 (год) values (2018);
insert into годы5 (год) values (2019);
insert into годы5 (год) values (2020);
insert into годы5 (год) values (2021);
insert into годы5 (год) values (2022);

go

print 'годы5';
go

CREATE TABLE [dbo].[мес€цы5](
	[мес€ц] [int] NOT NULL PRIMARY KEY CLUSTERED ,
	[наимен] [char](10) NOT NULL
	);
 

GO

insert into мес€цы5 (мес€ц, наимен)
values (1, '€нварь');

insert into мес€цы5 (мес€ц, наимен)
values (2, 'февраль');

insert into мес€цы5 (мес€ц, наимен)
values (3, 'март');

insert into мес€цы5 (мес€ц, наимен)
values (4, 'апрель');

insert into мес€цы5 (мес€ц, наимен)
values (5, 'май');

insert into мес€цы5 (мес€ц, наимен)
values (6, 'июнь');

insert into мес€цы5 (мес€ц, наимен)
values (7, 'июль');


insert into мес€цы5 (мес€ц, наимен)
values (8, 'август');

insert into мес€цы5 (мес€ц, наимен)
values (9, 'сент€брь');


insert into мес€цы5 (мес€ц, наимен)
values (10, 'окт€брь');

insert into мес€цы5 (мес€ц, наимен)
values (11, 'но€брь');

insert into мес€цы5 (мес€ц, наимен)
values (12, 'декабрь');

GO
print 'мес€цы5';

go
CREATE TABLE [dbo].[виды_оплат5](
	[вид_оплаты] [uniqueidentifier] NOT NULL DEFAULT (newid()) PRIMARY KEY,
	[наимен] [varchar](50) NOT NULL DEFAULT (' '),
	[пор€док] [int] NOT NULL DEFAULT ((0))
	)


GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[виды_оплат5] ([вид_оплаты], [наимен], [пор€док]) VALUES (N'3ac44089-9a8f-4c6a-9bce-5114cdd9f914', N'Ѕанк', 3)
GO
INSERT [dbo].[виды_оплат5] ([вид_оплаты], [наимен], [пор€док]) VALUES (N'4e620413-ebf5-4d69-be40-5627850f5215', N'Ќаличными', 1)
GO
INSERT [dbo].[виды_оплат5] ([вид_оплаты], [наимен], [пор€док]) VALUES (N'70a88bef-c36b-4b82-a032-c743456fe2f2', N' арточка', 2)
GO
print 'виды_оплат5';
 go

 CREATE TABLE [dbo].[виды_услуг5](
     вид_услуги uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[наимен] [varchar](50) NOT NULL default ' ',
	[пор€док] [int] NOT NULL default 0
	);
INSERT [dbo].[виды_услуг5] ([вид_услуги], [наимен], [пор€док]) VALUES (N'0142F249-72C9-413C-9BEA-26584C4F1F84', N'ƒомофон', 2)
GO
INSERT [dbo].[виды_услуг5] ([вид_услуги], [наимен], [пор€док]) VALUES (N'51900933-2903-4346-A96E-EF1675331573', N' абельное телевидение', 1)
GO
 
print 'виды_услуг5';
GO

CREATE TABLE [dbo].[поселки5](
    поселок uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default ' ',
	[пор€док] [int] NOT NULL default 0
	);

GO

INSERT поселки5 (поселок, наимен, пор€док) VALUES (N'9396726F-DFDF-48A1-879B-C65C9A68FA54', N'÷ентральный', 1);
INSERT поселки5 (поселок, наимен, пор€док) VALUES (N'5151D388-D446-4F8D-9BB4-3C871EC8C11C', N'—оветский', 2);
INSERT поселки5 (поселок, наимен, пор€док) VALUES (N'517148BF-B864-40AB-89DE-379FAE875EEB', N'Ќовоберезовский', 3);
INSERT поселки5 (поселок, наимен, пор€док) VALUES (N'C1BE3B08-D345-433B-8A08-F080B8AE2E99', N' едровка', 4);
INSERT поселки5 (поселок, наимен, пор€док) VALUES (N'C999717D-72D5-462A-9CA5-03744461237F', N'ћонетный', 5);
INSERT поселки5 (поселок, наимен, пор€док) VALUES (N'C292BF6E-DA13-486C-AF57-3FF40705582D', N'Ћосинка', 6);

GO
 
print 'поселки';
GO