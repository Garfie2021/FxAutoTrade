USE [DemoA_FX];
go

DELETE FROM [hstr].[tMin15];
GO
DELETE FROM [hstr].[tMin5];
GO
DELETE FROM [hstr].[tMin1];
GO
DELETE FROM [hstr].[tSec];



DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	INSERT INTO [hstr].[tMin15]
        ([�ʉ݃y�ANo]
        ,[StartDate]
        ,[����Rate_�n�l]
        ,[����Rate_���l]
        ,[����Rate_���l]
        ,[����Rate_�I�l]
        ,[����Rate_�n�l]
        ,[����Rate_���l]
        ,[����Rate_���l]
        ,[����Rate_�I�l])
	SELECT 
		 [�ʉ݃y�ANo]
		,[StartDate]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
	FROM [dbo].[T_RateHistory_15m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	INSERT INTO [hstr].[tMin5]
        ([�ʉ݃y�ANo]
        ,[StartDate]
        ,[����Rate_�n�l]
        ,[����Rate_���l]
        ,[����Rate_���l]
        ,[����Rate_�I�l]
        ,[����Rate_�n�l]
        ,[����Rate_���l]
        ,[����Rate_���l]
        ,[����Rate_�I�l])
	SELECT 
		 [�ʉ݃y�ANo]
		,[StartDate]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
	FROM [dbo].[T_RateHistory_5m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	INSERT INTO [hstr].[tMin1]
        ([�ʉ݃y�ANo]
        ,[StartDate]
        ,[����Rate_�n�l]
        ,[����Rate_���l]
        ,[����Rate_���l]
        ,[����Rate_�I�l]
        ,[����Rate_�n�l]
        ,[����Rate_���l]
        ,[����Rate_���l]
        ,[����Rate_�I�l])
	SELECT 
		 [�ʉ݃y�ANo]
		,[StartDate]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
	FROM [dbo].[T_RateHistory_1m]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

DECLARE @�ʉ݃y�ANo	tinyint = 0;
WHILE @�ʉ݃y�ANo < 44
BEGIN

	INSERT INTO [hstr].[tSec]
        ([�ʉ݃y�ANo]
        ,[StartDate]
        ,[����Swap]
        ,[����Rate]
        ,[����Swap]
        ,[����Rate])
	SELECT 
		 [�ʉ݃y�A]
		,[Date]
		,[Swap_����]
		,[Rate_����]
		,[Swap_����]
		,[Rate_����]
	FROM [dbo].[T_RateHistory]
	WHERE [�ʉ݃y�A] = @�ʉ݃y�ANo;

	SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
END;
GO

