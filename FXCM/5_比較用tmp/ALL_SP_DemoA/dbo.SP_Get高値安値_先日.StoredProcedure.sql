USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Get高値安値_先日]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@買い_高値		float	output,
	@買い_安値		float	output,
	@売り_高値		float	output,
	@売り_安値		float	output
AS
BEGIN
	/*
	DECLARE @通貨ペアNo tinyint = 0
	DECLARE @now datetime = '2014/5/7 5:59:00'
	DECLARE @買い_高値 float
	DECLARE @買い_安値 float
	DECLARE @売り_高値 float
	DECLARE @売り_安値 float
	*/

	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime

	EXECUTE [cmn].[SP_GetThisDay] @now, -1, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

	--select @ThisDay, @StartDate, @EndDate

	SELECT @買い_高値 = [買い_高値], @買い_安値 = [買い_安値], @売り_高値 = [売り_高値], @売り_安値 = [売り_安値]
	FROM
		[dbo].[T_RateHistory_Daily]
	WHERE
		通貨ペアNo = @通貨ペアNo and 日時 = @ThisDay

END

GO
