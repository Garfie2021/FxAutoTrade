USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Daily]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_Day		smallint		-- マイナス値にしか対応していない
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 21
	declare @now			datetime = '2014/06/17 20:00:00';
	declare @back_Day		smallint = 0		-- マイナス値にしか対応していない
	*/

	declare @ThisDay date;
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThisDay] @now, @back_Day, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	select @ThisDay, @StartDate, @EndDate

	delete 
	--select *
	from [dbo].[T_RateHistory_Daily]
	where  通貨ペアNo = @通貨ペアNo and [日時] = @ThisDay;

	Insert [dbo].[T_RateHistory_Daily] (
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
		@ThisDay as 日時,

		(
			select top 1 買い_始値 from [dbo].[T_RateHistory_6h]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 買い_始値,
		MAX(買い_高値) as 買い_高値, 
		MIN(買い_安値) as 買い_安値, 
		(
			select top 1 買い_終値 from [dbo].[T_RateHistory_6h]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 売り_始値 from [dbo].[T_RateHistory_6h]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		) as 売り_始値,
		MAX(売り_高値) as 売り_高値,
		MIN(売り_安値) as 売り_安値,
		(
			select top 1 売り_終値 from [dbo].[T_RateHistory_6h]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		) as 売り_終値,
		@StartDate as StartDate,
		@EndDate as EndDate
	from [dbo].[T_RateHistory_6h] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate
	group by 通貨ペアNo
	--order by 通貨ペア
	;

END

GO
