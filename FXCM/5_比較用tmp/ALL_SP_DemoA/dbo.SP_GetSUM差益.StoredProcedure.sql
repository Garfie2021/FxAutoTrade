USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetSUM差益]
	@FromDate	datetime,
	@ToDate		datetime,
	@利益		int	output
AS
BEGIN

	/*
	*/

	SELECT
		@利益 = SUM(GrossPL) + SUM([Int])
	FROM
		T_ClosedTrades
	WHERE
		(@FromDate <= CloseTime) AND 
		(CloseTime < @ToDate)


END


GO
