USE OANDA_DemoB
GO

DROP PROCEDURE [swap].[spGetSwap_Žè“®“o˜^Swap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGetSwap_Žè“®“o˜^Swap]
	@’Ê‰ÝƒyƒANo		tinyint,
	@Swap_”„‚è		float	output,
	@Swap_”ƒ‚¢		float	output
AS
BEGIN

	/*
	DECLARE @’Ê‰ÝƒyƒANo		tinyint = 22
	DECLARE @Swap_”ƒ‚¢		float
	DECLARE @Swap_”„‚è		float
	*/

	declare @Cnt int = 0;
	SELECT @Cnt = count(*)
	FROM [swap].[tSwapŽè“®“o˜^_Day1]
	where [’Ê‰ÝƒyƒANo] = @’Ê‰ÝƒyƒANo and ([”ƒ‚¢Swap] <> 0 or [”„‚èSwap] <> 0)

	if @Cnt > 0
	begin
		SELECT TOP 1 @Swap_”ƒ‚¢ = [”ƒ‚¢Swap], @Swap_”„‚è = [”„‚èSwap]
		FROM [swap].[tSwapŽè“®“o˜^_Day1]
		where [’Ê‰ÝƒyƒANo] = @’Ê‰ÝƒyƒANo and ([”ƒ‚¢Swap] <> 0 or [”„‚èSwap] <> 0)
		order by [StartDate] desc;
	end
	else
	begin
		Set @Swap_”ƒ‚¢ = 0;
		Set @Swap_”„‚è = 0;
	end

	--select @Swap_”ƒ‚¢, @Swap_”„‚è

END
GO

