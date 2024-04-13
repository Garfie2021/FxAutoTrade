USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_fromFXCM_Rate_1m]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_fromFXCM_Rate_1m]
AS
BEGIN

	-- 古いデータを削除
	declare cursorT_Rate_1m cursor for
	SELECT [通貨ペアNo], [日時]
	FROM [fxcm].[T_Rate_1m];

	open cursorT_Rate_1m;

	declare @通貨ペアNo tinyint = 0;
	declare @日時 Datetime;
	FETCH NEXT FROM cursorT_Rate_1m INTO @通貨ペアNo, @日時;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select *
		delete
		from [dbo].[T_RateHistory]
		where 通貨ペア = @通貨ペアNo and [Date] = @日時

		FETCH NEXT FROM cursorT_Rate_1m INTO @通貨ペアNo, @日時;
	END

	CLOSE cursorT_Rate_1m;
	DEALLOCATE cursorT_Rate_1m;


	-- Insert
	INSERT INTO [dbo].[T_RateHistory]
           ([通貨ペア]
           ,[Date]
           ,[Rate_買い]
           ,[Rate_売り]
           ,[Swap_買い]
           ,[Swap_売り]
		   ,[Rate相反Status_買い]
		   ,[Rate相反Status_売り])
	SELECT [通貨ペアNo]
		,[日時]
		,[Rate_始値_買い]
		,[Rate_始値_売り]
		,0
		,0
		,null
		,null
	FROM [fxcm].[T_Rate_1m]
	

END

GO
