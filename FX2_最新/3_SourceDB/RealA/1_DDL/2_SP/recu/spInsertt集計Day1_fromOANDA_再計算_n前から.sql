USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spInsertt集計Day1_fromOANDA_再計算_n前から]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertt集計Day1_fromOANDA_再計算_n前から]
	@back_Day1 int = -1,
	@max_Day1 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisDate	datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Day1 < @max_Day1
	begin

		EXECUTE [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		EXECUTE [pfmc].[spInsertt集計Day1_fromOANDA] @StartDate, @EndDate;

		Set @back_Day1 = @back_Day1 + 1;
	end;

END

GO


