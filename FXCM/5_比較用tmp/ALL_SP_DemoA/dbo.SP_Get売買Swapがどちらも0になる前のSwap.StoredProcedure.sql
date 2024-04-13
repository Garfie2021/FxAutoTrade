USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Get売買Swapがどちらも0になる前のSwap]
	@通貨ペアNo		tinyint,
	@Swap_買い		float	output,
	@Swap_売り		float	output
AS
BEGIN

	/*
	DECLARE @通貨ペアNo		tinyint = 22
	DECLARE @Swap_買い		float
	DECLARE @Swap_売り		float
	*/

	declare @Cnt int = 0;
	SELECT @Cnt = count(*)
	FROM [dbo].[T_SwapHistory_Hourly]
	where [通貨ペアNo] = @通貨ペアNo and ([Swap_買い] <> 0 or [Swap_売り] <> 0)

	if @Cnt > 0
	begin
		SELECT TOP 1 @Swap_買い = [Swap_買い], @Swap_売り = [Swap_売り]
		FROM [dbo].[T_SwapHistory_Hourly]
		where [通貨ペアNo] = @通貨ペアNo and ([Swap_買い] <> 0 or [Swap_売り] <> 0)
		order by [日時] desc;
	end
	else
	begin
		Set @Swap_買い = 0;
		Set @Swap_売り = 0;
	end

	--select @Swap_買い, @Swap_売り

END

GO
