USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA�Čv�Z_n�O����_Week1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA�Čv�Z_n�O����_Week1]
	@back_Week1 int = -1,
	@max_Week1 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisWeek1	Date;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	while @back_Week1 < @max_Week1
	begin

		EXECUTE [cmn].[spGetThisWeek1] @now, @back_Week1, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @�ʉ݃y�ANo = 0;
		WHILE @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
		begin

			EXECUTE [rate].[spUpdateWMA_Week1] @�ʉ݃y�ANo, @StartDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Week1 = @back_Week1 + 1;
	end;

END
GO
