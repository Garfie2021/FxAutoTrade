USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs14_Hour1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs14_Hour1]
	@通貨ペアNo	tinyint,
	@StartDate	datetime,
	@買いWMAs14	float	output,
	@売りWMAs14	float	output
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 0;
	declare @StartDate		datetime = '2015-08-24 07:00:00.000';
	declare @買いWMAs14		float;
	declare @売りWMAs14		float;
	*/

	declare @期間	float = 14; --  Top 14 が基本値
	declare @三角数	float = 0; --  Top 14 が基本値
	
	exec [cmn].[spGet三角数] @期間, @三角数 output;

	--SELECT TOP 14 --  Top 14 が基本値
	--	[StartDate], [買いRate_終値], [売りRate_終値]
	--FROM [hltc].[tRateHistory_Hour1]
	--where 通貨ペアNo = @通貨ペアNo and StartDate <= @StartDate
	--order by [StartDate] desc
	declare cursor_tRateHistory_Hour1 cursor for
	SELECT TOP 14 --  Top 14 が基本値
       [StartDate], [買いRate_終値], [売りRate_終値]
	FROM [hstr].[tHour1]
	where 通貨ペアNo = @通貨ペアNo and StartDate <= @StartDate
	order by [StartDate] desc
	
	open cursor_tRateHistory_Hour1;

	declare @日時 datetime;
	declare @買い_終値 float = 0;
	declare @売り_終値 float = 0;
	FETCH NEXT FROM cursor_tRateHistory_Hour1 INTO @日時, @買い_終値, @売り_終値;

	declare @期間Cnt int = @期間;
	Set @買いWMAs14 = 0;
	Set @売りWMAs14 = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		Set @買いWMAs14 = @買いWMAs14 + (@買い_終値 * (@期間Cnt / @三角数));
		Set @売りWMAs14 = @売りWMAs14 + (@売り_終値 * (@期間Cnt / @三角数));

		--select @期間Cnt as 期間Cnt, @三角数 as 三角数, (@期間Cnt / @三角数)
		--select (@買い_終値 * (@期間Cnt / @三角数))
		--select @日時, @買い_終値, @期間Cnt, @三角数, @WMA

		FETCH NEXT FROM cursor_tRateHistory_Hour1 INTO @日時, @買い_終値, @売り_終値;
		Set @期間Cnt = @期間Cnt - 1;
	END

	CLOSE cursor_tRateHistory_Hour1;
	DEALLOCATE cursor_tRateHistory_Hour1;

	--select @通貨ペアNo, @StartDate, @買いWMAs14, @売りWMAs14;

END
GO
/*
*/
