USE DemoA_FX
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

	UPDATE [oder].[tOrderHistory]
	SET
		TradeID = b.TradeID
	FROM [fxcm].[tTrades] as b
	where
		b.OpenOrderID = [oder].[tOrderHistory].OpenOrderID AND
		[oder].[tOrderHistory].TradeID IS NULL;

END
GO
