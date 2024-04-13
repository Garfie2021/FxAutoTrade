USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Monthly]
	@通貨ペアNo		tinyint,
	@now			Datetime,
	@back_Month		int = 0	 --  0:当日、-1:前日、-n:n週前 ※マイナス値にしか対応していない。
AS
BEGIN

	/*
	declare @back_Month		int = 0
	declare @通貨ペアNo		tinyint = 12
	declare @now			Datetime = '2014/4/1 5:59:00'
	*/

	DECLARE @ThisMonth datetime
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThisMonth] @now, @back_Month, @ThisMonth OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	--select @ThisMonth, @StartDate, @EndDate

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
		,[StartDate]
		,[EndDate]
	)
	/*
	*/
	select
		通貨ペアNo, 
		@ThisMonth as 日時,

		(
			select top 1 買い_始値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 買い_始値,
		MAX(買い_高値) as 買い_高値,
		MIN(買い_安値) as 買い_安値,
		(
			select top 1 買い_終値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 売り_始値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 売り_始値,
		MAX(売り_高値) as 売り_高値,
		MIN(売り_安値) as 売り_安値,
		(
			select top 1 売り_終値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 売り_終値,

		@StartDate as StartDate,
		@EndDate as EndDate
	from [dbo].[T_RateHistory_Daily] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate
	group by 通貨ペアNo
	--order by 通貨ペア
	;

END

GO
