USE [RealA_FX_ACV];
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_Monthly]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [dbo].[T_RateHistory_Monthly]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Monthly_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_Weekly]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_Weekly]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Weekly_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_Daily]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT @�ʉ݃y�ANo, @����Min;
	INSERT INTO [dbo].[T_RateHistory_Daily]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Daily_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_6h]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_6h]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_6h_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go


DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_Hourly]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_Hourly]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_Hourly_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_30m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_30m]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_30m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_15m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_15m]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_15m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_5m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_5m]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_5m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([����]) 
	FROM [dbo].[T_RateHistory_1m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory_1m]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[StartDate]
		,[EndDate]
	FROM [acv].[T_RateHistory_1m_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	DECLARE @����Min	datetime;
	SELECT @����Min = MIN([Date]) 
	FROM [dbo].[T_RateHistory]
	WHERE [�ʉ݃y�A] = @�ʉ݃y�ANo;

	INSERT INTO [dbo].[T_RateHistory]
		([�ʉ݃y�A]
		,[Date]
		,[Rate_����]
		,[Rate_����]
		,[Swap_����]
		,[Swap_����])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[Rate_����]
		,[Rate_����]
		,[Swap_����]
		,[Swap_����]
	FROM [acv].[T_RateHistory_Past]
	WHERE [����] < @����Min AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
go

