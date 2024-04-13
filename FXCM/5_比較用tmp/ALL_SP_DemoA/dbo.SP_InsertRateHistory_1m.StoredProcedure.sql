USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_1m]
	@通貨ペアNo		tinyint = 12,
	@now			datetime, 
	@back_1m		smallint
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 12
	declare @StartDate		datetime = '2014/02/11 0:00:11'
	*/

	DECLARE @Start1m datetime
	DECLARE @End1m datetime
	EXECUTE [cmn].[SP_GetThis1m] @now, @back_1m, @Start1m OUTPUT, @End1m OUTPUT

	--select @通貨ペアNo as 通貨ペアNo, @Start1m as Start1m, @End1m as End1m

	delete 
	--select *
	from [dbo].[T_RateHistory_1m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @Start1m

	Insert [dbo].[T_RateHistory_1m] (
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
		@Start1m,
		(
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start1m <= [date] and [date] < @End1m
			order by [date]
		) as 買い_始値,
		MAX(Rate_買い) as 買い_高値, 
		MIN(Rate_買い) as 買い_安値, 
		(
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start1m <= [date] and [date] < @End1m
			order by [date] desc
		) as 買い_終値,
		(
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start1m <= [date] and [date] < @End1m
			order by [date]
		) as 売り_始値,
		MAX(Rate_売り) as 売り_高値, 
		MIN(Rate_売り) as 売り_安値, 
		(
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @Start1m <= [date] and [date] < @End1m
			order by [date] desc
		) as 売り_終値,
		@Start1m as StartDate,
		@End1m as EndDate
	from [dbo].[T_RateHistory] as a
	where @Start1m <= date and date < @End1m
		and a.通貨ペア = @通貨ペアNo
	group by 通貨ペア
	--order by 通貨ペア
	;

END

GO
