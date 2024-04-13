USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_GetWMA判定_1h_S2のみ]
	@通貨ペアNo		int,
	@now			datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@Swap判定		varchar(10),
	@WMA前_S2		float		output,
	@WMA今_S2		float		output
AS
BEGIN

	/*
	DECLARE @通貨ペアNo		int = 20
	DECLARE @now		datetime = getdate()
	DECLARE @WMA判定		varchar(10)	
	DECLARE @WMA角度前		float		
	DECLARE @WMA角度今		float		
	DECLARE @WMA角度判定	varchar(10)	
	*/

	DECLARE @WMA_買い_S2_今 float;
	DECLARE @WMA_売り_S2_今 float;
	DECLARE @WMA_買い_S2_1つ前 float;
	DECLARE @WMA_売り_S2_1つ前 float;

	DECLARE cursor_Indicator_1h CURSOR FOR
	SELECT TOP 2 WMA_買い_WMA_S2, WMA_売り_WMA_S2
	FROM indi.T_Indicator_1h
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @now and WMA_買い_WMA上昇角度_S2 != 0
	order by [日時] desc

	open cursor_Indicator_1h;

	FETCH NEXT FROM cursor_Indicator_1h INTO @WMA_買い_S2_今, @WMA_売り_S2_今;
	FETCH NEXT FROM cursor_Indicator_1h INTO @WMA_買い_S2_1つ前, @WMA_売り_S2_1つ前;

	CLOSE cursor_Indicator_1h;
	DEALLOCATE cursor_Indicator_1h;

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

		
	--select @WMA判定 as WMA判定, @WMA判定 as WMA判定, @WMA角度前 as WMA角度前, @WMA角度今 as WMA角度今, @WMA角度判定 as WMA角度判定

END

GO
