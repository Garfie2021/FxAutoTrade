USE OANDA_RealA
GO

DROP PROCEDURE [oder].[spUpdateOrderHistory_CloseOrderID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_CloseOrderID]
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [oder].[tOrderHistory2]
	SET
		CloseOrderID = b.CloseOrderID,
		Close日時 = b.CloseTime
	FROM [fxcm].[tClosedTrades] as b
	where
		a.口座No = b.口座No AND
		b.OpenOrderID = [oder].[tOrderHistory2].OpenOrderID AND
		b.TradeID = [oder].[tOrderHistory2].TradeID AND
		[oder].[tOrderHistory2].CloseOrderID IS NULL;

END
GO
