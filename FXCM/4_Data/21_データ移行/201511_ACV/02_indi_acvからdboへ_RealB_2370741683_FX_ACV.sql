USE [RealB_2370741683_FX_ACV];
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_Monthly]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_Monthly]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_Monthly_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_Weekly]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_Weekly]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_Weekly_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_Daily]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_Daily]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_Daily_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

delete FROM  [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h]

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	INSERT INTO [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [RealB_2370741683_FX].[acv].[T_Indicator_6h_Past]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_1h]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_1h]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_1h_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_30m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_30m]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_30m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_15m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_15m]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_15m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_5m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_5m]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_5m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	DECLARE @日時Min	datetime;
	SELECT @日時Min = MIN([日時]) 
	FROM [indi].[T_Indicator_1m]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT @通貨ペアNo, @日時Min;
	INSERT INTO [indi].[T_Indicator_1m]
		([通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2])
	SELECT 
		 [通貨ペアNo]
		,[日時]
		,[WMA_買い_WMA]
		,[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2]
	FROM [acv].[T_Indicator_1m_Past]
	WHERE [日時] < @日時Min AND [通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
go

