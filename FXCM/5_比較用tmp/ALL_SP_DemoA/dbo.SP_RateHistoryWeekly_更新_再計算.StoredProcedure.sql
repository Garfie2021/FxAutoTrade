USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_RateHistoryWeekly_更新_再計算]
AS
BEGIN

	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = 0
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -1
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -2
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -3
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -4
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -5
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -6
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -7
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -8
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -9
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -10
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -11
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -12
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -13
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -14
	EXEC [dbo].[SP_RateHistoryWeekly_更新] 
	   @back_week = -15


END


GO
