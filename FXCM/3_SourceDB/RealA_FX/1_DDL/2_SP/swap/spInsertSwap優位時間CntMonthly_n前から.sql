USE DemoA_FX
GO

DROP PROCEDURE [swap].[spInsertSwap優位時間CntMonthly_n前から]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spInsertSwap優位時間CntMonthly_n前から]
	@back_Month1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisWeek1	Datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @通貨ペアNo tinyint = 0;

	while @back_Month1 < 1
	begin

		EXECUTE [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			EXECUTE [swap].[spInsertSwap優位時間CntMonthly] @通貨ペアNo, @StartDate, @EndDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Month1 = @back_Month1 + 1;
	end;

END

GO


