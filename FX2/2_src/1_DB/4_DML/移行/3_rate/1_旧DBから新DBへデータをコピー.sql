--�e�X�g�f�[�^��S�č폜
DELETE FROM [FX2_Demo].[cmn].[t�ʉ݃y�AMst]
GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Month1]
--GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Week1]
--GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Day1]
--GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Hour1]
--GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min30]
--GO
DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min15]
GO
DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min5]
GO
DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min1]
GO



--cmn�X�L�[�}���ڍs
INSERT INTO [FX2_Demo].[cmn].[t�ʉ݃y�AMst] ([No] ,[�y�A��])
SELECT [No] ,[�y�A��]
FROM [RealA_FX].[dbo].[T_�ʉ݃y�AMst];


--oder�X�L�[�}���ڍs
INSERT INTO [FX2_Demo].[oder].[tOrderStatus] ([�ʉ݃y�ANo], [�ʉ݃y�A��])
SELECT [No] ,[�y�A��]
FROM [RealA_FX].[dbo].[T_�ʉ݃y�AMst];


--acv�X�L�[�}���ڍs
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Month1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[����]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Monthly_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Week1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[����]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Weekly_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Day1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[����]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Daily_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Hour1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[����]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Hourly_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min30]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[����]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_30m_Past]
--GO

DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([����]), @StartDate_acvMax = MAX([����])
FROM [RealA_FX].[acv].[T_RateHistory_15m_Past];

--SELECT @StartDate_acvMin, @StartDate_acvMax

DECLARE @StartDate_dboMin datetime;
SELECT @StartDate_dboMin = MIN([����]) FROM [RealA_FX].[dbo].[T_RateHistory_15m];

if @StartDate_acvMax > @StartDate_dboMin
begin
	SET @StartDate_acvMax = @StartDate_dboMin;
end;

--SELECT @StartDate_acvMin, @StartDate_acvMax, @StartDate_dboMin

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN
	--SELECT DATEADD(day, -1, @StartDate_acvMin), @StartDate_acvMin

	INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min15]
		([�ʉ݃y�ANo]
		,[StartDate]
		,[����Rate_�n�l]
		,[����Rate_���l]
		,[����Rate_���l]
		,[����Rate_�I�l]
		,[����Rate_�n�l]
		,[����Rate_���l]
		,[����Rate_���l]
		,[����Rate_�I�l])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
	FROM [RealA_FX].[acv].[T_RateHistory_15m_Past]
	WHERE DATEADD(day, -1, @StartDate_acvMin) < [����] AND [����] <= @StartDate_acvMin
	
	SET @StartDate_acvMin = DATEADD(day, 1, @StartDate_acvMin);
END;
GO

DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([����]), @StartDate_acvMax = MAX([����])
FROM [RealA_FX].[acv].[T_RateHistory_5m_Past];

DECLARE @StartDate_dboMin datetime;
SELECT @StartDate_dboMin = MIN([����]) FROM [RealA_FX].[dbo].[T_RateHistory_5m];

if @StartDate_acvMax > @StartDate_dboMin
begin
	SET @StartDate_acvMax = @StartDate_dboMin;
end;

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN
	INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min5]
		([�ʉ݃y�ANo]
		,[StartDate]
		,[����Rate_�n�l]
		,[����Rate_���l]
		,[����Rate_���l]
		,[����Rate_�I�l]
		,[����Rate_�n�l]
		,[����Rate_���l]
		,[����Rate_���l]
		,[����Rate_�I�l]
		,[�X�V����])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,GETDATE()
	FROM [RealA_FX].[acv].[T_RateHistory_5m_Past]
	WHERE DATEADD(day, -1, @StartDate_acvMin) < [����] AND [����] <= @StartDate_acvMin
	
	SET @StartDate_acvMin = DATEADD(day, 1, @StartDate_acvMin);
END;
GO

GO
DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([����]), @StartDate_acvMax = MAX([����])
FROM [RealA_FX].[acv].[T_RateHistory_1m_Past];

DECLARE @StartDate_dboMin datetime;
SELECT @StartDate_dboMin = MIN([����]) FROM [RealA_FX].[dbo].[T_RateHistory_1m];

if @StartDate_acvMax > @StartDate_dboMin
begin
	SET @StartDate_acvMax = @StartDate_dboMin;
