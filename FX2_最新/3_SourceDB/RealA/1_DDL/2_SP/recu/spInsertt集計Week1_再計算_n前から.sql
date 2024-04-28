USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spInsertt�W�vWeek1_�Čv�Z_n�O����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertt�W�vWeek1_�Čv�Z_n�O����]
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

		EXECUTE [pfmc].[spInsertt�W�vWeek1] @StartDate, @EndDate;

		Set @back_Week1 = @back_Week1 + 1;
	end;

END

GO


