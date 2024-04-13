USE [DemoA_FX];
go



DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @min	datetime;
	SELECT @min = MIn([日時])  FROM [DemoA_FX].[indi].[T_Indicator_15m];

	DECLARE @max	datetime;
	SELECT @max = MIn([StartDate])  FROM [DemoA_FX].[hstr].[tMin15];

	SELECT @通貨ペアNo, @min, @max;

	INSERT INTO [hstr].[tMin15]
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
		,[StartDate]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
	FROM [DemoA_FX_ACV].[dbo].[T_RateHistory_15m]
	WHERE [通貨ペアNo] = @通貨ペアNo AND
		@min < [StartDate] AND [StartDate] < @max;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO



DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @min	datetime;
	SELECT @min = MIn([日時])  FROM [DemoA_FX].[dbo].[T_RateHistory_15m] WHERE [通貨ペアNo] = @通貨ペアNo;

	DECLARE @max	datetime;
	SELECT @max = MIn([StartDate])  FROM [DemoA_FX].[hstr].[tMin15] WHERE [通貨ペアNo] = @通貨ペアNo;

	SELECT @通貨ペアNo, @min, @max;

	INSERT INTO [DemoA_FX].[hstr].[tMin15]
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
		,[StartDate]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
	FROM [DemoA_FX].[dbo].[T_RateHistory_15m]
	WHERE [通貨ペアNo] = @通貨ペアNo AND
		@min < [StartDate] AND [StartDate] < @max;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

