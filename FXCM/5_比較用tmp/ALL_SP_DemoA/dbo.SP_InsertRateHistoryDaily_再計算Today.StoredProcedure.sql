USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistoryDaily_再計算Today]
AS
BEGIN

	if DATEPART(hour, getdate()) < 6
	begin
		EXEC [dbo].[SP_RateHistoryHourly_更新] @back_day = -1;
	end
	else
	begin
		EXEC [dbo].[SP_RateHistoryHourly_更新] @back_day = 0;
	end

END


GO
