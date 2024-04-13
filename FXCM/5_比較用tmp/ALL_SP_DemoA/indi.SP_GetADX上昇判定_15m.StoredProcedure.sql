USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_GetADX上昇判定_15m]
	@通貨ペアNo			int,
	@現在日時			datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@ADX判定結果		varchar(5)	output
AS
BEGIN

	DECLARE @今_ADX_買い_ADX float;
	DECLARE @今_ADX_売り_ADX float;
	DECLARE @1つ前_ADX_買い_ADX float;
	DECLARE @1つ前_ADX_売り_ADX float;

	DECLARE cursor_Indicator_15m CURSOR FOR
	SELECT TOP 2 ADX_買い_ADX, ADX_売り_ADX
	FROM indi.T_Indicator_15m
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @現在日時
	order by [日時] desc

	open cursor_Indicator_15m;

	FETCH NEXT FROM cursor_Indicator_15m INTO @今_ADX_買い_ADX, @今_ADX_売り_ADX;
	FETCH NEXT FROM cursor_Indicator_15m INTO @1つ前_ADX_買い_ADX, @1つ前_ADX_売り_ADX;

	CLOSE cursor_Indicator_15m;
	DEALLOCATE cursor_Indicator_15m;

	if @今_ADX_買い_ADX > @1つ前_ADX_買い_ADX
	begin
		Set @ADX判定結果 = '上昇'
	end
	else
	begin
		Set @ADX判定結果 = '下降'
	end


END


GO
