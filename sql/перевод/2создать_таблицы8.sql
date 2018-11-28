use domofon8
GO

--CREATE TABLE [dbo].[годы](
--	[год] [int] NOT NULL PRIMARY KEY
-- )
--GO

--insert into годы (год) values (2011),(2012),(2013),(2014),(2015),(2016),(2017),(2018),(2019),(2020),(2021),(2022);




--print 'годы';
--go

--CREATE TABLE [dbo].[месяцы](
--	[месяц] [int] NOT NULL PRIMARY KEY ,
--	[наимен] [char](10) NOT NULL)


--GO

--insert into месяцы (месяц, наимен) values (1, 'январь'), (2, 'февраль'), (3, 'март'),(4, 'апрель'),(5, 'май'),(6, 'июнь'),(7, 'июль'),(8, 'август'),(9, 'сентябрь'),(10, 'октябрь'),(11, 'ноябрь'),(12, 'декабрь');

--GO
--print 'месяцы';






-------------------

CREATE TABLE [dbo].[del_оплаты](
    оплата uniqueidentifier NOT NULL DEFAULT NEWID ( )  PRIMARY KEY CLUSTERED ,
	[оплата10] [char](10) NOT NULL,
	[номер] [int] NOT NULL default 0,
	клиент  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	сотрудник uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[сотрудник10] [char](10) NOT NULL,
	[удалена] [datetime] NOT NULL DEFAULT getdate(),
	[дата] [date] NOT NULL
	)
GO

print 'del_оплаты';
---------------


CREATE TABLE [dbo].[del_оплачено](
	[код] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	оплата uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[оплата10] [char](10) NOT NULL,
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[услуга10] [char](10) NOT NULL,
	[дата] [datetime] NOT NULL DEFAULT getdate()
	)
 
GO
print 'del_оплачено';
----------------


CREATE TABLE [dbo].[виды_услуг](
     вид_услуги uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[вид_услуги10] [char](10) NOT NULL,
	[наимен] [varchar](50) NOT NULL default ' ',
	[порядок] [int] NOT NULL default 0,
	)
GO

print 'виды_услуг';

----------

CREATE TABLE [dbo].[возврат](
	[код] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	оплата uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[оплата10] [char](10) NOT NULL,
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[услуга10] [char](10) NOT NULL
	)
GO
print 'возврат';
-------------

CREATE TABLE [dbo].[воз_работы](
	[код] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[оплата] [uniqueidentifier] NOT NULL,
	[оплата10] [char](10) NOT NULL,
	[работа] [uniqueidentifier] NOT NULL,
	[работа10] [char](10) NOT NULL,
	[сумма] [int] NOT NULL default 0)

GO
print 'воз_работы';
-------------

CREATE TABLE [dbo].[дома](
дом uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[дом10] [char](10) NOT NULL,
	улица uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[улица10] [char](10) NOT NULL,
	[номер] [int] NOT NULL default 0,
	[корпус] [char](10) NOT NULL default ' ',
	[изменен] [datetime] NOT NULL DEFAULT (getdate())
	)
GO
print 'дома';
-----------

CREATE TABLE [dbo].[звонки](
	[звонок] [uniqueidentifier] NOT NULL default NEWID ( ) PRIMARY KEY  ,
	[звонок10] [char](10) NOT NULL,
	[клиент] [uniqueidentifier] NOT NULL default NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	[дата] [datetime] NOT NULL DEFAULT (getdate()),
	[прим] [varchar](50) NOT NULL DEFAULT ('')
	)
 
GO
print 'звонки';
----------

CREATE TABLE [dbo].[клиенты](
    клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[клиент10] [char](10) NOT NULL,
	[фамилия] [char](30) NOT NULL default ' ',
	[имя] [char](30) NOT NULL default ' ',
	[отчество] [char](30) NOT NULL default ' ',
    дом uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дом10] [char](10) NOT NULL,
	[квартира] [int] NOT NULL default 0,
	[фио]  AS (((((ltrim(rtrim([фамилия]))+' ')+left(rtrim(ltrim([имя])),(1)))+'.')+left(rtrim(ltrim([отчество])),(1)))+'.'),
	[прим] [varchar](50) NOT NULL default ' ',
	[подъезд] [int] NOT NULL default 0,
	[телефон] [varchar](50) NOT NULL default ' ',
	[ввод] [int] NOT NULL default 0
	)
