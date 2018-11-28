use domofon14
GO

CREATE TABLE [dbo].[годы](
	[год] [int] NOT NULL,
 CONSTRAINT [PK_год] PRIMARY KEY CLUSTERED 
(
	[год] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

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

CREATE TABLE [dbo].[месяцы](
	[месяц] [int] NOT NULL,
	[наимен] [char](10) NOT NULL,
 CONSTRAINT [PK_месяц] PRIMARY KEY CLUSTERED 
(
	[месяц] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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
    оплата uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[номер] [int] NOT NULL,
	клиент  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	сотрудник uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[удалена] [datetime] NOT NULL,
	[дата] [date] NOT NULL,
 CONSTRAINT [PK__del_опла__DB7F733B1699586C] PRIMARY KEY CLUSTERED 
(
	[оплата] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[del_оплаты] ADD   DEFAULT ((0)) FOR [номер]
GO


ALTER TABLE [dbo].[del_оплаты] ADD    DEFAULT (getdate()) FOR [удалена]
GO
print 'del_оплаты';
---------------

CREATE TABLE [dbo].[del_оплачено](
	[код] [int] IDENTITY(1,1) NOT NULL,
	оплата uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[код] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[del_оплачено] ADD  DEFAULT ((0)) FOR [сумма]
GO

ALTER TABLE [dbo].[del_оплачено] ADD    DEFAULT (getdate()) FOR [дата]
GO
print 'del_оплачено';
----------------


CREATE TABLE [dbo].[виды_услуг](
     вид_услуги uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[наимен] [varchar](50) NOT NULL,
	[порядок] [int] NOT NULL,
 CONSTRAINT [PK_вид_услуги] PRIMARY KEY CLUSTERED 
(
	[вид_услуги] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[виды_услуг] ADD  CONSTRAINT [DF_виды_услуг_наимен]  DEFAULT (' ') FOR [наимен]
GO

ALTER TABLE [dbo].[виды_услуг] ADD  CONSTRAINT [DF_виды_услуг_порядок]  DEFAULT ((0)) FOR [порядок]
GO



create trigger [dbo].[ti_виды_услуг]
on [dbo].[виды_услуг]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from виды_услуг
    update виды_услуг    set  порядок=@maxPor+1      from виды_услуг, inserted
          where  виды_услуг.вид_услуги=inserted.вид_услуги
          and inserted.порядок<1



GO


CREATE  trigger [dbo].[tu_виды_услуг]
on [dbo].[виды_услуг]
  for update
  as

if update (наимен)
begin
      declare @наимен varchar(50)
      select  @наимен =наимен from inserted
if rtrim(lTrim(@наимен))=''
      goto error
end
  return
error:
  
    rollback transaction



GO
print 'виды_услуг';
----------

CREATE TABLE [dbo].[возврат](
	[код] [int] IDENTITY(1,1) NOT NULL,
	оплата uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid(),
PRIMARY KEY CLUSTERED 
(
	[код] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[возврат] ADD  DEFAULT ((0)) FOR [сумма]
GO
print 'возврат';
-------------


CREATE TABLE [dbo].[дома](
дом uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[наимен] [char](10) NOT NULL,
	[порядок] [int] NOT NULL,
	улица uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[номер] [int] NOT NULL,
	[корпус] [char](10) NOT NULL,
	[изменен] [datetime] NOT NULL,
 CONSTRAINT [PK_дома] PRIMARY KEY CLUSTERED 
(
	[дом] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[дома] ADD    DEFAULT (' ') FOR [наимен]
GO

ALTER TABLE [dbo].[дома] ADD   DEFAULT ((0)) FOR [порядок]
GO

ALTER TABLE [dbo].[дома] ADD   DEFAULT ((0)) FOR [номер]
GO

ALTER TABLE [dbo].[дома] ADD   DEFAULT (' ') FOR [корпус]
GO

ALTER TABLE [dbo].[дома] ADD   DEFAULT (getdate()) FOR [изменен]
GO
print 'дома';
-----------

CREATE TABLE [dbo].[звонки](
звонок uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата] [datetime] NOT NULL  default getdate(),
	[прим] [varchar](50) NOT NULL default '',
	код_сообщения char(20) not null default '',
	телефон varchar(50) not null default '',
	доставка varchar(50) not null default '',
    статус varchar(50) not null default '',
	доставлено bit not null default 0,
 CONSTRAINT [PK_звонки] PRIMARY KEY CLUSTERED 
(
	[звонок] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
print 'звонки';
----------

CREATE TABLE [dbo].[клиенты](
    клиент uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[фамилия] [char](30) NOT NULL,
	[имя] [char](30) NOT NULL,
	[отчество] [char](30) NOT NULL,
    дом uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[квартира] [int] NOT NULL,
	[фио]  AS (((((ltrim(rtrim([фамилия]))+' ')+left(rtrim(ltrim([имя])),(1)))+'.')+left(rtrim(ltrim([отчество])),(1)))+'.'),
	[прим] [varchar](50) NOT NULL,
	[подъезд] [int] NOT NULL,
	[телефон] [varchar](50) NOT NULL,
	[ввод] [int] NOT NULL,
 CONSTRAINT [PK_клиенты] PRIMARY KEY CLUSTERED 
(
	[клиент] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_фамилия]  DEFAULT (' ') FOR [фамилия]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_имя]  DEFAULT (' ') FOR [имя]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_отчество]  DEFAULT (' ') FOR [отчество]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_квартира]  DEFAULT ((0)) FOR [квартира]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_прим]  DEFAULT (' ') FOR [прим]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_подъезд]  DEFAULT ((0)) FOR [подъезд]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_телефон]  DEFAULT (' ') FOR [телефон]
GO

ALTER TABLE [dbo].[клиенты] ADD  CONSTRAINT [DF_клиенты_ввод]  DEFAULT ((0)) FOR [ввод]
GO


create  trigger [dbo].[tu_клиенты]
on [dbo].[клиенты]
  for update
  as

if update (фамилия)
begin
      declare @фамилия varchar(30)
      select  @фамилия =фамилия from inserted
if rtrim(lTrim(@фамилия))=''
      goto error
end
  return
error:
  
    rollback transaction



GO
print 'клиенты';
----------

CREATE TABLE [dbo].[льготы](
    льгота  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата_с] [datetime] NOT NULL,
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[процент] [int] NOT NULL,
 CONSTRAINT [PK_льготы] PRIMARY KEY CLUSTERED 
(
	[льгота] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[льготы] ADD  CONSTRAINT [DF_льготы_дата_с]  DEFAULT (getdate()) FOR [дата_с]
GO

ALTER TABLE [dbo].[льготы] ADD  CONSTRAINT [DF_льготы_процент]  DEFAULT ((100)) FOR [процент]
GO

print 'льготы';
-------------

CREATE TABLE [dbo].[начало](
	[начало] [datetime] NOT NULL,
 CONSTRAINT [PK_начало_1] PRIMARY KEY CLUSTERED 
(
	[начало] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[начало] ADD  CONSTRAINT [DF_начало_начало]  DEFAULT (getdate()) FOR [начало]
GO
print 'начало';
------------


CREATE TABLE [dbo].[опл_работы](
	[оплата] [uniqueidentifier] NOT NULL,
	[работа] [uniqueidentifier] NOT NULL,
	[стоимость] [int] NOT NULL,
	[мастер] [uniqueidentifier] NOT NULL,
	[ст_материалов] [int] NOT NULL,
	[задание] [uniqueidentifier] NOT NULL,
	[номер] [int] NOT NULL,
 CONSTRAINT [PK_опл_работы_1] PRIMARY KEY CLUSTERED 
(
	[задание] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[опл_работы] ADD  CONSTRAINT [DF_опл_работы_стоимость]  DEFAULT ((0)) FOR [стоимость]
GO

ALTER TABLE [dbo].[опл_работы] ADD  CONSTRAINT [DF_опл_работы_ст_материалов]  DEFAULT ((0)) FOR [ст_материалов]
GO

ALTER TABLE [dbo].[опл_работы] ADD  CONSTRAINT [DF_опл_работы_номер]  DEFAULT ((0)) FOR [номер]
GO

ALTER TABLE [dbo].[опл_работы]  WITH CHECK ADD  CONSTRAINT [FK_опл_работы_оплаты] FOREIGN KEY([оплата])
REFERENCES [dbo].[оплаты] ([оплата])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[опл_работы] CHECK CONSTRAINT [FK_опл_работы_оплаты]
GO

ALTER TABLE [dbo].[опл_работы]  WITH CHECK ADD  CONSTRAINT [FK_опл_работы_работы] FOREIGN KEY([работа])
REFERENCES [dbo].[работы] ([работа])
GO

ALTER TABLE [dbo].[опл_работы] CHECK CONSTRAINT [FK_опл_работы_работы]
GO

ALTER TABLE [dbo].[опл_работы]  WITH CHECK ADD  CONSTRAINT [FK_опл_работы_сотрудники] FOREIGN KEY([мастер])
REFERENCES [dbo].[сотрудники] ([сотрудник])
GO

ALTER TABLE [dbo].[опл_работы] CHECK CONSTRAINT [FK_опл_работы_сотрудники]
GO



print 'опл_работы';
---------------


CREATE TABLE [dbo].[оплаты](
    оплата  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[номер] [int] NOT NULL,
	клиент  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата] [date] NOT NULL,
	сотрудник  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
 CONSTRAINT [PK_оплаты] PRIMARY KEY CLUSTERED 
(
	[оплата] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[оплаты] ADD  CONSTRAINT [DF_оплаты_номер]  DEFAULT ((0)) FOR [номер]
GO

ALTER TABLE [dbo].[оплаты] ADD  CONSTRAINT [DF_оплаты_дата]  DEFAULT (getdate()) FOR [дата]
GO



CREATE TRIGGER [dbo].[d_оплаты] 
   ON  [dbo].[оплаты]
   AFTER DELETE
AS 
BEGIN
 
   
   INSERT INTO [domofon12].[dbo].[del_оплаты]
           ([оплата]
           ,[номер]
           ,[клиент]
           ,[сотрудник]
           ,[дата])
           ( select  оплата ,номер  ,клиент ,сотрудник ,дата from deleted )
           
END
GO
print 'оплаты';
---------------

CREATE TABLE [dbo].[оплачено](
	[код] [int] IDENTITY(1,1) NOT NULL,
	оплата  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[месяц] [int] NOT NULL,
	[год] [int] NOT NULL,
	[сумма] [int] NOT NULL,
	услуга  uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дней] [int] NOT NULL,
	[длина_мес] [int] NOT NULL,
	[цена] [int] NOT NULL,
 CONSTRAINT [PK_оплачено] PRIMARY KEY CLUSTERED 
(
	[код] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[оплачено] ADD  CONSTRAINT [DF_оплачено_месяц]  DEFAULT ((0)) FOR [месяц]
GO

ALTER TABLE [dbo].[оплачено] ADD  CONSTRAINT [DF_оплачено_год]  DEFAULT ((0)) FOR [год]
GO

ALTER TABLE [dbo].[оплачено] ADD  CONSTRAINT [DF_оплачено_сумма]  DEFAULT ((0)) FOR [сумма]
GO


ALTER TABLE [dbo].[оплачено] ADD  CONSTRAINT [DF_оплачено_дней]  DEFAULT ((0)) FOR [дней]
GO

ALTER TABLE [dbo].[оплачено] ADD  CONSTRAINT [DF_оплачено_из]  DEFAULT ((0)) FOR [длина_мес]
GO

ALTER TABLE [dbo].[оплачено] ADD  CONSTRAINT [DF_оплачено_цена]  DEFAULT ((0)) FOR [цена]
GO

CREATE  TRIGGER [dbo].[d_оплачено] 
   ON  [dbo].[оплачено]
   AFTER DELETE
AS 
BEGIN
 
           
     INSERT INTO [domofon].[dbo].[del_оплачено]
           ([оплата]
           ,[месяц]
           ,[год]
           ,[услуга]
           ,[сумма])
           (select оплата ,месяц, год, услуга,сумма from deleted )
END
GO



--CREATE trigger [dbo].[ti_оплачено]
--on [dbo].[оплачено]
--  for INSERT
--  as
-- declare  @дом  uniqueidentifier
 
--  select  @дом= клиенты.дом 
--  from inserted inner join оплаты
--  on оплаты.оплата=inserted.оплата
--  inner join клиенты
--  on оплаты.клиент =клиенты.клиент
  
--    update дома    set  изменен=getdate()    
--    where дома.дом =@дом
     
--	 GO

print 'оплачено';
------------------


CREATE TABLE [dbo].[отключения](
    отключение uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата_с] [datetime] NOT NULL,
	[дата_по] [datetime] NULL,
	[прим] [varchar](50) NOT NULL,
	мастер uniqueidentifier NOT NULL DEFAULT newsequentialid(),
 CONSTRAINT [PK_отключения] PRIMARY KEY CLUSTERED 
(
	[отключение] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[отключения] ADD  CONSTRAINT [DF_отключения_дата_с]  DEFAULT (getdate()) FOR [дата_с]
GO

ALTER TABLE [dbo].[отключения] ADD  CONSTRAINT [DF_отключения_прим]  DEFAULT (' ') FOR [прим]
GO
print 'отключения';
----------------


CREATE TABLE [dbo].[повторы](
	подключение uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата_с] [datetime] NOT NULL,
	[прим] [varchar](50) NOT NULL,
	мастер uniqueidentifier NOT NULL DEFAULT newsequentialid(),
PRIMARY KEY CLUSTERED 
(
	[подключение] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[повторы] ADD  DEFAULT (getdate()) FOR [дата_с]
GO

ALTER TABLE [dbo].[повторы] ADD  DEFAULT (' ') FOR [прим]
GO
print 'повторы';
---------------

CREATE TABLE [dbo].[подключения](
    подключение uniqueidentifier NOT NULL DEFAULT newsequentialid()  PRIMARY KEY CLUSTERED,
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[дата_с] [datetime] NOT NULL,
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid(),
	[номер_дог] [char](20) NOT NULL,
	[дата_дог] [datetime] NOT NULL,
	[номер_пп] [int] NOT NULL,
	мастер uniqueidentifier NOT NULL DEFAULT newsequentialid()
 )

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[подключения] ADD    DEFAULT (getdate()) FOR [дата_с]
GO


ALTER TABLE [dbo].[подключения] ADD    DEFAULT (' ') FOR [номер_дог]
GO

ALTER TABLE [dbo].[подключения] ADD    DEFAULT (getdate()) FOR [дата_дог]
GO

ALTER TABLE [dbo].[подключения] ADD   DEFAULT ((0)) FOR [номер_пп]
GO
print 'подключения';
-----------------

CREATE TABLE [dbo].[поселки](
    поселок uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL,
	[порядок] [int] NOT NULL
	)

GO


ALTER TABLE [dbo].[поселки] ADD    DEFAULT (' ') FOR [наимен]
GO

ALTER TABLE [dbo].[поселки] ADD    DEFAULT ((0)) FOR [порядок]
GO


create trigger [dbo].[ti_поселки]
on [dbo].[поселки]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from поселки
    update поселки    set  порядок=@maxPor+1      from поселки, inserted
          where  поселки.поселок=inserted.поселок
          and inserted.порядок<1


GO

CREATE  trigger [dbo].[tu_поселки]
on [dbo].[поселки]
  for update
  as

if update (наимен)
begin
      declare @наимен varchar(50)
      select  @наимен =наимен from inserted
if rtrim(lTrim(@наимен))=''
      goto error
end
  return
error:
  
    rollback transaction


GO
print 'поселки';
---------------------

CREATE TABLE [dbo].[предупреждения](
    предупреждение uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[дата] [datetime] NOT NULL DEFAULT getdate(),
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid() 
	)
GO
print 'предупреждения';
--------------

CREATE TABLE [dbo].[примечания](
    услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[прим] [varchar](50) NOT NULL DEFAULT (' ') ,
 CONSTRAINT [PK_примечания] PRIMARY KEY CLUSTERED 
(
	[услуга] ASC,
	[клиент] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go
print 'примечания';
------------------------------

CREATE TABLE [dbo].[простои](
    простой uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	клиент uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[дата_с] [datetime] NOT NULL DEFAULT getdate(),
	[дата_по] [datetime] NULL,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() 
)
go
print 'простои';
--------------

CREATE TABLE [dbo].[раб_дней](
    клиент uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
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
    работа uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[стоимость] int NOT NULL default 0,
	[ст_материалов] int  NOT NULL  default 0,
	[прейскурант] [varchar](50) NOT NULL default '')

GO

create trigger [dbo].[ti_работы]
on [dbo].[работы]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from работы
    update работы    set  порядок=@maxPor+1      from работы, inserted
          where  работы.работа=inserted.работа
          and inserted.порядок<1

GO

CREATE  trigger [dbo].[tu_работы]
on [dbo].[работы]
  for update
  as

if update (наимен)
begin
      declare @наимен varchar(50)
      select  @наимен =наимен from inserted
if rtrim(lTrim(@наимен))=''
      goto error
end
  return
error:
  
    rollback transaction

GO
print 'работы';
---------------

CREATE TABLE [dbo].[сотрудники](
    сотрудник uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
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

create trigger [dbo].[ti_сотрудники]
on [dbo].[сотрудники]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from сотрудники
    update сотрудники    set  порядок=@maxPor+1      from сотрудники, inserted
          where  сотрудники.сотрудник=inserted.сотрудник
          and inserted.порядок<1
GO


CREATE  trigger [dbo].[tu_сотрудники]
on [dbo].[сотрудники]
  for update
  as

if update (фамилия)
begin
      declare @фамилия varchar(50)
      select  @фамилия =фамилия from inserted
if rtrim(lTrim(@фамилия))=''
      goto error
end
  return
error:
  
    rollback transaction

GO
print 'сотрудники';
-----------------

CREATE TABLE [dbo].[улицы](
    улица uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	поселок uniqueidentifier NOT NULL DEFAULT newsequentialid() 
)
GO

create trigger [dbo].[ti_улицы]
on [dbo].[улицы]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from улицы
    update улицы    set  порядок=@maxPor+1      from улицы, inserted
          where  улицы.улица=inserted.улица
          and inserted.порядок<1
GO

CREATE  trigger [dbo].[tu_улицы]
on [dbo].[улицы]
  for update
  as

if update (наимен)
begin
      declare @наимен varchar(50)
      select  @наимен =наимен from inserted
if rtrim(lTrim(@наимен))=''
      goto error
end
  return
error:
  
    rollback transaction
GO
print 'улицы';
------------


CREATE TABLE [dbo].[услуги](
    услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	вид_услуги uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	[обозначение] [char](10) NOT NULL default '')
GO

create trigger [dbo].[ti_услуги]
on [dbo].[услуги]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from услуги
    update услуги    set  порядок=@maxPor+1      from услуги, inserted
          where  услуги.услуга=inserted.услуга
          and inserted.порядок<1

GO


CREATE  trigger [dbo].[tu_услуги]
on [dbo].[услуги]
  for update
  as

if update (наимен)
begin
      declare @наимен varchar(50)
      select  @наимен =наимен from inserted
if rtrim(lTrim(@наимен))=''
      goto error
end
  return
error:
  
    rollback transaction

GO
print 'услуги';
--------------

CREATE TABLE [dbo].[услуги_клиента](
    клиент uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
	 услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
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
    филиал uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
	[наимен] [varchar](50) NOT NULL default '',
	[адрес] [varchar](50) NOT NULL default '',
	[порядок] [int] NOT NULL default 0,
	[телефон] [varchar](50) NOT NULL default '')
GO

create trigger [dbo].[ti_филиалы]
on [dbo].[филиалы]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from филиалы
    update филиалы    set  порядок=@maxPor+1      from филиалы, inserted
          where  филиалы.филиал=inserted.филиал
          and inserted.порядок<1

GO

CREATE  trigger [dbo].[tu_филиалы]
on [dbo].[филиалы]
  for update
  as

if update (наимен)
begin
      declare @наимен varchar(50)
      select  @наимен =наимен from inserted
if rtrim(lTrim(@наимен))=''
      goto error
end
  return
error:
  
    rollback transaction



GO
print 'филиалы';
--------------------

CREATE TABLE [dbo].[фирмы](
    фирма uniqueidentifier NOT NULL DEFAULT newsequentialid() PRIMARY KEY CLUSTERED,
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
	
create trigger [dbo].[ti_фирмы]
on [dbo].[фирмы]
  for INSERT
  as
 declare  @maxPor  int
  select  @maxPor=max(порядок) from фирмы
    update фирмы    set  порядок=@maxPor+1      from фирмы, inserted
          where  фирмы.фирма=inserted.фирма
          and inserted.порядок<1

GO
print 'фирмы';
-----------

CREATE TABLE [dbo].[цены](
	[год] [int] NOT NULL,
	[месяц] [int] NOT NULL,
	[стоимость] int  NOT NULL default 0,
	услуга uniqueidentifier NOT NULL DEFAULT newsequentialid() ,
 CONSTRAINT [PK_цены_1] PRIMARY KEY CLUSTERED 
(
	[год] ASC,
	[месяц] ASC,
	[услуга] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
----------
print 'цены';
GO

CREATE TABLE [dbo].[шаблоны](
	[шаблон] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[наимен] [varchar](50) NOT NULL default '',
	[путь] [varchar](50) NOT NULL default '')

--------------
print 'шаблоны';
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
