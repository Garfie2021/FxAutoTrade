USE [msdb]
GO

/****** Object:  Job [Buckup]    Script Date: 2018/12/20 20:35:30 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 2018/12/20 20:35:30 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Buckup', 
		@enabled=0, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'使用できる説明はありません。', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'PC-E\1111', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [print1]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'print1', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'print ''1''', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [OANDA_RealA]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'OANDA_RealA', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [OANDA_RealA] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_RealA.bak'' WITH NOFORMAT, INIT,  
NAME = N''OANDA_RealA-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''OANDA_RealA'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''OANDA_RealA'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''OANDA_RealA'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_RealA.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [OANDA_RealA_ACV]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'OANDA_RealA_ACV', 
		@step_id=3, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [OANDA_RealA_ACV] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_RealA_ACV.bak'' WITH NOFORMAT, INIT,  
NAME = N''OANDA_RealA_ACV-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''OANDA_RealA_ACV'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''OANDA_RealA_ACV'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''OANDA_RealA_ACV'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_RealA_ACV.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [OANDA_DemoB]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'OANDA_DemoB', 
		@step_id=4, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [OANDA_DemoB] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_DemoB.bak'' WITH NOFORMAT, INIT,  
NAME = N''OANDA_DemoB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''OANDA_DemoB'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''OANDA_DemoB'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''OANDA_DemoB'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_DemoB.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [OANDA_DemoB_ACV]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'OANDA_DemoB_ACV', 
		@step_id=5, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [OANDA_DemoB_ACV] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_DemoB_ACV.bak'' WITH NOFORMAT, INIT,  
NAME = N''OANDA_DemoB_ACV-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''OANDA_DemoB_ACV'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''OANDA_DemoB_ACV'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''OANDA_DemoB_ACV'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\OANDA_DemoB_ACV.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [SwapCollect]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'SwapCollect', 
		@step_id=6, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [SwapCollect] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\SwapCollect.bak'' WITH NOFORMAT, INIT,  
NAME = N''SwapCollect-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''SwapCollect'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''SwapCollect'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''SwapCollect'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\SwapCollect.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [FXCM]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'FXCM', 
		@step_id=7, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [FXCM] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\FXCM.bak'' WITH NOFORMAT, INIT,  
NAME = N''FXCM-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''FXCM'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''FXCM'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''FXCM'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\FXCM.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [DB_Profiler]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'DB_Profiler', 
		@step_id=8, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BACKUP DATABASE [DB_Profiler] TO  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\DB_Profiler.bak'' WITH NOFORMAT, INIT,  
NAME = N''DB_Profiler-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

declare @backupSetId as int
select @backupSetId = position 
from msdb..backupset 
where database_name=N''DB_Profiler'' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N''DB_Profiler'' )

if @backupSetId is null 
begin 
	raiserror(N''確認に失敗しました。データベース ''''DB_Profiler'''' のバックアップ情報が見つかりません。'', 16, 1) 
end

RESTORE VERIFYONLY FROM  DISK = N''C:\MSSQL\MSSQL11.MSSQLSERVER\MSSQL\Backup\DB_Profiler.bak'' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [print2]    Script Date: 2018/12/20 20:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'print2', 
		@step_id=9, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'print ''2''', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'sunday', 
		@enabled=1, 
		@freq_type=8, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20170205, 
		@active_end_date=99991231, 
		@active_start_time=60000, 
		@active_end_time=235959, 
		@schedule_uid=N'eabf7c92-0163-4170-bb71-48195fdec4dc'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


