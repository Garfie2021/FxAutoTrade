USE DemoA_FX
GO

DROP PROCEDURE [swap].[spInsertSwap優位時間CntMonthly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spInsertSwap優位時間CntMonthly]
	@通貨ペアNo	tinyint = 34,
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN

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

