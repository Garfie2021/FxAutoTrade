USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_再計算_WMA_Daily]
AS
BEGIN

	declare @通貨ペアNo tinyint = 0;
	declare @now		datetime = getdate();

	while @通貨ペアNo < 44
	begin

		declare @back_Daily int = -3;
		declare @ThisDaily datetime;
		declare @WMA float;
		declare @WMA_S2 float;

		while @back_Daily < 1
		begin

			EXECUTE [indi].[SP_CulcWMA_Daily] @通貨ペアNo, @back_Daily, @now, @ThisDaily OUTPUT, @WMA OUTPUT, @WMA_S2 OUTPUT

			--select @通貨ペアNo, @back_Daily, @ThisDaily, @WMA, @WMA_S2

			EXECUTE [indi].[SP_InsertIndicator_Daily_WMA] @通貨ペアNo, @ThisDaily, @WMA, 0, @WMA_S2, 0

			Set @back_Daily = @back_Daily + 1;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END

GO
