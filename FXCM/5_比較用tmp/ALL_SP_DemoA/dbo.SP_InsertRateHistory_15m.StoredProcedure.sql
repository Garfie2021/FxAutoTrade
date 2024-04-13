USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_15m]
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
	from [dbo].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	Insert [dbo].[T_RateHistory_15m] (
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
		通貨ペアNo, 
		@StartDate,

		(
			select top 1 買い_始値 from [dbo].[T_RateHistory_5m]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 買い_始値,
		MAX(買い_高値) as 買い_高値, 
		MIN(買い_安値) as 買い_安値, 
		(
			select top 1 買い_終値 from [dbo].[T_RateHistory_5m]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 売り_始値 from [dbo].[T_RateHistory_5m]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 売り_始値,
		MAX(売り_高値) as 売り_高値,
		MIN(売り_安値) as 売り_安値,
		(
			select top 1 売り_終値 from [dbo].[T_RateHistory_5m]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 売り_終値,

		@StartDate as StartDate,
		@EndDate as EndDate
	from [dbo].[T_RateHistory_5m] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate
	group by 通貨ペアNo
	--order by 通貨ペア
	;
END

GO
