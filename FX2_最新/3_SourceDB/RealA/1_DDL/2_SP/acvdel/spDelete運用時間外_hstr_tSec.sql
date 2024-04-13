USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete運用時間外Rate_hstr]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
*/
CREATE PROCEDURE [acvdel].[spDelete運用時間外Rate_hstr]
AS
BEGIN

	SET NOCOUNT ON;

	declare @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	WHILE @通貨ペアNo <= @通貨ペアNoMax
	begin
		-- 土曜日の6:00:00以降のRateは変化しないので削除。残っているとシグマ計算に影響が出る。

		/*
		select [StartDate], 買いRate, 売りrate
		FROM [hstr].[tSec]
		where [通貨ペアNo] = 34
		order by [StartDate] desc;

		select [StartDate], DATENAME(WEEKDAY, [StartDate]), DATEPART(WEEKDAY, [StartDate]), DATEPART (hour, [StartDate])
		FROM [hstr].[tSec]
		where [通貨ペアNo] = 34 and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6
		order by [StartDate] ;
		*/

		DELETE FROM [hstr].[tSec]
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMin1
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMin5
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMin15
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tHour1
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tDay1
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tWeek1
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMonth1
		where [通貨ペアNo] = @通貨ペアNo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO
/*
*/
