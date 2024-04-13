USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt“–“ú’•¶”]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt“–“ú’•¶”]
    @ŒûÀNo	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tOrderResponse]
	WHERE ŒûÀNo = @ŒûÀNo AND Time >= @from;

END
GO

