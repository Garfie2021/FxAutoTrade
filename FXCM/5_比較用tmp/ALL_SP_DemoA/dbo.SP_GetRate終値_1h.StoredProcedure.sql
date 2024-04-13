USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetRate終値_1h]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@back_1h		smallint,
	@買い_終値		float	output,
	@売り_終値		float	output
AS
BEGIN

	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	EXECUTE [cmn].[SP_GetThis1h] @now, @back_1h, @StartDate OUTPUT, @EndDate OUTPUT

	SELECT @買い_終値 = [買い_終値], @売り_終値 = [買い_終値]
	FROM [dbo].[T_RateHistory_Hourly]
	WHERE 通貨ペアNo = @通貨ペアNo and 日時 = @StartDate

END

GO
