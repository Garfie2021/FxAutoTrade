USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp再計算_Rate_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_Rate_Min15]
	@back_15m	int = -2,		-- マイナス値にしか対応していない
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_15m < 1
	begin

		--処理対象期間取得
		EXECUTE [cmn].[spGetTerm_Min15] @now, @back_15m, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @通貨ペアNo as 通貨ペアNo,@StartDate as Start5m,@EndDate as End5m

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [rate].[spInsertRateHistory_Min15] @通貨ペアNo, @now, @back_15m;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_15m = @back_15m + 1;
	end;

END

GO


