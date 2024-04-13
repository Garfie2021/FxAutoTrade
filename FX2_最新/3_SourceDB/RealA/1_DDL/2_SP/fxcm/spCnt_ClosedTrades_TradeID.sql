USE OANDA_RealA
GO

DROP PROCEDURE [fxcm].[spCnt_ClosedTrades_TradeID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spCnt_ClosedTrades_TradeID]
	@TradeID	varchar(100),
	@Cnt		int		output
AS
BEGIN

	/*
	DECLARE @TradeID	varchar(100)
	DECLARE @Cnt		int
	*/

	SELECT @Cnt = COUNT(*)
	FROM fxcm.tClosedTrades
	WHERE (TradeID = @TradeID)

	--select @Limit as limit

END
GO

