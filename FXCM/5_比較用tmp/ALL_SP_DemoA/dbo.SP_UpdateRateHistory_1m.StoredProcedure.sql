USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateRateHistory_1m]
	@通貨ペアNo		tinyint = 12,
	@now			datetime, 
	@back_1m		int
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 0;
	DECLARE @now			datetime = '2014-06-17 16:41:30.447';
	DECLARE @back_6h		smallint = 0;		-- マイナス値にしか対応していない
	*/

	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThis1m] @now, @back_1m, @StartDate OUTPUT, @EndDate OUTPUT

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as Start1m, @EndDate as End1m

	declare @cnt int;

	select @cnt = count(*)
	from [dbo].[T_RateHistory]
	where 通貨ペア = @通貨ペアNo and @StartDate <= [Date] and [Date] < @EndDate

	if @cnt < 1
	begin
		return;
	end;

	select @cnt = count(*)
	from [dbo].[T_RateHistory_1m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	if @cnt < 1
	begin
		Insert [dbo].[T_RateHistory_1m] ([通貨ペアNo], [日時]) Values (@通貨ペアNo, @StartDate);
	end;

	declare @買い_始値 float;
	declare @買い_高値 float;
	declare @買い_安値 float;
	declare @買い_終値 float;
	declare @売り_始値 float;
	declare @売り_高値 float;
	declare @売り_安値 float;
	declare @売り_終値 float;

	select
		@買い_始値 = (
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
			order by [date]
		),
		@買い_高値 = MAX(Rate_買い),
		@買い_安値 = MIN(Rate_買い),
		@買い_終値 = (
			select top 1 Rate_買い from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
			order by [date] desc
		),
		@売り_始値 = (
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
			order by [date]
		),
		@売り_高値 = MAX(Rate_売り),
		@売り_安値 = MIN(Rate_売り),
		@売り_終値 = (
			select top 1 Rate_売り from [dbo].[T_RateHistory]
			where 通貨ペア = a.通貨ペア and  @StartDate <= [date] and [date] < @EndDate
			order by [date] desc
		)
	from [dbo].[T_RateHistory] as a
	where @StartDate <= date and date < @EndDate
		and a.通貨ペア = @通貨ペアNo
	group by 通貨ペア
	--order by 通貨ペア
	;

	Update [dbo].[T_RateHistory_1m]
	Set
		 [買い_始値] = @買い_始値
		,[買い_高値] = @買い_高値
		,[買い_安値] = @買い_安値
		,[買い_終値] = @買い_終値
		,[売り_始値] = @売り_始値
		,[売り_高値] = @売り_高値
		,[売り_安値] = @売り_安値
		,[売り_終値] = @売り_終値
		,[StartDate] = @StartDate
		,[EndDate] = @EndDate
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

END

GO
