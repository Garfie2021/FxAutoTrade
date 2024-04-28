USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp�Čv�Z_WMA_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_WMA_Min1]
	@back_Min1	int = -2,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	DECLARE @����WMAs2 float;
	DECLARE @����WMAs2 float;

	DECLARE @�ʉ݃y�ANo tinyint = 0;

	while @back_Min1 < 1
	begin

		--�����Ώۊ��Ԏ擾
		EXECUTE [cmn].[spGetTerm_Min1] @now, @back_Min1, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @�ʉ݃y�ANo as �ʉ݃y�ANo,@StartDate as Start1m,@EndDate as End1m;

		SET @�ʉ݃y�ANo = 0;
		while @�ʉ݃y�ANo < 44
		begin

			--EXECUTE [reca].[spUpdateWMAs2_Min1] @�ʉ݃y�ANo, @StartDate;
			EXECUTE [rate].[spCulcWMAs2_Min1] @�ʉ݃y�ANo, @StartDate, @����WMAs2 OUTPUT, @����WMAs2 OUTPUT;

			UPDATE [rate].[tRateHistory_Min1]
			SET
				����WMAs2 = @����WMAs2,
				����WMAs2 = @����WMAs2,
				[�X�V����] = @now
			where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Min1 = @back_Min1 + 1;
	end;

END

GO


