USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt–ñ’è”]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt–ñ’è”]
    @ŒûÀNo	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tTransaction]
	where ŒûÀNo = @ŒûÀNo AND [type] = 'CloseOrder' AND [Time] >= @from;

END
GO

