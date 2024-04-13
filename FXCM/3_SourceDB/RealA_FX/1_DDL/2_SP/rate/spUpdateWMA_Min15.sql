USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [rate].[spUpdateWMA_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMA_Min15]
	@通貨ペアNo		tinyint = 34,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE  @通貨ペアNo	tinyint = 34;
	DECLARE  @StartDate		datetime = '2016-02-24 23:15:00.000';
	*/

	-- データ有無チェック
	DECLARE  @Cnt int;
	SELECT @Cnt = count(*)
	FROM [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;

	-- 前回のWMA取得
	DECLARE  @買いWMAs2_1つ前 float = 0;
	DECLARE  @買いWMAs14_1つ前 float = 0;
	DECLARE  @売りWMAs2_1つ前 float = 0;
	DECLARE  @売りWMAs14_1つ前 float = 0;
	select top 1 @買いWMAs2_1つ前 = 買いWMAs2, @買いWMAs14_1つ前 = 買いWMAs14, @売りWMAs2_1つ前 = 売りWMAs2, @売りWMAs14_1つ前 = 売りWMAs14
	from [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate
	order by [StartDate] desc;

	-- 今回のWMAs2計算
	DECLARE  @買いWMAs2 float;
	DECLARE  @売りWMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Min15] @通貨ペアNo, @StartDate, @買いWMAs2 OUTPUT, @売りWMAs2 OUTPUT;
	--select @買いWMA, @売りWMA, @買いWMAs2, @売りWMAs2

	-- 今回のWMAs2角度を計算
	DECLARE  @買いWMAs2角度 float = 0;
	DECLARE  @売りWMAs2角度 float = 0;
	EXECUTE [cmn].[spGetWMA角度] @買いWMAs2, @買いWMAs2_1つ前, @買いWMAs2角度 output, @売りWMAs2, @売りWMAs2_1つ前, @売りWMAs2角度 output;

	-- データ有無チェック
	if @Cnt < 14
	begin
		-- s2のみ結果を登録して終わる
		UPDATE [hstr].[tMin15]
		SET
			買いWMAs2 = @買いWMAs2,
			買いWMAs2角度 = @買いWMAs2角度,
			売りWMAs2 = @売りWMAs2,
			売りWMAs2角度 = @売りWMAs2角度,
			[更新日時] = GETDATE()
		where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate;

		return;
	end;

	DECLARE  @買いWMAs14 float;
	DECLARE  @売りWMAs14 float;
	EXECUTE [rate].[spCulcWMAs14_Min15] @通貨ペアNo, @StartDate, @買いWMAs14 OUTPUT, @売りWMAs14 OUTPUT;

	-- 今回のWMA角度を計算
	DECLARE  @買いWMAs14角度 float = 0;
	DECLARE  @売りWMAs14角度 float = 0;
	EXECUTE [cmn].[spGetWMA角度] @買いWMAs14, @買いWMAs14_1つ前, @買いWMAs14角度 output, @売りWMAs14, @売りWMAs14_1つ前, @売りWMAs14角度 output;

	-- 今回のWMA角度のシグマを計算
	DECLARE  @買いWMAs14角度シグマ float;
	DECLARE  @売りWMAs14角度シグマ float;
	EXECUTE [rate].[spCulcWMAs14角度シグマ_Min15] @通貨ペアNo, @StartDate, @買いWMAs14角度, @買いWMAs14角度シグマ output, @売りWMAs14角度, @売りWMAs14角度シグマ output;

	--select @買いWMAs14角度, @買いWMAs14角度シグマ, @売りWMAs14角度, @売りWMAs14角度シグマ

	-- 結果を登録
	UPDATE [hstr].[tMin15]
	SET
		買いWMAs2 = @買いWMAs2,
		買いWMAs2角度 = @買いWMAs2角度,
		買いWMAs14 = @買いWMAs14,
		買いWMAs14角度 = @買いWMAs14角度,
		買いWMAs14角度シグマ = @買いWMAs14角度シグマ,
		売りWMAs2 = @売りWMAs2,
		売りWMAs2角度 = @売りWMAs2角度,
		売りWMAs14 = @売りWMAs14,
		売りWMAs14角度 = @売りWMAs14角度,
		売りWMAs14角度シグマ = @売りWMAs14角度シグマ,
		[更新日時] = GETDATE()
	where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate	

END
GO
/*
*/
