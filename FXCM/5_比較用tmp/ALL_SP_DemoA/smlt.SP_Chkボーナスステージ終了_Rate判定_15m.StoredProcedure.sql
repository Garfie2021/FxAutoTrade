USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_Chkボーナスステージ終了_Rate判定_15m]
	@通貨ペアNo		tinyint,
	@売買モード		varchar(5),
	@now			datetime,
	@判定			tinyint	output
AS
BEGIN

	DECLARE @2つ前_買い_高値 float;
	DECLARE @2つ前_売り_安値 float;
	DECLARE @1つ前_買い_高値 float;
	DECLARE @1つ前_売り_安値 float;

	DECLARE cursor_RateHistory_15m CURSOR FOR
	SELECT TOP 3 [買い_高値], [売り_安値]
	FROM [dbo].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @now
	order by [日時]

	open cursor_RateHistory_15m;
	
	FETCH NEXT FROM cursor_RateHistory_15m INTO @2つ前_買い_高値, @2つ前_売り_安値;
	FETCH NEXT FROM cursor_RateHistory_15m INTO @1つ前_買い_高値, @1つ前_売り_安値;

	CLOSE cursor_RateHistory_15m;
	DEALLOCATE cursor_RateHistory_15m;
	
	if @売買モード = '買い'
	begin
		if @2つ前_買い_高値 > @1つ前_買い_高値
		begin
			Set @判定 = 1;	--ボーナスステージ終了
		end
		else
		begin
			Set @判定 = 0;	--ボーナスステージ中
		end
	end
	else
	begin
		if @2つ前_売り_安値 < @1つ前_売り_安値
		begin
			Set @判定 = 1;	--ボーナスステージ終了
		end
		else
		begin
			Set @判定 = 0;	--ボーナスステージ中
		end
	end

	--select @判定

END


GO
