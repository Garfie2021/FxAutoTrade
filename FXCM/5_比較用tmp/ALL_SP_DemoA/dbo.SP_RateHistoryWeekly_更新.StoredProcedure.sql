USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_RateHistoryWeekly_更新]
	@back_week	int = 0	 --  0:最新週、-n:n週前 ※マイナス値にしか対応していない。
AS
BEGIN

	--declare @Today datetime =  '2014/2/10 6:30:00';
	declare @Today datetime = GETDATE();

	Set @Today = DATEADD(dayofyear, (@back_week * 7), @Today);

	-- Year WeekNo を求める
	declare @Year	smallint = 0;
	declare @Week	tinyint = 0;
	declare @StartDate datetime;
	declare @EndDate datetime;
	SELECT  @Year = [year], @Week = [wk], @StartDate = [StartDate], @EndDate = [EndDate]
	FROM [dbo].[T_year_wk]
	where StartDate < @Today and @Today < EndDate

	--select @Today as Today, @StartDate as StartDate, @EndDate as EndDate, @Year as Year, @Week as Week

	delete from [dbo].[T_RateHistory_Weekly]
	where [Year] = @Year and [Week] = @Week;

	Insert [dbo].[T_RateHistory_Weekly] (
		 [通貨ペアNo]
		,[Year]
		,[Week]
		,[MinRate]
		,[MaxRate]
		,[MinSwap]
		,[MaxSwap]
		,[StartDate]
		,[EndDate]
	)
	select
		通貨ペア, 
		@Year,
		@Week,
		MIN(Rate_売り) as MinRate, 
		MAX(Rate_買い) as MaxRate, 
		(
			select MIN(swap)
			from (
				select MIN(swap_買い) as swap  from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= date and date < @EndDate
				union
				select MIN(swap_売り) as swap  from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= date and date < @EndDate
			) as b
		) as MinSwap,
		(
			select MAX(swap)
			from (
				select MAX(swap_買い) as swap  from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= date and date < @EndDate
				union
				select MAX(swap_売り) as swap  from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= date and date < @EndDate
			) as c
		) as MaxSwap,
		@StartDate,
		@EndDate
	from [dbo].[T_RateHistory] as a
	where @StartDate <= date and date < @EndDate
	group by 通貨ペア
	--order by 通貨ペア
	;

END


GO
