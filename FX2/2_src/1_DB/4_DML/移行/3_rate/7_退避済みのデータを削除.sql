--2�T�Ԉȏ�O�̃f�[�^���폜

--�e�X�g�f�[�^��S�č폜
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
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min15]
--GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min5]
--GO
--DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min1]
--GO





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
SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
FROM [FX2_Demo].[rate].[tRateHistory_Min15]

SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2�T�ԕ��̃f�[�^�͎c��

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN

	declare @�ʉ݃y�ANo tinyint = 0;
	while @�ʉ݃y�ANo < 44
	begin

		DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min15]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

	SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
END;
GO


DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
FROM [FX2_Demo].[rate].[tRateHistory_Min5]

SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2�T�ԕ��̃f�[�^�͎c��

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN

	declare @�ʉ݃y�ANo tinyint = 0;
	while @�ʉ݃y�ANo < 44
	begin

		DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min5]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

	SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
END;
GO


DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
FROM [FX2_Demo].[rate].[tRateHistory_Min1]

SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2�T�ԕ��̃f�[�^�͎c��

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN

	declare @�ʉ݃y�ANo tinyint = 0;
	while @�ʉ݃y�ANo < 44
	begin

		DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min1]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

	SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
END;
GO

