USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spUpdateWMAs2_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMAs2_Min5]
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
	FROM [rate].[tRateHistory_Min5]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;


	-- 今回のWMA計算
	declare @買いWMAs2 float;
	declare @売りWMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Min5] @通貨ペアNo, @StartDate, @買いWMAs2 OUTPUT, @売りWMAs2 OUTPUT;
	--select @買いWMA, @売りWMA, @買いWMAs2, @売りWMAs2


	-- 前回のWMA取得
	Declare @買いWMAs2_1つ前 float = 0;
	Declare @売りWMAs2_1つ前 float = 0;

	select top 1 @買いWMAs2_1つ前 = 買いWMAs2, @売りWMAs2_1つ前 = 売りWMAs2
	from [rate].[tRateHistory_Min5]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate	
	order by [StartDate] desc;

	-- 今回のWMA角度を計算
	Declare @買いWMAs2角度 float = 0;
	Declare @売りWMAs2角度 float = 0;
	EXECUTE [cmn].[spGetWMA角度] @買いWMAs2, @買いWMAs2_1つ前, @買いWMAs2角度 output, @売りWMAs2, @売りWMAs2_1つ前, @売りWMAs2角度 output;


	-- 今回のWMA角度のシグマを計算
	Declare @買いWMAs2角度シグマ float;
	Declare @売りWMAs2角度シグマ float;
	EXECUTE [rate].[spCulcWMAs2角度シグマ_Min5] @通貨ペアNo, @StartDate, @買いWMAs2角度, @買いWMAs2角度シグマ output, @売りWMAs2角度, @売りWMAs2角度シグマ output;


	-- 結果を登録
	UPDATE [rate].[tRateHistory_Min5]
	SET
		買いWMAs2 = @買いWMAs2,
		買いWMAs2角度 = @買いWMAs2角度,
		買いWMAs2角度シグマ = @買いWMAs2角度シグマ,
		売りWMAs2 = @売りWMAs2,
		売りWMAs2角度 = @売りWMAs2角度,
		売りWMAs2角度シグマ = @売りWMAs2角度シグマ,
		[更新日時] = GETDATE()
	where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate;

END
GO
