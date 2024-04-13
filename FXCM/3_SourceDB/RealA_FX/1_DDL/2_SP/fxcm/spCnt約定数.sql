USE DemoA_FX
GO

DROP PROCEDURE [fxcm].[spCnt–ñ’è”]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spCnt–ñ’è”]
	@from	datetime,
	@Cnt	int		output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM fxcm.tClosedTrades
	where CloseTime >= @from;

END
GO

