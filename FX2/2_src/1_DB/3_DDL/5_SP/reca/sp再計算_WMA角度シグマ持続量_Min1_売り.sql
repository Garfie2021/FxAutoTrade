USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [reca].[sp再計算_WMA角度シグマ持続量_Min1_売り]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_WMA角度シグマ持続量_Min1_売り]
	@シグマ	float = 1,	-- プラス値にしか対応していない。プラスシグマ大きい時の反動で相場の動きが停滞するとマイナスシグマになるので計算対象外。
	@now	Datetime
AS
BEGIN
	/*
	declare @シグマ	float = 1;
	declare @now	Datetime = getdate();
	*/

	-- 売りRateの持続量を計算

	declare cursor_tRateHistory_Min1_シグマ cursor for
	SELECT [通貨ペアNo], [StartDate], [売りRate_終値], [売りWMAs2角度]
	from [rate].[tRateHistory_Min1]
	where [売りWMAs2角度シグマ] >= @シグマ;

	open cursor_tRateHistory_Min1_シグマ;

	DECLARE @通貨ペアNo				tinyint = 0;
	DECLARE @StartDate				datetime;
	DECLARE @売りRate_終値			float;
	DECLARE @売りWMAs2角度			float;
	DECLARE @売りWMAs2角度持続行数	int;
	DECLARE @売りWMAs2角度Rate差	float;

	FETCH NEXT FROM cursor_tRateHistory_Min1_シグマ INTO @通貨ペアNo, @StartDate, @売りRate_終値, @売りWMAs2角度;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		EXECUTE [rate].[spCulcWMAs2角度シグマ持続量_Min1_売り] @通貨ペアNo, @StartDate, @売りRate_終値, @売りWMAs2角度, 
			@売りWMAs2角度持続行数 OUTPUT, @売りWMAs2角度Rate差 OUTPUT;

		--select @売りWMAs2角度持続行数 as 売りWMAs2角度持続行数, @売りWMAs2角度Rate差 as 売りWMAs2角度Rate差;

		UPDATE [rate].[tRateHistory_Min1]
		SET [売りWMAs2角度持続時間] = @売りWMAs2角度持続行数,
			[売りWMAs2角度持続Rate] = @売りWMAs2角度Rate差
		WHERE 通貨ペアNo = @通貨ペアNo AND StartDate = @StartDate;

		FETCH NEXT FROM cursor_tRateHistory_Min1_シグマ INTO @通貨ペアNo, @StartDate, @売りRate_終値, @売りWMAs2角度;
	END

	CLOSE cursor_tRateHistory_Min1_シグマ;
	DEALLOCATE cursor_tRateHistory_Min1_シグマ;
END
GO
/*
*/


