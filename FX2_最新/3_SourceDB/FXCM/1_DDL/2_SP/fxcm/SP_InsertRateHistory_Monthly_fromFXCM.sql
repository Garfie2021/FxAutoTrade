USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_Monthly_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_Monthly_fromFXCM]
AS
BEGIN

	-- 古いデータを削除
	declare cursor_T_Rate_Monthly cursor for
	SELECT [通貨ペアNo], [日時]
	FROM [fxcm].[T_Rate_Monthly];

	open cursor_T_Rate_Monthly;

	declare @通貨ペアNo tinyint = 0;
	declare @日時 date;
	FETCH NEXT FROM cursor_T_Rate_Monthly INTO @通貨ペアNo, @日時;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		delete 
		--select *
		from [dbo].[T_RateHistory_Monthly]
		where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

		FETCH NEXT FROM cursor_T_Rate_Monthly INTO @通貨ペアNo, @日時;
	END

	CLOSE cursor_T_Rate_Monthly;
	DEALLOCATE cursor_T_Rate_Monthly;

	-- Insert
	INSERT INTO [dbo].[T_RateHistory_Monthly]
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
	FROM [fxcm].[T_Rate_Monthly];

END

GO
