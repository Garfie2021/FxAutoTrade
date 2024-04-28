USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertIndicator_1m_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertIndicator_1m_fromFXCM]
AS
BEGIN

	declare cursorT_Indicator_1m_DMI cursor for
	SELECT [�ʉ݃y�ANo], [����], [����_DI_plus], [����_DI_minus], [����_DI_plus], [����_DI_minus]
	FROM [fxcm].[T_Indicator_1m_DMI];

	open cursorT_FXCM_RateHistory_Weekly;

	declare @�ʉ݃y�ANo tinyint = 0;
	declare @���� datetime;
	declare @����_DI_plus float = 0;
	declare @����_DI_minus float = 0;
	declare @����_DI_plus float = 0;
	declare @����_DI_minus float = 0;
	FETCH NEXT FROM cursorT_Indicator_1m_DMI INTO @�ʉ݃y�ANo, @����, @����_DI_plus, @����_DI_minus, @����_DI_plus, @����_DI_minus;

	declare @Cnt int = 0;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @Cnt = count(*)
		FROM [dbo].[T_Indicator_1m]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and ���� = @����

		if @Cnt = 0
		begin
			INSERT INTO [dbo].[T_Indicator_1m] ([�ʉ݃y�ANo], [����]) VALUES (@�ʉ݃y�ANo, @����);
		end

		UPDATE [dbo].[T_Indicator_1m]
		SET ����_DMI_DI_plus = @����_DI_plus, ����_DMI_DI_minus = @����_DI_minus, ����_DMI_DI_plus = @����_DI_plus, ����_DMI_DI_minus = @����_DI_minus
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and ���� = @����	

		FETCH NEXT FROM cursorT_Indicator_1m_DMI INTO @�ʉ݃y�ANo, @����, @����_DI_plus, @����_DI_minus, @����_DI_plus, @����_DI_minus;
	END

	CLOSE cursorT_Indicator_1m_DMI;
	DEALLOCATE cursorT_Indicator_1m_DMI;
	
END

GO
/*
*/
