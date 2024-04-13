USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Get高値安値_15m]
	@通貨ペアNo		tinyint,
	@Start15m		datetime,
	@買い_高値		float	output,
	@買い_安値		float	output,
	@売り_高値		float	output,
	@売り_安値		float	output
AS
BEGIN

	SELECT @買い_高値 = [買い_高値], @買い_安値 = [買い_安値], @売り_高値 = [売り_高値], @売り_安値 = [売り_安値]
	FROM
		[dbo].[T_RateHistory_15m]
	WHERE
		通貨ペアNo = @通貨ペアNo and 日時 = @Start15m

END

GO
