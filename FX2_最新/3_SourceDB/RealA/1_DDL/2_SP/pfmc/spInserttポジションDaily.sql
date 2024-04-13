USE OANDA_RealA
GO

DROP PROCEDURE [pfmc].[spInsertポジション実績Daily]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertポジション実績Daily]
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN

	DECLARE @買いRate_始値	float;
	DECLARE @売りRate_始値	float;
	DECLARE @通貨ペアNo		tinyint;

	select top 1 @買いRate_始値 = 買いRate_始値, @売りRate_始値 = 売りRate_始値
	from [hstr].[tHour1]
	where 通貨ペアNo = @通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
	order by [StartDate];


	DECLARE @買いSwap優位時間Cnt	int;
	DECLARE @売りSwap優位時間Cnt	int;

	--SELECT [通貨ペアNo] as 通貨ペアNo, count(*) as 買いSwap優位時間Cnt
	--FROM [hstr].[tHour1]
	--where [買いSwap] > [売りSwap] and '2016/04/01 06:00:00' <= StartDate and StartDate < '2016/05/01 06:00:00'
	--group by [通貨ペアNo]
	SELECT @買いSwap優位時間Cnt = count(*)
	FROM [hstr].[tHour1]
	where [通貨ペアNo] = @通貨ペアNo AND
		  [買いSwap] > [売りSwap] and 
		  @StartDate <= StartDate and StartDate < @EndDate;

	--SELECT [通貨ペアNo] as 通貨ペアNo, count(*) as 売りSwap優位時間Cnt
	--FROM [hstr].[tHour1]
	--where [買いSwap] < [売りSwap] and '2016/04/01 06:00:00' <= StartDate and StartDate < '2016/05/01 06:00:00'
	--group by [通貨ペアNo]
	SELECT @売りSwap優位時間Cnt = count(*)
	FROM [hstr].[tHour1]
	where [通貨ペアNo] = @通貨ペアNo AND
		  [買いSwap] < [売りSwap] and 
		  @StartDate <= StartDate and StartDate < @EndDate;


	DELETE FROM [swap].[tSwap優位時間CntMonthly]
	where [通貨ペアNo] = @通貨ペアNo AND @StartDate = StartDate;

	INSERT INTO [swap].[tSwap優位時間CntMonthly]
		([通貨ペアNo]
		,[StartDate]
		,[買いSwap優位時間Cnt]
		,[売りSwap優位時間Cnt]
		,[登録日時])
	VALUES
		(@通貨ペアNo
		,@StartDate
		,@買いSwap優位時間Cnt
		,@売りSwap優位時間Cnt
		,GETDATE())

END
GO

