USE [master]
GO

RESTORE DATABASE [FX_DemoA] FROM  
DISK = N'C:\MSSQL\Backup\FX_RealA.bak' WITH  FILE = 1,  
MOVE N'FX_RealA' TO N'C:\MSSQL\Data\FX_DemoA.mdf',  
MOVE N'FX_RealA_log' TO N'C:\MSSQL\Data\FX_DemoA_log.ldf',  
NOUNLOAD,  REPLACE,  STATS = 10
GO
