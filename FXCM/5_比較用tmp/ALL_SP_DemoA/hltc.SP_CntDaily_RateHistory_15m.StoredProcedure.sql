USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [hltc].[SP_CntDaily_RateHistory_15m]
AS
BEGIN

	declare @StartDate datetime;
	select @StartDate = MAX(日時) from [dbo].[T_RateHistory_15m];
	Set @StartDate = convert(varchar, YEAR(@StartDate)) + '-' + convert(varchar, MONTH(@StartDate))  + '-' + 
		convert(varchar, DAY(@StartDate)) + ' 00:00:00';

	declare @EndDate datetime;
	select @EndDate = MIN(日時) from [dbo].[T_RateHistory_15m];

	select @StartDate as StartDate, @EndDate as EndDate

	while @EndDate < @StartDate
	begin

		-- 24h × 4 = 96　になるはず。
		select @StartDate as StartDate, 通貨ペアNo, count(*) as cnt
		from [dbo].[T_RateHistory_15m]
		where @StartDate <= 日時 and 日時 < DATEADD(DAYOFYEAR, 1, @StartDate)
		group by 通貨ペアNo

		Set @StartDate = DATEADD(DAYOFYEAR, -1, @StartDate)
	end


END


GO
