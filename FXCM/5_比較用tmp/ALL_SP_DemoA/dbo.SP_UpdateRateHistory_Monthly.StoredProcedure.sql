USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateRateHistory_Monthly]
	@通貨ペアNo		tinyint,
	@now			Datetime,
	@back_Month		int = 0	 --  0:当日、-1:前日、-n:n週前 ※マイナス値にしか対応していない。
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 34;
	DECLARE @now			datetime = getdate();
	DECLARE @back_Month		smallint = -1;		-- マイナス値にしか対応していない
	*/

	DECLARE @ThisMonth datetime;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[SP_GetThisMonth] @now, @back_Month, @ThisMonth OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

	DECLARE @StartDate2 date = convert(varchar, YEAR(@StartDate)) + '-' + convert(varchar, MONTH(@StartDate)) + '-' + convert(varchar, DAY(@StartDate));
	DECLARE @EndDate2 date =  convert(varchar, YEAR(@EndDate)) + '-' + convert(varchar, MONTH(@EndDate)) + '-' + convert(varchar, DAY(@EndDate));

	--select @通貨ペアNo, @now, @back_Month, @ThisMonth, @StartDate, @EndDate, @StartDate2, @EndDate2;

	declare @cnt int;

	select @cnt = count(*)
	from [dbo].[T_RateHistory_Daily]
	where 通貨ペアNo = @通貨ペアNo and @StartDate2 <= [日時] and [日時] < @EndDate2

	if @cnt < 1
	begin
		return;
	end;

	select @cnt = count(*)
	from [dbo].[T_RateHistory_Monthly]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @ThisMonth

	if @cnt < 1
	begin
		Insert [dbo].[T_RateHistory_Monthly] ([通貨ペアNo], [日時]) Values (@通貨ペアNo, @ThisMonth);
	end;

	declare @買い_始値 float;
	declare @買い_高値 float;
	declare @買い_安値 float;
	declare @買い_終値 float;
	declare @売り_始値 float;
	declare @売り_高値 float;
	declare @売り_安値 float;
	declare @売り_終値 float;

	--select *
	--from [dbo].[T_RateHistory_Daily] as a
	--where 通貨ペアNo = @通貨ペアNo and @StartDate2 <= [日時] and [日時] < @EndDate2
	--order by [日時]

	select
		@買い_始値 = (
			select top 1 買い_始値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate2 <= [日時] and [日時] < @EndDate2
			order by [日時]
		),
		@買い_高値 = MAX(買い_高値),
		@買い_安値 = MIN(買い_安値),
		@買い_終値 = (
			select top 1 買い_終値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate2 <= [日時] and [日時] < @EndDate2
			order by [日時] desc
		),
		@売り_始値 = (
			select top 1 売り_始値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate2 <= [日時] and [日時] < @EndDate2
			order by [日時]
		),
		@売り_高値 = MAX(売り_高値),
		@売り_安値 = MIN(売り_安値),
		@売り_終値 = (
			select top 1 売り_終値 from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate2 <= [日時] and [日時] < @EndDate2
			order by [日時] desc
		)
	from [dbo].[T_RateHistory_Daily] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate2 <= [日時] and [日時] < @EndDate2
	group by 通貨ペアNo
	--order by 通貨ペア
	;

	Update [dbo].[T_RateHistory_Monthly]
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
	where 通貨ペアNo = @通貨ペアNo and 日時 = @ThisMonth

END

GO
