use domofon14
GO

CREATE TABLE [dbo].[годы](
	[год] [int] NOT NULL PRIMARY KEY CLUSTERED
	);

GO

insert into годы (год) values (2011);
insert into годы (год) values (2012);
insert into годы (год) values (2013);
insert into годы (год) values (2014);
insert into годы (год) values (2015);
insert into годы (год) values (2016);
insert into годы (год) values (2017);
insert into годы (год) values (2018);
insert into годы (год) values (2019);
insert into годы (год) values (2020);
insert into годы (год) values (2021);
insert into годы (год) values (2022);

print 'годы';
go

CREATE TABLE [dbo].[месяцы](
	[месяц] [int] NOT NULL PRIMARY KEY CLUSTERED ,
	[наимен] [char](10) NOT NULL
	);
 

GO

insert into месяцы (месяц, наимен)
values (1, 'январь');

insert into месяцы (месяц, наимен)
values (2, 'февраль');

insert into месяцы (месяц, наимен)
values (3, 'март');

insert into месяцы (месяц, наимен)
values (4, 'апрель');

insert into месяцы (месяц, наимен)
values (5, 'май');

insert into месяцы (месяц, наимен)
values (6, 'июнь');

insert into месяцы (месяц, наимен)
values (7, 'июль');


insert into месяцы (месяц, наимен)
values (8, 'август');

insert into месяцы (месяц, наимен)
values (9, 'сентябрь');


insert into месяцы (месяц, наимен)
values (10, 'октябрь');

insert into месяцы (месяц, наимен)
values (11, 'ноябрь');

insert into месяцы (месяц, наимен)
values (12, 'декабрь');

GO
print 'месяцы';

-----------------

CREATE TABLE [dbo].[del_оплаты](
    оплата uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[номер] [int] NOT NULL default 0,
	клиент  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	сотрудник uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[удалена] [datetime] NOT NULL  DEFAULT (getdate()),
	[дата] [date] NOT NULL  DEFAULT (getdate())
	) ;
GO
print 'del_оплаты';
go
---------------

CREATE TABLE [dbo].[del_оплачено](
	[код] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	оплата uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата] [datetime] NOT NULL DEFAULT (getdate())
	);
 
 print 'del_оплачено';
 go
----------------
CREATE TABLE [dbo].[виды_оплат](
	[вид_оплаты] [uniqueidentifier] NOT NULL DEFAULT (newid()) PRIMARY KEY,
	[наимен] [varchar](50) NOT NULL DEFAULT (' '),
	[порядок] [int] NOT NULL DEFAULT ((0))
	)


GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[виды_оплат] ([вид_оплаты], [наимен], [порядок]) VALUES (N'3ac44089-9a8f-4c6a-9bce-5114cdd9f914', N'Банк', 3)
GO
INSERT [dbo].[виды_оплат] ([вид_оплаты], [наимен], [порядок]) VALUES (N'4e620413-ebf5-4d69-be40-5627850f5215', N'Наличными', 1)
GO
INSERT [dbo].[виды_оплат] ([вид_оплаты], [наимен], [порядок]) VALUES (N'70a88bef-c36b-4b82-a032-c743456fe2f2', N'Карточка', 2)
GO
print 'виды_оплат';
 go


CREATE TABLE [dbo].[виды_услуг](
     вид_услуги uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[наимен] [varchar](50) NOT NULL default ' ',
	[порядок] [int] NOT NULL default 0
	);
 
print 'виды_услуг';
GO

----------

CREATE TABLE [dbo].[возврат](
	[код] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	оплата uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( )
	);
 
print 'возврат';

GO

CREATE TABLE [dbo].[воз_работы](
	[код] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[оплата] [uniqueidentifier] NOT NULL,
	[работа] [uniqueidentifier] NOT NULL,
	[сумма] [int] NOT NULL default 0)

GO
print 'воз_работы';

-------------


CREATE TABLE [dbo].[дома](
дом uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	улица uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[номер] [int] NOT NULL default 0,
	[корпус] [char](10) NOT NULL default ' ',
	[изменен] [datetime] NOT NULL DEFAULT (getdate())
	);
 
print 'дома';
GO
-----------

CREATE TABLE [dbo].[звонки](
	[звонок] [uniqueidentifier] NOT NULL PRIMARY KEY CLUSTERED ,
	[клиент] [uniqueidentifier] NOT NULL,
	[дата] [datetime] NOT NULL DEFAULT (getdate()),
	[прим] [varchar](50) NOT NULL DEFAULT ('')
	);
 

print 'звонки';
GO
----------

CREATE TABLE [dbo].[клиенты](
    клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[фамилия] [char](30) NOT NULL default ' ',
	[имя] [char](30) NOT NULL default ' ',
	[отчество] [char](30) NOT NULL default ' ',
    дом uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[квартира] [int] NOT NULL default 0,
	[фио]  AS (((((ltrim(rtrim([фамилия]))+' ')+left(rtrim(ltrim([имя])),(1)))+'.')+left(rtrim(ltrim([отчество])),(1)))+'.'),
	[прим] [varchar](50) NOT NULL default ' ',
	[подъезд] [int] NOT NULL default 0,
	[телефон] [varchar](50) NOT NULL default ' ',
	[ввод] [int] NOT NULL default 0
	);
 
