USE [master]
GO

/****** Object:  BackupDevice [домофон14]    Script Date: 18.08.2016 2:04:04 ******/
EXEC master.dbo.sp_addumpdevice  @devtype = N'disk', @logicalname = N'домофон14', @physicalname = N'D:\backup\domofon14.bak'
GO


