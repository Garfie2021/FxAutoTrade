USE RealB_2370741683_FX
GO

DROP PROCEDURE [fxcm].[spGetSUMç∑âv]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spGetSUMç∑âv]
	@FromDate	datetime,
	@ToDate		datetime,
	@óòâv		int			output
AS
BEGIN

	SELECT @óòâv = SUM(GrossPL) + SUM([Int])
	FROM fxcm.tClosedTrades
	WHERE (@FromDate <= CloseTime) AND (CloseTime < @ToDate)

END
GO

