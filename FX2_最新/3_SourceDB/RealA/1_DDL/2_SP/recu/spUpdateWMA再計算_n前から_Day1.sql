USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算_n前から_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算_n前から_Day1]
	@back_Day1 int = -1,
	@max_Day1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisDate	datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	while @back_Day1 < @max_Day1
	begin

		EXECUTE [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @通貨ペアNo = 0;
		WHILE @通貨ペアNo <= @通貨ペアNoMax
		begin

			EXECUTE [rate].[spUpdateWMA_Day1] @通貨ペアNo, @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Day1 = @back_Day1 + 1;
	end;

END

GO


