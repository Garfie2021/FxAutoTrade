USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_再計算_WMA_Monthly]
AS
BEGIN


	declare @通貨ペアNo tinyint = 0;
	declare @now		datetime = getdate();

	while @通貨ペアNo < 44
	begin

		declare @back_Month int = -3;
		declare @ThisMonth datetime;
		declare @WMA float;
		declare @WMA_S2 float;

		while @back_Month < 1
		begin

			EXECUTE [indi].[SP_CulcWMA_Monthly] @通貨ペアNo, @back_Month, @now, @ThisMonth OUTPUT, @WMA OUTPUT, @WMA_S2 OUTPUT

			--select @通貨ペアNo, @back_Month, @ThisMonth, @WMA

			EXECUTE [indi].[SP_InsertIndicator_Monthly_WMA] @通貨ペアNo, @ThisMonth, @WMA, 0, @WMA_S2, 0

			Set @back_Month = @back_Month + 1;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


END

GO
