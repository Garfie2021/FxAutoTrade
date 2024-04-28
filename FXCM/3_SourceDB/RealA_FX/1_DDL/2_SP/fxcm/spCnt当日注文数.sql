USE DemoA_FX
GO

DROP PROCEDURE [fxcm].[spCnt����������]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spCnt����������]
	@from	datetime,
	@Cnt	int		output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM fxcm.tTrades
	WHERE (Time >= @from);

END
GO

