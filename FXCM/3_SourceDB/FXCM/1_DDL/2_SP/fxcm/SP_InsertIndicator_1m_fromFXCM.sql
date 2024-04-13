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
	SELECT [ΚέyANo], [ϊ], [’_DI_plus], [’_DI_minus], [θ_DI_plus], [θ_DI_minus]
	FROM [fxcm].[T_Indicator_1m_DMI];

	open cursorT_FXCM_RateHistory_Weekly;

	declare @ΚέyANo tinyint = 0;
	declare @ϊ datetime;
	declare @’_DI_plus float = 0;
	declare @’_DI_minus float = 0;
	declare @θ_DI_plus float = 0;
	declare @θ_DI_minus float = 0;
	FETCH NEXT FROM cursorT_Indicator_1m_DMI INTO @ΚέyANo, @ϊ, @’_DI_plus, @’_DI_minus, @θ_DI_plus, @θ_DI_minus;

	declare @Cnt int = 0;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @Cnt = count(*)
		FROM [dbo].[T_Indicator_1m]
		where ΚέyANo = @ΚέyANo and ϊ = @ϊ

		if @Cnt = 0
		begin
			INSERT INTO [dbo].[T_Indicator_1m] ([ΚέyANo], [ϊ]) VALUES (@ΚέyANo, @ϊ);
		end

		UPDATE [dbo].[T_Indicator_1m]
		SET ’_DMI_DI_plus = @’_DI_plus, ’_DMI_DI_minus = @’_DI_minus, θ_DMI_DI_plus = @θ_DI_plus, θ_DMI_DI_minus = @θ_DI_minus
		where ΚέyANo = @ΚέyANo and ϊ = @ϊ	

		FETCH NEXT FROM cursorT_Indicator_1m_DMI INTO @ΚέyANo, @ϊ, @’_DI_plus, @’_DI_minus, @θ_DI_plus, @θ_DI_minus;
	END

	CLOSE cursorT_Indicator_1m_DMI;
	DEALLOCATE cursorT_Indicator_1m_DMI;
	
END

GO
/*
*/
