USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_GetWMA判定_Weekly_S2のみ]
	@通貨ペアNo		int,
	@now			datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@Swap判定		varchar(10),
	@WMA前_S2		float		output,
	@WMA今_S2		float		output
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		int = 33
	DECLARE @now			datetime = getdate()
	DECLARE @Swap判定		varchar(10)	= '売り'
	DECLARE @WMA前_S2		float		
	DECLARE @WMA今_S2		float		
	*/


	DECLARE @WMA_買い_S2_今 float;
	DECLARE @WMA_売り_S2_今 float;
	DECLARE @WMA_買い_S2_1つ前 float;
	DECLARE @WMA_売り_S2_1つ前 float;

	DECLARE cursor_Indicator_Weekly CURSOR FOR
	SELECT TOP 2 WMA_買い_WMA_S2, WMA_売り_WMA_S2
	FROM indi.T_Indicator_Weekly
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @now and WMA_買い_WMA上昇角度_S2 != 0
	order by [日時] desc

	open cursor_Indicator_Weekly;

	FETCH NEXT FROM cursor_Indicator_Weekly INTO @WMA_買い_S2_今, @WMA_売り_S2_今;
	FETCH NEXT FROM cursor_Indicator_Weekly INTO @WMA_買い_S2_1つ前, @WMA_売り_S2_1つ前;

	CLOSE cursor_Indicator_Weekly;
	DEALLOCATE cursor_Indicator_Weekly;

	if @Swap判定 = '買い'
	begin
		Set @WMA前_S2 = @WMA_買い_S2_1つ前;
		Set @WMA今_S2 = @WMA_買い_S2_今;
	end
	else if @Swap判定 = '売り'
	begin
		Set @WMA前_S2 = @WMA_売り_S2_1つ前;
		Set @WMA今_S2 = @WMA_売り_S2_今;
	end;

		
	--select @通貨ペアNo as 通貨ペアNo, @now as now, @Swap判定 as Swap判定, @WMA前_S2 as WMA前_S2, @WMA今_S2 as WMA今_S2

END

GO
