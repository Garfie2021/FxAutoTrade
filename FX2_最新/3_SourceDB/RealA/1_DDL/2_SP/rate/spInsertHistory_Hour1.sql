USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [rate].[spInsertHistory_Hour1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertHistory_Hour1]
	@通貨ペアNo	tinyint = 34,
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN
	/*
	DECLARE @通貨ペアNo	tinyint = 34;
	DECLARE @StartDate	datetime = '2015-11-25 00:30:00.000';
	DECLARE @EndDate	datetime = '2015-11-25 00:45:00.000';
	*/

	--処理元データの有無確認
	declare @cnt int;
	select @cnt = count(*)
	from [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [StartDate] and [StartDate] < @EndDate

	if @cnt < 1
	begin
		return;
	end;


	--登録更新データ作成
	declare @買いSwap float;
	declare @買いRate_始値 float;
	declare @買いRate_高値 float;
	declare @買いRate_安値 float;
	declare @買いRate_終値 float;
	declare @売りSwap float;
	declare @売りRate_始値 float;
	declare @売りRate_高値 float;
	declare @売りRate_安値 float;
	declare @売りRate_終値 float;

	select top 1 @買いRate_始値 = 買いRate_始値, @売りRate_始値 = 売りRate_始値
	from [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
	order by [StartDate];

	select top 1 @買いSwap = 買いSwap, @買いRate_終値 = 買いRate_終値, @売りSwap = 売りSwap, @売りRate_終値 = 売りRate_終値
	from [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
	order by [StartDate] desc;

	select @買いRate_高値 = MAX(買いRate_高値), @買いRate_安値 = MIN(買いRate_安値), @売りRate_高値 = MAX(売りRate_高値), @売りRate_安値 = MIN(売りRate_安値)
	from [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [StartDate] and [StartDate] < @EndDate;

	--select @通貨ペアNo, @StartDate, @買いSwap, @買いRate_始値, @買いRate_高値, @買いRate_安値, @買いRate_終値,
	--	@売りSwap, @売りRate_始値, @売りRate_高値, @売りRate_安値, @売りRate_終値

	--登録更新
	select @cnt = count(*)
	from [hstr].[tHour1]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate;

	if @cnt < 1
	begin
		Insert [hstr].[tHour1] (
			[通貨ペアNo],
			[StartDate],
			[買いSwap],
			[買いRate_始値],
			[買いRate_高値],
			[買いRate_安値],
			[買いRate_終値],
			[売りSwap],
			[売りRate_始値],
			[売りRate_高値],
			[売りRate_安値],
			[売りRate_終値],
			[登録日時],
			[更新日時]
		) Values (
			@通貨ペアNo,
			@StartDate,
			@買いSwap,
			@買いRate_始値,
			@買いRate_高値,
			@買いRate_安値,
			@買いRate_終値,
			@売りSwap,
			@売りRate_始値,
			@売りRate_高値,
			@売りRate_安値,
			@売りRate_終値,
			GETDATE(),
			GETDATE()
		);
	end
	else
	begin
		Update [hstr].[tHour1]
		Set
			[買いSwap] = @買いSwap,
			[買いRate_始値] = @買いRate_始値,
			[買いRate_高値] = @買いRate_高値,
			[買いRate_安値] = @買いRate_安値,
			[買いRate_終値] = @買いRate_終値,
			[売りSwap] = @売りSwap,
			[売りRate_始値] = @売りRate_始値,
			[売りRate_高値] = @売りRate_高値,
			[売りRate_安値] = @売りRate_安値,
			[売りRate_終値] = @売りRate_終値,
			[更新日時] = GETDATE()
		where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate;
	end;

END
GO
/*
*/