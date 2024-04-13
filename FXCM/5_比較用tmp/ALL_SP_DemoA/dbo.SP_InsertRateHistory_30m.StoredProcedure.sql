USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_30m]
	@通貨ペアNo		tinyint = 12,
	@now		datetime, 
	@back_30m smallint
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 12
	declare @StartDate		datetime = '2014/02/11 0:00:11'
	*/

	DECLARE @Start30m datetime
	DECLARE @End30m datetime
	EXECUTE [cmn].[SP_GetThis30m] @now, @back_30m, @Start30m OUTPUT, @End30m OUTPUT

	--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @EndDate as EndDate

	delete 
	--select *
	from [dbo].[T_RateHistory_30m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @Start30m

	Insert [dbo].[T_RateHistory_30m] (
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
		通貨ペアNo as 通貨ペアNo,
		@Start30m as 日時,

		(
			select top 1 買い_始値 from [dbo].[T_RateHistory_15m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start30m <= [日時] and [日時] < @End30m
			order by [日時]
		) as 買い_始値,
		MAX(買い_高値) as 買い_高値, 
		MIN(買い_安値) as 買い_安値, 
		(
			select top 1 買い_終値 from [dbo].[T_RateHistory_15m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start30m <= [日時] and [日時] < @End30m
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 売り_始値 from [dbo].[T_RateHistory_15m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start30m <= [日時] and [日時] < @End30m
			order by [日時]
		) as 売り_始値,
		MAX(売り_高値) as 売り_高値,
		MIN(売り_安値) as 売り_安値,
		(
			select top 1 売り_終値 from [dbo].[T_RateHistory_15m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start30m <= [日時] and [日時] < @End30m
			order by [日時] desc
		) as 売り_終値,

		@Start30m as StartDate,
		@End30m as EndDate
	from [dbo].[T_RateHistory_15m] as a
	where 通貨ペアNo = @通貨ペアNo and @Start30m <= [日時] and [日時] < @End30m
	group by 通貨ペアNo
	--order by 通貨ペア
	;


END

GO
