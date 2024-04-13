USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Chk直前でRate相反している]
	@通貨ペアNo		tinyint,
	@売買モード		varchar(5),
	@判定			tinyint	output
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
	SELECT TOP 2 [Rate_買い], [Rate_売り]
	FROM [dbo].[T_RateHistory]
	where 通貨ペア = @通貨ペアNo
	order by [Date] desc

	open cursor_T_RateHistory;
	
	FETCH NEXT FROM cursor_T_RateHistory INTO @今_Rate_買い, @今_Rate_売り;
	FETCH NEXT FROM cursor_T_RateHistory INTO @1つ前_Rate_買い, @1つ前_Rate_売り;

	CLOSE cursor_T_RateHistory;
	DEALLOCATE cursor_T_RateHistory;

	if @売買モード = '買い'
	begin
		if @1つ前_Rate_買い > @今_Rate_買い
		begin
			Set @判定 = 0;	-- Orderを出すのは危険
		end
		else
		begin
			Set @判定 = 1;	-- Orderを出しても大丈夫
		end
	end
	else
	begin
		if @1つ前_Rate_売り < @今_Rate_売り
		begin
			Set @判定 = 0;	-- Orderを出すのは危険
		end
		else
		begin
			Set @判定 = 1;	-- Orderを出しても大丈夫
		end
	end

	--select @判定

END

GO
