USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spInsertHistory�Čv�Z_n�O����_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory�Čv�Z_n�O����_Min5]
	@back_Min5 int = -1,
	@max_Min5 int = 1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	while @back_Min5 < @max_Min5
	begin

		EXECUTE [cmn].[spGetThisMin5] @now, @back_Min5, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @�ʉ݃y�ANo = 0;
		WHILE @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
		begin

			EXECUTE [rate].[spInsertHistory_Min5] @�ʉ݃y�ANo, @StartDate, @EndDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Min5 = @back_Min5 + 1;
	end;

END

GO


