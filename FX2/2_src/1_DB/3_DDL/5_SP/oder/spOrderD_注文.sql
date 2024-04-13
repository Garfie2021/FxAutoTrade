USE [FX2_Demo]
GO

DROP PROCEDURE [oder].[spOrderD_注文]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderD_注文]
	@Rate記録以降の処理をスキップ		bit,				-- 0:スキップしない　1:スキップする
	@期間別Rate計算以降の処理をスキップ	bit,				-- 0:スキップしない　1:スキップする
	@通貨ペアNo							tinyint,
	@StartDate							datetime,
	@買いRate							float,
	@売りRate							float,
	@注文判定							tinyint		output,	-- 0:注文しない　1:注文する
	@売買判定							tinyint		output,	-- 1:買い　2:売り
	@Close予定Date						datetime	output,	-- 過去のデータを予想として使う
	@注文数								int			output,
	@手数料								int			output
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


	SET @注文判定 = 0;
	SET @売買判定 = 1;
	SET @Close予定Date = 0;
	SET @注文数 = 0;
	SET @手数料 = 0;

	/*** Rate記録 ***/

	EXECUTE [rate].[spInsertRateHistory] @通貨ペアNo ,@StartDate ,@買いRate ,@売りRate;

	if @Rate記録以降の処理をスキップ = 1
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, 'Rate記録以降の処理をスキップ';
		return;
	end;

	EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, 'Rate記録以降の処理を続行';

	DECLARE @Start1m datetime
	DECLARE @End1m datetime
	EXECUTE [cmn].[spGetTerm_Min1] @StartDate, 0, @Start1m OUTPUT, @End1m OUTPUT

	DECLARE @Start5m datetime
	DECLARE @End5m datetime
	EXECUTE [cmn].[spGetTerm_Min5] @StartDate, 0, @Start5m OUTPUT, @End1m OUTPUT

	DECLARE @Start15m datetime
	DECLARE @End15m datetime
	EXECUTE [cmn].[spGetTerm_Min15] @StartDate, 0, @Start15m OUTPUT, @End1m OUTPUT

	EXECUTE [rate].[spInsertRateHistory_Min1] @通貨ペアNo, @Start1m;
	EXECUTE [rate].[spInsertRateHistory_Min5] @通貨ペアNo, @Start5m;
	EXECUTE [rate].[spInsertRateHistory_Min15] @通貨ペアNo, @Start15m;

	if @期間別Rate計算以降の処理をスキップ = 1
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '期間別Rate計算以降の処理をスキップ';
		return;
	end;

	--30分以上のRate計算はJob定期実行（一分おき）で行う


	/*** 計算対象かチェック ***/

	DECLARE @計算対象 tinyint
	EXECUTE [oder].[spChk計算対象] @通貨ペアNo ,@計算対象 OUTPUT;
	if @計算対象 = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '計算対象外';
		return;
	end;

	EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '計算対象';

	SET @注文判定 = 0;


	/*** 計算 ***/

	-- spUpdateWMAs2は、WMA、角度、シグマまで計算する。
	EXECUTE [rate].[spUpdateWMAs2_Min1] @通貨ペアNo, @Start1m;
	EXECUTE [rate].[spUpdateWMAs2_Min5] @通貨ペアNo, @Start5m;
	EXECUTE [rate].[spUpdateWMAs2_Min15] @通貨ペアNo, @Start15m;
	--持続量は土日に計算


	/*** 注文判定 START ***/

	DECLARE @注文対象 tinyint
	EXECUTE [oder].[spChk注文対象] @通貨ペアNo ,@注文対象 OUTPUT;
	if @注文対象 = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外';
		return;
	end;

	EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象';

	if @買いRate = 0 or @売りRate = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（Rate0）';
		return;
	end;

	DECLARE @15分以内のCloseポジション数 int = 0;
	select @15分以内のCloseポジション数 = count(*)
	from [oder].[tOrderHistory]
	where 通貨ペアNo = @通貨ペアNo and [OrderDate] > DateAdd(MINUTE, -15, @Start15m);

	if @15分以内のCloseポジション数 > 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（15分以内にポジション有り）';
		return;
	end;

	-- Min15を基準に、今回のシグマ値が。
	-- Min15テーブルの[買いWMAs2角度持続時間]と比較して、15分以上持続すると判断された場合、注文対象と判断する。
	-- Min15テーブルの[買いWMAs2角度持続時間]と比較して、15分以上持続すると判断されなかった場合でも、
	-- Min1テーブルorMin5テーブルの[買いWMAs2角度持続時間]から、1分以上、5分以上持続すると判断される場合は、注文対象と判断する。
	-- 持続することが予想されても、Rate幅が手数料を下回っている場合は、注文対象外と判断する。
	-- Min15が持続していなくても、Min5、Min1がいくらか持続することもあるので、Min5、Min1の持続時間を、Min15の持続時間に足す。
	-- 過去の注文データをシグマ単位に集計して、利益のでないシグマ値は注文対象外にする。

	DECLARE @買いWMAs2角度			float;
	DECLARE @買いWMAs2角度シグマ	float;
	DECLARE @売りWMAs2角度			float;
	DECLARE @売りWMAs2角度シグマ	float;
	DECLARE @WMAs2角度持続時間_過去	int;
	DECLARE @WMAs2角度持続Rate_過去	float;

	SELECT TOP 1 @買いWMAs2角度 = [買いWMAs2角度], @買いWMAs2角度シグマ = [買いWMAs2角度シグマ],
		@売りWMAs2角度 = [売りWMAs2角度], @売りWMAs2角度シグマ = [売りWMAs2角度シグマ]
	FROM [rate].[tRateHistory_Min15]
	WHERE [通貨ペアNo] = @通貨ペアNo
	ORDER BY [StartDate] DESC;

	SET @注文判定 = 0;
	DECLARE @角度シグマ	float;

	if @買いWMAs2角度 > 0
	begin
		if @買いWMAs2角度シグマ > 2
		begin
			SET @売買判定 = 1;
			SET @角度シグマ	= @買いWMAs2角度シグマ;

			--SELECT TOP 1 @WMAs2角度持続時間_過去 = [買いWMAs2角度持続時間], @WMAs2角度持続Rate_過去 = [買いWMAs2角度持続Rate]
			--FROM [indi].[tIndicatorHistory_Min15]
			--WHERE [通貨ペアNo] = @通貨ペアNo AND [買いWMAs2角度シグマ] <= @買いWMAs2角度シグマ
			--ORDER BY [StartDate] DESC;
			--当面は固定
			SET @WMAs2角度持続時間_過去 = 15;
			SET @WMAs2角度持続Rate_過去 = 0;
		end
		ELSE
		begin
			EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（買いシグマ0.1以下）';
			return;
		end;
	end
	ELSE if @売りWMAs2角度 < 0
	begin
		if @売りWMAs2角度シグマ > 2
		begin
			SET @売買判定 = 2;
			SET @角度シグマ	= @売りWMAs2角度シグマ;

			--SELECT TOP 1 @WMAs2角度持続時間_過去 = [売りWMAs2角度持続時間], @WMAs2角度持続Rate_過去 = [売りWMAs2角度持続Rate]
			--FROM [indi].[tIndicatorHistory_Min15]
			--WHERE [通貨ペアNo] = @通貨ペアNo AND [売りWMAs2角度シグマ] <= @売りWMAs2角度シグマ
			--ORDER BY [StartDate] DESC;
			--当面は固定
			SET @WMAs2角度持続時間_過去 = 15
			SET @WMAs2角度持続Rate_過去 = 0;
		end
		ELSE
		begin
			EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（売りシグマ0.1以下）';
			return;
		end;
	end
	ELSE
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（角度判定）';
		return;
	end;

	if @売買判定 = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（注文判定）';
		return;
	end;

	if @WMAs2角度持続Rate_過去 < @手数料
	begin
		EXECUTE [oder].[spUpdateOrderStatus_取引状況] @通貨ペアNo, '注文対象外（手数料を超える利益を見込めない）';
		return;
	end;

	-- 注文する
	SET @注文判定 = 1;
	SET @Close予定Date = DATEADD(minute, @WMAs2角度持続時間_過去, @Start15m);

	EXECUTE [cmn].[spGet注文数] @角度シグマ, @注文数 OUTPUT;
	EXECUTE [cmn].[spGetFXCM手数料] @注文数, @手数料 OUTPUT;

END
GO
/*
*/

