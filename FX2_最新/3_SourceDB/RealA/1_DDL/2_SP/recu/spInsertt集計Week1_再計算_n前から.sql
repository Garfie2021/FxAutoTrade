USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spInsertt集計Week1_再計算_n前から]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertt集計Week1_再計算_n前から]
	@back_Week1 int = -1,
	@max_Week1 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisDate	datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Week1 < @max_Week1
	begin

		EXECUTE [cmn].[spGetThisWeek1] @now, @back_Week1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		EXECUTE [pfmc].[spInsertt集計Week1] @StartDate, @EndDate;

		Set @back_Week1 = @back_Week1 + 1;
	end;

END

GO


