USE [FX2_����]
GO

DROP PROCEDURE [reca].[sp�Čv�Z_WMA�p�x�V�O�}_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_WMA�p�x�V�O�}_Min1]
	@back_Min1	int = -2,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	DECLARE @����WMAs2�p�x float;
	DECLARE @����WMAs2�p�x float;
	DECLARE @����WMAs2�p�x�V�O�} float;
	DECLARE @����WMAs2�p�x�V�O�} float;

	DECLARE @�ʉ݃y�ANo tinyint = 0;

	while @back_Min1 < 1
	begin

		--�����Ώۊ��Ԏ擾
		EXECUTE [cmn].[spGetTerm_Min1] @now, @back_Min1, @StartDate OUTPUT, @EndDate OUTPUT;

		SET @�ʉ݃y�ANo = 0;
		while @�ʉ݃y�ANo < 44
		begin

			SELECT @����WMAs2�p�x = [����WMAs2�p�x], @����WMAs2�p�x = [����WMAs2�p�x]
			from [rate].[tRateHistory_Min1]
			where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

			EXECUTE [rate].[spCulcWMAs2�p�x�V�O�}_Min1] @�ʉ݃y�ANo, @StartDate, @����WMAs2�p�x, 
				@����WMAs2�p�x�V�O�} OUTPUT, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} OUTPUT;

			UPDATE [rate].[tRateHistory_Min1]
			SET
				����WMAs2�p�x�V�O�} = @����WMAs2�p�x�V�O�},
				����WMAs2�p�x�V�O�} = @����WMAs2�p�x�V�O�},
				[�X�V����] = @now
			where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Min1 = @back_Min1 + 1;
	end;

END

GO


