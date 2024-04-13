USE RealB_2370741683_FX
GO

DROP PROCEDURE [swap].[spGet売買Swapがどちらも0になる前のSwap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGet売買Swapがどちらも0になる前のSwap]
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
	FROM [hstr].[tHour1]
	where [通貨ペアNo] = @通貨ペアNo and ([買いSwap] <> 0 or [売りSwap] <> 0)

	if @Cnt > 0
	begin
		SELECT TOP 1 @Swap_買い = [買いSwap], @Swap_売り = [売りSwap]
		FROM [hstr].[tHour1]
		where [通貨ペアNo] = @通貨ペアNo and ([買いSwap] <> 0 or [売りSwap] <> 0)
		order by [StartDate] desc;
	end
	else
	begin
		Set @Swap_買い = 0;
		Set @Swap_売り = 0;
	end

	--select @Swap_買い, @Swap_売り

END
GO

