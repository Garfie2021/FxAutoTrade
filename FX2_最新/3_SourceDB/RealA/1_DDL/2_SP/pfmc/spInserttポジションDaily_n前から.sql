USE OANDA_RealA
GO

DROP PROCEDURE [pfmc].[spInsertポジション実績Daily_n前から]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertポジション実績Daily_n前から]
	@back_Day1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisDay1	Datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Day1 < 1
	begin

		EXECUTE [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDay1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		EXECUTE [pfmc].[spInserttポジション実績Daily] @StartDate, @EndDate;

		Set @back_Day1 = @back_Day1 + 1;
	end;

END

GO


