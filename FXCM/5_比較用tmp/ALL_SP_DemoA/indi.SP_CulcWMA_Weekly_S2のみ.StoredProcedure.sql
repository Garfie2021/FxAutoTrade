USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_CulcWMA_Weekly_S2のみ]
	@通貨ペアNo		tinyint,
	@StartDate		date,
	@WMA_買い_S2	float	output,
	@WMA_売り_S2	float	output
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 34
	declare @StartDate		datetime = '2014-06-28 05:30:00.000'
	declare @WMA_買い_S2	float
	declare @WMA_売り_S2	float
	*/

	declare @日時 date;
	declare @買い_終値 float = 0;
	declare @売り_終値 float = 0;

	declare @期間	float = 2; --  Top 2 が基本値
	declare @三角数	float = 0; --  Top 2 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_Weekly cursor for
	SELECT TOP 2 --  Top 2 が基本値
       [日時], [買い_終値], [売り_終値]
	FROM [dbo].[T_RateHistory_Weekly]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate
	order by [日時] desc
	
	open cursor_T_RateHistory_Weekly;

	FETCH NEXT FROM cursor_T_RateHistory_Weekly INTO @日時, @買い_終値, @売り_終値;

	declare @期間Cnt int = @期間;
	Set @WMA_買い_S2 = 0;
	Set @WMA_売り_S2 = 0;

	Set @WMA_買い_S2 = @WMA_買い_S2 + (@買い_終値 * (@期間Cnt / @三角数));
	Set @WMA_売り_S2 = @WMA_売り_S2 + (@売り_終値 * (@期間Cnt / @三角数));

	FETCH NEXT FROM cursor_T_RateHistory_Weekly INTO @日時, @買い_終値, @売り_終値;
	Set @期間Cnt = @期間Cnt - 1;

	Set @WMA_買い_S2 = @WMA_買い_S2 + (@買い_終値 * (@期間Cnt / @三角数));
	Set @WMA_売り_S2 = @WMA_売り_S2 + (@売り_終値 * (@期間Cnt / @三角数));

	CLOSE cursor_T_RateHistory_Weekly;
	DEALLOCATE cursor_T_RateHistory_Weekly;

END

GO
