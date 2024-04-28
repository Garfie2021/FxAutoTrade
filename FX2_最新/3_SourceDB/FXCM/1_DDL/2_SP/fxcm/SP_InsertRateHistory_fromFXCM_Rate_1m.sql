USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_fromFXCM_Rate_1m]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_fromFXCM_Rate_1m]
AS
BEGIN

	-- �Â��f�[�^���폜
	declare cursorT_Rate_1m cursor for
	SELECT [�ʉ݃y�ANo], [����]
	FROM [fxcm].[T_Rate_1m];

	open cursorT_Rate_1m;

	declare @�ʉ݃y�ANo tinyint = 0;
	declare @���� Datetime;
	FETCH NEXT FROM cursorT_Rate_1m INTO @�ʉ݃y�ANo, @����;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select *
		delete
		from [dbo].[T_RateHistory]
		where �ʉ݃y�A = @�ʉ݃y�ANo and [Date] = @����

		FETCH NEXT FROM cursorT_Rate_1m INTO @�ʉ݃y�ANo, @����;
	END

	CLOSE cursorT_Rate_1m;
	DEALLOCATE cursorT_Rate_1m;


	-- Insert
	INSERT INTO [dbo].[T_RateHistory]
           ([�ʉ݃y�A]
           ,[Date]
           ,[Rate_����]
           ,[Rate_����]
           ,[Swap_����]
           ,[Swap_����]
		   ,[Rate����Status_����]
		   ,[Rate����Status_����])
	SELECT [�ʉ݃y�ANo]
		,[����]
		,[Rate_�n�l_����]
		,[Rate_�n�l_����]
		,0
		,0
		,null
		,null
	FROM [fxcm].[T_Rate_1m]
	

END

GO
