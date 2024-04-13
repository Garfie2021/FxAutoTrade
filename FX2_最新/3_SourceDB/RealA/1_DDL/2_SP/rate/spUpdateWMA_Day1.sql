USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [rate].[spUpdateWMA_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMA_Day1]
	@通貨ペアNo		tinyint = 34,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE  @通貨ペアNo	tinyint = 34;
	DECLARE  @StartDate		datetime = '2015-11-26 22:00:00.000';
	*/

	-- データ有無チェック
	DECLARE  @Cnt int;
	SELECT @Cnt = count(*)
	FROM [hstr].[tDay1]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;

	-- 前回のWMA取得
	DECLARE  @買いWMAs2_1つ前 float = 0;
	DECLARE  @売りWMAs2_1つ前 float = 0;
	select top 1 @買いWMAs2_1つ前 = 買いWMAs2, @売りWMAs2_1つ前 = 売りWMAs2
	from [hstr].[tDay1]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate
	order by [StartDate] desc;

	-- 今回のWMAs2計算
	DECLARE  @買いWMAs2 float;
	DECLARE  @売りWMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Day1] @通貨ペアNo, @StartDate, @買いWMAs2 OUTPUT, @売りWMAs2 OUTPUT;

	-- 今回のWMAs2角度を計算
	DECLARE  @買いWMAs2角度 float = 0;
	DECLARE  @売りWMAs2角度 float = 0;
	EXECUTE [cmn].[spGetWMA角度] @買いWMAs2, @買いWMAs2_1つ前, @買いWMAs2角度 output, @売りWMAs2, @売りWMAs2_1つ前, @売りWMAs2角度 output;

	-- データ有無チェック
	if @Cnt < 14
	begin
		-- 結果を登録
		UPDATE [hstr].[tDay1]
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
	EXECUTE [rate].[spCulcWMAs14_Day1] @通貨ペアNo, @StartDate, @買いWMAs14 OUTPUT, @売りWMAs14 OUTPUT;

	-- 結果を登録
	UPDATE [hstr].[tDay1]
	SET
		買いWMAs2 = @買いWMAs2,
		買いWMAs2角度 = @買いWMAs2角度,
		買いWMAs14 = @買いWMAs14,
		売りWMAs2 = @売りWMAs2,
		売りWMAs2角度 = @売りWMAs2角度,
		売りWMAs14 = @売りWMAs14,
		[更新日時] = GETDATE()
	where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate	

END
GO
/*
*/
