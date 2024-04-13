USE [msdb]
GO

/****** Object:  Job [Mente_FX2_Demo]    Script Date: 2015/11/01 14:08:30 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 2015/11/01 14:08:30 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Mente_FX2_Demo', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'使用できる説明はありません。', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [sp再計算_WMA角度シグマ持続量_Min1]    Script Date: 2015/11/01 14:08:31 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'sp再計算_WMA角度シグマ持続量_Min1', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'DECLARE @計算対象シグマ_1以上	float = 1;
DECLARE @now					datetime = getdate();
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min1_買い] @計算対象シグマ_1以上, @now;
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min1_売り] @計算対象シグマ_1以上, @now;
GO
', 
		@database_name=N'FX2_Demo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [sp再計算_WMA角度シグマ持続量_Min5]    Script Date: 2015/11/01 14:08:31 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'sp再計算_WMA角度シグマ持続量_Min5', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'DECLARE @計算対象シグマ_1以上	float = 1;
DECLARE @now					datetime = getdate();
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min5_買い] @計算対象シグマ_1以上, @now;
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min5_売り] @計算対象シグマ_1以上, @now;
GO
', 
		@database_name=N'FX2_Demo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [sp再計算_WMA角度シグマ持続量_Min15]    Script Date: 2015/11/01 14:08:31 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'sp再計算_WMA角度シグマ持続量_Min15', 
		@step_id=3, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'DECLARE @計算対象シグマ_1以上	float = 0;
DECLARE @now					datetime = getdate();
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min15_買い] @計算対象シグマ_1以上, @now;
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min15_売り] @計算対象シグマ_1以上, @now;
GO
', 
		@database_name=N'FX2_Demo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [SP_Save_RateHistory_Min1]    Script Date: 2015/11/01 14:08:31 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'SP_Save_RateHistory_Min1', 
		@step_id=4, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'EXECUTE [acv].[SP_Save_RateHistory_Min1] 
GO
', 
		@database_name=N'FX2_Demo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [SP_Save_RateHistory_Min5]    Script Date: 2015/11/01 14:08:31 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'SP_Save_RateHistory_Min5', 
		@step_id=5, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'EXECUTE [acv].[SP_Save_RateHistory_Min5] 
GO
', 
		@database_name=N'FX2_Demo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [SP_Save_RateHistory_Min15]    Script Date: 2015/11/01 14:08:31 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'SP_Save_RateHistory_Min15', 
		@step_id=6, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'EXECUTE [acv].[SP_Save_RateHistory_Min15] 
GO
', 
		@database_name=N'FX2_Demo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'weekly', 
		@enabled=1, 
		@freq_type=8, 
		@freq_interval=64, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20151023, 
		@active_end_date=99991231, 
		@active_start_time=211000, 
		@active_end_time=235959, 
		@schedule_uid=N'db66af60-d877-490a-ae7c-677149256ea8'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


