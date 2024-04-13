USE OANDA_DemoB
GO

/*
*/
DROP PROCEDURE [rate].[spInsertHistoryAll_Week1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertHistoryAll_Week1]
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN
	/*
	DECLARE @StartDate	datetime = '2017/08/14 6:00:00';
	DECLARE @EndDate	datetime = '2017/08/21 6:00:00';
	*/

	declare @cnt int;

	--処理元データの有無確認
	Select @cnt = count(*)
	From hstr.tDay1
	Where @StartDate <= [StartDate] and [StartDate] < @EndDate

	If @cnt < 1
	Begin
		return;
	End;

	--登録更新
	Select @cnt = count(*)
	From [hstr].[tWeek1]
	Where [StartDate] = @StartDate;

	If @cnt < 1
	Begin
		INSERT INTO [hstr].[tWeek1] (
			[通貨ペアNo],
			[StartDate],
			[登録日時]
		)
		Select 
			通貨ペアNo as 通貨ペアNo,
			@StartDate,
			GETDATE()
		From hstr.[tDay1]
		Where [StartDate] = (SELECT MIN([StartDate]) FROM [hstr].[tDay1] where @StartDate <= [StartDate] and [StartDate] < @EndDate);
	End;

	With min1 as (
		select
			t1.通貨ペアNo as 通貨ペアNo,
			t1.買いSwap as 買いSwap,
			t1.買いRate_始値 as 買いRate_始値,
			t1.売りSwap as 売りSwap,
			t1.売りRate_始値 as 売りRate_始値
		from [hstr].[tDay1] as t1 join hstr.tWeek1 as t2 on t1.通貨ペアNo = t2.通貨ペアNo
		where t1.StartDate = (SELECT MIN([StartDate]) FROM [hstr].[tDay1] where @StartDate <= [StartDate] and [StartDate] < @EndDate)
    )
	Update hstr.tWeek1
	Set
		買いSwap = min1.買いSwap,
		買いRate_始値 = min1.買いRate_始値,
		売りSwap = min1.売りSwap,
		売りRate_始値 = min1.売りRate_始値
	From min1
	where min1.通貨ペアNo = hstr.tWeek1.通貨ペアNo and [hstr].tWeek1.StartDate = @StartDate;

	With min1 as (
		Select
			t1.通貨ペアNo as 通貨ペアNo,
			MAX(t1.買いRate_高値) as 買いRate_高値,
			MIN(t1.買いRate_安値) as 買いRate_安値,
			MAX(t1.売りRate_高値) as 売りRate_高値,
			MIN(t1.売りRate_安値) as 売りRate_安値
		From [hstr].[tDay1] as t1 join hstr.tWeek1 as t2 on t1.通貨ペアNo = t2.通貨ペアNo
		Where @StartDate <= t1.[StartDate] and t1.[StartDate] < @EndDate
		Group by t1.通貨ペアNo
    )
	Update hstr.tWeek1
	Set
		買いRate_高値 = min1.買いRate_高値,
		買いRate_安値 = min1.買いRate_安値,
		売りRate_高値 = min1.売りRate_高値,
		売りRate_安値 = min1.売りRate_安値
	From min1
	where min1.通貨ペアNo = hstr.tWeek1.通貨ペアNo and [hstr].tWeek1.StartDate = @StartDate;

	With min1 as (
		select
			t1.通貨ペアNo as 通貨ペアNo,
			t1.買いRate_終値 as 買いRate_終値,
			t1.売りRate_終値 as 売りRate_終値
		from [hstr].tDay1 as t1 join hstr.tWeek1 as t2 on t1.通貨ペアNo = t2.通貨ペアNo
		where t1.StartDate = (SELECT MAX([StartDate]) FROM [hstr].tDay1 where @StartDate <= [StartDate] and [StartDate] < @EndDate)
	)
	Update hstr.tWeek1
	Set
		買いRate_終値 = min1.買いRate_終値,
		売りRate_終値 = min1.売りRate_終値
	From min1
	where min1.通貨ペアNo = hstr.tWeek1.通貨ペアNo and hstr.tWeek1.StartDate = @StartDate;

END
GO
/*
*/
