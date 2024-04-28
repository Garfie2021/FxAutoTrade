USE DemoA_FX
GO

DROP PROCEDURE [fxcm].[spCnt��萔]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spCnt��萔]
	@from	datetime,
	@Cnt	int		output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM fxcm.tClosedTrades
	where CloseTime >= @from;

END
GO

