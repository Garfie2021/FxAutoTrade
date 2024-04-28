USE OANDA_RealA
GO

DROP PROCEDURE [pfmc].[spInsert�|�W�V��������Daily]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsert�|�W�V��������Daily]
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN

	DECLARE @����Rate_�n�l	float;
	DECLARE @����Rate_�n�l	float;
	DECLARE @�ʉ݃y�ANo		tinyint;

	select top 1 @����Rate_�n�l = ����Rate_�n�l, @����Rate_�n�l = ����Rate_�n�l
	from [hstr].[tHour1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
	order by [StartDate];


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

