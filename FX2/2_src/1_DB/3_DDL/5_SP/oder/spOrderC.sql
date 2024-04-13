USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spOrderC]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderC]
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


	/*** 計算 START ***/

	DECLARE @計算対象 tinyint
	EXECUTE [oder].[spChk計算対象] @通貨ペアNo ,@計算対象 OUTPUT;
	if @計算対象 = 0
	begin
		return;
	end

	EXECUTE [rate].[spInsertRateHistory_Month1] @通貨ペアNo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Week1] @通貨ペアNo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Day1] @通貨ペアNo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Min15] @通貨ペアNo ,@StartDate ,0;

	EXECUTE [indi].[spInsertIndicatorHistory_Month1_WMA] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Month1_WMA_S2] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Week1_WMA] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Week1_WMA_S2] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Day1_WMA] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Day1_WMA_S2] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Min15_WMA] @通貨ペアNo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Min15_WMA_S2] @通貨ペアNo ,@StartDate;



	/*** 注文判定 START ***/

	-- 注文対象外？
	DECLARE @注文対象 tinyint
	EXECUTE [oder].[spChk注文対象] @通貨ペアNo ,@注文対象 OUTPUT;
	if @注文対象 = 0
	begin
		return;
	end

	-- 前回の判定結果をクリア
	UPDATE [oder].[tOrderSettings]
	SET [売買判定] = 0,
		[取引状況] = ''
	WHERE [通貨ペアNo] = @通貨ペアNo;

	-- Rateに異常あり？
	if @買いRate = 0 or @売りRate = 0
	begin
		EXECUTE [oder].[spUpdateOrderSettings_取引状況] @通貨ペアNo ,'Order対象外（Rateが0）';
		return;
	end

	DECLARE @売買判定 tinyint
	DECLARE @相反 tinyint
	EXECUTE [oder].[spChk直前でRate相反している] @通貨ペアNo ,@売買判定 ,@相反 OUTPUT

	if @相反 = 0
	begin
		EXECUTE [oder].[spUpdateOrderSettings_取引状況] @通貨ペアNo ,'Order対象外(直前でRate相反)';
		return;
	end

		public static bool 注文設定_売買モード_WMA_S2_15m(SqlConnection cn, byte 通貨ペアNo, DateTime now, ref DataGridView dgv注文)
		{
			Indi.GetWMA判定_15m_S2のみ(cn, 通貨ペアNo, now, out 注文設定_売買モード_WMA_15m_WMA前_S2, out 注文設定_売買モード_WMA_15m_WMA今_S2);

			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA前_15m_S2].Value = 注文設定_売買モード_WMA_15m_WMA前_S2;
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA今_15m_S2].Value = 注文設定_売買モード_WMA_15m_WMA今_S2;

			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外（売買モード_WMA_S2_15m）";
			return false;
		}



	@OrderV1_余剰金の割合


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

		if @今_売りWMA上昇角度_シグマ > @シグマ閾値 * -1
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

