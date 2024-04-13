USE [DemoA_FX];
go

DELETE FROM [hstr].[tMin15];
GO
DELETE FROM [hstr].[tMin5];
GO
DELETE FROM [hstr].[tMin1];
GO
DELETE FROM [hstr].[tSec];



DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

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
	FROM [dbo].[T_RateHistory_15m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	INSERT INTO [hstr].[tMin5]
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
	FROM [dbo].[T_RateHistory_5m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	INSERT INTO [hstr].[tMin1]
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
	FROM [dbo].[T_RateHistory_1m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	INSERT INTO [hstr].[tSec]
        ([通貨ペアNo]
        ,[StartDate]
        ,[買いSwap]
        ,[買いRate]
        ,[売りSwap]
        ,[売りRate])
	SELECT 
		 [通貨ペア]
		,[Date]
		,[Swap_買い]
		,[Rate_買い]
		,[Swap_売り]
		,[Rate_売り]
	FROM [dbo].[T_RateHistory]
	WHERE [通貨ペア] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

