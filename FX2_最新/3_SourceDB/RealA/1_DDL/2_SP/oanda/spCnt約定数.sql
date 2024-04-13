USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt約定数]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt約定数]
    @口座No	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tTransaction]
	where 口座No = @口座No AND [type] = 'CloseOrder' AND [Time] >= @from;

END
GO

