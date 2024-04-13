USE OANDA_RealA
GO

DROP PROCEDURE [swap].[spGet手動登録済み最新Swap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGet手動登録済み最新Swap]
	@通貨ペアNo		tinyint,
	@Swap_売り		float	output,
	@Swap_買い		float	output
AS
BEGIN

	/*
	DECLARE @通貨ペアNo		tinyint = 22
	DECLARE @Swap_買い		float
	DECLARE @Swap_売り		float
	*/
	
	SELECT TOP 1 @Swap_買い = [買いSwap], @Swap_売り = [売りSwap]
	FROM [OANDA_RealA].[swap].[tSwap手動登録_Day1]
	where [通貨ペアNo] = @通貨ペアNo
	ORDER BY [StartDate] DESC;

	--select @Swap_買い, @Swap_売り

END
GO

