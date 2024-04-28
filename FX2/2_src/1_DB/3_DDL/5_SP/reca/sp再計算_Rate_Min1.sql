USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp�Čv�Z_Rate_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp�Čv�Z_Rate_Min1]
	@back_1m	int = -2,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@now		Datetime
AS
BEGIN

	while @back_1m < 1
	begin

		DECLARE @�ʉ݃y�ANo tinyint = 0
		while @�ʉ݃y�ANo < 44
		begin

			EXECUTE [rate].[spInsertRateHistory_Min1] @�ʉ݃y�ANo, @now, @back_1m

			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
		end;

		Set @back_1m = @back_1m + 1;
	end;

END

GO


