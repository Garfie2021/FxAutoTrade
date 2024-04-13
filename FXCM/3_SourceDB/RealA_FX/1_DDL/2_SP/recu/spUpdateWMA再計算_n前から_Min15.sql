USE [RealA_FX_ACV]
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算_n前から_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算_n前から_Min15]
	@back_Min15 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	DECLARE @通貨ペアNo tinyint = 0;

	while @back_Min15 < 1
	begin

		EXECUTE [cmn].[spGetThisMin15] @now, @back_Min15, @StartDate OUTPUT, @EndDate OUTPUT;

		print @StartDate;

		SET @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			EXECUTE [rate].[spUpdateWMA_Min15] @通貨ペアNo, @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Min15 = @back_Min15 + 1;
	end;

END

GO


