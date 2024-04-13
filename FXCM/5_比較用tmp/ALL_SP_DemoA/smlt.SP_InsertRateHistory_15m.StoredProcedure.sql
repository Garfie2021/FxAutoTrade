USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_InsertRateHistory_15m]
	@通貨ペアNo		tinyint = 12,
	@StartDate		datetime,
	@EndDate		datetime
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 2
	declare @StartDate		datetime = '2014/05/21 16:00:00'
	declare @EndDate		datetime = '2014/05/21 16:10:28'
	*/

	--declare @EndDate datetime = DATEADD(MINUTE, 15, @StartDate);

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @EndDate as EndDate

	delete 
	--select *
	from [smlt].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	Insert [smlt].[T_RateHistory_15m] (
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
		,[StartDate]
		,[EndDate]
	)
	select
	/*
	*
	*/
		通貨ペア, 
		@StartDate,
		(
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] <= @EndDate
			order by [date]
		) as 買い_始値,
		MAX(Rate_買い) as 買い_高値, 
		MIN(Rate_買い) as 買い_安値, 
		(
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] <= @EndDate
			order by [date] desc
		) as 買い_終値,
		(
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] <= @EndDate
			order by [date]
		) as 売り_始値,
		MAX(Rate_売り) as 売り_高値, 
		MIN(Rate_売り) as 売り_安値, 
		(
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] <= @EndDate
			order by [date] desc
		) as 売り_終値,
		@StartDate as StartDate,
		@EndDate as EndDate
	from [dbo].[T_RateHistory] as a
	where @StartDate <= date and date <= @EndDate
		and a.通貨ペア = @通貨ペアNo
	group by 通貨ペア
	--order by 通貨ペア, [date]
	;

END

GO
