USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [oder].[spChkボーナスステージ15m]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChkボーナスステージ15m]
	@通貨ペアNo					tinyint,
	@StartDate					datetime,
	@シグマ閾値					float = 2.5,			-- 基本値は2.5　※マイナス値には対応していない
	@買いWMAs14					float		output,
	@買いWMAs14上昇角度シグマ	float		output,
	@売りWMAs14					float		output,
	@売りWMAs14上昇角度シグマ	float		output,
	@WMA判定					varchar(1)	output,		-- B(買い) or S(売り)
	@BS判定						varchar(1)	output		-- B(BonusStage中) or ブランク(通常)
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

	-- 直近のRateを取得

	DECLARE @今_買いWMAs14 float;
	DECLARE @今_買いWMAs14上昇角度シグマ float;
	DECLARE @今_売りWMAs14 float;
	DECLARE @今_売りWMAs14上昇角度シグマ float;

	DECLARE @1つ前_買いWMAs14 float;
	DECLARE @1つ前_買いWMAs14上昇角度シグマ float;
	DECLARE @1つ前_売りWMAs14 float;
	DECLARE @1つ前_売りWMAs14上昇角度シグマ float;


	DECLARE cursor_T_RateHistory_15m CURSOR FOR
	SELECT TOP 2 [買いWMAs14], [買いWMAs14角度シグマ], [売りWMAs14], [売りWMAs14角度シグマ]
	FROM [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate
	order by [StartDate] desc

	open cursor_T_RateHistory_15m;
	
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @今_買いWMAs14, @今_買いWMAs14上昇角度シグマ, @今_売りWMAs14, @今_売りWMAs14上昇角度シグマ;
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @1つ前_買いWMAs14, @1つ前_買いWMAs14上昇角度シグマ, @1つ前_売りWMAs14, @1つ前_売りWMAs14上昇角度シグマ;

	CLOSE cursor_T_RateHistory_15m;
	DEALLOCATE cursor_T_RateHistory_15m;

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate


	-- Bonus Stage 判定

	SET @買いWMAs14 = @今_買いWMAs14;
	SET @買いWMAs14上昇角度シグマ = @今_買いWMAs14上昇角度シグマ;
	SET @売りWMAs14 = @今_売りWMAs14;
	SET @売りWMAs14上昇角度シグマ = @今_売りWMAs14上昇角度シグマ;

	if @1つ前_買いWMAs14 < @今_買いWMAs14
	begin
		Set @WMA判定 = 'B'

		if @今_買いWMAs14上昇角度シグマ < @シグマ閾値
		begin
			Set @BS判定 = '';	
			return;
		end
	end
	else if @1つ前_売りWMAs14 > @今_売りWMAs14
	begin
		Set @WMA判定 = 'S'

		if @今_売りWMAs14上昇角度シグマ < @シグマ閾値
		begin
			Set @BS判定 = '';	
			return;
		end
	end
	else
	begin
		Set @WMA判定 = ''
		Set @BS判定 = '';	
		return;
	end

	Set @BS判定 = 'B';	-- Bonus Stage 開始

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @WMA判定 as WMA判定, @BonusStage判定 as BonusStage判定

END
GO
/*
*/

