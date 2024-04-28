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

	--�������f�[�^�̗L���m�F
	Select @cnt = count(*)
	From [hstr].[tSec]
	Where @StartDate <= [StartDate] and [StartDate] < @EndDate;

	If @cnt < 1
	Begin
		return;
	End;

	--�o�^�X�V
	Select @cnt = count(*)
	From [hstr].[tMin1]
	Where [StartDate] = @StartDate;

	--select @cnt;

	If @cnt < 1
	Begin
		INSERT INTO [hstr].[tMin1] (
			[�ʉ݃y�ANo],
			[StartDate],
			[�o�^����]
		)
		Select 
			�ʉ݃y�ANo as �ʉ݃y�ANo,
			@StartDate,
			GETDATE()
		From hstr.tSec
		Where [StartDate] = (SELECT MIN([StartDate]) FROM [hstr].[tSec] where @StartDate <= [StartDate] and [StartDate] < @EndDate);
	End;

	With sec as (
		select
			t1.�ʉ݃y�ANo as �ʉ݃y�ANo,
			t1.����Swap as ����Swap,
			t1.����Rate as ����Rate_�n�l,
			t1.����Swap as ����Swap,
			t1.����Rate as ����Rate_�n�l
		from [hstr].[tSec] as t1 join hstr.tMin1 as t2 on t1.�ʉ݃y�ANo = t2.�ʉ݃y�ANo
		where t1.StartDate = (SELECT MIN([StartDate]) FROM [hstr].[tSec] where @StartDate <= [StartDate] and [StartDate] < @EndDate)
    )
	Update hstr.tMin1
	Set
		����Swap = sec.����Swap,
		����Rate_�n�l = sec.����Rate_�n�l,
		����Swap = sec.����Swap,
		����Rate_�n�l = sec.����Rate_�n�l
	From sec
	where sec.�ʉ݃y�ANo = hstr.tMin1.�ʉ݃y�ANo and [hstr].[tMin1].StartDate = @StartDate;

	With sec as (
		Select
			t1.�ʉ݃y�ANo as �ʉ݃y�ANo,
			MAX(����Rate) as ����Rate_���l,
			MIN(����Rate) as ����Rate_���l,
			MAX(����Rate) as ����Rate_���l,
			MIN(����Rate) as ����Rate_���l
		From [hstr].[tSec] as t1 join hstr.tMin1 as t2 on t1.�ʉ݃y�ANo = t2.�ʉ݃y�ANo
		Where @StartDate <= t1.[StartDate] and t1.[StartDate] < @EndDate
		Group by t1.�ʉ݃y�ANo
    )
	Update hstr.tMin1
	Set
		����Rate_���l = sec.����Rate_���l,
		����Rate_���l = sec.����Rate_���l,
		����Rate_���l = sec.����Rate_���l,
		����Rate_���l = sec.����Rate_���l
	From sec
	where sec.�ʉ݃y�ANo = hstr.tMin1.�ʉ݃y�ANo and [hstr].[tMin1].StartDate = @StartDate;

	With sec as (
		select
			t1.�ʉ݃y�ANo as �ʉ݃y�ANo,
			t1.����Rate as ����Rate_�I�l,
			t1.����Rate as ����Rate_�I�l
		from [hstr].[tSec] as t1 join hstr.tMin1 as t2 on t1.�ʉ݃y�ANo = t2.�ʉ݃y�ANo
		where t1.StartDate = (SELECT MAX([StartDate]) FROM [hstr].[tSec] where @StartDate <= [StartDate] and [StartDate] < @EndDate)
    )
	Update hstr.tMin1
	Set
		����Rate_�I�l = sec.����Rate_�I�l,
		����Rate_�I�l = sec.����Rate_�I�l
	From sec
	where sec.�ʉ݃y�ANo = hstr.tMin1.�ʉ݃y�ANo and [hstr].[tMin1].StartDate = @StartDate;

END
GO
/*
*/

