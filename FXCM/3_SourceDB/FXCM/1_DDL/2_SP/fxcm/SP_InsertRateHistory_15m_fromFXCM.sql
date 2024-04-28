USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_15m_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_15m_fromFXCM]
AS
BEGIN

	-- �Â��f�[�^���폜
	declare cursorT_Rate_15m cursor for
	SELECT [�ʉ݃y�ANo], [����]
	FROM [fxcm].[T_Rate_15m];

	open cursorT_Rate_15m;

	declare @�ʉ݃y�ANo tinyint = 0;
	declare @���� Datetime;
	FETCH NEXT FROM cursorT_Rate_15m INTO @�ʉ݃y�ANo, @����;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select *
		delete
		from [dbo].[T_RateHistory_15m]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and ���� = @����

		FETCH NEXT FROM cursorT_Rate_15m INTO @�ʉ݃y�ANo, @����;
	END

	CLOSE cursorT_Rate_15m;
	DEALLOCATE cursorT_Rate_15m;


	-- Insert
	INSERT INTO [dbo].[T_RateHistory_15m]
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
	FROM [fxcm].[T_Rate_15m];
	

END

GO
