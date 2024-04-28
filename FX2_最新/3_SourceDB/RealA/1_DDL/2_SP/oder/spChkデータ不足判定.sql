USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oder].[spChk�f�[�^�s������]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk�f�[�^�s������]
	@�ʉ݃y�ANo			tinyint,
	@DiffWeek_Min15		int		output,
	@DiffWeek_Week1		int		output,
	@DiffMonth_Month1	int		output
AS
BEGIN

	/*
	declare @�ʉ݃y�ANo			tinyint = 37;
	declare @DiffMonth_Min15	int;
	declare @DiffMonth_Week1	int;
	declare @DiffMonth_Month1	int;
	*/
	
	--SELECT MIN([StartDate]), MAX([StartDate]), DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate]))
	SELECT @DiffWeek_Min15 = DATEDIFF(WEEK, MIN([StartDate]), MAX([StartDate]))
	FROM [hstr].[tMin15]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT MIN([StartDate]), MAX([StartDate]), DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate])), DATEDIFF(WEEK, MIN([StartDate]), MAX([StartDate]))
	SELECT @DiffWeek_Week1 = DATEDIFF(WEEK, MIN([StartDate]), MAX([StartDate]))
	FROM [hstr].[tWeek1]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	--SELECT MIN([StartDate]), MAX([StartDate]), DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate]))
	SELECT @DiffMonth_Month1 = DATEDIFF(MONTH, MIN([StartDate]), MAX([StartDate]))
	FROM [hstr].[tMonth1]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	select @DiffWeek_Min15, @DiffWeek_Week1, @DiffMonth_Month1;

END
GO
/*
*/