end;

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN
	INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min1]
		([�ʉ݃y�ANo]
		,[StartDate]
		,[����Rate_�n�l]
		,[����Rate_���l]
		,[����Rate_���l]
		,[����Rate_�I�l]
		,[����Rate_�n�l]
		,[����Rate_���l]
		,[����Rate_���l]
		,[����Rate_�I�l]
		,[�X�V����])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,GETDATE()
	FROM [RealA_FX].[acv].[T_RateHistory_1m_Past]
	WHERE DATEADD(day, -1, @StartDate_acvMin) < [����] AND [����] <= @StartDate_acvMin
	
	SET @StartDate_acvMin = DATEADD(day, 1, @StartDate_acvMin);
END;
GO


--Rate�X�L�[�}���ڍs
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Month1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[StartDate]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Monthly]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Week1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[StartDate]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Weekly]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Day1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[StartDate]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Daily]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Hour1]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[StartDate]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Hourly]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min30]
--	([�ʉ݃y�ANo]
--	,[StartDate]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[����Rate_�n�l]
--	,[����Rate_���l]
--	,[����Rate_���l]
--	,[����Rate_�I�l]
--	,[�X�V����])
--SELECT
--	 [�ʉ݃y�ANo]
--	,[StartDate]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,[����_�n�l]
--	,[����_���l]
--	,[����_���l]
--	,[����_�I�l]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_30m]
--GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min15]
	([�ʉ݃y�ANo]
	,[StartDate]
	,[����Rate_�n�l]
	,[����Rate_���l]
	,[����Rate_���l]
	,[����Rate_�I�l]
	,[����Rate_�n�l]
	,[����Rate_���l]
	,[����Rate_���l]
	,[����Rate_�I�l]
	,[�X�V����])
SELECT
	 [�ʉ݃y�ANo]
	,[StartDate]
	,[����_�n�l]
	,[����_���l]
	,[����_���l]
	,[����_�I�l]
	,[����_�n�l]
	,[����_���l]
	,[����_���l]
	,[����_�I�l]
	,GETDATE()
FROM [RealA_FX].[dbo].[T_RateHistory_15m]
GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min5]
	([�ʉ݃y�ANo]
	,[StartDate]
	,[����Rate_�n�l]
	,[����Rate_���l]
	,[����Rate_���l]
	,[����Rate_�I�l]
	,[����Rate_�n�l]
	,[����Rate_���l]
	,[����Rate_���l]
	,[����Rate_�I�l]
	,[�X�V����])
SELECT
	 [�ʉ݃y�ANo]
	,[StartDate]
	,[����_�n�l]
	,[����_���l]
	,[����_���l]
	,[����_�I�l]
	,[����_�n�l]
	,[����_���l]
	,[����_���l]
	,[����_�I�l]
	,GETDATE()
FROM [RealA_FX].[dbo].[T_RateHistory_5m]
GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min1]
	([�ʉ݃y�ANo]
	,[StartDate]
	,[����Rate_�n�l]
	,[����Rate_���l]
	,[����Rate_���l]
	,[����Rate_�I�l]
	,[����Rate_�n�l]
	,[����Rate_���l]
	,[����Rate_���l]
	,[����Rate_�I�l]
	,[�X�V����])
SELECT
	 [�ʉ݃y�ANo]
	,[StartDate]
	,[����_�n�l]
	,[����_���l]
	,[����_���l]
	,[����_�I�l]
	,[����_�n�l]
	,[����_���l]
	,[����_���l]
	,[����_�I�l]
	,GETDATE()
FROM [RealA_FX].[dbo].[T_RateHistory_1m]
GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory]
	([�ʉ݃y�ANo]
	,[StartDate]
	,[����Rate]
	,[����Rate])
SELECT [�ʉ݃y�A]
	,[Date]
	,[Rate_����]
	,[Rate_����]
FROM [RealA_FX].[dbo].[T_RateHistory]
go

/*
-- �ڍs����DB��0���n�܂�ɂȂ��Ă���̂ŁA6���n�܂�ɕύX����B
UPDATE [FX2_Demo].[rate].[tRateHistory_Month1]
SET [StartDate] = DATEADD(HOUR, 6, [StartDate])
where DATEPART(HOUR, [StartDate]) = 0
*/
