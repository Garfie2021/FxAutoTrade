USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spInsertHistory�Čv�Z_n�O����_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory�Čv�Z_n�O����_Min15]
	@back_Min15 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @�ʉ݃y�ANo tinyint = 0;

	while @back_Min15 < 1
	begin

		EXECUTE [cmn].[spGetThisMin15] @now, @back_Min15, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @�ʉ݃y�ANo = 0;
		while @�ʉ݃y�ANo < 44
		begin

			EXECUTE [rate].[spInsertHistory_Min15] @�ʉ݃y�ANo, @StartDate, @EndDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Min15 = @back_Min15 + 1;
	end;

END

GO


