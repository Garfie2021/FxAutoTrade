USE [RealA_FX_ACV];
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_Monthly]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [dbo].[T_RateHistory_Monthly]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Monthly_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_Weekly]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_Weekly]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Weekly_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_Daily]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [dbo].[T_RateHistory_Daily]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Daily_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_6h]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_6h]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_6h_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go


DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_Hourly]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_Hourly]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Hourly_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_30m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_30m]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_30m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_15m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_15m]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_15m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_5m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_5m]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_5m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [dbo].[T_RateHistory_1m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory_1m]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値]
		,[StartDate]
		,[EndDate])
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
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_1m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([Date]) 
	FROM [dbo].[T_RateHistory]
	WHERE [通貨ペア] = @通貨ペアNo;

	INSERT INTO [dbo].[T_RateHistory]
		([通貨ペア]
		,[Date]
		,[Rate_買い]
		,[Rate_売り]
		,[Swap_買い]
		,[Swap_売り])
	SELECT
		 [通貨ペアNo]
		,[日時]
		,[Rate_買い]
		,[Rate_売り]
		,[Swap_買い]
		,[Swap_売り]
	FROM [acv].[T_RateHistory_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

