
DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	UPDATE [DemoA_FX].[hstr].[tMin15]
	SET  [����WMAs2] = [WMA_����_WMA_S2]
		,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
		,[����WMAs14] = [WMA_����_WMA]
		,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
		,[����WMAs14�p�x�V�O�}] = [WMA_����_WMA�㏸�p�x_�V�O�}]
		,[����WMAs2] = [WMA_����_WMA_S2]
		,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
		,[����WMAs14] = [WMA_����_WMA]
		,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
		,[����WMAs14�p�x�V�O�}] = [WMA_����_WMA�㏸�p�x_�V�O�}]
	FROM [DemoA_FX].[indi].[T_Indicator_15m]
	WHERE [DemoA_FX].[hstr].[tMin15].[�ʉ݃y�ANo] = [DemoA_FX].[indi].[T_Indicator_15m].[�ʉ݃y�ANo] AND
		  [DemoA_FX].[hstr].[tMin15].[StartDate] = [DemoA_FX].[indi].[T_Indicator_15m].[����] AND
		  [DemoA_FX].[hstr].[tMin15].[�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO


DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	UPDATE [DemoA_FX].[hstr].[tMin5]
	SET  [����WMAs2] = [WMA_����_WMA_S2]
		,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
		,[����WMAs14] = [WMA_����_WMA]
		,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
		,[����WMAs2] = [WMA_����_WMA_S2]
		,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
		,[����WMAs14] = [WMA_����_WMA]
		,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
	FROM [DemoA_FX].[indi].[T_Indicator_5m]
	WHERE [DemoA_FX].[hstr].[tMin5].[�ʉ݃y�ANo] = [DemoA_FX].[indi].[T_Indicator_5m].[�ʉ݃y�ANo] AND
		  [DemoA_FX].[hstr].[tMin5].[StartDate] = [DemoA_FX].[indi].[T_Indicator_5m].[����] AND
		  [DemoA_FX].[hstr].[tMin5].[�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO


DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	UPDATE [DemoA_FX].[hstr].[tMin1]
	SET  [����WMAs2] = [WMA_����_WMA_S2]
		,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
		,[����WMAs14] = [WMA_����_WMA]
		,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
		,[����WMAs2] = [WMA_����_WMA_S2]
		,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
		,[����WMAs14] = [WMA_����_WMA]
		,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
	FROM [DemoA_FX].[indi].[T_Indicator_1m]
	WHERE [DemoA_FX].[hstr].[tMin1].[�ʉ݃y�ANo] = [DemoA_FX].[indi].[T_Indicator_1m].[�ʉ݃y�ANo] AND
		  [DemoA_FX].[hstr].[tMin1].[StartDate] = [DemoA_FX].[indi].[T_Indicator_1m].[����] AND
		  [DemoA_FX].[hstr].[tMin1].[�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO
