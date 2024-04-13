USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_InsertIndicator_15m_WMA]
	@通貨ペアNo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 34;
	declare @StartDate		datetime = '2014-06-28 05:30:00.000';
	*/
	--print '通貨ペアNo:' + convert(varchar, @通貨ペアNo) + '  StartDate:' + convert(varchar, @StartDate)


	-- データ有無チェック

	declare @Cnt int;
	SELECT @Cnt = count(*)
	FROM [dbo].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;


	-- WMAを計算する

	declare @WMA_買い float;
	declare @WMA_売り float;
	declare @WMA_買い_S2 float;
	declare @WMA_売り_S2 float;
	EXECUTE [indi].[SP_CulcWMA_15m] @通貨ペアNo, @StartDate, @WMA_買い OUTPUT, @WMA_売り OUTPUT, @WMA_買い_S2 OUTPUT, @WMA_売り_S2 OUTPUT;
	--select @WMA_買い, @WMA_売り, @WMA_買い_S2, @WMA_売り_S2


	-- WMAの角度を計算する

	Declare @WMA_買い_WMA_1つ前 float = 0;
	Declare @WMA_売り_WMA_1つ前 float = 0;
	Declare @WMA_買い_WMA_1つ前_S2 float = 0;
	Declare @WMA_売り_WMA_1つ前_S2 float = 0;

	select top 1 @WMA_買い_WMA_1つ前 = WMA_買い_WMA, @WMA_売り_WMA_1つ前 = WMA_売り_WMA, @WMA_買い_WMA_1つ前_S2 = WMA_買い_WMA_S2, @WMA_売り_WMA_1つ前_S2 = WMA_売り_WMA_S2
	from [indi].[T_Indicator_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 < @StartDate
	order by [日時] desc

	Declare @底辺x float = 1;

	Declare @上昇角度_買い float;
	Declare @高さy_上昇値_買い float = @WMA_買い - @WMA_買い_WMA_1つ前;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x, @高さy_上昇値_買い, @上昇角度_買い OUTPUT;

	Declare @上昇角度_売り float;
	Declare @高さy_上昇値_売り float = @WMA_売り - @WMA_売り_WMA_1つ前;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x, @高さy_上昇値_売り, @上昇角度_売り OUTPUT;

	Declare @上昇角度_買い_S2 float;
	Declare @高さy_上昇値_買い_S2 float = @WMA_買い_S2 - @WMA_買い_WMA_1つ前_S2;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x, @高さy_上昇値_買い_S2, @上昇角度_買い_S2 OUTPUT;

	Declare @上昇角度_売り_S2 float;
	Declare @高さy_上昇値_売り_S2 float = @WMA_売り_S2 - @WMA_売り_WMA_1つ前_S2;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x, @高さy_上昇値_売り_S2, @上昇角度_売り_S2 OUTPUT;


	-- Bonus Stage 閾値を計算する

	Declare @WMA_買い_WMA上昇角度_シグマ float;
	Declare @WMA_売り_WMA上昇角度_シグマ float;

	-- 過去2ヵ月間の上昇角度平均の3σ
	--SELECT	@WMA_買い_WMA上昇角度_BonusStage閾値 = AVG([WMA_買い_WMA上昇角度]) + (STDEV([WMA_買い_WMA上昇角度]) * 3),
	--		@WMA_売り_WMA上昇角度_BonusStage閾値 = AVG([WMA_売り_WMA上昇角度]) - (STDEV([WMA_売り_WMA上昇角度]) * 3)
	--from [indi].[T_Indicator_15m]
	--where 通貨ペアNo = @通貨ペアNo and DATEADD(month, -2, @StartDate) < 日時 and 日時 < @StartDate

	-- 過去2ヵ月間の上昇角度平均のnσ(何シグマか)

	Declare @WMA_買い_WMA上昇角度_AVG float;
	Declare @WMA_売り_WMA上昇角度_AVG float;
	Declare @WMA_買い_WMA上昇角度_STDEV float;
	Declare @WMA_売り_WMA上昇角度_STDEV float;

	SELECT
		@WMA_買い_WMA上昇角度_AVG = AVG([WMA_買い_WMA上昇角度]),
		@WMA_買い_WMA上昇角度_STDEV = STDEV([WMA_買い_WMA上昇角度]),
		@WMA_売り_WMA上昇角度_AVG = AVG([WMA_売り_WMA上昇角度]),
		@WMA_売り_WMA上昇角度_STDEV = STDEV([WMA_売り_WMA上昇角度])
	from [indi].[T_Indicator_15m]
	where 通貨ペアNo = @通貨ペアNo and DATEADD(month, -2, @StartDate) < 日時 and 日時 < @StartDate

	Set @WMA_買い_WMA上昇角度_シグマ = (@上昇角度_買い - @WMA_買い_WMA上昇角度_AVG) / @WMA_買い_WMA上昇角度_STDEV;				--マイナスの値は判断に使えない
	Set @WMA_売り_WMA上昇角度_シグマ = (@上昇角度_売り + ABS(@WMA_売り_WMA上昇角度_AVG)) / ABS(@WMA_売り_WMA上昇角度_STDEV);	--プラスの値は判断に使えない


	-- 初期レコードを、事前にInsertしておく

	SELECT @Cnt = count(*)
	FROM [indi].[T_Indicator_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	if @Cnt = 0
	begin
		INSERT INTO [indi].[T_Indicator_15m] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @StartDate);
	end


	-- 結果をUpdate

	UPDATE [indi].[T_Indicator_15m]
	SET
		WMA_買い_WMA = @WMA_買い,
		WMA_売り_WMA = @WMA_売り,
		WMA_買い_WMA上昇角度 = @上昇角度_買い,
		WMA_売り_WMA上昇角度 = @上昇角度_売り,
		WMA_買い_WMA上昇角度_シグマ = @WMA_買い_WMA上昇角度_シグマ,
		WMA_売り_WMA上昇角度_シグマ = @WMA_売り_WMA上昇角度_シグマ,
		WMA_買い_WMA_S2 = @WMA_買い_S2,
		WMA_売り_WMA_S2 = @WMA_売り_S2,
		WMA_買い_WMA上昇角度_S2 = @上昇角度_買い_S2,
		WMA_売り_WMA上昇角度_S2 = @上昇角度_売り_S2
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate	

END

GO
