
DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	UPDATE [DemoA_FX].[hstr].[tMin15]
	SET  [買いWMAs2] = [WMA_買い_WMA_S2]
		,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
		,[買いWMAs14] = [WMA_買い_WMA]
		,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
		,[買いWMAs14角度シグマ] = [WMA_買い_WMA上昇角度_シグマ]
		,[売りWMAs2] = [WMA_売り_WMA_S2]
		,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
		,[売りWMAs14] = [WMA_売り_WMA]
		,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
		,[売りWMAs14角度シグマ] = [WMA_売り_WMA上昇角度_シグマ]
	FROM [DemoA_FX].[indi].[T_Indicator_15m]
	WHERE [DemoA_FX].[hstr].[tMin15].[通貨ペアNo] = [DemoA_FX].[indi].[T_Indicator_15m].[通貨ペアNo] AND
		  [DemoA_FX].[hstr].[tMin15].[StartDate] = [DemoA_FX].[indi].[T_Indicator_15m].[日時] AND
		  [DemoA_FX].[hstr].[tMin15].[通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO


DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	UPDATE [DemoA_FX].[hstr].[tMin5]
	SET  [買いWMAs2] = [WMA_買い_WMA_S2]
		,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
		,[買いWMAs14] = [WMA_買い_WMA]
		,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
		,[売りWMAs2] = [WMA_売り_WMA_S2]
		,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
		,[売りWMAs14] = [WMA_売り_WMA]
		,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
	FROM [DemoA_FX].[indi].[T_Indicator_5m]
	WHERE [DemoA_FX].[hstr].[tMin5].[通貨ペアNo] = [DemoA_FX].[indi].[T_Indicator_5m].[通貨ペアNo] AND
		  [DemoA_FX].[hstr].[tMin5].[StartDate] = [DemoA_FX].[indi].[T_Indicator_5m].[日時] AND
		  [DemoA_FX].[hstr].[tMin5].[通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO


DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	UPDATE [DemoA_FX].[hstr].[tMin1]
	SET  [買いWMAs2] = [WMA_買い_WMA_S2]
		,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
		,[買いWMAs14] = [WMA_買い_WMA]
		,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
		,[売りWMAs2] = [WMA_売り_WMA_S2]
		,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
		,[売りWMAs14] = [WMA_売り_WMA]
		,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
	FROM [DemoA_FX].[indi].[T_Indicator_1m]
	WHERE [DemoA_FX].[hstr].[tMin1].[通貨ペアNo] = [DemoA_FX].[indi].[T_Indicator_1m].[通貨ペアNo] AND
		  [DemoA_FX].[hstr].[tMin1].[StartDate] = [DemoA_FX].[indi].[T_Indicator_1m].[日時] AND
		  [DemoA_FX].[hstr].[tMin1].[通貨ペアNo] = @通貨ペアNo;

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO
