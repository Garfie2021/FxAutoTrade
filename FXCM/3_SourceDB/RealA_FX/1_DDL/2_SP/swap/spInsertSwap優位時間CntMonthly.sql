USE DemoA_FX
GO

DROP PROCEDURE [swap].[spInsertSwap�D�ʎ���CntMonthly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spInsertSwap�D�ʎ���CntMonthly]
	@�ʉ݃y�ANo	tinyint = 34,
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN

	DECLARE @����Swap�D�ʎ���Cnt	int;
	DECLARE @����Swap�D�ʎ���Cnt	int;

	--SELECT [�ʉ݃y�ANo] as �ʉ݃y�ANo, count(*) as ����Swap�D�ʎ���Cnt
	--FROM [hstr].[tHour1]
	--where [����Swap] > [����Swap] and '2016/04/01 06:00:00' <= StartDate and StartDate < '2016/05/01 06:00:00'
	--group by [�ʉ݃y�ANo]
	SELECT @����Swap�D�ʎ���Cnt = count(*)
	FROM [hstr].[tHour1]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND
		  [����Swap] > [����Swap] and 
		  @StartDate <= StartDate and StartDate < @EndDate;

	--SELECT [�ʉ݃y�ANo] as �ʉ݃y�ANo, count(*) as ����Swap�D�ʎ���Cnt
	--FROM [hstr].[tHour1]
	--where [����Swap] < [����Swap] and '2016/04/01 06:00:00' <= StartDate and StartDate < '2016/05/01 06:00:00'
	--group by [�ʉ݃y�ANo]
	SELECT @����Swap�D�ʎ���Cnt = count(*)
	FROM [hstr].[tHour1]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND
		  [����Swap] < [����Swap] and 
		  @StartDate <= StartDate and StartDate < @EndDate;


	DELETE FROM [swap].[tSwap�D�ʎ���CntMonthly]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND @StartDate = StartDate;

	INSERT INTO [swap].[tSwap�D�ʎ���CntMonthly]
		([�ʉ݃y�ANo]
		,[StartDate]
		,[����Swap�D�ʎ���Cnt]
		,[����Swap�D�ʎ���Cnt]
		,[�o�^����])
	VALUES
		(@�ʉ݃y�ANo
		,@StartDate
		,@����Swap�D�ʎ���Cnt
		,@����Swap�D�ʎ���Cnt
		,GETDATE())

END
GO

