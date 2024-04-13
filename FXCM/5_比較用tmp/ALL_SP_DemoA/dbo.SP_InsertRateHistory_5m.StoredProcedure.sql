USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_5m]
	@通貨ペアNo		tinyint = 12,
	@now			datetime, 
	@back_5m		smallint
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 12
	declare @StartDate		datetime = '2014/02/11 0:00:11'
	*/

	DECLARE @Start5m datetime
	DECLARE @End5m datetime
	EXECUTE [cmn].[SP_GetThis5m] @now, @back_5m, @Start5m OUTPUT, @End5m OUTPUT

	select @通貨ペアNo as 通貨ペアNo, @Start5m as Start5m, @End5m as End5m

	delete 
	--select *
	from [dbo].[T_RateHistory_5m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @Start5m

	Insert [dbo].[T_RateHistory_5m] (
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
		通貨ペア, 
		@Start5m,
		(
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start5m <= [date] and [date] < @End5m
			order by [date]
		) as 買い_始値,
		MAX(Rate_買い) as 買い_高値, 
		MIN(Rate_買い) as 買い_安値, 
		(
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start5m <= [date] and [date] < @End5m
			order by [date] desc
		) as 買い_終値,
		(
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start5m <= [date] and [date] < @End5m
			order by [date]
		) as 売り_始値,
		MAX(Rate_売り) as 売り_高値, 
		MIN(Rate_売り) as 売り_安値, 
		(
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start5m <= [date] and [date] < @End5m
			order by [date] desc
		) as 売り_終値,
		@Start5m as StartDate,
		@End5m as EndDate
	from [dbo].[T_RateHistory] as a
	where @Start5m <= date and date < @End5m
		and a.通貨ペア = @通貨ペアNo
	group by 通貨ペア
	--order by 通貨ペア
	;


END


GO
