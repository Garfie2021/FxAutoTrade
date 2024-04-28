USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spUpdateWMA�Čv�Z_n�O����_Month1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA�Čv�Z_n�O����_Month1]
	@back_Month1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisWeek1	Datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @�ʉ݃y�ANo tinyint = 0;

	while @back_Month1 < 1
	begin

		EXECUTE [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		SET @�ʉ݃y�ANo = 0;
		while @�ʉ݃y�ANo < 44
		begin
			--select @�ʉ݃y�ANo, @StartDate;

			EXECUTE [rate].[spUpdateWMA_Month1] @�ʉ݃y�ANo, @StartDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Month1 = @back_Month1 + 1;
	end;

END

GO


