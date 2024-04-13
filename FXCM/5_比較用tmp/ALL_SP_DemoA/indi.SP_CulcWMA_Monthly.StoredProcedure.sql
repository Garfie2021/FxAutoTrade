USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_CulcWMA_Monthly]
	@通貨ペアNo		tinyint,
	@StartDate		date,
	@WMA_買い		float		output,
	@WMA_売り		float		output,
	@WMA_買い_S2	float		output,
	@WMA_売り_S2	float		output
AS
BEGIN
	/*	
	declare @通貨ペアNo		tinyint = 34
	declare @StartDate		datetime = '2014-06-28 05:30:00.000'
	declare @WMA_買い		float
	declare @WMA_売り		float
	declare @WMA_買い_S2	float
	declare @WMA_売り_S2	float
	*/


	declare @期間	float = 14; --  Top 14 が基本値
	declare @三角数	float = 0; --  Top 14 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_Monthly cursor for
	SELECT TOP 14 --  Top 14 が基本値
       [日時], [買い_終値], [売り_終値]
	FROM [dbo].[T_RateHistory_Monthly]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate
	order by [日時] desc
	
	open cursor_T_RateHistory_Monthly;

	declare @日時 date;
	declare @買い_終値 float = 0;
	declare @売り_終値 float = 0;
	FETCH NEXT FROM cursor_T_RateHistory_Monthly INTO @日時, @買い_終値, @売り_終値;

	declare @期間Cnt int = @期間;
	Set @WMA_買い = 0;
	Set @WMA_売り = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		Set @WMA_買い = @WMA_買い + (@買い_終値 * (@期間Cnt / @三角数));
		Set @WMA_売り = @WMA_売り + (@売り_終値 * (@期間Cnt / @三角数));

		--select @期間Cnt as 期間Cnt, @三角数 as 三角数, (@期間Cnt / @三角数)
		--select (@買い_終値 * (@期間Cnt / @三角数))
		--select @日時, @買い_終値, @期間Cnt, @三角数, @WMA_買い

		FETCH NEXT FROM cursor_T_RateHistory_Monthly INTO @日時, @買い_終値, @売り_終値;
		Set @期間Cnt = @期間Cnt - 1;
	END

	CLOSE cursor_T_RateHistory_Monthly;
	DEALLOCATE cursor_T_RateHistory_Monthly;


	Set @期間 = 2; --  Top 2 が基本値
	Set @三角数 = 0; --  Top 2 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_Monthly cursor for
	SELECT TOP 2 --  Top 2 が基本値
       [日時], [買い_終値], [売り_終値]
	FROM [dbo].[T_RateHistory_Monthly]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate
	order by [日時] desc
	
	open cursor_T_RateHistory_Monthly;

	FETCH NEXT FROM cursor_T_RateHistory_Monthly INTO @日時, @買い_終値, @売り_終値;

	Set @期間Cnt = @期間;
	Set @WMA_買い_S2 = 0;
	Set @WMA_売り_S2 = 0;

	Set @WMA_買い_S2 = @WMA_買い_S2 + (@買い_終値 * (@期間Cnt / @三角数));
	Set @WMA_売り_S2 = @WMA_売り_S2 + (@売り_終値 * (@期間Cnt / @三角数));
	
	FETCH NEXT FROM cursor_T_RateHistory_Monthly INTO @日時, @買い_終値, @売り_終値;
	Set @期間Cnt = @期間Cnt - 1;

	Set @WMA_買い_S2 = @WMA_買い_S2 + (@買い_終値 * (@期間Cnt / @三角数));
	Set @WMA_売り_S2 = @WMA_売り_S2 + (@売り_終値 * (@期間Cnt / @三角数));

	CLOSE cursor_T_RateHistory_Monthly;
	DEALLOCATE cursor_T_RateHistory_Monthly;


	--select @通貨ペアNo, @back_Month, @StartDate, @WMA_買い, @WMA_買い_S2

END

GO
