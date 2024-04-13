
DECLARE @通貨ペアNo	tinyint = 0;
WHILE @通貨ペアNo < 44
BEGIN

	UPDATE [RealB_2370741683_FX].[indi].[T_Indicator_15m]
	SET	 [WMA_買い_WMA] = b.[WMA_買い_WMA]
		,[WMA_売り_WMA] = b.[WMA_売り_WMA]
		,[WMA_買い_WMA上昇角度] = b.[WMA_買い_WMA上昇角度]
		,[WMA_売り_WMA上昇角度] = b.[WMA_売り_WMA上昇角度]
		,[WMA_買い_WMA上昇角度_シグマ] = b.[WMA_買い_WMA上昇角度_シグマ]
		,[WMA_売り_WMA上昇角度_シグマ] = b.[WMA_売り_WMA上昇角度_シグマ]
		,[WMA_買い_WMA_S2] = b.[WMA_買い_WMA_S2]
		,[WMA_売り_WMA_S2] = b.[WMA_売り_WMA_S2]
		,[WMA_買い_WMA上昇角度_S2] = b.[WMA_買い_WMA上昇角度_S2]
		,[WMA_売り_WMA上昇角度_S2] = b.[WMA_売り_WMA上昇角度_S2]
	FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_15m] as b
	WHERE [RealB_2370741683_FX].[indi].[T_Indicator_15m].[通貨ペアNo] = @通貨ペアNo and
		  [RealB_2370741683_FX].[indi].[T_Indicator_15m].[通貨ペアNo] = b.[通貨ペアNo] and 
		  [RealB_2370741683_FX].[indi].[T_Indicator_15m].[日時] = b.[日時]

	SET @通貨ペアNo = @通貨ペアNo + 1;
END;
GO

