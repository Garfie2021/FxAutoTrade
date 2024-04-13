USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_CulcWMA_Monthly]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_Month		smallint,		-- マイナス値にしか対応していない
	@ThisMonth		date output,
	@WMA			float output
AS
BEGIN

	/*	
	declare @通貨ペアNo		tinyint = 12;
	declare @back_Month		smallint = -50;
	declare @ThisMonth		date
	declare @WMA			float
	*/

	Set @ThisMonth = DATEADD(MONTH, @back_Month, @now);
	Set @ThisMonth = convert(varchar, YEAR(@ThisMonth)) + '/' + convert(varchar, MONTH(@ThisMonth))  + '/1';

	declare @期間	float = 14; --  Top 14 が基本値
	declare @三角数	float = 0; --  Top 14 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_Monthly cursor for
	SELECT TOP 14 --  Top 14 が基本値
       [日時]
	  ,[買い_終値]
      ,[売り_終値]
	FROM [dbo].[T_RateHistory_Monthly]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @ThisMonth
	order by [日時] desc
	
	open cursor_T_RateHistory_Monthly;

	declare @日時 date;
	declare @買い_終値 float = 0;
	declare @売り_終値 float = 0;
	FETCH NEXT FROM cursor_T_RateHistory_Monthly INTO @日時, @買い_終値, @売り_終値;

	declare @期間Cnt int = @期間;
	Set @WMA = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		Set @WMA = @WMA + (@買い_終値 * (@期間Cnt / @三角数));

		--select @期間Cnt as 期間Cnt, @三角数 as 三角数, (@期間Cnt / @三角数)
		--select (@買い_終値 * (@期間Cnt / @三角数))
		--select @日時, @買い_終値, @期間Cnt, @三角数, @WMA

		FETCH NEXT FROM cursor_T_RateHistory_Monthly INTO @日時, @買い_終値, @売り_終値;
		Set @期間Cnt = @期間Cnt - 1;
	END

	CLOSE cursor_T_RateHistory_Monthly;
	DEALLOCATE cursor_T_RateHistory_Monthly;

	--select @通貨ペアNo, @back_Month, @ThisMonth, @WMA
	

END

GO
