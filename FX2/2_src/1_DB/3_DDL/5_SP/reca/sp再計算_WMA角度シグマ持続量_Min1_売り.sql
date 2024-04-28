USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [reca].[sp�Čv�Z_WMA�p�x�V�O�}������_Min1_����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_WMA�p�x�V�O�}������_Min1_����]
	@�V�O�}	float = 1,	-- �v���X�l�ɂ����Ή����Ă��Ȃ��B�v���X�V�O�}�傫�����̔����ő���̓�������؂���ƃ}�C�i�X�V�O�}�ɂȂ�̂Ōv�Z�ΏۊO�B
	@now	Datetime
AS
BEGIN
	/*
	declare @�V�O�}	float = 1;
	declare @now	Datetime = getdate();
	*/

	-- ����Rate�̎����ʂ��v�Z

	declare cursor_tRateHistory_Min1_�V�O�} cursor for
	SELECT [�ʉ݃y�ANo], [StartDate], [����Rate_�I�l], [����WMAs2�p�x]
	from [rate].[tRateHistory_Min1]
	where [����WMAs2�p�x�V�O�}] >= @�V�O�};

	open cursor_tRateHistory_Min1_�V�O�};

	DECLARE @�ʉ݃y�ANo				tinyint = 0;
	DECLARE @StartDate				datetime;
	DECLARE @����Rate_�I�l			float;
	DECLARE @����WMAs2�p�x			float;
	DECLARE @����WMAs2�p�x�����s��	int;
	DECLARE @����WMAs2�p�xRate��	float;

	FETCH NEXT FROM cursor_tRateHistory_Min1_�V�O�} INTO @�ʉ݃y�ANo, @StartDate, @����Rate_�I�l, @����WMAs2�p�x;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		EXECUTE [rate].[spCulcWMAs2�p�x�V�O�}������_Min1_����] @�ʉ݃y�ANo, @StartDate, @����Rate_�I�l, @����WMAs2�p�x, 
			@����WMAs2�p�x�����s�� OUTPUT, @����WMAs2�p�xRate�� OUTPUT;

		--select @����WMAs2�p�x�����s�� as ����WMAs2�p�x�����s��, @����WMAs2�p�xRate�� as ����WMAs2�p�xRate��;

		UPDATE [rate].[tRateHistory_Min1]
		SET [����WMAs2�p�x��������] = @����WMAs2�p�x�����s��,
			[����WMAs2�p�x����Rate] = @����WMAs2�p�xRate��
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo AND StartDate = @StartDate;

		FETCH NEXT FROM cursor_tRateHistory_Min1_�V�O�} INTO @�ʉ݃y�ANo, @StartDate, @����Rate_�I�l, @����WMAs2�p�x;
	END

	CLOSE cursor_tRateHistory_Min1_�V�O�};
	DEALLOCATE cursor_tRateHistory_Min1_�V�O�};
END
GO
/*
*/


