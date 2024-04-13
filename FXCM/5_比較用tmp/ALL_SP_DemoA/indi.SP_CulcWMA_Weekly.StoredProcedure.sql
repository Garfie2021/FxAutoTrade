USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_CulcWMA_Weekly]
	@通貨ペアNo		tinyint,
	@back_Week		smallint,		-- マイナス値にしか対応していない
	@now			Datetime,
	@ThisWeek		date output,
	@WMA			float output,
	@WMA_S2			float output
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 0;
	declare @back_Week		smallint = -3;
	declare @ThisWeek		date
	declare @WMA			float
	declare @WMA_S2			float
	declare @now			Datetime = '2014/6/7 2:37:00'
	*/

	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThisWeek] @now, @back_Week, @ThisWeek OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	--select @ThisWeek, @StartDate, @EndDate
	
	declare @期間	float = 14; --  Top 14 が基本値
	declare @三角数	float = 0; --  Top 14 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_Weekly cursor for
	SELECT TOP 14 --  Top 14 が基本値
       [日時], [買い_終値], [売り_終値]
	FROM [dbo].[T_RateHistory_Weekly]
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @ThisWeek
	order by [日時] desc
	
	open cursor_T_RateHistory_Weekly;

	declare @日時 date;
	declare @買い_終値 float = 0;
	declare @売り_終値 float = 0;
	FETCH NEXT FROM cursor_T_RateHistory_Weekly INTO @日時, @買い_終値, @売り_終値;

	declare @期間Cnt int = @期間;
	Set @WMA = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		Set @WMA = @WMA + (@買い_終値 * (@期間Cnt / @三角数));

		--select @期間Cnt as 期間Cnt, @三角数 as 三角数, (@期間Cnt / @三角数)
		--select (@買い_終値 * (@期間Cnt / @三角数))
		--select @日時, @買い_終値, @期間Cnt, @三角数, @WMA

		FETCH NEXT FROM cursor_T_RateHistory_Weekly INTO @日時, @買い_終値, @売り_終値;
		Set @期間Cnt = @期間Cnt - 1;
	END

	CLOSE cursor_T_RateHistory_Weekly;
	DEALLOCATE cursor_T_RateHistory_Weekly;

	Set @期間 = 2; --  Top 2 が基本値
	Set @三角数 = 0; --  Top 2 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_Weekly cursor for
	SELECT TOP 2 --  Top 2 が基本値
       [日時], [買い_終値], [売り_終値]
	FROM [dbo].[T_RateHistory_Weekly]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @ThisWeek
	order by [日時] desc
	
	open cursor_T_RateHistory_Weekly;

	FETCH NEXT FROM cursor_T_RateHistory_Weekly INTO @日時, @買い_終値, @売り_終値;

	Set @期間Cnt = @期間;
	Set @WMA_S2 = 0;

	Set @WMA_S2 = @WMA_S2 + (@買い_終値 * (@期間Cnt / @三角数));

	FETCH NEXT FROM cursor_T_RateHistory_Weekly INTO @日時, @買い_終値, @売り_終値;
	Set @期間Cnt = @期間Cnt - 1;

	Set @WMA_S2 = @WMA_S2 + (@買い_終値 * (@期間Cnt / @三角数));

	CLOSE cursor_T_RateHistory_Weekly;
	DEALLOCATE cursor_T_RateHistory_Weekly;

	--select @通貨ペアNo, @back_Week, @ThisWeek, @WMA, @WMA_S2

END

GO
