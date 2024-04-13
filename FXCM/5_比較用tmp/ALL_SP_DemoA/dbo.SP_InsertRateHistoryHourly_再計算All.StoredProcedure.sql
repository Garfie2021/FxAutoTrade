USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistoryHourly_再計算All]
AS
BEGIN

	-- 全期間
	declare @StartDate datetime;
	declare @EndDate datetime;	
	select @StartDate = MIN([Date]), @EndDate = MAX([Date]) from [dbo].T_RateHistory;

	-- 特定期間
	--declare @EndDate datetime = getdate();
	--declare @StartDate datetime = DATEADD(DAYOFYEAR, -14, @EndDate);

	declare @diff int = 0;
	Set @diff = DATEDIFF(dayofyear, @StartDate, @EndDate) * -1;

	select @StartDate, @EndDate, @diff


	while @diff < 1
	begin
		select @diff

		EXEC [dbo].[SP_InsertRateHistoryHourly] @back_day = @diff;

		Set @diff = @diff + 1;
	end;
	
END


GO
