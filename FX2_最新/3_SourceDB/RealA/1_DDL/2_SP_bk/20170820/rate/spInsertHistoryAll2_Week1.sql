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

	--�������f�[�^�̗L���m�F
	Select @cnt = count(*)
	From hstr.tDay1
	Where @StartDate <= [StartDate] and [StartDate] < @EndDate

	If @cnt < 1
	Begin
		return;
	End;

	--�o�^�X�V
	Select @cnt = count(*)
	From [hstr].[tWeek1]
	Where [StartDate] = @StartDate;

	If @cnt < 1
	Begin
		INSERT INTO [hstr].[tWeek1] (
			[�ʉ݃y�ANo],
			[StartDate],
			[�o�^����]
		)
		Select 
			�ʉ݃y�ANo as �ʉ݃y�ANo,
			@StartDate,
			GETDATE()
		From hstr.[tDay1]
		Where [StartDate] = (SELECT MIN([StartDate]) FROM [hstr].[tDay1] where @StartDate <= [StartDate] and [StartDate] < @EndDate);
	End;

	With min1 as (
		select
			t1.�ʉ݃y�ANo as �ʉ݃y�ANo,
			t1.����Swap as ����Swap,
			t1.����Rate_�n�l as ����Rate_�n�l,
			t1.����Swap as ����Swap,
			t1.����Rate_�n�l as ����Rate_�n�l
		from [hstr].[tDay1] as t1 join hstr.tWeek1 as t2 on t1.�ʉ݃y�ANo = t2.�ʉ݃y�ANo
		where t1.StartDate = (SELECT MIN([StartDate]) FROM [hstr].[tDay1] where @StartDate <= [StartDate] and [StartDate] < @EndDate)
    )
	Update hstr.tWeek1
	Set
		����Swap = min1.����Swap,
		����Rate_�n�l = min1.����Rate_�n�l,
		����Swap = min1.����Swap,
		����Rate_�n�l = min1.����Rate_�n�l
	From min1
	where min1.�ʉ݃y�ANo = hstr.tWeek1.�ʉ݃y�ANo and [hstr].tWeek1.StartDate = @StartDate;

	With min1 as (
		Select
			t1.�ʉ݃y�ANo as �ʉ݃y�ANo,
			MAX(t1.����Rate_���l) as ����Rate_���l,
			MIN(t1.����Rate_���l) as ����Rate_���l,
			MAX(t1.����Rate_���l) as ����Rate_���l,
			MIN(t1.����Rate_���l) as ����Rate_���l
		From [hstr].[tDay1] as t1 join hstr.tWeek1 as t2 on t1.�ʉ݃y�ANo = t2.�ʉ݃y�ANo
		Where @StartDate <= t1.[StartDate] and t1.[StartDate] < @EndDate
		Group by t1.�ʉ݃y�ANo
    )
	Update hstr.tWeek1
	Set
		����Rate_���l = min1.����Rate_���l,
		����Rate_���l = min1.����Rate_���l,
		����Rate_���l = min1.����Rate_���l,
		����Rate_���l = min1.����Rate_���l
	From min1
	where min1.�ʉ݃y�ANo = hstr.tWeek1.�ʉ݃y�ANo and [hstr].tWeek1.StartDate = @StartDate;

	With min1 as (
		select
			t1.�ʉ݃y�ANo as �ʉ݃y�ANo,
			t1.����Rate_�I�l as ����Rate_�I�l,
			t1.����Rate_�I�l as ����Rate_�I�l
		from [hstr].tDay1 as t1 join hstr.tWeek1 as t2 on t1.�ʉ݃y�ANo = t2.�ʉ݃y�ANo
		where t1.StartDate = (SELECT MAX([StartDate]) FROM [hstr].tDay1 where @StartDate <= [StartDate] and [StartDate] < @EndDate)
	)
	Update hstr.tWeek1
	Set
		����Rate_�I�l = min1.����Rate_�I�l,
		����Rate_�I�l = min1.����Rate_�I�l
	From min1
	where min1.�ʉ݃y�ANo = hstr.tWeek1.�ʉ݃y�ANo and hstr.tWeek1.StartDate = @StartDate;

END
GO
/*
*/
