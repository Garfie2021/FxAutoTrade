USE [RealA_FX_ACV];
go

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_Monthly]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_Monthly]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_Monthly_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
GO

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_Weekly]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_Weekly]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_Weekly_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
GO

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_Daily]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_Daily]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_Daily_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
GO

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	--DECLARE @úMin	datetime;
	--SELECT @úMin = MIN([ú]) 
	--delete FROM [indi].[T_Indicator_6h]

	--delete FROM  [RealA_FX_ACV].[indi].[T_Indicator_6h]

	INSERT INTO [RealA_FX_ACV].[indi].[T_Indicator_6h]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [RealA_FX].[acv].[T_Indicator_6h_Past]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
go

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_1h]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_1h]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_1h_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
go

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_30m]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_30m]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_30m_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
go

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_15m]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_15m]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_15m_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
go

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_5m]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_5m]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_5m_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
go

DECLARE @ÊÝyANo	tinyint = 0;
WHILE @ÊÝyANo < 44
BEGIN

	DECLARE @úMin	datetime;
	SELECT @úMin = MIN([ú]) 
	FROM [indi].[T_Indicator_1m]
	WHERE [ÊÝyANo] = @ÊÝyANo;

	--SELECT @ÊÝyANo, @úMin;
	INSERT INTO [indi].[T_Indicator_1m]
		([ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2])
	SELECT 
		 [ÊÝyANo]
		,[ú]
		,[WMA_¢_WMA]
		,[WMA_è_WMA]
		,[WMA_¢_WMAã¸px]
		,[WMA_è_WMAã¸px]
		,[WMA_¢_WMA_S2]
		,[WMA_è_WMA_S2]
		,[WMA_¢_WMAã¸px_S2]
		,[WMA_è_WMAã¸px_S2]
	FROM [acv].[T_Indicator_1m_Past]
	WHERE [ú] < @úMin AND [ÊÝyANo] = @ÊÝyANo;

	SET @ÊÝyANo = @ÊÝyANo + 1;
END;
go

