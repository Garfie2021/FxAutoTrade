USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistoryHourly_1Day]
	@back_day	int = 0,	 --  0:最新週、-n:n週前 ※マイナス値にしか対応していない。
	@通貨ペアNo		tinyint
AS
BEGIN

	--declare @Today datetime =  '2014/2/7 6:30:00';
	declare @Today date = DATEADD(dayofyear, @back_day + -1, GETDATE());

	Set @Today = convert(varchar, YEAR(@Today)) + '/' + convert(varchar, MONTH(@Today))  + '/' + convert(varchar, DAY(@Today));

	declare @24Cnt tinyint = 0;

	declare @StartDate datetime = convert(varchar, YEAR(@Today)) + '/' + convert(varchar, MONTH(@Today))  + '/' + convert(varchar, DAY(@Today)) + ' 6:00:00';
	declare @EndDate datetime = DATEADD(hour, +1, @StartDate);

	while @24Cnt < 24
	begin

		--select @Today, @24Cnt as [24Cnt], @StartDate as StartDate, @EndDate as EndDate

		delete 
		--select *
		from [dbo].[T_RateHistory_Hourly]
		where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate
		;

		Insert [dbo].[T_RateHistory_Hourly] (
			 [通貨ペアNo]
			,[日時]
			,[買い_始値]
			,[買い_高値]
			,[買い_安値]
			,[買い_終値]
			,[売り_始値]
			,[売り_高値]
			,[売り_安値]
			,[売り_終値]
			,[MinSwap]
			,[MaxSwap]
			,[StartDate]
			,[EndDate]
		)
		select
			通貨ペア, 
			@StartDate,
			(
				select top 1 Rate_買い from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
				order by [date]
			) as 買い_始値,
			MAX(Rate_買い) as 買い_高値, 
			MIN(Rate_買い) as 買い_安値, 
			(
				select top 1 Rate_買い from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
				order by [date] desc
			) as 買い_終値,
			(
				select top 1 Rate_売り from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
				order by [date]
			) as 売り_始値,
			MAX(Rate_売り) as 売り_高値, 
			MIN(Rate_売り) as 売り_安値, 
			(
				select top 1 Rate_売り from [dbo].[T_RateHistory]
				where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
				order by [date] desc
			) as 売り_終値,
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

		Set @StartDate = DATEADD(hour, +1, @StartDate);
		Set @EndDate = DATEADD(hour, +1, @EndDate);
		Set @24Cnt = @24Cnt + 1;
		
	end;


END


GO
