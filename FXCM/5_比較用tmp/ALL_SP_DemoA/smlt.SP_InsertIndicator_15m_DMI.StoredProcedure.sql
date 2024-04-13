USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_InsertIndicator_15m_DMI]
	@通貨ペアNo			tinyint = 12,
	@日時				datetime,
	@買い_DI_plus	float,
	@買い_DI_minus	float,
	@売り_DI_plus	float,
	@売り_DI_minus	float
AS
BEGIN

	declare @Cnt int = 0;

	SELECT @Cnt = count(*)
	FROM [smlt].[T_Indicator_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

	if @Cnt = 0
	begin
		INSERT INTO [smlt].[T_Indicator_15m] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @日時);
	end

	UPDATE [smlt].[T_Indicator_15m]
	SET DMI_買い_DI_plus = @買い_DI_plus, DMI_買い_DI_minus = @買い_DI_minus, DMI_売り_DI_plus = @売り_DI_plus, DMI_売り_DI_minus = @売り_DI_minus
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	


END


GO
