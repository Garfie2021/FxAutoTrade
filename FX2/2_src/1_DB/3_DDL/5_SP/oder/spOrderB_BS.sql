USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spOrderB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderB]
	@通貨ペアNo				tinyint,
	@StartDate				datetime,
	@買いRate				float,
	@売りRate				float,
	@注文単位				float,
	@OrderV1_余剰金の割合	float,
	@注文判定				tinyint output
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 21
	DECLARE @StartDate		datetime = getdate()
	DECLARE @シグマ閾値		float = 2.5
	DECLARE @WMA判定		varchar(5)
	DECLARE @BonusStage判定	varchar(5)
	DECLARE @WMA前_S2		float = 2.5
	DECLARE @WMA今_S2		float = 2.5
	*/

	/*** Rate記録 START ***/

	EXECUTE [rate].[spInsertRateHistory] @通貨ペアNo ,@StartDate ,@買いRate ,@売りRate


	/*** 基本Rate記録 START ***/

	EXECUTE [rate].[spInsertRateHistory_Min1] @通貨ペアNo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Min5] @通貨ペアNo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Min15] @通貨ペアNo ,@StartDate ,0;
	--30分以上のRate計算はJob定期実行（一分おき）で行う


	/*** 計算 START ***/

	DECLARE @計算対象 tinyint
	EXECUTE [oder].[spChk計算対象] @通貨ペアNo ,@計算対象 OUTPUT;
	if @計算対象 = 0
	begin
		return;
	end

	EXECUTE [rate].[spUpdateWMA_Min15] @通貨ペアNo ,@StartDate;


	/*** 注文判定 START ***/

	--角度が上昇していてシグマがマイナスの場合、角度が下降していてシグマがプラスの場合は、明らかに注文対象外。

	DECLARE @注文対象 tinyint
	EXECUTE [oder].[spChk注文対象] @通貨ペアNo ,@注文対象 OUTPUT;
	if @注文対象 = 0
	begin
		return;
	end

	-- 前回の判定結果をクリア
	UPDATE [oder].[tOrderSettings]
	SET
      ,[Swap判定] = 0
      ,[WMA判定_Monthly] = 0
      ,[WMA判定_Monthly_S2_GC] = 0
      ,[WMA角度判定_Monthly] = 0
      ,[危険Rate判定_Monthly] = 0
      ,[危険Rate判定_Weekly] = 0
      ,[危険Rate判定_Daily] = 0
      ,[SMLT_シグマ閾値] = 0
      ,[BonusStage判定_前] = 0
      ,[BonusStage判定_今] = 0
      ,[売買判定] = 0
      ,[Rate終値_1つ前_月] = 0
      ,[Rate終値_1つ前_週] = 0
      ,[Rate終値_1つ前_日] = 0
      ,[Rate終値_1つ前_6h] = 0
      ,[Rate終値_1つ前_1h] = 0
      ,[Rate終値_1つ前_30m] = 0
      ,[Rate終値_1つ前_Min15] = 0
      ,[Rate終値_1つ前_5m] = 0
      ,[Rate終値_1つ前_1m] = 0
      ,[WMA今_Monthly] = 0
      ,[WMA_Monthly] = 0
      ,[WMA角度前_Monthly] = 0
      ,[WMA角度今_Monthly] = 0
      ,[WMA前_Monthly_S2] = 0
      ,[WMA今_Monthly_S2] = 0
      ,[WMA前_Weekly_S2] = 0
      ,[WMA今_Weekly_S2] = 0
      ,[WMA前_Daily_S2] = 0
      ,[WMA今_Daily_S2] = 0
      ,[WMA前_6h_S2] = 0
      ,[WMA今_6h_S2] = 0
      ,[WMA前_1h_S2] = 0
      ,[WMA今_1h_S2] = 0
      ,[WMA前_30m_S2] = 0
      ,[WMA今_30m_S2] = 0
      ,[WMA前_Min15_S2] = 0
      ,[WMA今_Min15_S2] = 0
      ,[WMA前_5m_S2] = 0
      ,[WMA今_5m_S2] = 0
      ,[WMA前_1m_S2] = 0
      ,[WMA今_1m_S2] = 0
      ,[Rate高値_先月] = 0
      ,[Rate安値_先月] = 0
      ,[Rate高値_先週] = 0
      ,[Rate安値_先週] = 0
      ,[Rate高値_先日] = 0
      ,[Rate安値_先日] = 0
      ,[Rate高値_30m前] = 0
      ,[Rate安値_30m前] = 0
      ,[Rate高値_Min15前] = 0
      ,[Rate安値_Min15前] = 0
      ,[Rate高値_5m前] = 0
      ,[Rate安値_5m前] = 0
      ,[SMLT_直近1ヵ月の利益Sum] = 0
      ,[高値安値_Monthly] = 0
      ,[高値安値_Weekly] = 0
      ,[高値安値_Daily] = 0
      ,[WMA前_Min15] = 0
      ,[WMA今_Min15] = 0
      ,[WMA上昇角度_今_Min15] = 0
      ,[WMA判定_Min15] = 0
      ,[取引状況] = 0
	WHERE [通貨ペアNo] = @通貨ペアNo;

	@OrderV1_余剰金の割合

	if @買いRate = 0 or @売りRate = 0
	begin
		EXECUTE [oder].[spUpdateOrderSettings_取引状況] @通貨ペアNo ,'Order対象外（Rateが0）';
		return;
	end



	-- 直近の指標を取得

	DECLARE @今_買いWMA float;
	DECLARE @今_売りWMA float;
	DECLARE @今_買いWMA上昇角度 float;
	DECLARE @今_売りWMA上昇角度 float;
	DECLARE @今_買いWMA上昇角度_シグマ float;
	DECLARE @今_売りWMA上昇角度_シグマ float;
	DECLARE @1つ前_買いWMA float;
	DECLARE @1つ前_売りWMA float;
	DECLARE @1つ前_買いWMA上昇角度 float;
	DECLARE @1つ前_売りWMA上昇角度 float;
	DECLARE @1つ前_買いWMA上昇角度_シグマ float;
	DECLARE @1つ前_売りWMA上昇角度_シグマ float;

	DECLARE cursor_tIndicatorHistory_Min15 CURSOR FOR
	SELECT TOP 2 [買いWMA], [売りWMA], [買いWMA上昇角度], [売りWMA上昇角度], [買いWMA上昇角度_シグマ], [売りWMA上昇角度_シグマ]
	FROM [indi].[tIndicatorHistory_Min15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate
	order by [StartDate] desc

	open cursor_tIndicatorHistory_Min15;
	
	FETCH NEXT FROM cursor_tIndicatorHistory_Min15 INTO @今_買いWMA, @今_売りWMA, @今_買いWMA上昇角度, 
		@今_売りWMA上昇角度, @今_買いWMA上昇角度_シグマ, @今_売りWMA上昇角度_シグマ;

	FETCH NEXT FROM cursor_tIndicatorHistory_Min15 INTO @1つ前_買いWMA, @1つ前_売りWMA, @1つ前_買いWMA上昇角度, 
		@1つ前_売りWMA上昇角度, @1つ前_買いWMA上昇角度_シグマ, @1つ前_売りWMA上昇角度_シグマ;

	CLOSE cursor_tIndicatorHistory_Min15;
	DEALLOCATE cursor_tIndicatorHistory_Min15;


	-- 直近のRateを取得

	DECLARE @1つ前_買い_始値 float;
	DECLARE @1つ前_買い_高値 float;
	DECLARE @1つ前_買い_安値 float;
	DECLARE @1つ前_買い_終値 float;
	DECLARE @1つ前_売り_始値 float;
	DECLARE @1つ前_売り_高値 float;
	DECLARE @1つ前_売り_安値 float;
	DECLARE @1つ前_売り_終値 float;
	DECLARE @今_買い_始値 float;
	DECLARE @今_買い_高値 float;
	DECLARE @今_買い_安値 float;
	DECLARE @今_買い_終値 float;
	DECLARE @今_売り_始値 float;
	DECLARE @今_売り_高値 float;
	DECLARE @今_売り_安値 float;
	DECLARE @今_売り_終値 float;

	DECLARE cursor_tRateHistory_Min15 CURSOR FOR
	SELECT TOP 3 [買い_始値], [買い_高値], [買い_安値], [買い_終値], [売り_始値], [売り_高値], [売り_安値], [売り_終値]
	FROM [dbo].[tRateHistory_Min15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate
	order by [StartDate] desc

	open cursor_tRateHistory_Min15;
	
	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @今_買い_始値, @今_買い_高値, @今_買い_安値, @今_買い_終値, @今_売り_始値, @今_売り_高値, @今_売り_安値, @今_売り_終値;
	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @1つ前_買い_始値, @1つ前_買い_高値, @1つ前_買い_安値, @1つ前_買い_終値, @1つ前_売り_始値, @1つ前_売り_高値, @1つ前_売り_安値, @1つ前_売り_終値;

	CLOSE cursor_tRateHistory_Min15;
	DEALLOCATE cursor_tRateHistory_Min15;

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate


	-- Bonus Stage 判定

	Set @WMA判定 = '';
	Set @BonusStage判定 = '';

	if @1つ前_買いWMA < @今_買いWMA
	begin

		Set @WMA判定 = '買い'
		Set @WMA前 = @1つ前_買いWMA;
		Set @WMA今 = @今_買いWMA;
		Set @WMA上昇角度_今 = @今_買いWMA上昇角度;

		if @今_買いWMA上昇角度_シグマ < @シグマ閾値
		begin
			return;
		end

		if @1つ前_買いWMA上昇角度 > @今_買いWMA上昇角度
		begin
			return;
		end

		if @1つ前_買い_安値 > @今_買い_安値
		begin
			return;
		end

		if @1つ前_買い_高値 > @今_買い_高値
		begin
			return;
		end

		Set @BonusStage判定 = 'B';	-- Bonus Stage 開始

	end
	else if @1つ前_売りWMA > @今_売りWMA
	begin

		Set @WMA判定 = '売り'
		Set @WMA前 = @1つ前_売りWMA;
		Set @WMA今 = @今_売りWMA;
		Set @WMA上昇角度_今 = @今_売りWMA上昇角度;

		if @今_売りWMA上昇角度_シグマ < @シグマ閾値
		begin
			return;
		end

		if @1つ前_売りWMA上昇角度 < @今_売りWMA上昇角度
		begin
			return;
		end

		if @1つ前_売り_安値 < @今_売り_安値
		begin
			return;
		end

		if @1つ前_売り_高値 < @今_売り_高値
		begin
			return;
		end

		Set @BonusStage判定 = 'B';	-- Bonus Stage 開始

	end

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @WMA判定 as WMA判定, @BonusStage判定 as BonusStage判定

END
GO
/*
*/

