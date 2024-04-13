USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetRate終値_Weekly]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_Week		smallint,
	@買い_終値		float	output,
	@売り_終値		float	output
AS
BEGIN

	DECLARE @ThisWeek date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThisWeek] @now, @back_Week, @ThisWeek OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	SELECT @買い_終値 = [買い_終値], @売り_終値 = [買い_終値]
	FROM [dbo].[T_RateHistory_Weekly]
	WHERE 通貨ペアNo = @通貨ペアNo and 日時 = @ThisWeek

END

GO
