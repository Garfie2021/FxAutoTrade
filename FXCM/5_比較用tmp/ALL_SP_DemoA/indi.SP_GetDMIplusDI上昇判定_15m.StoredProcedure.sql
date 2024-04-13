USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_GetDMIplusDI上昇判定_15m]
	@通貨ペアNo		int,
	@現在日時		datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@判定結果		varchar(5)	output
AS
BEGIN

		DECLARE @今_DMI_買い_DI_plus float;
		DECLARE @今_DMI_買い_DI_minus float;
		DECLARE @今_DMI_売り_DI_plus float;
		DECLARE @今_DMI_売り_DI_minus float;

		DECLARE @1つ前_DMI_買い_DI_plus float;
		DECLARE @1つ前_DMI_買い_DI_minus float;
		DECLARE @1つ前_DMI_売り_DI_plus float;
		DECLARE @1つ前_DMI_売り_DI_minus float;

		DECLARE cursor_Indicator_15m CURSOR FOR
		SELECT TOP 2 [DMI_買い_DI_plus], [DMI_買い_DI_minus], [DMI_売り_DI_plus], [DMI_売り_DI_minus]
		FROM indi.T_Indicator_15m
		where 通貨ペアNo = @通貨ペアNo and [日時] <= @現在日時
		order by [日時] desc

		open cursor_Indicator_15m;

		FETCH NEXT FROM cursor_Indicator_15m INTO @今_DMI_買い_DI_plus, @今_DMI_買い_DI_minus, @今_DMI_売り_DI_plus, @今_DMI_売り_DI_minus;
		FETCH NEXT FROM cursor_Indicator_15m INTO @1つ前_DMI_買い_DI_plus, @1つ前_DMI_買い_DI_minus, @1つ前_DMI_売り_DI_plus, @1つ前_DMI_売り_DI_minus;

		CLOSE cursor_Indicator_15m;
		DEALLOCATE cursor_Indicator_15m;

		if @今_DMI_買い_DI_plus > @1つ前_DMI_買い_DI_plus
		begin
			Set @判定結果 = '上昇'
		end
		else
		begin
			Set @判定結果 = '下降'
		end


END


GO
