USE OANDA_DemoB
GO

/*
*/
DROP PROCEDURE [rate].[spInsertHistoryAll_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertHistoryAll_Min1]
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN
	/*
	DECLARE @StartDate	datetime = '2017/08/18 22:33:00';
	DECLARE @EndDate	datetime = '2017/08/18 22:34:00';
	*/

	declare @cnt int;

	--処理元データの有無確認
	Select @cnt = count(*)
	From [hstr].[tSec]
	Where @StartDate <= [StartDate] and [StartDate] < @EndDate;

	If @cnt < 1
	Begin
		return;
	End;

	--登録更新
	Select @cnt = count(*)
	From [hstr].[tMin1]
	Where [StartDate] = @StartDate;

	--select @cnt;

	If @cnt < 1
	Begin
		INSERT INTO [hstr].[tMin1] (
			[通貨ペアNo],
			[StartDate],
			[登録日時]
		)
		Select 
			通貨ペアNo as 通貨ペアNo,
			@StartDate,
			GETDATE()
		From hstr.tSec
		Where [StartDate] = (SELECT MIN([StartDate]) FROM [hstr].[tSec] where @StartDate <= [StartDate] and [StartDate] < @EndDate);
	End;

	With sec as (
		select
			t1.通貨ペアNo as 通貨ペアNo,
			t1.買いSwap as 買いSwap,
			t1.買いRate as 買いRate_始値,
			t1.売りSwap as 売りSwap,
			t1.売りRate as 売りRate_始値
		from [hstr].[tSec] as t1 join hstr.tMin1 as t2 on t1.通貨ペアNo = t2.通貨ペアNo
		where t1.StartDate = (SELECT MIN([StartDate]) FROM [hstr].[tSec] where @StartDate <= [StartDate] and [StartDate] < @EndDate)
    )
	Update hstr.tMin1
	Set
		買いSwap = sec.買いSwap,
		買いRate_始値 = sec.買いRate_始値,
		売りSwap = sec.売りSwap,
		売りRate_始値 = sec.売りRate_始値
	From sec
	where sec.通貨ペアNo = hstr.tMin1.通貨ペアNo and [hstr].[tMin1].StartDate = @StartDate;

	With sec as (
		Select
			t1.通貨ペアNo as 通貨ペアNo,
			MAX(買いRate) as 買いRate_高値,
			MIN(買いRate) as 買いRate_安値,
			MAX(売りRate) as 売りRate_高値,
			MIN(売りRate) as 売りRate_安値
		From [hstr].[tSec] as t1 join hstr.tMin1 as t2 on t1.通貨ペアNo = t2.通貨ペアNo
		Where @StartDate <= t1.[StartDate] and t1.[StartDate] < @EndDate
		Group by t1.通貨ペアNo
    )
	Update hstr.tMin1
	Set
		買いRate_高値 = sec.買いRate_高値,
		買いRate_安値 = sec.買いRate_安値,
		売りRate_高値 = sec.売りRate_高値,
		売りRate_安値 = sec.売りRate_安値
	From sec
	where sec.通貨ペアNo = hstr.tMin1.通貨ペアNo and [hstr].[tMin1].StartDate = @StartDate;

	With sec as (
		select
			t1.通貨ペアNo as 通貨ペアNo,
			t1.買いRate as 買いRate_終値,
			t1.売りRate as 売りRate_終値
		from [hstr].[tSec] as t1 join hstr.tMin1 as t2 on t1.通貨ペアNo = t2.通貨ペアNo
		where t1.StartDate = (SELECT MAX([StartDate]) FROM [hstr].[tSec] where @StartDate <= [StartDate] and [StartDate] < @EndDate)
    )
	Update hstr.tMin1
	Set
		買いRate_終値 = sec.買いRate_終値,
		売りRate_終値 = sec.売りRate_終値
	From sec
	where sec.通貨ペアNo = hstr.tMin1.通貨ペアNo and [hstr].[tMin1].StartDate = @StartDate;

END
GO
/*
*/

