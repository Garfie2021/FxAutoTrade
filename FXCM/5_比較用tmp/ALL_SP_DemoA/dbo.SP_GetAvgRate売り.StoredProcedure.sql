USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetAvgRate売り]
	@通貨ペアNo		tinyint,
	@MinDate		datetime,
	@MaxDate		datetime,
	@AvgRate		float	output
AS
BEGIN

	/*
	*/

	SELECT
		@AvgRate = AVG(Rate_売り)
	FROM
		T_RateHistory
	WHERE
		(通貨ペア = @通貨ペアNo) AND 
		(@MinDate <= Date) AND (Date < @MaxDate)


END


GO
