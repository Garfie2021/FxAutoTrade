
DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	UPDATE [RealA_FX].[indi].[T_Indicator_15m]
	SET	 [WMA_����_WMA] = b.[WMA_����_WMA]
		,[WMA_����_WMA] = b.[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x] = b.[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x] = b.[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x_�V�O�}] = b.[WMA_����_WMA�㏸�p�x_�V�O�}]
		,[WMA_����_WMA�㏸�p�x_�V�O�}] = b.[WMA_����_WMA�㏸�p�x_�V�O�}]
		,[WMA_����_WMA_S2] = b.[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2] = b.[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2] = b.[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2] = b.[WMA_����_WMA�㏸�p�x_S2]
	FROM [RealA_FX_ACV].[indi].[T_Indicator_15m] as b
	WHERE [RealA_FX].[indi].[T_Indicator_15m].[�ʉ݃y�ANo] = @�ʉ݃y�ANo and
		  [RealA_FX].[indi].[T_Indicator_15m].[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] and 
		  [RealA_FX].[indi].[T_Indicator_15m].[����] = b.[����]

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

