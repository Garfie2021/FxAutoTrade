USE OANDA_RealA
GO

DROP PROCEDURE [fxcm].[spCnt当日注文数]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spCnt当日注文数]
	@from	datetime,
	@Cnt	int		output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM fxcm.tTrades
	WHERE (Time >= @from);

END
GO

