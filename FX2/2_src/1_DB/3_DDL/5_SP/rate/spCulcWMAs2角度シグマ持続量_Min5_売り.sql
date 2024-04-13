USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2角度シグマ持続量_Min5_売り]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2角度シグマ持続量_Min5_売り]
	@通貨ペアNo				tinyint,
	@StartDate				datetime,
	@売りRate_終値_Target	float,
	@売りWMAs2角度_Target	float,
	@持続行数				int		output,
	@Rate差					float	output
AS
BEGIN
	/*
	declare @通貨ペアNo				tinyint = 34;
	declare @StartDate				datetime = '2015-08-24 07:30:00.000';
	declare @売りRate_終値_Target	float = 121.693;
	declare @売りWMAs2角度_Target	float = -8.69879615470361;
	--declare @StartDate				datetime = '2015-08-24 08:00:00.000';
	--declare @売りRate_終値_Target	float = 121.311;
	--declare @売りWMAs2角度_Target	float = 11.5301303888022;
	declare @持続行数				int;
	declare @Rate差					float;
	*/

	DECLARE @売りRate_終値 float;
	DECLARE @売りWMAs2角度 float;

	-- 売り
	declare cursor_tRateHistory_Min5 cursor for
	SELECT [売りRate_終値], [売りWMAs2角度]
	from [rate].[tRateHistory_Min5]
	where [通貨ペアNo] = @通貨ペアNo AND [StartDate] > @StartDate
	order by [StartDate];

	open cursor_tRateHistory_Min5;
	FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @売りRate_終値, @売りWMAs2角度;

	SET @持続行数 = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN
			
		if @売りWMAs2角度_Target > 0
		begin
			if @売りWMAs2角度 > 0
			begin
				--WMAs2角度シグマ持続中
				SET @持続行数 = @持続行数 + 1;
				SET @Rate差 = @売りRate_終値 - @売りRate_終値_Target;
			end
			else
			begin
				--WMAs2角度シグマ持続終了
				BREAK;
			end;
		end
		else
		begin
			if @売りWMAs2角度 < 0
			begin
				--WMAs2角度シグマ持続中
				SET @持続行数 = @持続行数 + 1;
				SET @Rate差 = @売りRate_終値_Target - @売りRate_終値;
			end
			else
			begin
				--WMAs2角度シグマ持続終了
				BREAK;
			end;
		end;


		FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @売りRate_終値, @売りWMAs2角度;
	END

	CLOSE cursor_tRateHistory_Min5;
	DEALLOCATE cursor_tRateHistory_Min5;

	--select @持続行数 as 持続行数, @Rate差 as Rate差, @売りRate_終値 as 売りRate_終値, @売りWMAs2角度 as 売りWMAs2角度;

END
GO
/*
*/
