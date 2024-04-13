USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_InsertIndicator_15m_ADX]
	@通貨ペアNo			tinyint = 12,
	@日時				datetime,
	@買い_ADX		float,
	@売り_ADX		float
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
	SET ADX_買い_ADX = @買い_ADX, ADX_売り_ADX = @売り_ADX
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	


END


GO
