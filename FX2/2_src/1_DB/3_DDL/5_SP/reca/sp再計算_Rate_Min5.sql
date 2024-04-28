USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp�Čv�Z_Rate_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_Rate_Min5]
	@back_Min5	int = -2,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Min5 < 1
	begin

		--�����Ώۊ��Ԏ擾
		EXECUTE [cmn].[spGetTerm_Min5] @now, @back_Min5, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @�ʉ݃y�ANo as �ʉ݃y�ANo,@StartDate as Start5m,@EndDate as End5m

		DECLARE @�ʉ݃y�ANo tinyint = 0
		while @�ʉ݃y�ANo < 44
		begin

			EXECUTE [rate].[spInsertRateHistory_Min5] @�ʉ݃y�ANo, @now, @back_Min5;

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_Min5 = @back_Min5 + 1;
	end;

END

GO