print 'клиенты';
GO

----------

CREATE TABLE [dbo].[льготы](
    льгота  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата_с] [datetime] NOT NULL DEFAULT (getdate()),
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[процент] [int] NOT NULL default 100
	);
 
print 'льготы';
GO


-------------

CREATE TABLE [dbo].[начало](
	[дата] [datetime] NOT NULL PRIMARY KEY CLUSTERED
	);
 
print 'начало';
GO

------------


CREATE TABLE [dbo].[опл_работы](
	[оплата] [uniqueidentifier] NOT NULL,
	[работа] [uniqueidentifier] NOT NULL,
	[стоимость] [int] NOT NULL default 0,
	[мастер] [uniqueidentifier] NOT NULL,
	[ст_материалов] [int] NOT NULL default 0,
	[задание] [uniqueidentifier] NOT NULL PRIMARY KEY CLUSTERED,
	[номер] [int] NOT NULL default 0
	);
 
print 'опл_работы';
GO

--ALTER TABLE [dbo].[опл_работы]  WITH CHECK ADD  CONSTRAINT [FK_опл_работы_оплаты] FOREIGN KEY([оплата])
--REFERENCES [dbo].[оплаты] ([оплата])
--ON DELETE CASCADE
--GO

--ALTER TABLE [dbo].[опл_работы] CHECK CONSTRAINT [FK_опл_работы_оплаты]
--GO

--ALTER TABLE [dbo].[опл_работы]  WITH CHECK ADD  CONSTRAINT [FK_опл_работы_работы] FOREIGN KEY([работа])
--REFERENCES [dbo].[работы] ([работа])
--GO

--ALTER TABLE [dbo].[опл_работы] CHECK CONSTRAINT [FK_опл_работы_работы]
--GO

--ALTER TABLE [dbo].[опл_работы]  WITH CHECK ADD  CONSTRAINT [FK_опл_работы_сотрудники] FOREIGN KEY([мастер])
--REFERENCES [dbo].[сотрудники] ([сотрудник])
--GO

--ALTER TABLE [dbo].[опл_работы] CHECK CONSTRAINT [FK_опл_работы_сотрудники]
--GO



---------------


CREATE TABLE [dbo].[оплаты](
    оплата  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[номер] [int] NOT NULL default 0,
	клиент  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата] [date] NOT NULL DEFAULT (getdate()),
	сотрудник  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	вид_оплаты  uniqueidentifier NOT NULL default '4e620413-ebf5-4d69-be40-5627850f5215'
	);
 
print 'оплаты';
GO




---------------

CREATE TABLE [dbo].[оплачено](
	[код] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	оплата  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL default 0,
	услуга  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дней] [int] NOT NULL default 0,
	[длина_мес] [int] NOT NULL default 0,
	[цена] [int] NOT NULL default 0
	);
print 'оплачено';
GO



------------------


CREATE TABLE [dbo].[отключения](
    отключение uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата_с] [datetime] NOT NULL DEFAULT (getdate()),
	[дата_по] [datetime] NULL,
	[прим] [varchar](50) NOT NULL default ' ',
	мастер uniqueidentifier NOT NULL DEFAULT NEWID ( )
	);
 
print 'отключения';
GO
----------------


CREATE TABLE [dbo].[повторы](
	подключение uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата_с] [datetime] NOT NULL DEFAULT (getdate()),
	[прим] [varchar](50) NOT NULL default ' ',
	мастер uniqueidentifier NOT NULL DEFAULT NEWID ( )
	);

print 'повторы';
GO
---------------

CREATE TABLE [dbo].[подключения](
    подключение uniqueidentifier NOT NULL DEFAULT NEWID ( )  PRIMARY KEY CLUSTERED,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата_с] [datetime] NOT NULL DEFAULT (getdate()),
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[номер_дог] [char](20) NOT NULL default ' ',
	[дата_дог] [datetime] NOT NULL DEFAULT (getdate()),
	[номер_пп] [int] NOT NULL default 0,
	мастер uniqueidentifier NOT NULL DEFAULT NEWID ( )
 );

GO

print 'подключения';
GO

-----------------

CREATE TABLE [dbo].[поселки](
    поселок uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default ' ',
	[порядок] [int] NOT NULL default 0
	);

GO





---------------------

CREATE TABLE [dbo].[предупреждения](
    предупреждение uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[дата] [datetime] NOT NULL DEFAULT getdate(),
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) 
	)
	print 'предупреждения';
GO
--------------

