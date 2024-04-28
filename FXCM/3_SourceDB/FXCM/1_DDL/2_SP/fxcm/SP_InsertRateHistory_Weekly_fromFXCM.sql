USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistoryWeekly_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistoryWeekly_fromFXCM]
AS
BEGIN
/*
*/
	-- �Â��f�[�^���폜
	declare cursorT_FXCM_RateHistory_Weekly cursor for
	SELECT [�ʉ݃y�ANo], convert(varchar, YEAR([����])) + '/' + convert(varchar, MONTH([����])) + '/' + convert(varchar, DAY([����])), Rate_���l_����, Rate_���l_����
	FROM [dbo].[T_FXCM_RateHistory_Weekly]
  	;

	open cursorT_FXCM_RateHistory_Weekly;

	declare @�ʉ݃y�ANo tinyint = 0;
	declare @date varchar(20);
	declare @Rate_���l_���� float = 0;
	declare @Rate_���l_���� float = 0;
	FETCH NEXT FROM cursorT_FXCM_RateHistory_Weekly INTO @�ʉ݃y�ANo, @date, @Rate_���l_����, @Rate_���l_����;

	declare @Year smallint = 0;
	declare @Week tinyint = 0;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @Year = [year], @Week = [wk]
		FROM [dbo].[GetYearWeek] (CONVERT(DATE, @date))

		--SELECT @�ʉ݃y�ANo, @Year, @Week, @date,CONVERT(DATE, @date)

		delete from [dbo].[T_RateHistory_Weekly]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [Year] = @Year and [Week] = @Week

		INSERT INTO [dbo].[T_RateHistory_Weekly](
			 [�ʉ݃y�ANo]
			,[Year]
			,[Week]
			,[MaxRate]
			,[MinRate]
		)VALUES(
			 @�ʉ݃y�ANo
			,@Year
			,@Week
			,@Rate_���l_����
			,@Rate_���l_����
		);

		FETCH NEXT FROM cursorT_FXCM_RateHistory_Weekly INTO @�ʉ݃y�ANo, @date, @Rate_���l_����, @Rate_���l_����;
	END

	CLOSE cursorT_FXCM_RateHistory_Weekly;
	DEALLOCATE cursorT_FXCM_RateHistory_Weekly;
	
END

GO
/*
*/
