USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Get高値安値_先週]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@買い_高値		float	output,
	@買い_安値		float	output,
	@売り_高値		float	output,
	@売り_安値		float	output
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 0
	DECLARE @now			datetime = '2014/06/11 8:28:30'
	DECLARE @買い_高値		float
	DECLARE @買い_安値		float
	DECLARE @売り_高値		float
	DECLARE @売り_安値		float
	*/

	DECLARE @ThisWeek date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime

	EXECUTE [cmn].[SP_GetThisWeek] @now, -1, @ThisWeek OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	--select @ThisWeek, @StartDate, @EndDate

	SELECT
		@買い_高値 = [買い_高値], @買い_安値 = [買い_安値], @売り_高値 = [売り_高値], @売り_安値 = [売り_安値]
	FROM
		[dbo].[T_RateHistory_Weekly]
	WHERE
		通貨ペアNo = @通貨ペアNo and [日時] = @ThisWeek

	--select @買い_高値, @買い_安値, @売り_高値, @売り_安値

END

GO
