USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt_Trades_TradeID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt_Trades_TradeID]
    @����No		Int,
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
	WHERE ����No = @����No AND id = @id

	--select @Limit as limit

END
GO

