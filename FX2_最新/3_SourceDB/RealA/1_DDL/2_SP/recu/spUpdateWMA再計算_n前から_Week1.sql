USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算_n前から_Week1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算_n前から_Week1]
	@back_Week1 int = -1,
	@max_Week1 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisWeek1	Date;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	while @back_Week1 < @max_Week1
	begin

		EXECUTE [cmn].[spGetThisWeek1] @now, @back_Week1, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @通貨ペアNo = 0;
		WHILE @通貨ペアNo <= @通貨ペアNoMax
		begin

			EXECUTE [rate].[spUpdateWMA_Week1] @通貨ペアNo, @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Week1 = @back_Week1 + 1;
	end;

END
GO
