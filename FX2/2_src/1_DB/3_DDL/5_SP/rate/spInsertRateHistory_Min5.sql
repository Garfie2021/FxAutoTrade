USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spInsertRateHistory_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertRateHistory_Min5]
	@通貨ペアNo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 0;
	DECLARE @now			datetime = '2014-06-17 16:41:30.447';
	DECLARE @back_6h		smallint = 0;		-- マイナス値にしか対応していない
	*/

	DECLARE @EndDate datetime = DATEADD(minute, 5, @StartDate);	

	--処理元データの有無確認
	declare @cnt int;
	select @cnt = count(*)
	from [rate].[tRateHistory_Min1]
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [StartDate] and [StartDate] < @EndDate

	if @cnt < 1
	begin
		return;
	end;


	--登録更新データ作成
	declare @買いRate_始値 float;
	declare @買いRate_高値 float;
	declare @買いRate_安値 float;
	declare @買いRate_終値 float;
	declare @売りRate_始値 float;
	declare @売りRate_高値 float;
	declare @売りRate_安値 float;
	declare @売りRate_終値 float;

	select
		@買いRate_始値 = (
			select top 1 買いRate_始値 from [rate].[tRateHistory_Min1]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate]
		),
		@買いRate_高値 = MAX(買いRate_高値),
		@買いRate_安値 = MIN(買いRate_安値),
		@買いRate_終値 = (
			select top 1 買いRate_終値 from [rate].[tRateHistory_Min1]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate] desc
		),
		@売りRate_始値 = (
			select top 1 売りRate_始値 from [rate].[tRateHistory_Min1]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate]
		),
		@売りRate_高値 = MAX(売りRate_高値),
		@売りRate_安値 = MIN(売りRate_安値),
		@売りRate_終値 = (
			select top 1 売りRate_終値 from [rate].[tRateHistory_Min1]
			where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate] desc
		)
	from [rate].[tRateHistory_Min1] as a
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [StartDate] and [StartDate] < @EndDate
	group by 通貨ペアNo
	--order by 通貨ペア
	;


	--登録更新
	select @cnt = count(*)
	from [rate].[tRateHistory_Min5]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate

	if @cnt < 1
	begin
		Insert [rate].[tRateHistory_Min5] (
			[通貨ペアNo],
			[StartDate],
			[買いRate_始値],
			[買いRate_高値],
			[買いRate_安値],
			[買いRate_終値],
			[売りRate_始値],
			[売りRate_高値],
			[売りRate_安値],
			[売りRate_終値],
			[更新日時]
		) Values (
			@通貨ペアNo,
			@StartDate,
			@買いRate_始値,
			@買いRate_高値,
			@買いRate_安値,
			@買いRate_終値,
			@売りRate_始値,
			@売りRate_高値,
			@売りRate_安値,
			@売りRate_終値,
			GETDATE()
		);
	end
	else
	begin
		Update [rate].[tRateHistory_Min5]
		Set
			[買いRate_始値] = @買いRate_始値,
			[買いRate_高値] = @買いRate_高値,
			[買いRate_安値] = @買いRate_安値,
			[買いRate_終値] = @買いRate_終値,
			[売りRate_始値] = @売りRate_始値,
			[売りRate_高値] = @売りRate_高値,
			[売りRate_安値] = @売りRate_安値,
			[売りRate_終値] = @売りRate_終値,
			[更新日時] = GETDATE()
		where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate
	end;

END
GO
