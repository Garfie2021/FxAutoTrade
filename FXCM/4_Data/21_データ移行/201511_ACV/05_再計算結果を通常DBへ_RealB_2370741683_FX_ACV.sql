
DECLARE @ΚέyANo	tinyint = 0;
WHILE @ΚέyANo < 44
BEGIN

	UPDATE [RealB_2370741683_FX].[indi].[T_Indicator_15m]
	SET	 [WMA_’_WMA] = b.[WMA_’_WMA]
		,[WMA_θ_WMA] = b.[WMA_θ_WMA]
		,[WMA_’_WMAγΈpx] = b.[WMA_’_WMAγΈpx]
		,[WMA_θ_WMAγΈpx] = b.[WMA_θ_WMAγΈpx]
		,[WMA_’_WMAγΈpx_VO}] = b.[WMA_’_WMAγΈpx_VO}]
		,[WMA_θ_WMAγΈpx_VO}] = b.[WMA_θ_WMAγΈpx_VO}]
		,[WMA_’_WMA_S2] = b.[WMA_’_WMA_S2]
		,[WMA_θ_WMA_S2] = b.[WMA_θ_WMA_S2]
		,[WMA_’_WMAγΈpx_S2] = b.[WMA_’_WMAγΈpx_S2]
		,[WMA_θ_WMAγΈpx_S2] = b.[WMA_θ_WMAγΈpx_S2]
	FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_15m] as b
	WHERE [RealB_2370741683_FX].[indi].[T_Indicator_15m].[ΚέyANo] = @ΚέyANo and
		  [RealB_2370741683_FX].[indi].[T_Indicator_15m].[ΚέyANo] = b.[ΚέyANo] and 
		  [RealB_2370741683_FX].[indi].[T_Indicator_15m].[ϊ] = b.[ϊ]

	SET @ΚέyANo = @ΚέyANo + 1;
END;
GO

