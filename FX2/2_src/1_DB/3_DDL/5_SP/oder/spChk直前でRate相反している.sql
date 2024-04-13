USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spChk直前でRate相反している]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk直前でRate相反している]
	@通貨ペアNo		tinyint,
	@売買判定		tinyint,		-- 0：売り　1：買い
	@相反			tinyint	output	-- 0：相反している　1：相反していない
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 29
	DECLARE @売買モード		varchar = '買い'
	DECLARE @判定			tinyint
	*/

	DECLARE @今_Rate_買い float;
	DECLARE @今_Rate_売り float;
	DECLARE @1つ前_Rate_買い float;
	DECLARE @1つ前_Rate_売り float;

	DECLARE cursor_T_RateHistory CURSOR FOR
	SELECT TOP 2 [買いRate], [売りRate]
	FROM [rate].[tRateHistory]
	where 通貨ペアNo = @通貨ペアNo
	order by [StartDate] desc

	open cursor_T_RateHistory;
	
	FETCH NEXT FROM cursor_T_RateHistory INTO @今_Rate_買い, @今_Rate_売り;
	FETCH NEXT FROM cursor_T_RateHistory INTO @1つ前_Rate_買い, @1つ前_Rate_売り;

	CLOSE cursor_T_RateHistory;
	DEALLOCATE cursor_T_RateHistory;

	if @売買判定 = 1
	begin
		--買い
		if @1つ前_Rate_買い > @今_Rate_買い
		begin
			Set @相反 = 0;	-- Orderを出すのは危険
		end
		else
		begin
			Set @相反 = 1;	-- Orderを出しても大丈夫
		end
	end
	else
	begin
		--売り
		if @1つ前_Rate_売り < @今_Rate_売り
		begin
			Set @相反 = 0;	-- Orderを出すのは危険
		end
		else
		begin
			Set @相反 = 1;	-- Orderを出しても大丈夫
		end
	end

	--select @判定

END
GO
/*
*/

