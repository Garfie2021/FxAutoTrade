USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt_Trades_TradeID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt_Trades_TradeID]
    @å˚ç¿No		Int,
	@id			BigInt,
	@Cnt		int		output
AS
BEGIN

	/*
	DECLARE @TradeID	varchar(100)
	DECLARE @Cnt		int
	*/

	SELECT @Cnt = COUNT(*)
	FROM oanda.tTrade
	WHERE å˚ç¿No = @å˚ç¿No AND id = @id

	--select @Limit as limit

END
GO

