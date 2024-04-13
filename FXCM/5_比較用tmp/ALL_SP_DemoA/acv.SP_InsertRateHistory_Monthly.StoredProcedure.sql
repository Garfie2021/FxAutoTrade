USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [acv].[SP_InsertRateHistory_Monthly]
	@back_Month		int = 0,	 --  0:当日、-1:前日、-n:n週前 ※マイナス値にしか対応していない。
	@通貨ペアNo		tinyint
AS
BEGIN

	/*
	declare @back_Month		int = 0
	declare @通貨ペアNo		tinyint = 12
	*/

	--declare @ThisMonth datetime =  '2014/2/10 6:30:00';
	declare @ThisMonth date = DATEADD(MONTH, @back_Month, GETDATE());

	Set @ThisMonth = convert(varchar, YEAR(@ThisMonth)) + '/' + convert(varchar, MONTH(@ThisMonth))  + '/1 00:00:00';

	declare @StartDate datetime = convert(varchar, YEAR(@ThisMonth)) + '/' + convert(varchar, MONTH(@ThisMonth))  + '/01 6:00:00';
	declare @EndDate datetime = DATEADD(MONTH, 1, @StartDate);

	select @ThisMonth, @StartDate, @EndDate

	/*
	delete 
	--select *
	from [dbo].[T_RateHistory_Monthly]
	where  通貨ペアNo = @通貨ペアNo and [日時] = @ThisMonth;

	Insert [dbo].[T_RateHistory_Monthly] (
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
		,[MaxSwap]
		,[MinSwap]
		,[StartDate]
		,[EndDate]
	)
	select
		通貨ペアNo as 通貨ペアNo, 
		@ThisMonth as 日時,
		(
			select top 1 Rate_買い from [acv].[T_RateHistory_Past]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 買い_始値,
		MAX(Rate_買い) as 買い_高値, 
		MIN(Rate_買い) as 買い_安値, 
		(
			select top 1 Rate_買い from [acv].[T_RateHistory_Past]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 Rate_売り from [acv].[T_RateHistory_Past]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 売り_始値,
		MAX(Rate_売り) as 売り_高値, 
		MIN(Rate_売り) as 売り_安値, 
		(
			select top 1 Rate_売り from [acv].[T_RateHistory_Past]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 売り_終値,
		(
			select MAX(swap)
			from (
				select MAX(swap_買い) as swap  from [acv].[T_RateHistory_Past]
				where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
				union
				select MAX(swap_売り) as swap  from [acv].[T_RateHistory_Past]
				where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			) as c
		) as MaxSwap,
		(
			select MIN(swap)
			from (
				select MIN(swap_買い) as swap  from [acv].[T_RateHistory_Past]
				where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
				union
				select MIN(swap_売り) as swap  from [acv].[T_RateHistory_Past]
				where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			) as b
		) as MinSwap,
		@StartDate as StartDate,
		@EndDate as EndDate
	from [acv].[T_RateHistory_Past] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate
	group by 通貨ペアNo
	--order by 通貨ペア
	;
	*/

END


GO
