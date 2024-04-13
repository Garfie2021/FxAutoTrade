USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_Daily_fromFXCM]
AS
BEGIN

	-- 古いデータを削除
	declare cursorT_Rate_Daily cursor for
	SELECT [通貨ペアNo], [日時]
	FROM [fxcm].[T_Rate_Daily];

	open cursorT_Rate_Daily;

	declare @通貨ペアNo tinyint = 0;
	declare @日時 Datetime;
	FETCH NEXT FROM cursorT_Rate_Daily INTO @通貨ペアNo, @日時;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select *
		delete
		from [dbo].[T_RateHistory_Daily]
		where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

		FETCH NEXT FROM cursorT_Rate_Daily INTO @通貨ペアNo, @日時;
	END

	CLOSE cursorT_Rate_Daily;
	DEALLOCATE cursorT_Rate_Daily;


	-- Insert
	INSERT INTO [dbo].[T_RateHistory_Daily]
		([通貨ペアNo]
		,[日時]
		,[買い_始値]
		,[買い_高値]
		,[買い_安値]
		,[買い_終値]
		,[売り_始値]
		,[売り_高値]
		,[売り_安値]
		,[売り_終値])
	SELECT
		 [通貨ペアNo]
		,[日時]
		,[Rate_始値_買い]
		,[Rate_高値_買い]
		,[Rate_安値_買い]
		,[Rate_終値_買い]
		,[Rate_始値_売り]
		,[Rate_高値_売り]
		,[Rate_安値_売り]
		,[Rate_終値_売り]
	FROM [fxcm].[T_Rate_Daily];

END


GO
