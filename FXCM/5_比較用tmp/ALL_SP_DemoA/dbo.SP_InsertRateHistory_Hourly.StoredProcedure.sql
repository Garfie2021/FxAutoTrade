USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Hourly]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_1h		smallint		-- マイナス値にしか対応していない
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 0
	declare @now			datetime = '2014/04/24 00:00:00';
	*/

	DECLARE @Start1h datetime
	DECLARE @End1h datetime
	EXECUTE [cmn].[SP_GetThis1h] @now, @back_1h, @Start1h OUTPUT, @End1h OUTPUT

	--select @Start1h, @Start1h, @End1h

	delete 
	--select *
	from [dbo].[T_RateHistory_Hourly]
	where  通貨ペアNo = @通貨ペアNo and [日時] = @Start1h;

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
		,[StartDate]
		,[EndDate]
	)
	select
		通貨ペアNo as 通貨ペアNo,
		@Start1h as 日時,

		(
			select top 1 買い_始値 from [dbo].[T_RateHistory_30m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start1h <= [日時] and [日時] < @End1h
			order by [日時]
		) as 買い_始値,
		MAX(買い_高値) as 買い_高値, 
		MIN(買い_安値) as 買い_安値, 
		(
			select top 1 買い_終値 from [dbo].[T_RateHistory_30m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start1h <= [日時] and [日時] < @End1h
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 売り_始値 from [dbo].[T_RateHistory_30m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start1h <= [日時] and [日時] < @End1h
			order by [日時]
		) as 売り_始値,
		MAX(売り_高値) as 売り_高値,
		MIN(売り_安値) as 売り_安値,
		(
			select top 1 売り_終値 from [dbo].[T_RateHistory_30m]
			where 通貨ペアNo = a.通貨ペアNo and  @Start1h <= [日時] and [日時] < @End1h
			order by [日時] desc
		) as 売り_終値,

		@Start1h as StartDate,
		@End1h as EndDate
	from [dbo].[T_RateHistory_30m] as a
	where 通貨ペアNo = @通貨ペアNo and @Start1h <= [日時] and [日時] < @End1h
	group by 通貨ペアNo
	--order by 通貨ペア
	;



END


GO
