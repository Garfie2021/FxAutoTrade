USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetAvgRate買い]
	@通貨ペアNo		tinyint,
	@MinDate		datetime,
	@MaxDate		datetime,
	@AvgRate		float	output
AS
BEGIN
	/*
	declare @通貨ペアNo		tinyint = 2
	declare @MinDate		datetime = '2014/05/15 16:28:36'
	declare @MaxDate		datetime = '2014/05/15 16:28:56'
	declare @AvgRate		float
	*/

	SELECT
		@AvgRate = AVG(Rate_買い)
	FROM
		T_RateHistory
	WHERE
		(通貨ペア = @通貨ペアNo) AND 
		(@MinDate <= Date) AND (Date < @MaxDate)

	--select @AvgRate
END

GO
