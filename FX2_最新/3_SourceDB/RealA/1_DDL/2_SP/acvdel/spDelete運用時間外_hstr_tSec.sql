USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete�^�p���ԊORate_hstr]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
*/
CREATE PROCEDURE [acvdel].[spDelete�^�p���ԊORate_hstr]
AS
BEGIN

	SET NOCOUNT ON;

	declare @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	WHILE @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
	begin
		-- �y�j����6:00:00�ȍ~��Rate�͕ω����Ȃ��̂ō폜�B�c���Ă���ƃV�O�}�v�Z�ɉe�����o��B

		/*
		select [StartDate], ����Rate, ����rate
		FROM [hstr].[tSec]
		where [�ʉ݃y�ANo] = 34
		order by [StartDate] desc;

		select [StartDate], DATENAME(WEEKDAY, [StartDate]), DATEPART(WEEKDAY, [StartDate]), DATEPART (hour, [StartDate])
		FROM [hstr].[tSec]
		where [�ʉ݃y�ANo] = 34 and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6
		order by [StartDate] ;
		*/

		DELETE FROM [hstr].[tSec]
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMin1
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMin5
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMin15
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tHour1
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tDay1
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tWeek1
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		DELETE FROM [hstr].tMonth1
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and DATEPART(WEEKDAY, [StartDate]) = 7 and  DATEPART (hour, [StartDate]) >= 6;

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END
GO
/*
*/
