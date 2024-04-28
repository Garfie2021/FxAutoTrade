USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spInsertHistory�Čv�Z_n�O����_Hour1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory�Čv�Z_n�O����_Hour1]
	@back_Hour1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @�ʉ݃y�ANo tinyint = 0;

	while @back_Hour1 < 1
	begin

		EXECUTE [cmn].[spGetThisHour1] @now, @back_Hour1, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @�ʉ݃y�ANo = 0;
		while @�ʉ݃y�ANo < 44
		begin

			EXECUTE [rate].[spInsertHistory_Hour1] @�ʉ݃y�ANo, @StartDate, @EndDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Hour1 = @back_Hour1 + 1;
	end;

END

GO


