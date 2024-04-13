USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistoryHourly_fromFXCM]
AS
BEGIN

	-- 古いデータを削除
	declare cursorT_FXCM_RateHistory_Hourly cursor for
	SELECT [通貨ペアNo], [日時]
	FROM [dbo].[T_FXCM_RateHistory_Hourly]
  	;

	open cursorT_FXCM_RateHistory_Hourly;

	declare @通貨ペアNo tinyint = 0;
	declare @日時 Datetime;
	FETCH NEXT FROM cursorT_FXCM_RateHistory_Hourly INTO @通貨ペアNo, @日時;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select *
		delete
		from [dbo].[T_RateHistory_Hourly]
		where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

		FETCH NEXT FROM cursorT_FXCM_RateHistory_Hourly INTO @通貨ペアNo, @日時;
	END

	CLOSE cursorT_FXCM_RateHistory_Hourly;
	DEALLOCATE cursorT_FXCM_RateHistory_Hourly;


	-- Insert
	INSERT INTO [dbo].[T_RateHistory_Hourly](
		 [通貨ペアNo]
		,[日時]
		,[MaxRate]
		,[MinRate]
	)
	SELECT [通貨ペアNo]
		,[日時]
		,[Rate_高値_買い]
		,[Rate_安値_売り]
	FROM [dbo].[T_FXCM_RateHistory_Hourly]
	;
	

END


GO
