USE [RealB_2370741683_FX_ACV];
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_Monthly]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_Monthly]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_Monthly_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_Weekly]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_Weekly]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_Weekly_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_Daily]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_Daily]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_Daily_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

delete FROM  [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h]

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	INSERT INTO [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [RealB_2370741683_FX].[acv].[T_Indicator_6h_Past]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_1h]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_1h]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_1h_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_30m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_30m]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_30m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_15m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_15m]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_15m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_5m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_5m]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_5m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [indi].[T_Indicator_1m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [indi].[T_Indicator_1m]
		([�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2])
	SELECT 
		 [�ʉ݃y�ANo]
		,[����]
		,[WMA_����_WMA]
		,[WMA_����_WMA]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA�㏸�p�x]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
		,[WMA_����_WMA�㏸�p�x_S2]
	FROM [acv].[T_Indicator_1m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

