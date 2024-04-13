USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_RateHistoryMonthly_更新_再計算]
AS
BEGIN

	EXEC [dbo].[SP_RateHistoryMonthly_更新] 
	   @back_month = 0
	EXEC [dbo].[SP_RateHistoryMonthly_更新] 
	   @back_month = -1
	EXEC [dbo].[SP_RateHistoryMonthly_更新] 
	   @back_month = -2

END


GO
