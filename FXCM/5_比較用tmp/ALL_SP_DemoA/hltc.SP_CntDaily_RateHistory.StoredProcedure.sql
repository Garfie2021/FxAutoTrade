USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [hltc].[SP_CntDaily_RateHistory]
AS
BEGIN

	declare @StartDate datetime;
	select @StartDate = MAX([Date]) from [dbo].[T_RateHistory];
	Set @StartDate = convert(varchar, YEAR(@StartDate)) + '-' + convert(varchar, MONTH(@StartDate))  + '-' + 
		convert(varchar, DAY(@StartDate)) + ' 00:00:00';

	declare @EndDate datetime;
	select @EndDate = MIN([Date]) from [dbo].[T_RateHistory];

	select @StartDate as StartDate, @EndDate as EndDate

	while @EndDate < @StartDate
	begin

		-- 24h × 4 = 96　になるはず。
		select @StartDate as StartDate, 通貨ペア, count(*) as cnt
		from [dbo].[T_RateHistory]
		where @StartDate <= [Date] and [Date] < DATEADD(DAYOFYEAR, 1, @StartDate)
		group by 通貨ペア

		Set @StartDate = DATEADD(DAYOFYEAR, -1, @StartDate)
	end


END


GO
