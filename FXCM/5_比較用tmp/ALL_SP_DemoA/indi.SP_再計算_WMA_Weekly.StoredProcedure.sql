USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_再計算_WMA_Weekly]
AS
BEGIN

	declare @通貨ペアNo tinyint = 0;
	declare @now		datetime = getdate();

	while @通貨ペアNo < 44
	begin

		declare @back_Weekly int = -3;
		declare @ThisWeekly datetime;
		declare @WMA float;
		declare @WMA_S2 float;

		while @back_Weekly < 1
		begin

			EXECUTE [indi].[SP_CulcWMA_Weekly] @通貨ペアNo, @back_Weekly, @now, @ThisWeekly OUTPUT, @WMA OUTPUT, @WMA_S2 OUTPUT

			--select @通貨ペアNo, @back_Weekly, @ThisWeekly, @WMA, @WMA_S2

			EXECUTE [indi].[SP_InsertIndicator_Weekly_WMA] @通貨ペアNo, @ThisWeekly, @WMA, 0, @WMA_S2, 0

			Set @back_Weekly = @back_Weekly + 1;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END

GO
