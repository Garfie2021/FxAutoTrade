USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_InsertIndicator_Daily_ASI]
	@通貨ペアNo			tinyint = 12,
	@日時				datetime,
	@買い_ASI		float,
	@売り_ASI		float
AS
BEGIN

	declare @Cnt int = 0;

	SELECT @Cnt = count(*)
	FROM [indi].[T_Indicator_Daily]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

	if @Cnt = 0
	begin
		INSERT INTO [indi].[T_Indicator_Daily] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @日時);
	end

	UPDATE [indi].[T_Indicator_Daily]
	SET ASI_買い_ASI = @買い_ASI, ASI_売り_ASI = @売り_ASI
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	


END


GO