GO
print 'клиенты';

GO
----------

CREATE TABLE [dbo].[льготы](
    льгота  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[льгота10] [char](10) NOT NULL,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	[дата_с] [datetime] NOT NULL DEFAULT (getdate()),
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[услуга10] [char](10) NOT NULL
	
	)
GO

print 'льготы';
-------------

CREATE TABLE [dbo].[начало](
	[дата] [datetime] NOT NULL PRIMARY KEY CLUSTERED
	)
 
GO
print 'начало';
--------------


CREATE TABLE [dbo].[опл_работы](
	задание  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[задание10] [char](10) NOT NULL,
	оплата  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[оплата10] [char](10) NOT NULL,
	работа  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[работа10] [char](10) NOT NULL,
	[стоимость] [decimal](10, 2) NOT NULL default 0,
	[оплачено] [decimal](10, 2) NOT NULL default 0,
	мастер  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[мастер10] [char](10) NOT NULL,
	[ст_материалов] [decimal](10, 2) NOT NULL default 0,
	номер int not null  default 0
	)
 
GO
print 'опл_работы';
---------------


CREATE TABLE [dbo].[оплаты](
    оплата  uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[оплата10] [char](10) NOT NULL,
	[номер] [int] NOT NULL default 0,
	клиент  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	[дата] [date] NOT NULL DEFAULT getdate(),
	сотрудник  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[сотрудник10] [char](10) NOT NULL,
	вид_оплаты uniqueidentifier NOT NULL DEFAULT '4E620413-EBF5-4D69-BE40-5627850F5215'
	)
 
GO

print 'оплаты';

---------------

CREATE TABLE [dbo].[оплачено](
	[код] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	оплата  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[оплата10] [char](10) NOT NULL,
	[месяц] [int] NOT NULL default 0,
	[год] [int] NOT NULL default 0,
	[сумма] [int] NOT NULL default 0,
	услуга  uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[услуга10] [char](10) NOT NULL,
	[дней] [int] NOT NULL default 0,
	[длина_мес] [int] NOT NULL default 0,
	[цена] [int] NOT NULL default 0
	)

 GO

print 'оплачено';

------------------


CREATE TABLE [dbo].[отключения](
    отключение uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED ,
	[отключение10] [char](10) NOT NULL,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	[услуга10] [char](10) NOT NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[дата_с] [datetime] NOT NULL  DEFAULT getdate(),
	[дата_по] [datetime] NULL,
	[прим] [varchar](50) NOT NULL default ' ',
	мастер uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[мастер10] [char](10) NOT NULL
	)

 GO
print 'отключения';
----------------


CREATE TABLE [dbo].[повторы](
	подключение uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[подключение10] [char](10) NOT NULL,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[услуга10] [char](10) NOT NULL,
	[дата_с] [datetime] NOT NULL DEFAULT getdate(),
	[прим] [varchar](50) NOT NULL default ' ',
	мастер uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[мастер10] [char](10) NOT NULL
	)
 
GO
print 'повторы';
---------------

CREATE TABLE [dbo].[подключения](
    подключение uniqueidentifier NOT NULL DEFAULT NEWID ( )  PRIMARY KEY CLUSTERED,
	[код10] [char](10) NOT NULL,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[клиент10] [char](10) NOT NULL,
	[дата_с] [datetime] NOT NULL  DEFAULT getdate() ,
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[услуга10] [char](10) NOT NULL,
	[номер_дог] [char](20) NOT NULL default ' ',
	[дата_дог] [datetime] NOT NULL  DEFAULT getdate(),
	[номер_пп] [int] NOT NULL default 0,
	мастер uniqueidentifier NOT NULL DEFAULT NEWID ( ),
	[мастер10] [char](10) NOT NULL
 )

GO

print 'подключения';
-----------------

CREATE TABLE [dbo].[поселки](
    поселок uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[поселок10] [char](10) NOT NULL,
	[наимен] [varchar](50) NOT NULL default ' ',
	[порядок] [int] NOT NULL default 0
	)

