--テストデータを全て削除
DELETE FROM [FX2_Demo].[cmn].[t通貨ペアMst]
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



--cmnスキーマを移行
INSERT INTO [FX2_Demo].[cmn].[t通貨ペアMst] ([No] ,[ペア名])
SELECT [No] ,[ペア名]
FROM [RealA_FX].[dbo].[T_通貨ペアMst];


--oderスキーマを移行
INSERT INTO [FX2_Demo].[oder].[tOrderStatus] ([通貨ペアNo], [通貨ペア名])
SELECT [No] ,[ペア名]
FROM [RealA_FX].[dbo].[T_通貨ペアMst];


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
SELECT @StartDate_acvMin = MIN([日時]), @StartDate_acvMax = MAX([日時])
FROM [RealA_FX].[acv].[T_RateHistory_15m_Past];

--SELECT @StartDate_acvMin, @StartDate_acvMax

DECLARE @StartDate_dboMin datetime;
SELECT @StartDate_dboMin = MIN([日時]) FROM [RealA_FX].[dbo].[T_RateHistory_15m];

if @StartDate_acvMax > @StartDate_dboMin
begin
	SET @StartDate_acvMax = @StartDate_dboMin;
end;

--SELECT @StartDate_acvMin, @StartDate_acvMax, @StartDate_dboMin

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN
	--SELECT DATEADD(day, -1, @StartDate_acvMin), @StartDate_acvMin

	INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min15]
		([通貨ペアNo]
		,[StartDate]
		,[買いRate_始値]
		,[買いRate_高値]
		,[買いRate_安値]
		,[買いRate_終値]
		,[売りRate_始値]
		,[売りRate_高値]
		,[売りRate_安値]
		,[売りRate_終値])
	SELECT
		 [通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
	FROM [RealA_FX].[acv].[T_RateHistory_15m_Past]
	WHERE DATEADD(day, -1, @StartDate_acvMin) < [日時] AND [日時] <= @StartDate_acvMin
	
	SET @StartDate_acvMin = DATEADD(day, 1, @StartDate_acvMin);
END;
GO

DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([日時]), @StartDate_acvMax = MAX([日時])
FROM [RealA_FX].[acv].[T_RateHistory_5m_Past];

DECLARE @StartDate_dboMin datetime;
SELECT @StartDate_dboMin = MIN([日時]) FROM [RealA_FX].[dbo].[T_RateHistory_5m];

if @StartDate_acvMax > @StartDate_dboMin
begin
	SET @StartDate_acvMax = @StartDate_dboMin;
end;

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN
	INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min5]
		([通貨ペアNo]
		,[StartDate]
		,[買いRate_始値]
		,[買いRate_高値]
		,[買いRate_安値]
		,[買いRate_終値]
		,[売りRate_始値]
		,[売りRate_高値]
		,[売りRate_安値]
		,[売りRate_終値]
		,[更新日時])
	SELECT
		 [通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,GETDATE()
	FROM [RealA_FX].[acv].[T_RateHistory_5m_Past]
	WHERE DATEADD(day, -1, @StartDate_acvMin) < [日時] AND [日時] <= @StartDate_acvMin
	
	SET @StartDate_acvMin = DATEADD(day, 1, @StartDate_acvMin);
END;
GO

GO
DECLARE @StartDate_acvMin	datetime;
DECLARE @StartDate_acvMax	datetime;
SELECT @StartDate_acvMin = MIN([日時]), @StartDate_acvMax = MAX([日時])
FROM [RealA_FX].[acv].[T_RateHistory_1m_Past];

DECLARE @StartDate_dboMin datetime;
SELECT @StartDate_dboMin = MIN([日時]) FROM [RealA_FX].[dbo].[T_RateHistory_1m];

if @StartDate_acvMax > @StartDate_dboMin
begin
	SET @StartDate_acvMax = @StartDate_dboMin;
end;

WHILE @StartDate_acvMin < @StartDate_acvMax
BEGIN
	INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min1]
		([通貨ペアNo]
		,[StartDate]
		,[買いRate_始値]
		,[買いRate_高値]
		,[買いRate_安値]
		,[買いRate_終値]
		,[売りRate_始値]
		,[売りRate_高値]
		,[売りRate_安値]
		,[売りRate_終値]
		,[更新日時])
	SELECT
		 [通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,GETDATE()
	FROM [RealA_FX].[acv].[T_RateHistory_1m_Past]
	WHERE DATEADD(day, -1, @StartDate_acvMin) < [日時] AND [日時] <= @StartDate_acvMin
	
	SET @StartDate_acvMin = DATEADD(day, 1, @StartDate_acvMin);
END;
GO


--Rateスキーマを移行
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
--	,[StartDate]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Monthly]
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
--	,[StartDate]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Weekly]
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
--	,[StartDate]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Daily]
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
--	,[StartDate]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_Hourly]
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
--	,[StartDate]
--	,[買い_始値]
--	,[買い_高値]
--	,[買い_安値]
--	,[買い_終値]
--	,[売り_始値]
--	,[売り_高値]
--	,[売り_安値]
--	,[売り_終値]
--	,GETDATE()
--FROM [RealA_FX].[dbo].[T_RateHistory_30m]
--GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min15]
	([通貨ペアNo]
	,[StartDate]
	,[買いRate_始値]
	,[買いRate_高値]
	,[買いRate_安値]
	,[買いRate_終値]
	,[売りRate_始値]
	,[売りRate_高値]
	,[売りRate_安値]
	,[売りRate_終値]
	,[更新日時])
