USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_InsertIndicator_5m_WMA]
	@通貨ペアNo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 12
	declare @StartDate		datetime
	*/

	-- WMAを計算する

	declare @WMA_買い float;
	declare @WMA_売り float;
	EXECUTE [indi].[SP_CulcWMA_5m] @通貨ペアNo, @StartDate, @WMA_買い OUTPUT, @WMA_売り OUTPUT


	-- WMAの角度を計算する

	Declare @WMA_買い_WMA_15分前 float = 0;
	Declare @WMA_売り_WMA_15分前 float = 0;

	select top 1 @WMA_買い_WMA_15分前 = WMA_買い_WMA, @WMA_売り_WMA_15分前 = WMA_売り_WMA
	from [indi].[T_Indicator_5m]
	where 通貨ペアNo = @通貨ペアNo and 日時 < @StartDate	
	order by [日時] desc

	Declare @底辺x_月 float = 1;
	Declare @高さy_上昇値 float = @WMA_買い - @WMA_買い_WMA_15分前;

	Declare @上昇角度_買い float;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x_月, @高さy_上昇値, @上昇角度_買い OUTPUT

	Set @高さy_上昇値 = @WMA_売り - @WMA_売り_WMA_15分前;

	Declare @上昇角度_売り float;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x_月, @高さy_上昇値, @上昇角度_売り OUTPUT


	-- Bonus Stage 閾値を計算する

	Declare @WMA_買い_WMA上昇角度_シグマ float;
	Declare @WMA_売り_WMA上昇角度_シグマ float;

	-- 過去2ヵ月間の上昇角度平均の3σ
	--SELECT	@WMA_買い_WMA上昇角度_BonusStage閾値 = AVG([WMA_買い_WMA上昇角度]) + (STDEV([WMA_買い_WMA上昇角度]) * 3),
	--		@WMA_売り_WMA上昇角度_BonusStage閾値 = AVG([WMA_売り_WMA上昇角度]) - (STDEV([WMA_売り_WMA上昇角度]) * 3)
	--from [indi].[T_Indicator_5m]
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
	from [indi].[T_Indicator_5m]
	where 通貨ペアNo = @通貨ペアNo and DATEADD(month, -2, @StartDate) < 日時 and 日時 < @StartDate

	Set @WMA_買い_WMA上昇角度_シグマ = (@上昇角度_買い - @WMA_買い_WMA上昇角度_AVG) / @WMA_買い_WMA上昇角度_STDEV;				--マイナスの値は判断に使えない
	Set @WMA_売り_WMA上昇角度_シグマ = (@上昇角度_売り + ABS(@WMA_売り_WMA上昇角度_AVG)) / ABS(@WMA_売り_WMA上昇角度_STDEV);	--プラスの値は判断に使えない


	-- 初期レコードを、事前にInsertしておく

	declare @Cnt int = 0;
	SELECT @Cnt = count(*)
	FROM [indi].[T_Indicator_5m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	if @Cnt = 0
	begin
		INSERT INTO [indi].[T_Indicator_5m] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @StartDate);
	end


	-- 結果をUpdate

	UPDATE [indi].[T_Indicator_5m]
	SET
		WMA_買い_WMA = @WMA_買い,
		WMA_売り_WMA = @WMA_売り,
		WMA_買い_WMA上昇角度 = @上昇角度_買い,
		WMA_売り_WMA上昇角度 = @上昇角度_売り,
		WMA_買い_WMA上昇角度_シグマ = @WMA_買い_WMA上昇角度_シグマ,
		WMA_売り_WMA上昇角度_シグマ = @WMA_売り_WMA上昇角度_シグマ
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate


END


GO
