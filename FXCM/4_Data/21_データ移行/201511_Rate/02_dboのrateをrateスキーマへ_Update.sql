USE [DemoA_FX];
go



DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @min	datetime;
	SELECT @min = MIn([����])  FROM [DemoA_FX].[indi].[T_Indicator_15m];

	DECLARE @max	datetime;
	SELECT @max = MIn([StartDate])  FROM [DemoA_FX].[hstr].[tMin15];

	SELECT @�ʉ݃y�ANo, @min, @max;

	INSERT INTO [hstr].[tMin15]
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
		,[StartDate]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
	FROM [DemoA_FX_ACV].[dbo].[T_RateHistory_15m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND
		@min < [StartDate] AND [StartDate] < @max;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO



DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @min	datetime;
	SELECT @min = MIn([����])  FROM [DemoA_FX].[dbo].[T_RateHistory_15m] WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	DECLARE @max	datetime;
	SELECT @max = MIn([StartDate])  FROM [DemoA_FX].[hstr].[tMin15] WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SELECT @�ʉ݃y�ANo, @min, @max;

	INSERT INTO [DemoA_FX].[hstr].[tMin15]
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
		,[StartDate]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
	FROM [DemoA_FX].[dbo].[T_RateHistory_15m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND
		@min < [StartDate] AND [StartDate] < @max;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

