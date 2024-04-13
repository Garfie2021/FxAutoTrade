USE OANDA_DemoB
GO

DROP PROCEDURE [swap].[spGetSwap_è®o^Swap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGetSwap_è®o^Swap]
	@ÊÝyANo		tinyint,
	@Swap_è		float	output,
	@Swap_¢		float	output
AS
BEGIN

	/*
	DECLARE @ÊÝyANo		tinyint = 22
	DECLARE @Swap_¢		float
	DECLARE @Swap_è		float
	*/

	declare @Cnt int = 0;
	SELECT @Cnt = count(*)
	FROM [swap].[tSwapè®o^_Day1]
	where [ÊÝyANo] = @ÊÝyANo and ([¢Swap] <> 0 or [èSwap] <> 0)

	if @Cnt > 0
	begin
		SELECT TOP 1 @Swap_¢ = [¢Swap], @Swap_è = [èSwap]
		FROM [swap].[tSwapè®o^_Day1]
		where [ÊÝyANo] = @ÊÝyANo and ([¢Swap] <> 0 or [èSwap] <> 0)
		order by [StartDate] desc;
	end
	else
	begin
		Set @Swap_¢ = 0;
		Set @Swap_è = 0;
	end

	--select @Swap_¢, @Swap_è

END
GO

