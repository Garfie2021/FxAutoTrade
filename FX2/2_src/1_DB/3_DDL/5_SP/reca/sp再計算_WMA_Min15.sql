USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp再計算_WMA_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_WMA_Min15]
	@back_Min15 int = -2,		-- マイナス値にしか対応していない
	@now		Datetime
AS
BEGIN
	
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	DECLARE @買いWMAs2 float;
	DECLARE @売りWMAs2 float;

	DECLARE @通貨ペアNo tinyint = 0;

	while @back_Min15 < 1
	begin

		--処理対象期間取得
		EXECUTE [cmn].[spGetTerm_Min15] @now, @back_Min15, @StartDate OUTPUT, @EndDate OUTPUT;
		--SELECT @back_Min15 as back_Min15, @StartDate as StartDate, @EndDate as EndDate;

		SET @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			--EXECUTE [reca].[spUpdateWMAs2_Min15] @通貨ペアNo, @StartDate; ←Order時の計算ではこれを使う
			EXECUTE [rate].[spCulcWMAs2_Min15] @通貨ペアNo, @StartDate, @買いWMAs2 OUTPUT, @売りWMAs2 OUTPUT;

			UPDATE [rate].[tRateHistory_Min15]
			SET
				買いWMAs2 = @買いWMAs2,
				売りWMAs2 = @売りWMAs2,
				[更新日時] = @now
			where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Min15 = @back_Min15 + 1;
	end;

END
GO


