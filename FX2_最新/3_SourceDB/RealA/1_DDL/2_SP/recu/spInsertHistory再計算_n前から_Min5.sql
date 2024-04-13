USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spInsertHistory再計算_n前から_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory再計算_n前から_Min5]
	@back_Min5 int = -1,
	@max_Min5 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	while @back_Min5 < @max_Min5
	begin

		EXECUTE [cmn].[spGetThisMin5] @now, @back_Min5, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @通貨ペアNo = 0;
		WHILE @通貨ペアNo <= @通貨ペアNoMax
		begin

			EXECUTE [rate].[spInsertHistory_Min5] @通貨ペアNo, @StartDate, @EndDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Min5 = @back_Min5 + 1;
	end;

END

GO


