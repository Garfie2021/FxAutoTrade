USE OANDA_RealA
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
	@�ʉ݃y�A�� tinyint,
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo	tinyint = 0;
	DECLARE @StartDate	datetime = '2015-12-17 22:40:00';
	DECLARE @EndDate	datetime = '2015-12-17 22:45:00';
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
		from [hstr].[tSec]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate

		if @cnt < 1
		begin
			continue;
		end;


		select top 1 @����Rate_�n�l = ����Rate, @����Rate_�n�l = ����Rate
		from [hstr].[tSec]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
		order by [StartDate];

		select top 1 @����Swap = ����Swap, @����Rate_�I�l = ����Rate, @����Swap = ����Swap, @����Rate_�I�l = ����Rate
		from [hstr].[tSec]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and  @StartDate <= [StartDate] and [StartDate] < @EndDate
		order by [StartDate] desc;

		select @����Rate_���l = MAX(����Rate), @����Rate_���l = MIN(����Rate), @����Rate_���l = MAX(����Rate), @����Rate_���l = MIN(����Rate)
		from [hstr].[tSec]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDate <= [StartDate] and [StartDate] < @EndDate;

		--�o�^�X�V
		select @cnt = count(*)
		from [hstr].[tMin1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

		if @cnt < 1
		begin
			Insert [hstr].[tMin1] (
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
			Update [hstr].[tMin1]
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
