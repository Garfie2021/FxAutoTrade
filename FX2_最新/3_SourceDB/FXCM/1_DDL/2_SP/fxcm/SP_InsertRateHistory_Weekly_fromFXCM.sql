USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistoryWeekly_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistoryWeekly_fromFXCM]
AS
BEGIN
/*
*/
	-- 古いデータを削除
	declare cursorT_FXCM_RateHistory_Weekly cursor for
	SELECT [通貨ペアNo], convert(varchar, YEAR([日時])) + '/' + convert(varchar, MONTH([日時])) + '/' + convert(varchar, DAY([日時])), Rate_高値_買い, Rate_安値_売り
	FROM [dbo].[T_FXCM_RateHistory_Weekly]
  	;

	open cursorT_FXCM_RateHistory_Weekly;

	declare @通貨ペアNo tinyint = 0;
	declare @date varchar(20);
	declare @Rate_高値_買い float = 0;
	declare @Rate_安値_売り float = 0;
	FETCH NEXT FROM cursorT_FXCM_RateHistory_Weekly INTO @通貨ペアNo, @date, @Rate_高値_買い, @Rate_安値_売り;

	declare @Year smallint = 0;
	declare @Week tinyint = 0;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @Year = [year], @Week = [wk]
		FROM [dbo].[GetYearWeek] (CONVERT(DATE, @date))

		--SELECT @通貨ペアNo, @Year, @Week, @date,CONVERT(DATE, @date)

		delete from [dbo].[T_RateHistory_Weekly]
		where 通貨ペアNo = @通貨ペアNo and [Year] = @Year and [Week] = @Week

		INSERT INTO [dbo].[T_RateHistory_Weekly](
			 [通貨ペアNo]
			,[Year]
			,[Week]
			,[MaxRate]
			,[MinRate]
		)VALUES(
			 @通貨ペアNo
			,@Year
			,@Week
			,@Rate_高値_買い
			,@Rate_安値_売り
		);

		FETCH NEXT FROM cursorT_FXCM_RateHistory_Weekly INTO @通貨ペアNo, @date, @Rate_高値_買い, @Rate_安値_売り;
	END

	CLOSE cursorT_FXCM_RateHistory_Weekly;
	DEALLOCATE cursorT_FXCM_RateHistory_Weekly;
	
END

GO
/*
*/
