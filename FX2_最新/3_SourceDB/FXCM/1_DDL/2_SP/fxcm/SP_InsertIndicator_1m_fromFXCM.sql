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
	SELECT [通貨ペアNo], [日時], [買い_DI_plus], [買い_DI_minus], [売り_DI_plus], [売り_DI_minus]
	FROM [fxcm].[T_Indicator_1m_DMI];

	open cursorT_FXCM_RateHistory_Weekly;

	declare @通貨ペアNo tinyint = 0;
	declare @日時 datetime;
	declare @買い_DI_plus float = 0;
	declare @買い_DI_minus float = 0;
	declare @売り_DI_plus float = 0;
	declare @売り_DI_minus float = 0;
	FETCH NEXT FROM cursorT_Indicator_1m_DMI INTO @通貨ペアNo, @日時, @買い_DI_plus, @買い_DI_minus, @売り_DI_plus, @売り_DI_minus;

	declare @Cnt int = 0;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @Cnt = count(*)
		FROM [dbo].[T_Indicator_1m]
		where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

		if @Cnt = 0
		begin
			INSERT INTO [dbo].[T_Indicator_1m] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @日時);
		end

		UPDATE [dbo].[T_Indicator_1m]
		SET 買い_DMI_DI_plus = @買い_DI_plus, 買い_DMI_DI_minus = @買い_DI_minus, 売り_DMI_DI_plus = @売り_DI_plus, 売り_DMI_DI_minus = @売り_DI_minus
		where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	

		FETCH NEXT FROM cursorT_Indicator_1m_DMI INTO @通貨ペアNo, @日時, @買い_DI_plus, @買い_DI_minus, @売り_DI_plus, @売り_DI_minus;
	END

	CLOSE cursorT_Indicator_1m_DMI;
	DEALLOCATE cursorT_Indicator_1m_DMI;
	
END

GO
/*
*/
