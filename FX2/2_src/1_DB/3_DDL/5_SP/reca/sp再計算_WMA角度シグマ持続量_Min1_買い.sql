USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [reca].[sp再計算_WMA角度シグマ持続量_Min1_買い]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_WMA角度シグマ持続量_Min1_買い]
	@シグマ	float = 1,	-- プラス値にしか対応していない。プラスシグマ大きい時の反動で相場の動きが停滞するとマイナスシグマになるので計算対象外。
	@now	Datetime
AS
BEGIN
	/*
	declare @シグマ	float = 1;
	declare @now	Datetime = getdate();
	*/

	-- 買いRateの持続量を計算

	declare cursor_tRateHistory_Min1_シグマ cursor for
	SELECT [通貨ペアNo], [StartDate], [買いRate_終値], [買いWMAs2角度]
	from [rate].[tRateHistory_Min1]
	where [買いWMAs2角度シグマ] >= @シグマ;

	open cursor_tRateHistory_Min1_シグマ;

	DECLARE @通貨ペアNo				tinyint = 0;
	DECLARE @StartDate				datetime;
	DECLARE @買いRate_終値			float;
	DECLARE @買いWMAs2角度			float;
	DECLARE @買いWMAs2角度持続行数	int;
	DECLARE @買いWMAs2角度Rate差	float;

	FETCH NEXT FROM cursor_tRateHistory_Min1_シグマ INTO @通貨ペアNo, @StartDate, @買いRate_終値, @買いWMAs2角度;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		EXECUTE [rate].[spCulcWMAs2角度シグマ持続量_Min1_買い] @通貨ペアNo, @StartDate, @買いRate_終値, @買いWMAs2角度, 
			@買いWMAs2角度持続行数 OUTPUT, @買いWMAs2角度Rate差 OUTPUT;

		--select @買いWMAs2角度持続行数 as 買いWMAs2角度持続行数, @買いWMAs2角度Rate差 as 買いWMAs2角度Rate差;

		UPDATE [rate].[tRateHistory_Min1]
		SET [買いWMAs2角度持続時間] = @買いWMAs2角度持続行数,
			[買いWMAs2角度持続Rate] = @買いWMAs2角度Rate差
		WHERE 通貨ペアNo = @通貨ペアNo AND StartDate = @StartDate;

		FETCH NEXT FROM cursor_tRateHistory_Min1_シグマ INTO @通貨ペアNo, @StartDate, @買いRate_終値, @買いWMAs2角度;
	END

	CLOSE cursor_tRateHistory_Min1_シグマ;
	DEALLOCATE cursor_tRateHistory_Min1_シグマ;
END
GO
/*
*/


