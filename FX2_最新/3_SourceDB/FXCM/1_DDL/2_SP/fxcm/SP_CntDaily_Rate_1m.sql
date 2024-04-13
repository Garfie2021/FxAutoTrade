USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_CntDaily_Rate_1m]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_CntDaily_Rate_1m]
AS
BEGIN

	declare @StartDate datetime;
	select @StartDate = MAX(“úŽž) from [fxcm].[T_Rate_1m];
	Set @StartDate = convert(varchar, YEAR(@StartDate)) + '-' + convert(varchar, MONTH(@StartDate))  + '-' + 
		convert(varchar, DAY(@StartDate)) + ' 00:00:00';

	declare @EndDate datetime;
	select @EndDate = MIN(“úŽž) from [fxcm].[T_Rate_1m];

	select @StartDate as StartDate, @EndDate as EndDate

	while @EndDate < @StartDate
	begin

		-- 24h ~ 60m = 1440@‚É‚È‚é‚Í‚¸B
		select @StartDate as StartDate, count(*) as cnt
		from [fxcm].[T_Rate_1m]
		where @StartDate <= “úŽž and “úŽž < DATEADD(DAYOFYEAR, 1, @StartDate)

		Set @StartDate = DATEADD(DAYOFYEAR, -1, @StartDate)
	end


END

GO
