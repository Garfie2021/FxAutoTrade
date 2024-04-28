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
	@�ʉ݃y�ANo	tinyint = 34,
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo	tinyint = 34;
	DECLARE @StartDate	datetime = '2015-11-25 00:30:00.000';
	DECLARE @EndDate	datetime = '2015-11-25 00:45:00.000';
	*/

	--�������f�[�^�̗L���m�F
	declare @cnt int;
	select @cnt = count(*)
	from [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate

	if @cnt < 1
	begin
		return;
	end;


	--�o�^�X�V�f�[�^�쐬
	declare @����Swap float;
	declare @����Rate_�n�l float;
	declare @����Rate_���l float;
	declare @����Rate_���l float;
	declare @����Rate_�I�l float;
	declare @����Swap float;
	declare @����Rate_�n�l float;
	declare @����Rate_���l float;
	declare @����Rate_���l float;
	declare @����Rate_�I�l float;

	select top 1 @����Rate_�n�l = ����Rate_�n�l, @����Rate_�n�l = ����Rate_�n�l
	from [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
	order by [StartDate];

	select top 1 @����Swap = ����Swap, @����Rate_�I�l = ����Rate_�I�l, @����Swap = ����Swap, @����Rate_�I�l = ����Rate_�I�l
	from [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
	order by [StartDate] desc;

	select @����Rate_���l = MAX(����Rate_���l), @����Rate_���l = MIN(����Rate_���l), @����Rate_���l = MAX(����Rate_���l), @����Rate_���l = MIN(����Rate_���l)
	from [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate;

	--select @�ʉ݃y�ANo, @StartDate, @����Swap, @����Rate_�n�l, @����Rate_���l, @����Rate_���l, @����Rate_�I�l,
	--	@����Swap, @����Rate_�n�l, @����Rate_���l, @����Rate_���l, @����Rate_�I�l

	--�o�^�X�V
	select @cnt = count(*)
	from [hstr].[tHour1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

	if @cnt < 1
	begin
		Insert [hstr].[tHour1] (
			[�ʉ݃y�ANo],
			[StartDate],
			[����Swap],
			[����Rate_�n�l],
			[����Rate_���l],
			[����Rate_���l],
			[����Rate_�I�l],
			[����Swap],
			[����Rate_�n�l],
			[����Rate_���l],
			[����Rate_���l],
			[����Rate_�I�l],
			[�o�^����],
			[�X�V����]
		) Values (
			@�ʉ݃y�ANo,
			@StartDate,
			@����Swap,
			@����Rate_�n�l,
			@����Rate_���l,
			@����Rate_���l,
			@����Rate_�I�l,
			@����Swap,
			@����Rate_�n�l,
			@����Rate_���l,
			@����Rate_���l,
			@����Rate_�I�l,
			GETDATE(),
			GETDATE()
		);
	end
	else
	begin
		Update [hstr].[tHour1]
		Set
			[����Swap] = @����Swap,
			[����Rate_�n�l] = @����Rate_�n�l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_�I�l] = @����Rate_�I�l,
			[����Swap] = @����Swap,
			[����Rate_�n�l] = @����Rate_�n�l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_�I�l] = @����Rate_�I�l,
			[�X�V����] = GETDATE()
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;
	end;

END
GO
/*
*/