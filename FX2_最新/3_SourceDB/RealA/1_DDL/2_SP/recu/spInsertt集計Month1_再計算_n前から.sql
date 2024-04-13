USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spInsertt集計Month1_再計算_n前から]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertt集計Month1_再計算_n前から]
	@back_Month1 int = -1,
	@max_Month1 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisDate	datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Month1 < @max_Month1
	begin

		EXECUTE [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		EXECUTE [pfmc].[spInsertt集計Month1] @StartDate, @EndDate;

		Set @back_Month1 = @back_Month1 + 1;
	end;

END

GO


