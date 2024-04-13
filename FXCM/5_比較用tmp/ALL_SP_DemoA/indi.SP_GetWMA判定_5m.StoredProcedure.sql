USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_GetWMA判定_5m]
	@通貨ペアNo			int,
	@現在日時			datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@WMA今				float		output,
	@WMA判定			varchar(10)	output,
	@WMA角度前			float		output,
	@WMA角度今			float		output,
	@WMA角度判定		varchar(10)	output,
	@WMA前_S2			float		output,
	@WMA今_S2			float		output,
	@WMA判定_S2			varchar(10)	output
AS
BEGIN

	/*
	DECLARE @通貨ペアNo		int = 20
	DECLARE @現在日時		datetime = getdate()
	DECLARE @WMA判定		varchar(10)	
	DECLARE @WMA角度前		float		
	DECLARE @WMA角度今		float		
	DECLARE @WMA角度判定	varchar(10)	
	*/

	DECLARE @今_WMA_買い_WMA float;
	DECLARE @今_WMA_売り_WMA float;
	DECLARE @今_WMA_買い_WMA上昇角度 float;
	DECLARE @1つ前_WMA_買い_WMA float;
	DECLARE @1つ前_WMA_売り_WMA float;
	DECLARE @1つ前_WMA_買い_WMA上昇角度 float;
	DECLARE @2つ前_WMA_買い_WMA float;
	DECLARE @2つ前_WMA_売り_WMA float;
	DECLARE @2つ前_WMA_買い_WMA上昇角度 float;

	DECLARE @今_WMA_買い_WMA_S2 float;
	DECLARE @今_WMA_売り_WMA_S2 float;
	DECLARE @今_WMA_買い_WMA上昇角度_S2 float;
	DECLARE @1つ前_WMA_買い_WMA_S2 float;
	DECLARE @1つ前_WMA_売り_WMA_S2 float;
	DECLARE @1つ前_WMA_買い_WMA上昇角度_S2 float;
	DECLARE @2つ前_WMA_買い_WMA_S2 float;
	DECLARE @2つ前_WMA_売り_WMA_S2 float;
	DECLARE @2つ前_WMA_買い_WMA上昇角度_S2 float;

	DECLARE cursor_Indicator_5m CURSOR FOR
	SELECT TOP 3 WMA_買い_WMA, WMA_売り_WMA, WMA_買い_WMA上昇角度, WMA_買い_WMA_S2, WMA_売り_WMA_S2, WMA_買い_WMA上昇角度_S2
	FROM indi.T_Indicator_5m
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @現在日時 and WMA_買い_WMA上昇角度 != 0
	order by [日時] desc

	open cursor_Indicator_5m;

	FETCH NEXT FROM cursor_Indicator_5m INTO @今_WMA_買い_WMA, @今_WMA_売り_WMA, @今_WMA_買い_WMA上昇角度, @今_WMA_買い_WMA_S2, @今_WMA_売り_WMA_S2, @今_WMA_買い_WMA上昇角度_S2;
	FETCH NEXT FROM cursor_Indicator_5m INTO @1つ前_WMA_買い_WMA, @1つ前_WMA_売り_WMA, @1つ前_WMA_買い_WMA上昇角度, @1つ前_WMA_買い_WMA_S2, @1つ前_WMA_売り_WMA_S2, @1つ前_WMA_買い_WMA上昇角度_S2;
	FETCH NEXT FROM cursor_Indicator_5m INTO @2つ前_WMA_買い_WMA, @2つ前_WMA_売り_WMA, @2つ前_WMA_買い_WMA上昇角度, @2つ前_WMA_買い_WMA, @2つ前_WMA_売り_WMA, @2つ前_WMA_買い_WMA上昇角度;

	CLOSE cursor_Indicator_5m;
	DEALLOCATE cursor_Indicator_5m;

	Set @WMA今 = @今_WMA_買い_WMA;

	if @1つ前_WMA_買い_WMA < @今_WMA_買い_WMA
	begin
		Set @WMA判定 = '上昇';
	end
	else if @1つ前_WMA_買い_WMA > @今_WMA_買い_WMA
	begin
		Set @WMA判定 = '下降';
	end
	else
	begin
		Set @WMA判定 = '';
	end;

	Set @WMA角度前 = @1つ前_WMA_買い_WMA上昇角度;
	Set @WMA角度今 = @今_WMA_買い_WMA上昇角度;

	if @WMA判定 = '上昇'
	begin
		if @WMA角度前 > @WMA角度今
		begin
			Set @WMA角度判定 = '減少';
		end
		else if @WMA角度前 < @WMA角度今
		begin
			Set @WMA角度判定 = '拡大';
		end
		else
		begin
			Set @WMA角度判定 = '';
		end
	end;
	else if @WMA判定 = '下降'
	begin
		if @WMA角度前 < @WMA角度今
		begin
			Set @WMA角度判定 = '減少';
		end
		else if @WMA角度前 > @WMA角度今
		begin
			Set @WMA角度判定 = '拡大';
		end
		else
		begin
			Set @WMA角度判定 = '';
		end
	end
	else
	begin
		Set @WMA角度判定 = '';
	end
	;
	
	Set @WMA前_S2 = @1つ前_WMA_買い_WMA_S2;
	Set @WMA今_S2 = @今_WMA_買い_WMA_S2;

	if @1つ前_WMA_買い_WMA_S2 < @今_WMA_買い_WMA_S2
	begin
		Set @WMA判定_S2 = '上昇';
	end
	else if @1つ前_WMA_買い_WMA_S2 > @今_WMA_買い_WMA_S2
	begin
		Set @WMA判定_S2 = '下降';
	end
	else
	begin
		Set @WMA判定_S2 = '';
	end;


	--select @WMA判定 as WMA判定, @WMA判定 as WMA判定, @WMA角度前 as WMA角度前, @WMA角度今 as WMA角度今, @WMA角度判定 as WMA角度判定



END

GO
