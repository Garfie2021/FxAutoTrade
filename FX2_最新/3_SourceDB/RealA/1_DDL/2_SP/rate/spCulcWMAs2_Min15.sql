USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2_Min15]
	@通貨ペアNo	tinyint,
	@StartDate	datetime,
	@買いWMAs2	float	output,
	@売りWMAs2	float	output
AS
BEGIN
	/*	
	declare @通貨ペアNo	tinyint = 0;
	declare @StartDate	datetime = '2015/12/04 21:30:00';
	declare @買いWMAs2	float;
	declare @売りWMAs2	float;
	*/

	declare @日時 datetime;
	declare @買いRate_終値 float = 0;
	declare @売りRate_終値 float = 0;

	declare @期間	float = 2; --  Top 2 が基本値
	declare @三角数	float = 0; --  Top 2 が基本値
	
	exec [cmn].[spGet三角数] @期間, @三角数 output;

	declare cursor_tRateHistory_Min15 cursor for
	SELECT TOP 2 --  Top 2 が基本値
       [StartDate], [買いRate_終値], [売りRate_終値]
	FROM [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate
	order by [StartDate] desc;
	
	open cursor_tRateHistory_Min15;

	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @日時, @買いRate_終値, @売りRate_終値;

	declare @期間Cnt int = @期間;
	Set @買いWMAs2 = 0;
	Set @売りWMAs2 = 0;

	Set @買いWMAs2 = @買いWMAs2 + (@買いRate_終値 * (@期間Cnt / @三角数));
	Set @売りWMAs2 = @売りWMAs2 + (@売りRate_終値 * (@期間Cnt / @三角数));

	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @日時, @買いRate_終値, @売りRate_終値;
	Set @期間Cnt = @期間Cnt - 1;

	Set @買いWMAs2 = @買いWMAs2 + (@買いRate_終値 * (@期間Cnt / @三角数));
	Set @売りWMAs2 = @売りWMAs2 + (@売りRate_終値 * (@期間Cnt / @三角数));

	CLOSE cursor_tRateHistory_Min15;
	DEALLOCATE cursor_tRateHistory_Min15;

	--SELECT @買いWMAs2, @売りWMAs2;

END
GO
/*
*/
