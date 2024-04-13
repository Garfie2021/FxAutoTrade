USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_InsertIndicator_15m_BB]
	@通貨ペアNo	tinyint = 12,
	@日時		datetime,
	@BB_買い_TL	float,
	@BB_買い_BL	float,
	@BB_買い_AL	float,
	@BB_売り_TL	float,
	@BB_売り_BL	float,
	@BB_売り_AL	float
AS
BEGIN

	declare @Cnt int = 0;

	SELECT @Cnt = count(*)
	FROM [indi].[T_Indicator_15m]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

	if @Cnt = 0
	begin
		INSERT INTO [indi].[T_Indicator_15m] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @日時);
	end

	UPDATE [indi].[T_Indicator_15m]
	SET 
		[BB_買い_TL] = @BB_買い_TL, 
		[BB_買い_BL] = @BB_買い_BL, 
		[BB_買い_AL] = @BB_買い_AL, 
		[BB_売り_TL] = @BB_売り_TL,
		[BB_売り_BL] = @BB_売り_BL,
		[BB_売り_AL] = @BB_売り_AL
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	

END


GO
