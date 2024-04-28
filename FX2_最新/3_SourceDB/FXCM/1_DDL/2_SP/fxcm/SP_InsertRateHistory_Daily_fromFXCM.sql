USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_Daily_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_Daily_fromFXCM]
AS
BEGIN

	-- �Â��f�[�^���폜
	declare cursorT_Rate_Daily cursor for
	SELECT [�ʉ݃y�ANo], [����]
	FROM [fxcm].[T_Rate_Daily];

	open cursorT_Rate_Daily;

	declare @�ʉ݃y�ANo tinyint = 0;
	declare @���� Datetime;
	FETCH NEXT FROM cursorT_Rate_Daily INTO @�ʉ݃y�ANo, @����;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select *
		delete
		from [dbo].[T_RateHistory_Daily]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and ���� = @����

		FETCH NEXT FROM cursorT_Rate_Daily INTO @�ʉ݃y�ANo, @����;
	END

	CLOSE cursorT_Rate_Daily;
	DEALLOCATE cursorT_Rate_Daily;


	-- Insert
	INSERT INTO [dbo].[T_RateHistory_Daily]
		([�ʉ݃y�ANo]
		,[����]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l]
		,[����_�n�l]
		,[����_���l]
		,[����_���l]
		,[����_�I�l])
	SELECT
		 [�ʉ݃y�ANo]
		,[����]
		,[Rate_�n�l_����]
		,[Rate_���l_����]
		,[Rate_���l_����]
		,[Rate_�I�l_����]
		,[Rate_�n�l_����]
		,[Rate_���l_����]
		,[Rate_���l_����]
		,[Rate_�I�l_����]
	FROM [fxcm].[T_Rate_Daily];

END

GO
