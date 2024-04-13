USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oder].[spChkデータ不足判定]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChkデータ不足判定]
	@通貨ペアNo			tinyint,
	@DiffWeek_Min15		int		output,
	@DiffWeek_Week1		int		output,
	@DiffMonth_Month1	int		output
AS
BEGIN

	/*
	declare @通貨ペアNo			tinyint = 37;
	declare @DiffMonth_Min15	int;
	declare @DiffMonth_Week1	int;
	declare @DiffMonth_Month1	int;
	*/
	
	--SELECT MIN([StartDate]), MAX([StartDate]), DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate]))
	SELECT @DiffWeek_Min15 = DATEDIFF(WEEK, MIN([StartDate]), MAX([StartDate]))
	FROM [hstr].[tMin15]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT MIN([StartDate]), MAX([StartDate]), DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate])), DATEDIFF(WEEK, MIN([StartDate]), MAX([StartDate]))
	SELECT @DiffWeek_Week1 = DATEDIFF(WEEK, MIN([StartDate]), MAX([StartDate]))
	FROM [hstr].[tWeek1]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	--SELECT MIN([StartDate]), MAX([StartDate]), DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate]))
	SELECT @DiffMonth_Month1 = DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate]))
	FROM [hstr].[tMonth1]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	select @DiffWeek_Min15, @DiffWeek_Week1, @DiffMonth_Month1;

END
GO
/*
*/

