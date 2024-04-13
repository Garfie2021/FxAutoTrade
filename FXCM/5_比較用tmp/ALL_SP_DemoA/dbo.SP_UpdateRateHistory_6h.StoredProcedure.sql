USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateRateHistory_6h]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_6h		int		-- マイナス値にしか対応していない
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 0;
	DECLARE @now			datetime = '2014-06-17 16:41:30.447';
	DECLARE @back_6h		smallint = 0;		-- マイナス値にしか対応していない
	*/

	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThis6h] @now, @back_6h, @StartDate OUTPUT, @EndDate OUTPUT

	--select @StartDate, @StartDate, @EndDate

	declare @cnt int;

	select @cnt = count(*)
	from [dbo].[T_RateHistory_Hourly]
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate

	if @cnt < 1
	begin
		return;
	end;

	select @cnt = count(*)
	from [dbo].[T_RateHistory_6h]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

	if @cnt < 1
	begin
		Insert [dbo].[T_RateHistory_6h] ([通貨ペアNo], [日時]) Values (@通貨ペアNo, @StartDate);
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
			select top 1 買い_始値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		),
		@買い_高値 = MAX(買い_高値),
		@買い_安値 = MIN(買い_安値),
		@買い_終値 = (
			select top 1 買い_終値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		),
		@売り_始値 = (
			select top 1 売り_始値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時]
		),
		@売り_高値 = MAX(売り_高値),
		@売り_安値 = MIN(売り_安値),
		@売り_終値 = (
			select top 1 売り_終値 from [dbo].[T_RateHistory_Hourly]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [日時] and [日時] < @EndDate
			order by [日時] desc
		)
	from [dbo].[T_RateHistory_Hourly] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] < @EndDate
	group by 通貨ペアNo
	--order by 通貨ペア
	;

	Update [dbo].[T_RateHistory_6h]
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
