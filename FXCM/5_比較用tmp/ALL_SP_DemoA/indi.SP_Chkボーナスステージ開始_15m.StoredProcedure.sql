USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_Chkボーナスステージ開始_15m]
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@シグマ閾値		float = 2.5,			-- 基本値は2.5　※マイナス値には対応していない
	@WMA判定		varchar(5)	output,			-- 買い or 売り
	@BonusStage判定	varchar(5)	output			-- B：Bonus Stage 中 or ブランク：通常
AS
BEGIN

	/*
	DECLARE @通貨ペアNo		tinyint = 0
	DECLARE @StartDate		datetime = '2014-04-04 22:30:00'
	DECLARE @シグマ閾値		float = 2.5
	DECLARE @WMA判定		varchar(5)
	DECLARE @BonusStage判定	varchar(5)
	*/


	-- 直近の指標を取得

	DECLARE @今_WMA_買い_WMA float;
	DECLARE @今_WMA_売り_WMA float;
	DECLARE @今_WMA_買い_WMA上昇角度 float;
	DECLARE @今_WMA_売り_WMA上昇角度 float;
	DECLARE @今_WMA_買い_WMA上昇角度_シグマ float;
	DECLARE @今_WMA_売り_WMA上昇角度_シグマ float;
	DECLARE @1つ前_WMA_買い_WMA float;
	DECLARE @1つ前_WMA_売り_WMA float;
	DECLARE @1つ前_WMA_買い_WMA上昇角度 float;
	DECLARE @1つ前_WMA_売り_WMA上昇角度 float;
	DECLARE @1つ前_WMA_買い_WMA上昇角度_シグマ float;
	DECLARE @1つ前_WMA_売り_WMA上昇角度_シグマ float;

	DECLARE cursor_T_Indicator_15m CURSOR FOR
	SELECT TOP 2 [WMA_買い_WMA], [WMA_売り_WMA], [WMA_買い_WMA上昇角度], [WMA_売り_WMA上昇角度], [WMA_買い_WMA上昇角度_シグマ], [WMA_売り_WMA上昇角度_シグマ]
	FROM [indi].[T_Indicator_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate
	order by [日時] desc

	open cursor_T_Indicator_15m;
	
	FETCH NEXT FROM cursor_T_Indicator_15m INTO @今_WMA_買い_WMA, @今_WMA_売り_WMA, @今_WMA_買い_WMA上昇角度, @今_WMA_売り_WMA上昇角度,
		@今_WMA_買い_WMA上昇角度_シグマ, @今_WMA_売り_WMA上昇角度_シグマ;
	FETCH NEXT FROM cursor_T_Indicator_15m INTO @1つ前_WMA_買い_WMA, @1つ前_WMA_売り_WMA, @1つ前_WMA_買い_WMA上昇角度, @1つ前_WMA_売り_WMA上昇角度,
		@1つ前_WMA_買い_WMA上昇角度_シグマ, @1つ前_WMA_売り_WMA上昇角度_シグマ;

	CLOSE cursor_T_Indicator_15m;
	DEALLOCATE cursor_T_Indicator_15m;


	-- 直近のRateを取得

	DECLARE @2つ前_買い_始値 float;
	DECLARE @2つ前_買い_高値 float;
	DECLARE @2つ前_買い_安値 float;
	DECLARE @2つ前_買い_終値 float;
	DECLARE @2つ前_売り_始値 float;
	DECLARE @2つ前_売り_高値 float;
	DECLARE @2つ前_売り_安値 float;
	DECLARE @2つ前_売り_終値 float;
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

	DECLARE cursor_T_RateHistory_15m CURSOR FOR
	SELECT TOP 3 [買い_始値], [買い_高値], [買い_安値], [買い_終値], [売り_始値], [売り_高値], [売り_安値], [売り_終値]
	FROM [dbo].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate
	order by [日時] desc

	open cursor_T_RateHistory_15m;
	
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @今_買い_始値, @今_買い_高値, @今_買い_安値, @今_買い_終値, @今_売り_始値, @今_売り_高値, @今_売り_安値, @今_売り_終値;
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @1つ前_買い_始値, @1つ前_買い_高値, @1つ前_買い_安値, @1つ前_買い_終値, @1つ前_売り_始値, @1つ前_売り_高値, @1つ前_売り_安値, @1つ前_売り_終値;
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @2つ前_買い_始値, @2つ前_買い_高値, @2つ前_買い_安値, @2つ前_買い_終値, @2つ前_売り_始値, @2つ前_売り_高値, @2つ前_売り_安値, @2つ前_売り_終値;

	CLOSE cursor_T_RateHistory_15m;
	DEALLOCATE cursor_T_RateHistory_15m;

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate


	-- Bonus Stage 判定

	Set @BonusStage判定 = 0;

	if @1つ前_WMA_買い_WMA < @今_WMA_買い_WMA
	begin

		Set @WMA判定 = '買い'

		if @今_WMA_買い_WMA上昇角度_シグマ < @シグマ閾値
		begin
			return;
		end

		if @1つ前_WMA_買い_WMA上昇角度 > @今_WMA_買い_WMA上昇角度
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
	else if @1つ前_WMA_売り_WMA > @今_WMA_売り_WMA
	begin

		Set @WMA判定 = '売り'

		if @今_WMA_売り_WMA上昇角度_シグマ > @シグマ閾値 * -1
		begin
			return;
		end

		if @1つ前_WMA_売り_WMA上昇角度 < @今_WMA_売り_WMA上昇角度
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