SELECT
	 [通貨ペアNo]
	,[StartDate]
	,[買い_始値]
	,[買い_高値]
	,[買い_安値]
	,[買い_終値]
	,[売り_始値]
	,[売り_高値]
	,[売り_安値]
	,[売り_終値]
	,GETDATE()
FROM [RealA_FX].[dbo].[T_RateHistory_15m]
GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min5]
	([通貨ペアNo]
	,[StartDate]
	,[買いRate_始値]
	,[買いRate_高値]
	,[買いRate_安値]
	,[買いRate_終値]
	,[売りRate_始値]
	,[売りRate_高値]
	,[売りRate_安値]
	,[売りRate_終値]
	,[更新日時])
SELECT
	 [通貨ペアNo]
	,[StartDate]
	,[買い_始値]
	,[買い_高値]
	,[買い_安値]
	,[買い_終値]
	,[売り_始値]
	,[売り_高値]
	,[売り_安値]
	,[売り_終値]
	,GETDATE()
FROM [RealA_FX].[dbo].[T_RateHistory_5m]
GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory_Min1]
	([通貨ペアNo]
	,[StartDate]
	,[買いRate_始値]
	,[買いRate_高値]
	,[買いRate_安値]
	,[買いRate_終値]
	,[売りRate_始値]
	,[売りRate_高値]
	,[売りRate_安値]
	,[売りRate_終値]
	,[更新日時])
SELECT
	 [通貨ペアNo]
	,[StartDate]
	,[買い_始値]
	,[買い_高値]
	,[買い_安値]
	,[買い_終値]
	,[売り_始値]
	,[売り_高値]
	,[売り_安値]
	,[売り_終値]
	,GETDATE()
FROM [RealA_FX].[dbo].[T_RateHistory_1m]
GO
INSERT INTO [FX2_Demo].[rate].[tRateHistory]
	([通貨ペアNo]
	,[StartDate]
	,[買いRate]
	,[売りRate])
SELECT [通貨ペア]
	,[Date]
	,[Rate_買い]
	,[Rate_売り]
FROM [RealA_FX].[dbo].[T_RateHistory]
go

/*
-- 移行元のDBは0時始まりになっているので、6時始まりに変更する。
UPDATE [FX2_Demo].[rate].[tRateHistory_Month1]
SET [StartDate] = DATEADD(HOUR, 6, [StartDate])
where DATEPART(HOUR, [StartDate]) = 0
*/
