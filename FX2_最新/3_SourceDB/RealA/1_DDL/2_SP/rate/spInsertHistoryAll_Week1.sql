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
	@�ʉ݃y�A�� tinyint,
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN
	/*
	DECLARE @now		Datetime = '2016-01-27 00:30:00.000';
	DECLARE @ThisWeek1	datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;
	EXECUTE [cmn].[spGetThisWeek1] @now, 0, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;
	DECLARE @�ʉ݃y�ANo	tinyint = 34;
	select @StartDate, @EndDate;
	*/

	declare @cnt int;



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

	DECLARE @�ʉ݃y�ANo	tinyint = 0;
	WHILE @�ʉ݃y�ANo < @�ʉ݃y�A��
	BEGIN

		--�������f�[�^�̗L���m�F
		select @cnt = count(*)
		from [hstr].[tDay1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate

		if @cnt < 1
		begin
			return;
		end;

		select top 1 @����Rate_�n�l = ����Rate_�n�l, @����Rate_�n�l = ����Rate_�n�l
		from [hstr].[tDay1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
		order by [StartDate];

		select top 1 @����Swap = ����Swap, @����Rate_�I�l = ����Rate_�I�l, @����Swap = ����Swap, @����Rate_�I�l = ����Rate_�I�l
		from [hstr].[tDay1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
		order by [StartDate] desc;

		select @����Rate_���l = MAX(����Rate_���l), @����Rate_���l = MIN(����Rate_���l), @����Rate_���l = MAX(����Rate_���l), @����Rate_���l = MIN(����Rate_���l)
		from [hstr].[tDay1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate;

		--select @�ʉ݃y�ANo, @StartDate, @����Swap, @����Rate_�n�l, @����Rate_���l, @����Rate_���l, @����Rate_�I�l,
		--	@����Swap, @����Rate_�n�l, @����Rate_���l, @����Rate_���l, @����Rate_�I�l

		--�o�^�X�V
		select @cnt = count(*)
		from [hstr].[tWeek1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

		if @cnt < 1
		begin
			Insert [hstr].[tWeek1] (
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
			Update [hstr].[tWeek1]
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

	end;

END
GO
/*
*/