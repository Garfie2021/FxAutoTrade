USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetRate終値_Daily]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_Day		smallint,
	@買い_終値		float	output,
	@売り_終値		float	output
AS
BEGIN

	declare @ThisDay date;
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThisDay] @now, @back_Day, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	SELECT @買い_終値 = [買い_終値], @売り_終値 = [買い_終値]
	FROM [dbo].[T_RateHistory_Daily]
	WHERE 通貨ペアNo = @通貨ペアNo and 日時 = @ThisDay

END

GO
