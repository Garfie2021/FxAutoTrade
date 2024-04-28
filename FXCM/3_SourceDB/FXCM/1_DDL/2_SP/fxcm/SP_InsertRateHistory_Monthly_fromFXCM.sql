USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_Monthly_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_Monthly_fromFXCM]
AS
BEGIN

	-- �Â��f�[�^���폜
	declare cursor_T_Rate_Monthly cursor for
	SELECT [�ʉ݃y�ANo], [����]
	FROM [fxcm].[T_Rate_Monthly];

	open cursor_T_Rate_Monthly;

	declare @�ʉ݃y�ANo tinyint = 0;
	declare @���� date;
	FETCH NEXT FROM cursor_T_Rate_Monthly INTO @�ʉ݃y�ANo, @����;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		delete 
		--select *
		from [dbo].[T_RateHistory_Monthly]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and ���� = @����

		FETCH NEXT FROM cursor_T_Rate_Monthly INTO @�ʉ݃y�ANo, @����;
	END

	CLOSE cursor_T_Rate_Monthly;
	DEALLOCATE cursor_T_Rate_Monthly;

	-- Insert
	INSERT INTO [dbo].[T_RateHistory_Monthly]
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
	FROM [fxcm].[T_Rate_Monthly];

END

GO
