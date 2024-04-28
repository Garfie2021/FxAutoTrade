USE [FX2_Demo]
GO

/*
*/
DROP PROCEDURE [rate].[spInsertRateHistory_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertRateHistory_Min1]
	@�ʉ݃y�ANo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 0;
	DECLARE @now			datetime = '2014-06-17 16:41:30.447';
	DECLARE @back_1m		smallint = -10;		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	*/

	DECLARE @EndDate datetime = DATEADD(minute, 1, @StartDate);	

	--�������f�[�^�̗L���m�F
	declare @cnt int;
	select @cnt = count(*)
	from [rate].[tRateHistory]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate

	if @cnt < 1
	begin
		return;
	end;


	--�o�^�X�V�f�[�^�쐬
	declare @����Rate_�n�l float;
	declare @����Rate_���l float;
	declare @����Rate_���l float;
	declare @����Rate_�I�l float;
	declare @����Rate_�n�l float;
	declare @����Rate_���l float;
	declare @����Rate_���l float;
	declare @����Rate_�I�l float;

	select
		@����Rate_�n�l = (
			select top 1 ����Rate from [rate].[tRateHistory]
			where �ʉ݃y�ANo = a.�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate]
		),
		@����Rate_���l = MAX(����Rate),
		@����Rate_���l = MIN(����Rate),
		@����Rate_�I�l = (
			select top 1 ����Rate from [rate].[tRateHistory]
			where �ʉ݃y�ANo = a.�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate] desc
		),
		@����Rate_�n�l = (
			select top 1 ����Rate from [rate].[tRateHistory]
			where �ʉ݃y�ANo = a.�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate]
		),
		@����Rate_���l = MAX(����Rate),
		@����Rate_���l = MIN(����Rate),
		@����Rate_�I�l = (
			select top 1 ����Rate from [rate].[tRateHistory]
			where �ʉ݃y�ANo = a.�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
			order by [StartDate] desc
		)
	from [rate].[tRateHistory] as a
	where @StartDate <= [StartDate] and [StartDate] < @EndDate
		and a.�ʉ݃y�ANo = @�ʉ݃y�ANo
	group by �ʉ݃y�ANo
	--order by �ʉ݃y�A
	;


	--�o�^�X�V
	select @cnt = count(*)
	from [rate].[tRateHistory_Min1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate

	if @cnt < 1
	begin
		Insert [rate].[tRateHistory_Min1] (
			[�ʉ݃y�ANo],
			[StartDate],
			[����Rate_�n�l],
			[����Rate_���l],
			[����Rate_���l],
			[����Rate_�I�l],
			[����Rate_�n�l],
			[����Rate_���l],
			[����Rate_���l],
			[����Rate_�I�l],
			[�X�V����]
		) Values (
			@�ʉ݃y�ANo,
			@StartDate,
			@����Rate_�n�l,
			@����Rate_���l,
			@����Rate_���l,
			@����Rate_�I�l,
			@����Rate_�n�l,
			@����Rate_���l,
			@����Rate_���l,
			@����Rate_�I�l,
			GETDATE()
		);
	end
	else
	begin
		Update [rate].[tRateHistory_Min1]
		Set
			[����Rate_�n�l] = @����Rate_�n�l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_�I�l] = @����Rate_�I�l,
			[����Rate_�n�l] = @����Rate_�n�l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_���l] = @����Rate_���l,
			[����Rate_�I�l] = @����Rate_�I�l,
			[�X�V����] = GETDATE()
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate
	end;
END
GO
/*
*/
