USE RealB_2370741683_FX
GO

DROP PROCEDURE [fxcm].[spGetSUM���v]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spGetSUM���v]
	@FromDate	datetime,
	@ToDate		datetime,
	@���v		int			output
AS
BEGIN

	SELECT @���v = SUM(GrossPL) + SUM([Int])
	FROM fxcm.tClosedTrades
	WHERE (@FromDate <= CloseTime) AND (CloseTime < @ToDate)

END
GO

