USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp�Čv�Z_WMA�p�x_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_WMA�p�x_Min15]
	@back_Min15	int = -2,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@now		Datetime
AS
BEGIN
	
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	DECLARE @����WMAs2		float;
	DECLARE @����WMAs2		float;
	DECLARE @����WMAs2�p�x	float;
	DECLARE @����WMAs2�p�x	float;

	DECLARE @�ʉ݃y�ANo tinyint = 0;

	while @back_Min15 < 1
	begin

		--�����Ώۊ��Ԏ擾
		EXECUTE [cmn].[spGetTerm_Min15] @now, @back_Min15, @StartDate OUTPUT, @EndDate OUTPUT;
		--SELECT @back_Min15 as back_Min15, @StartDate as StartDate, @EndDate as EndDate;

		SET @�ʉ݃y�ANo = 0;
		while @�ʉ݃y�ANo < 44
		begin

			SELECT TOP 1 @����WMAs2 = [����WMAs2], @����WMAs2 = [����WMAs2]
			FROM [rate].[tRateHistory_Min15]
			where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate
			order by [StartDate] desc;

			--EXECUTE [reca].[spUpdateWMAs2_Min15] @�ʉ݃y�ANo, @StartDate; ��Order���̌v�Z�ł͂�����g��
			EXECUTE [rate].[spCulcWMAs2�p�x_Min15] @�ʉ݃y�ANo, @StartDate, @����WMAs2, @����WMAs2, @����WMAs2�p�x OUTPUT, @����WMAs2�p�x OUTPUT;

			UPDATE [rate].[tRateHistory_Min15]
			SET
				����WMAs2�p�x = @����WMAs2�p�x,
				����WMAs2�p�x = @����WMAs2�p�x,
				[�X�V����] = @now
			where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Min15 = @back_Min15 + 1;
	end;

END
GO


