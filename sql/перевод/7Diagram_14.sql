use domofon14

go
/*
   9 ноября 2013 г.19:30:52
   Пользователь: sa
   Сервер: USER14
   База данных: domofon12
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.сотрудники SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.работы SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.поселки SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

ALTER TABLE dbo.воз_работы ADD CONSTRAINT
	FK_воз_работы_работы FOREIGN KEY
	(
	работа
	) REFERENCES dbo.работы
	(
	работа
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.воз_работы ADD CONSTRAINT
	FK_воз_работы_оплаты FOREIGN KEY
	(
	оплата
	) REFERENCES dbo.оплаты
	(
	оплата
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO



BEGIN TRANSACTION
GO
ALTER TABLE dbo.улицы ADD CONSTRAINT
	FK_улицы_поселки FOREIGN KEY
	(
	поселок
	) REFERENCES dbo.поселки
	(
	поселок
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.улицы SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.дома ADD CONSTRAINT
	FK_дома_улицы FOREIGN KEY
	(
	улица
	) REFERENCES dbo.улицы
	(
	улица
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.дома SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.клиенты ADD CONSTRAINT
	FK_клиенты_дома FOREIGN KEY
	(
	дом
	) REFERENCES dbo.дома
	(
	дом
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.клиенты SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.оплаты ADD CONSTRAINT
	FK_оплаты_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.оплаты ADD CONSTRAINT
	FK_оплаты_сотрудники FOREIGN KEY
	(
	сотрудник
	) REFERENCES dbo.сотрудники
	(
	сотрудник
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.оплаты ADD CONSTRAINT
	FK_оплаты_виды_оплат FOREIGN KEY
	(
	вид_оплаты
	) REFERENCES dbo.виды_оплат
	(
	вид_оплаты
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 	
GO
ALTER TABLE dbo.оплаты SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.опл_работы ADD CONSTRAINT
	FK_опл_работы_оплаты FOREIGN KEY
	(
	оплата
	) REFERENCES dbo.оплаты
	(
	оплата
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.опл_работы ADD CONSTRAINT
	FK_опл_работы_работы FOREIGN KEY
	(
	работа
	) REFERENCES dbo.работы
	(
	работа
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.опл_работы ADD CONSTRAINT
	FK_опл_работы_сотрудники FOREIGN KEY
	(
	мастер
	) REFERENCES dbo.сотрудники
	(
	сотрудник
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.опл_работы SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.виды_услуг SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.услуги ADD CONSTRAINT
	FK_услуги_виды_услуг FOREIGN KEY
	(
	вид_услуги
	) REFERENCES dbo.виды_услуг
	(
	вид_услуги
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.услуги SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.льготы ADD CONSTRAINT
	FK_льготы_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.льготы ADD CONSTRAINT
	FK_льготы_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.льготы SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.оплачено ADD CONSTRAINT
	FK_оплачено_оплаты FOREIGN KEY
	(
	оплата
	) REFERENCES dbo.оплаты
	(
	оплата
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.оплачено ADD CONSTRAINT
	FK_оплачено_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.оплачено SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.возврат ADD CONSTRAINT
	FK_возврат_оплаты FOREIGN KEY
	(
	оплата
	) REFERENCES dbo.оплаты
	(
	оплата
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.возврат ADD CONSTRAINT
	FK_возврат_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.возврат SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.звонки ADD CONSTRAINT
	FK_звонки_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
--GO
--ALTER TABLE dbo.звонки ADD CONSTRAINT
--	FK_звонки_услуги FOREIGN KEY
--	(
--	услуга
--	) REFERENCES dbo.услуги
--	(
--	услуга
--	) ON UPDATE  NO ACTION 
--	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.звонки SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.отключения ADD CONSTRAINT
	FK_отключения_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.отключения ADD CONSTRAINT
	FK_отключения_сотрудники FOREIGN KEY
	(
	мастер
	) REFERENCES dbo.сотрудники
	(
	сотрудник
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.отключения ADD CONSTRAINT
	FK_отключения_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.отключения SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.раб_дней ADD CONSTRAINT
	FK_раб_дней_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.раб_дней ADD CONSTRAINT
	FK_раб_дней_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.раб_дней SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.предупреждения ADD CONSTRAINT
	FK_предупреждения_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.предупреждения ADD CONSTRAINT
	FK_предупреждения_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.предупреждения SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.повторы ADD CONSTRAINT
	FK_повторы_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.повторы ADD CONSTRAINT
	FK_повторы_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.повторы ADD CONSTRAINT
	FK_повторы_сотрудники FOREIGN KEY
	(
	мастер
	) REFERENCES dbo.сотрудники
	(
	сотрудник
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.повторы SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.простои ADD CONSTRAINT
	FK_простои_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.простои ADD CONSTRAINT
	FK_простои_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.простои SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.подключения ADD CONSTRAINT
	FK_подключения_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.подключения ADD CONSTRAINT
	FK_подключения_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.подключения ADD CONSTRAINT
	FK_подключения_сотрудники FOREIGN KEY
	(
	мастер
	) REFERENCES dbo.сотрудники
	(
	сотрудник
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.подключения SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.примечания ADD CONSTRAINT
	FK_примечания_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.примечания ADD CONSTRAINT
	FK_примечания_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.примечания SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.цены ADD CONSTRAINT
	FK_цены_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.цены SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.услуги_клиента ADD CONSTRAINT
	FK_услуги_клиента_клиенты FOREIGN KEY
	(
	клиент
	) REFERENCES dbo.клиенты
	(
	клиент
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.услуги_клиента ADD CONSTRAINT
	FK_услуги_клиента_услуги FOREIGN KEY
	(
	услуга
	) REFERENCES dbo.услуги
	(
	услуга
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.услуги_клиента SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
