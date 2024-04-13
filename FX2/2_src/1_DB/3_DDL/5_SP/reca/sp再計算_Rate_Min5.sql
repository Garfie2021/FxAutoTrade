USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp再計算_Rate_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_Rate_Min5]
	@back_Min5	int = -2,		-- マイナス値にしか対応していない
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Min5 < 1
	begin

		--処理対象期間取得
		EXECUTE [cmn].[spGetTerm_Min5] @now, @back_Min5, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @通貨ペアNo as 通貨ペアNo,@StartDate as Start5m,@EndDate as End5m

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [rate].[spInsertRateHistory_Min5] @通貨ペアNo, @now, @back_Min5;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Min5 = @back_Min5 + 1;
	end;

END

GO


