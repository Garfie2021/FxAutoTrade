USE OANDA_RealA
GO

DROP PROCEDURE [oder].[spUpdateOrderHistory_TradeID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_TradeID]
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [oder].[tOrderHistory2]
	SET
		TradeID = b.TradeID
	FROM [fxcm].[tTrades] as b
	where
		b.OpenOrderID = [oder].[tOrderHistory2].OpenOrderID AND
		[oder].[tOrderHistory2].TradeID IS NULL;

END
GO
