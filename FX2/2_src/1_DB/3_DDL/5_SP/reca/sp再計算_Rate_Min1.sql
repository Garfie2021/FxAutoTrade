USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp再計算_Rate_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_Rate_Min1]
	@back_1m	int = -2,		-- マイナス値にしか対応していない
	@now		Datetime
AS
BEGIN

	while @back_1m < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [rate].[spInsertRateHistory_Min1] @通貨ペアNo, @now, @back_1m

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_1m = @back_1m + 1;
	end;

END

GO