GO


print 'поселки';

GO
---------------------

CREATE TABLE [dbo].[предупреждения](
    предупреждение uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[предупреждение10] [char](10) NOT NULL,
	[дата] [datetime] NOT NULL DEFAULT getdate(),
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[услуга10] [char](10) NOT NULL,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[клиент10] [char](10) NOT NULL)
GO
print 'предупреждения';
--------------

CREATE TABLE [dbo].[примечания](
    услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[услуга10] [char](10) NOT NULL,
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[клиент10] [char](10) NOT NULL,
	[прим] [varchar](50) NOT NULL DEFAULT (' ') ,
 CONSTRAINT [PK_примечания] PRIMARY KEY CLUSTERED 
(
	[услуга] ASC,
	[клиент] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

------------------------------

CREATE TABLE [dbo].[простои](
    простой uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[простой10] [char](10) NOT NULL ,
	[наимен] [varchar](50) NOT NULL default '',
	клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[клиент10] [char](10) NOT NULL,
	[дата_с] [datetime] NOT NULL DEFAULT getdate(),
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[услуга10] [char](10) NOT NULL)

print 'простои';
--------------

CREATE TABLE [dbo].[раб_дней](
    клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[клиент10] [char](10) NOT NULL,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[услуга10] [char](10) NOT NULL,
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
) ON [PRIMARY]

GO
print 'раб_дней';
------------------

CREATE TABLE [dbo].[работы](
    работа uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[работа10] [char](10) NOT NULL,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[стоимость] int NOT NULL default 0,
	[ст_материалов] int  NOT NULL  default 0,
	[прейскурант] [varchar](50) NOT NULL default '')

GO



print 'работы';
GO


---------------

CREATE TABLE [dbo].[сотрудники](
    сотрудник uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[сотрудник10] [char](10) NOT NULL,
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
	[кассир] [bit] NOT NULL default 1)
GO

print 'сотрудники';
-----------------

CREATE TABLE [dbo].[улицы](
    улица uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[улица10] [char](10) NOT NULL,
	[наимен] [varchar](50) NOT NULL default '',
	поселок uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[поселок10] [char](10) NOT NULL)
GO

print 'улицы';

------------


CREATE TABLE [dbo].[услуги](
    услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[услуга10] [char](10) NOT NULL,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	вид_услуги uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[вид_услуги10] [char](10) NOT NULL,
	[обозначение] [char](10) NOT NULL default '')
GO

print 'услуги';
--------------

CREATE TABLE [dbo].[услуги_клиента](
    клиент uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[клиент10] [char](10) NOT NULL,
	 услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[услуга10] [char](10) NOT NULL,
 CONSTRAINT [PK_услуги_клиента] PRIMARY KEY CLUSTERED 
(
	[клиент] ASC,
	[услуга] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
print 'услуги_клиента';
---------------

CREATE TABLE [dbo].[филиалы](
    филиал uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[филиал10] [char](10) NOT NULL,
	[наимен] [varchar](50) NOT NULL default '',
	[адрес] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[телефон] [varchar](50) NOT NULL default '')
GO

print 'филиалы';

--------------------

CREATE TABLE [dbo].[фирмы](
    фирма uniqueidentifier NOT NULL DEFAULT NEWID ( ) PRIMARY KEY CLUSTERED,
	[фирма10] [char](10) NOT NULL,
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
	[груз_пол] [varchar](60) NOT NULL default '')

	GO
	
	print 'фирмы';
-----------

CREATE TABLE [dbo].[цены](
	[год] [int] NOT NULL,
	[месяц] [int] NOT NULL,
	[стоимость] int  NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT NEWID ( ) ,
	[услуга10] [char](10) NOT NULL,
 CONSTRAINT [PK_цены_1] PRIMARY KEY CLUSTERED 
(
	[год] ASC,
	[месяц] ASC,
	[услуга] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

print 'цены';
----------
GO

CREATE TABLE [dbo].[шаблоны](
	[шаблон] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[наимен] [varchar](50) NOT NULL default '',
	[путь] [varchar](50) NOT NULL default '')

--------------
GO
print 'шаблоны';