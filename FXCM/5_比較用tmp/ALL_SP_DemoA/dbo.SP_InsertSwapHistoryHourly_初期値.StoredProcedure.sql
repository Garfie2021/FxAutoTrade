USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertSwapHistoryHourly_初期値]
AS
BEGIN

	declare @通貨ペアNo	tinyint = 0;

	while @通貨ペアNo < 44
	begin

		INSERT INTO [dbo].[T_SwapHistory_Hourly] 
		(
			[通貨ペアNo], [日時], [Swap_買い], [Swap_売り]
		)
		SELECT TOP 1 @通貨ペアNo, [Date], [Swap_買い], [Swap_売り]
		FROM [dbo].[T_RateHistory]
		WHERE [通貨ペア] = @通貨ペアNo and ([Swap_買い] <> 0 or [Swap_売り] <> 0)
		ORDER BY [date] desc

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end

END


GO
