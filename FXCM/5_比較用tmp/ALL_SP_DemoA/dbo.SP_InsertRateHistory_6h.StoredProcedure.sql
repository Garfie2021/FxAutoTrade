USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_6h]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_6h		smallint		-- マイナス値にしか対応していない
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 0
	declare @now			datetime = '2014/06/12 22:00:00';
	declare @back_6h		smallint = -1
	*/

	DECLARE @Start6h datetime
	DECLARE @End6h datetime
	EXECUTE [cmn].[SP_GetThis6h] @now, @back_6h, @Start6h OUTPUT, @End6h OUTPUT

	--select @Start6h, @Start6h, @End6h

	delete 
	--select *
	from [dbo].[T_RateHistory_6h]
	where  通貨ペアNo = @通貨ペアNo and [日時] = @Start6h;

	Insert [dbo].[T_RateHistory_6h] (
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
		@Start6h as 日時,

		(
			select top 1 買い_始値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @Start6h <= [日時] and [日時] < @End6h
			order by [日時]
		) as 買い_始値,
		MAX(買い_高値) as 買い_高値, 
		MIN(買い_安値) as 買い_安値, 
		(
			select top 1 買い_終値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @Start6h <= [日時] and [日時] < @End6h
			order by [日時] desc
		) as 買い_終値,
		(
			select top 1 売り_始値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @Start6h <= [日時] and [日時] < @End6h
			order by [日時]
		) as 売り_始値,
		MAX(売り_高値) as 売り_高値,
		MIN(売り_安値) as 売り_安値,
		(
			select top 1 売り_終値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @Start6h <= [日時] and [日時] < @End6h
			order by [日時] desc
		) as 売り_終値,

		@Start6h as StartDate,
		@End6h as EndDate
	from [dbo].[T_RateHistory_Hourly] as a
	where 通貨ペアNo = @通貨ペアNo and @Start6h <= [日時] and [日時] < @End6h
	group by 通貨ペアNo
	--order by 通貨ペア
	;

END

GO
