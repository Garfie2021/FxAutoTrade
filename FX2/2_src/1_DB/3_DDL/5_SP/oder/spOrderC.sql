USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spOrderC]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderC]
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


	/*** �v�Z START ***/

	DECLARE @�v�Z�Ώ� tinyint
	EXECUTE [oder].[spChk�v�Z�Ώ�] @�ʉ݃y�ANo ,@�v�Z�Ώ� OUTPUT;
	if @�v�Z�Ώ� = 0
	begin
		return;
	end

	EXECUTE [rate].[spInsertRateHistory_Month1] @�ʉ݃y�ANo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Week1] @�ʉ݃y�ANo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Day1] @�ʉ݃y�ANo ,@StartDate ,0;
	EXECUTE [rate].[spInsertRateHistory_Min15] @�ʉ݃y�ANo ,@StartDate ,0;

	EXECUTE [indi].[spInsertIndicatorHistory_Month1_WMA] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Month1_WMA_S2] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Week1_WMA] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Week1_WMA_S2] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Day1_WMA] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Day1_WMA_S2] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Min15_WMA] @�ʉ݃y�ANo ,@StartDate;
	EXECUTE [indi].[spInsertIndicatorHistory_Min15_WMA_S2] @�ʉ݃y�ANo ,@StartDate;



	/*** �������� START ***/

	-- �����ΏۊO�H
	DECLARE @�����Ώ� tinyint
	EXECUTE [oder].[spChk�����Ώ�] @�ʉ݃y�ANo ,@�����Ώ� OUTPUT;
	if @�����Ώ� = 0
	begin
		return;
	end

	-- �O��̔��茋�ʂ��N���A
	UPDATE [oder].[tOrderSettings]
	SET [��������] = 0,
		[�����] = ''
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

	-- Rate�Ɉُ킠��H
	if @����Rate = 0 or @����Rate = 0
	begin
		EXECUTE [oder].[spUpdateOrderSettings_�����] @�ʉ݃y�ANo ,'Order�ΏۊO�iRate��0�j';
		return;
	end

	DECLARE @�������� tinyint
	DECLARE @���� tinyint
	EXECUTE [oder].[spChk���O��Rate�������Ă���] @�ʉ݃y�ANo ,@�������� ,@���� OUTPUT

	if @���� = 0
	begin
		EXECUTE [oder].[spUpdateOrderSettings_�����] @�ʉ݃y�ANo ,'Order�ΏۊO(���O��Rate����)';
		return;
	end

		public static bool �����ݒ�_�������[�h_WMA_S2_15m(SqlConnection cn, byte �ʉ݃y�ANo, DateTime now, ref DataGridView dgv����)
		{
			Indi.GetWMA����_15m_S2�̂�(cn, �ʉ݃y�ANo, now, out �����ݒ�_�������[�h_WMA_15m_WMA�O_S2, out �����ݒ�_�������[�h_WMA_15m_WMA��_S2);

			dgv����.Rows[�ʉ݃y�ANo].Cells[DGVClmNo����.WMA�O_15m_S2].Value = �����ݒ�_�������[�h_WMA_15m_WMA�O_S2;
			dgv����.Rows[�ʉ݃y�ANo].Cells[DGVClmNo����.WMA��_15m_S2].Value = �����ݒ�_�������[�h_WMA_15m_WMA��_S2;

			dgv����.Rows[�ʉ݃y�ANo].Cells[DGVClmNo����.�����].Value = "Order�ΏۊO�i�������[�h_WMA_S2_15m�j";
			return false;
		}



	@OrderV1_�]����̊���


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

		if @��_����WMA�㏸�p�x_�V�O�} > @�V�O�}臒l * -1
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

