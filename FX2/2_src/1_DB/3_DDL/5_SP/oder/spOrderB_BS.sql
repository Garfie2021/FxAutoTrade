USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spOrderB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderB]
	@�ʉ݃y�ANo				tinyint,
	@StartDate				datetime,
	@����Rate				float,
	@����Rate				float,
	@�����P��				float,
	@OrderV1_�]����̊���	float,
	@��������				tinyint output
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 21
	DECLARE @StartDate		datetime = getdate()
	DECLARE @�V�O�}臒l		float = 2.5
	DECLARE @WMA����		varchar(5)
	DECLARE @BonusStage����	varchar(5)
	DECLARE @WMA�O_S2		float = 2.5
	DECLARE @WMA��_S2		float = 2.5
	*/

	/*** Rate�L�^ START ***/

	EXECUTE [rate].[spInsertRateHistory] @�ʉ݃y�ANo ,@StartDate ,@����Rate ,@����Rate


	/*** ��{Rate�L�^ START ***/

	EXECUTE [rate].[spInsertRateHistory_Min1] @�ʉ݃y�ANo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Min5] @�ʉ݃y�ANo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Min15] @�ʉ݃y�ANo ,@StartDate ,0;
	--30���ȏ��Rate�v�Z��Job������s�i�ꕪ�����j�ōs��


	/*** �v�Z START ***/

	DECLARE @�v�Z�Ώ� tinyint
	EXECUTE [oder].[spChk�v�Z�Ώ�] @�ʉ݃y�ANo ,@�v�Z�Ώ� OUTPUT;
	if @�v�Z�Ώ� = 0
	begin
		return;
	end

	EXECUTE [rate].[spUpdateWMA_Min15] @�ʉ݃y�ANo ,@StartDate;


	/*** �������� START ***/

	--�p�x���㏸���Ă��ăV�O�}���}�C�i�X�̏ꍇ�A�p�x�����~���Ă��ăV�O�}���v���X�̏ꍇ�́A���炩�ɒ����ΏۊO�B

	DECLARE @�����Ώ� tinyint
	EXECUTE [oder].[spChk�����Ώ�] @�ʉ݃y�ANo ,@�����Ώ� OUTPUT;
	if @�����Ώ� = 0
	begin
		return;
	end

	-- �O��̔��茋�ʂ��N���A
	UPDATE [oder].[tOrderSettings]
	SET
      ,[Swap����] = 0
      ,[WMA����_Monthly] = 0
      ,[WMA����_Monthly_S2_GC] = 0
      ,[WMA�p�x����_Monthly] = 0
      ,[�댯Rate����_Monthly] = 0
      ,[�댯Rate����_Weekly] = 0
      ,[�댯Rate����_Daily] = 0
      ,[SMLT_�V�O�}臒l] = 0
      ,[BonusStage����_�O] = 0
      ,[BonusStage����_��] = 0
      ,[��������] = 0
      ,[Rate�I�l_1�O_��] = 0
      ,[Rate�I�l_1�O_�T] = 0
      ,[Rate�I�l_1�O_��] = 0
      ,[Rate�I�l_1�O_6h] = 0
      ,[Rate�I�l_1�O_1h] = 0
      ,[Rate�I�l_1�O_30m] = 0
      ,[Rate�I�l_1�O_Min15] = 0
      ,[Rate�I�l_1�O_5m] = 0
      ,[Rate�I�l_1�O_1m] = 0
      ,[WMA��_Monthly] = 0
      ,[WMA_Monthly] = 0
      ,[WMA�p�x�O_Monthly] = 0
      ,[WMA�p�x��_Monthly] = 0
      ,[WMA�O_Monthly_S2] = 0
      ,[WMA��_Monthly_S2] = 0
      ,[WMA�O_Weekly_S2] = 0
      ,[WMA��_Weekly_S2] = 0
      ,[WMA�O_Daily_S2] = 0
      ,[WMA��_Daily_S2] = 0
      ,[WMA�O_6h_S2] = 0
      ,[WMA��_6h_S2] = 0
      ,[WMA�O_1h_S2] = 0
      ,[WMA��_1h_S2] = 0
      ,[WMA�O_30m_S2] = 0
      ,[WMA��_30m_S2] = 0
      ,[WMA�O_Min15_S2] = 0
      ,[WMA��_Min15_S2] = 0
      ,[WMA�O_5m_S2] = 0
      ,[WMA��_5m_S2] = 0
      ,[WMA�O_1m_S2] = 0
      ,[WMA��_1m_S2] = 0
      ,[Rate���l_�挎] = 0
      ,[Rate���l_�挎] = 0
      ,[Rate���l_��T] = 0
      ,[Rate���l_��T] = 0
      ,[Rate���l_���] = 0
      ,[Rate���l_���] = 0
      ,[Rate���l_30m�O] = 0
      ,[Rate���l_30m�O] = 0
      ,[Rate���l_Min15�O] = 0
      ,[Rate���l_Min15�O] = 0
      ,[Rate���l_5m�O] = 0
      ,[Rate���l_5m�O] = 0
      ,[SMLT_����1�����̗��vSum] = 0
      ,[���l���l_Monthly] = 0
      ,[���l���l_Weekly] = 0
      ,[���l���l_Daily] = 0
      ,[WMA�O_Min15] = 0
      ,[WMA��_Min15] = 0
      ,[WMA�㏸�p�x_��_Min15] = 0
      ,[WMA����_Min15] = 0
      ,[�����] = 0
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	@OrderV1_�]����̊���

	if @����Rate = 0 or @����Rate = 0
	begin
		EXECUTE [oder].[spUpdateOrderSettings_�����] @�ʉ݃y�ANo ,'Order�ΏۊO�iRate��0�j';
		return;
	end



	-- ���߂̎w�W���擾

	DECLARE @��_����WMA float;
	DECLARE @��_����WMA float;
	DECLARE @��_����WMA�㏸�p�x float;
	DECLARE @��_����WMA�㏸�p�x float;
	DECLARE @��_����WMA�㏸�p�x_�V�O�} float;
	DECLARE @��_����WMA�㏸�p�x_�V�O�} float;
	DECLARE @1�O_����WMA float;
	DECLARE @1�O_����WMA float;
	DECLARE @1�O_����WMA�㏸�p�x float;
	DECLARE @1�O_����WMA�㏸�p�x float;
	DECLARE @1�O_����WMA�㏸�p�x_�V�O�} float;
	DECLARE @1�O_����WMA�㏸�p�x_�V�O�} float;

	DECLARE cursor_tIndicatorHistory_Min15 CURSOR FOR
	SELECT TOP 2 [����WMA], [����WMA], [����WMA�㏸�p�x], [����WMA�㏸�p�x], [����WMA�㏸�p�x_�V�O�}], [����WMA�㏸�p�x_�V�O�}]
	FROM [indi].[tIndicatorHistory_Min15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate
	order by [StartDate] desc

	open cursor_tIndicatorHistory_Min15;
	
	FETCH NEXT FROM cursor_tIndicatorHistory_Min15 INTO @��_����WMA, @��_����WMA, @��_����WMA�㏸�p�x, 
		@��_����WMA�㏸�p�x, @��_����WMA�㏸�p�x_�V�O�}, @��_����WMA�㏸�p�x_�V�O�};

	FETCH NEXT FROM cursor_tIndicatorHistory_Min15 INTO @1�O_����WMA, @1�O_����WMA, @1�O_����WMA�㏸�p�x, 
		@1�O_����WMA�㏸�p�x, @1�O_����WMA�㏸�p�x_�V�O�}, @1�O_����WMA�㏸�p�x_�V�O�};

	CLOSE cursor_tIndicatorHistory_Min15;
	DEALLOCATE cursor_tIndicatorHistory_Min15;


	-- ���߂�Rate���擾

	DECLARE @1�O_����_�n�l float;
	DECLARE @1�O_����_���l float;
	DECLARE @1�O_����_���l float;
	DECLARE @1�O_����_�I�l float;
	DECLARE @1�O_����_�n�l float;
	DECLARE @1�O_����_���l float;
	DECLARE @1�O_����_���l float;
	DECLARE @1�O_����_�I�l float;
	DECLARE @��_����_�n�l float;
	DECLARE @��_����_���l float;
	DECLARE @��_����_���l float;
	DECLARE @��_����_�I�l float;
	DECLARE @��_����_�n�l float;
	DECLARE @��_����_���l float;
	DECLARE @��_����_���l float;
	DECLARE @��_����_�I�l float;

	DECLARE cursor_tRateHistory_Min15 CURSOR FOR
	SELECT TOP 3 [����_�n�l], [����_���l], [����_���l], [����_�I�l], [����_�n�l], [����_���l], [����_���l], [����_�I�l]
	FROM [dbo].[tRateHistory_Min15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate
	order by [StartDate] desc

	open cursor_tRateHistory_Min15;
	
	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @��_����_�n�l, @��_����_���l, @��_����_���l, @��_����_�I�l, @��_����_�n�l, @��_����_���l, @��_����_���l, @��_����_�I�l;
	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @1�O_����_�n�l, @1�O_����_���l, @1�O_����_���l, @1�O_����_�I�l, @1�O_����_�n�l, @1�O_����_���l, @1�O_����_���l, @1�O_����_�I�l;

	CLOSE cursor_tRateHistory_Min15;
	DEALLOCATE cursor_tRateHistory_Min15;

	--select @�ʉ݃y�ANo as �ʉ݃y�ANo, @StartDate as StartDate


	-- Bonus Stage ����

	Set @WMA���� = '';
	Set @BonusStage���� = '';

	if @1�O_����WMA < @��_����WMA
	begin

		Set @WMA���� = '����'
		Set @WMA�O = @1�O_����WMA;
		Set @WMA�� = @��_����WMA;
		Set @WMA�㏸�p�x_�� = @��_����WMA�㏸�p�x;

		if @��_����WMA�㏸�p�x_�V�O�} < @�V�O�}臒l
		begin
			return;
		end

		if @1�O_����WMA�㏸�p�x > @��_����WMA�㏸�p�x
		begin
			return;
		end

		if @1�O_����_���l > @��_����_���l
		begin
			return;
		end

		if @1�O_����_���l > @��_����_���l
		begin
			return;
		end

		Set @BonusStage���� = 'B';	-- Bonus Stage �J�n

	end
	else if @1�O_����WMA > @��_����WMA
	begin

		Set @WMA���� = '����'
		Set @WMA�O = @1�O_����WMA;
		Set @WMA�� = @��_����WMA;
		Set @WMA�㏸�p�x_�� = @��_����WMA�㏸�p�x;

		if @��_����WMA�㏸�p�x_�V�O�} < @�V�O�}臒l
		begin
			return;
		end

		if @1�O_����WMA�㏸�p�x < @��_����WMA�㏸�p�x
		begin
			return;
		end

		if @1�O_����_���l < @��_����_���l
		begin
			return;
		end

		if @1�O_����_���l < @��_����_���l
		begin
			return;
		end

		Set @BonusStage���� = 'B';	-- Bonus Stage �J�n

	end

	--select @�ʉ݃y�ANo as �ʉ݃y�ANo, @StartDate as StartDate, @WMA���� as WMA����, @BonusStage���� as BonusStage����

END
GO
/*
*/

