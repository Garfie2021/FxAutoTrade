USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算_n前から_Month1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算_n前から_Month1]
	@back_Month1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisWeek1	Datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @通貨ペアNo tinyint = 0;

	while @back_Month1 < 1
	begin

		EXECUTE [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		SET @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin
			--select @通貨ペアNo, @StartDate;

			EXECUTE [rate].[spUpdateWMA_Month1] @通貨ペアNo, @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Month1 = @back_Month1 + 1;
	end;

END

GO


