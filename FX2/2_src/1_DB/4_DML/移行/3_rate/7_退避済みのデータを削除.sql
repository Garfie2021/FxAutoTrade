--2週間以上前のデータを削除

--テストデータを全て削除
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





--acvスキーマを移行
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Month1]
--	([通貨ペアNo]
--	,[StartDate]
--	,[買いRate_始値]
--	,[買いRate_高値]
--	,[買いRate_安値]
--	,[買いRate_終値]
--	,[売りRate_始値]
--	,[売りRate_高値]
--	,[売りRate_安値]
--	,[売りRate_終値]
--	,[更新日時])
--SELECT
--	 [通貨ペアNo]
--	,[日時]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Monthly_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Week1]
--	([通貨ペアNo]
--	,[StartDate]
--	,[買いRate_始値]
--	,[買いRate_高値]
--	,[買いRate_安値]
--	,[買いRate_終値]
--	,[売りRate_始値]
--	,[売りRate_高値]
--	,[売りRate_安値]
--	,[売りRate_終値]
--	,[更新日時])
--SELECT
--	 [通貨ペアNo]
--	,[日時]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Weekly_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Day1]
--	([通貨ペアNo]
--	,[StartDate]
--	,[買いRate_始値]
--	,[買いRate_高値]
--	,[買いRate_安値]
--	,[買いRate_終値]
--	,[売りRate_始値]
--	,[売りRate_高値]
--	,[売りRate_安値]
--	,[売りRate_終値]
--	,[更新日時])
--SELECT
--	 [通貨ペアNo]
--	,[日時]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Daily_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Hour1]
--	([通貨ペアNo]
--	,[StartDate]
--	,[買いRate_始値]
--	,[買いRate_高値]
--	,[買いRate_安値]
--	,[買いRate_終値]
--	,[売りRate_始値]
--	,[売りRate_高値]
--	,[売りRate_安値]
--	,[売りRate_終値]
--	,[更新日時])
--SELECT
--	 [通貨ペアNo]
--	,[日時]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_Hourly_Past]
--GO
--INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min30]
--	([通貨ペアNo]
--	,[StartDate]
--	,[買いRate_始値]
--	,[買いRate_高値]
--	,[買いRate_安値]
--	,[買いRate_終値]
--	,[売りRate_始値]
--	,[売りRate_高値]
--	,[売りRate_安値]
--	,[売りRate_終値]
--	,[更新日時])
--SELECT
--	 [通貨ペアNo]
--	,[日時]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[acv].[T_RateHistory_30m_Past]
--GO

DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
FROM [FX2_Demo].[rate].[tRateHistory_Min15]

SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2週間分のデータは残す

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN

	declare @通貨ペアNo tinyint = 0;
	while @通貨ペアNo < 44
	begin

		DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min15]
		WHERE 通貨ペアNo = @通貨ペアNo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

	SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
END;
GO


DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
FROM [FX2_Demo].[rate].[tRateHistory_Min5]

SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2週間分のデータは残す

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN

	declare @通貨ペアNo tinyint = 0;
	while @通貨ペアNo < 44
	begin

		DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min5]
		WHERE 通貨ペアNo = @通貨ペアNo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

	SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
END;
GO


DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
FROM [FX2_Demo].[rate].[tRateHistory_Min1]

SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2週間分のデータは残す

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN

	declare @通貨ペアNo tinyint = 0;
	while @通貨ペアNo < 44
	begin

		DELETE FROM [FX2_Demo].[rate].[tRateHistory_Min1]
		WHERE 通貨ペアNo = @通貨ペアNo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

	SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
END;
GO

