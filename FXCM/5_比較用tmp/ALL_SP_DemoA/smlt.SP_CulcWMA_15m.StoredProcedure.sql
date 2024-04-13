USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_CulcWMA_15m]
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@WMA_買い		float		output,
	@WMA_売り		float		output
AS
BEGIN

	/*	
	declare @通貨ペアNo		tinyint = 12;
	declare @StartDate		datetime = '2014/03/06 22:00:00';
	declare @back_Minute	int = 0;		-- マイナス値にしか対応していない
	declare @back_15m		smallint = -50;
	declare @This15m		datetime;
	declare @WMA_買い		float;
	declare @WMA_売り		float;
	*/

	declare @期間	float = 14; --  Top 14 が基本値
	declare @三角数	float = 0; --  Top 14 が基本値
	
	exec [cmn].[SP_Get三角数] @期間, @三角数 output

	declare cursor_T_RateHistory_15m cursor for
	SELECT TOP 14 --  Top 14 が基本値
       [日時]
	  ,[買い_終値]
      ,[売り_終値]
	FROM [smlt].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate
	order by [日時] desc
	
	open cursor_T_RateHistory_15m;

	declare @日時 datetime;
	declare @買い_終値 float = 0;
	declare @売り_終値 float = 0;
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @日時, @買い_終値, @売り_終値;

	declare @期間Cnt int = @期間;
	Set @WMA_買い = 0;
	Set @WMA_売り = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		Set @WMA_買い = @WMA_買い + (@買い_終値 * (@期間Cnt / @三角数));
		Set @WMA_売り = @WMA_売り + (@売り_終値 * (@期間Cnt / @三角数));

		--select @期間Cnt as 期間Cnt, @三角数 as 三角数, (@期間Cnt / @三角数)
		--select (@買い_終値 * (@期間Cnt / @三角数))
		--select @日時, @買い_終値, @期間Cnt, @三角数, @WMA

		FETCH NEXT FROM cursor_T_RateHistory_15m INTO @日時, @買い_終値, @売り_終値;
		Set @期間Cnt = @期間Cnt - 1;
	END

	CLOSE cursor_T_RateHistory_15m;
	DEALLOCATE cursor_T_RateHistory_15m;

	--select @通貨ペアNo, @back_15m, @This15m, @WMA
	


END

GO