CREATE TABLE [dbo].[примечания](
    услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[прим] [varchar](50) NOT NULL DEFAULT (' ') ,
 CONSTRAINT [PK_примечания] PRIMARY KEY CLUSTERED 
(
	[услуга] ASC,
	[клиент] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
go
print 'примечания';
go
------------------------------

CREATE TABLE [dbo].[простои](
    простой uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[дата_с] [datetime] NOT NULL DEFAULT getdate(),
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) 
)
print 'простои';
--------------

CREATE TABLE [dbo].[раб_дней](
    клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[год] [int] NOT NULL,
	[месяц] [int] NOT NULL,
	[дней] [int] NOT NULL default 0,
	[прим] [varchar](50) NOT NULL default '',
 CONSTRAINT [PK_раб_дней] PRIMARY KEY CLUSTERED 
(
	[клиент] ASC,
	[услуга] ASC,
	[год] ASC,
	[месяц] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
go
print 'раб_дней';
GO
------------------

CREATE TABLE [dbo].[работы](
    работа uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[стоимость] int NOT NULL default 0,
	[ст_материалов] int  NOT NULL  default 0,
	[прейскурант] [varchar](50) NOT NULL default '')

	print 'работы';
GO

---------------

CREATE TABLE [dbo].[сотрудники](
    сотрудник uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[фамилия] [varchar](50) NOT NULL default '',
	[имя] [varchar](50) NOT NULL default '',
	[отчество] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[прим] [varchar](50) NOT NULL default '',
	[адрес] [varchar](50) NOT NULL default '',
	[телефон] [varchar](50) NOT NULL default '',
	[фото] [varchar](50) NOT NULL default '',
	[дата_рож] [datetime] NULL,
	[фио]  AS (((((ltrim(rtrim([фамилия]))+' ')+left(rtrim(ltrim([имя])),(1)))+'.')+left(rtrim(ltrim([отчество])),(1)))+'.'),
	[принят] [datetime] NULL,
	[уволен] [datetime] NULL,
	[должность] [varchar](50) NOT NULL default '',
	[кассир] [bit] NOT NULL default 1);
	go

	print 'сотрудники';
GO

-----------------

CREATE TABLE [dbo].[улицы](
    улица uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	поселок uniqueidentifier NOT NULL DEFAULT NEWID ( ) 
)
print 'улицы';
GO


------------


CREATE TABLE [dbo].[услуги](
    услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	вид_услуги uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[обозначение] [char](10) NOT NULL default '');

	print 'услуги';
GO

--------------

CREATE TABLE [dbo].[услуги_клиента](
    клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	 услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
 CONSTRAINT [PK_услуги_клиента] PRIMARY KEY CLUSTERED 
(
	[клиент] ASC,
	[услуга] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

print 'услуги_клиента';

GO
---------------

CREATE TABLE [dbo].[филиалы](
    филиал uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[адрес] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[телефон] [varchar](50) NOT NULL default '');

	print 'филиалы';
GO


--------------------

CREATE TABLE [dbo].[фирмы](
    фирма uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[название] [varchar](50) NOT NULL default '',
	[адрес] [varchar](80) NOT NULL default '',
	[факт_адрес] [varchar](80) NOT NULL default '',
	[телефон] [varchar](30) NOT NULL default '',
	[р_счет] [char](20) NOT NULL default '',
	[к_счет] [char](20) NOT NULL default '',
	[банк] [varchar](80) NOT NULL default '',
	[город] [varchar](30) NOT NULL default '',
	[бик] [char](10) NOT NULL default '',
	[код] [char](10) NOT NULL default '',
	[инн] [char](12) NOT NULL default '',
	[окпо] [char](8) NOT NULL default '',
	[оконх] [char](5) NOT NULL default '',
	[груз_пол] [varchar](60) NOT NULL default '');
	go 

	print 'фирмы';

	GO
	
-----------

CREATE TABLE [dbo].[цены](
	[год] [int] NOT NULL,
	[месяц] [int] NOT NULL,
	[стоимость] int  NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
 CONSTRAINT [PK_цены_1] PRIMARY KEY CLUSTERED 
(
	[год] ASC,
	[месяц] ASC,
	[услуга] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

print 'цены';
----------
GO

CREATE TABLE [dbo].[шаблоны](
	[шаблон] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[наимен] [varchar](50) NOT NULL default '',
	[путь] [varchar](50) NOT NULL default '');

	print 'шаблоны';

--------------
GO
--create trigger [dbo].[ti_повторы]
--on [dbo].[повторы]
--  for INSERT
-- as
--declare @клиент uniqueidentifier
--declare @услуга  uniqueidentifier
 
--select @клиент = inserted.клиент,
--       @услуга = inserted.услуга
--  from inserted

  

--delete from услуги_клиента 
--where услуга= @услуга and клиент =@клиент



--insert into услуги_клиента (клиент, услуга)
--values ( @клиент, @услуга)

--GO

--create  trigger [dbo].[ti_подключения]
--on [dbo].[подключения]
--  for INSERT
-- as


--declare @клиент uniqueidentifier
--declare @услуга  uniqueidentifier
 
--select @клиент = inserted.клиент,
--       @услуга = inserted.услуга
--  from inserted

--delete from услуги_клиента
--where услуга =@услуга and клиент=@клиент
  

--insert into услуги_клиента (клиент, услуга)
--values ( @клиент, @услуга)
--GO
