USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_InsertIndicator_Weekly_WMA_S2のみ]
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
	FROM [dbo].[T_RateHistory_Weekly]
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;


	-- WMAを計算する

	declare @WMA_買い_S2 float;
	declare @WMA_売り_S2 float;
	EXECUTE [indi].[SP_CulcWMA_Weekly_S2のみ] @通貨ペアNo, @StartDate, @WMA_買い_S2 OUTPUT, @WMA_売り_S2 OUTPUT;
	--select @WMA_買い, @WMA_売り, @WMA_買い_S2, @WMA_売り_S2


	-- WMAの角度を計算する

	Declare @WMA_買い_WMA_1つ前_S2 float = 0;
	Declare @WMA_売り_WMA_1つ前_S2 float = 0;

	select top 1 @WMA_買い_WMA_1つ前_S2 = WMA_買い_WMA_S2, @WMA_売り_WMA_1つ前_S2 = WMA_売り_WMA_S2
	from [indi].[T_Indicator_Weekly]
	where 通貨ペアNo = @通貨ペアNo and 日時 < @StartDate	
	order by [日時] desc;

	Declare @底辺x float = 1;

	Declare @上昇角度_買い_S2 float;
	Declare @高さy_上昇値_買い_S2 float = @WMA_買い_S2 - @WMA_買い_WMA_1つ前_S2;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x, @高さy_上昇値_買い_S2, @上昇角度_買い_S2 OUTPUT

	Declare @上昇角度_売り_S2 float;
	Declare @高さy_上昇値_売り_S2 float = @WMA_売り_S2 - @WMA_売り_WMA_1つ前_S2;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x, @高さy_上昇値_売り_S2, @上昇角度_売り_S2 OUTPUT;


	-- 初期レコードを、事前にInsertしておく

	SELECT @Cnt = count(*)
	FROM [indi].[T_Indicator_Weekly]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	if @Cnt = 0
	begin
		INSERT INTO [indi].[T_Indicator_Weekly] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @StartDate);
	end


	-- 結果をUpdate

	UPDATE [indi].[T_Indicator_Weekly]
	SET
		WMA_買い_WMA_S2 = @WMA_買い_S2,
		WMA_売り_WMA_S2 = @WMA_売り_S2,
		WMA_買い_WMA上昇角度_S2 = @上昇角度_買い_S2,
		WMA_売り_WMA上昇角度_S2 = @上昇角度_売り_S2
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

END

GO
