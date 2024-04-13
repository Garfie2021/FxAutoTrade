USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Get高値安値_先月]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@買い_高値		float	output,
	@買い_安値		float	output,
	@売り_高値		float	output,
	@売り_安値		float	output
AS
BEGIN

	DECLARE @ThisMonth datetime
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime

	EXECUTE [cmn].[SP_GetThisMonth] @now, -1, @ThisMonth OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

	Declare @先月 datetime = DATEADD(month, -1, @now);
	Set @先月 = convert(varchar, YEAR(@先月)) + '/' + convert(varchar, MONTH(@先月)) + '/01 00:00:00';

	SELECT @買い_高値 = [買い_高値], @買い_安値 = [買い_安値], @売り_高値 = [売り_高値], @売り_安値 = [売り_安値]
	FROM
		[dbo].[T_RateHistory_Monthly]
	WHERE
		通貨ペアNo = @通貨ペアNo and 日時 = @ThisMonth

END

GO
