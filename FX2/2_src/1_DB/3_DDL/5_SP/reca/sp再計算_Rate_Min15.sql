USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp�Čv�Z_Rate_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_Rate_Min15]
	@back_15m	int = -2,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_15m < 1
	begin

		--�����Ώۊ��Ԏ擾
		EXECUTE [cmn].[spGetTerm_Min15] @now, @back_15m, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @�ʉ݃y�ANo as �ʉ݃y�ANo,@StartDate as Start5m,@EndDate as End5m

		DECLARE @�ʉ݃y�ANo tinyint = 0
		while @�ʉ݃y�ANo < 44
		begin

			EXECUTE [rate].[spInsertRateHistory_Min15] @�ʉ݃y�ANo, @now, @back_15m;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_15m = @back_15m + 1;
	end;

END

GO


