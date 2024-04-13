USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_InsertIndicator_15m_AC]
	@通貨ペアNo		tinyint = 12,
	@日時			datetime,
	@買い_AC		float,
	@売り_AC		float
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
	SET AC_買い_AC = @買い_AC, AC_売り_AC = @売り_AC
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	


END


GO
