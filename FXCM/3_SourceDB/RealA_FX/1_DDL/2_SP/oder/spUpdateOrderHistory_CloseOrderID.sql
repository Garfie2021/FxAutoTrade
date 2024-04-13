USE RealA_FX
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

	UPDATE [oder].[tOrderHistory]
	SET
		CloseOrderID = b.CloseOrderID,
		Close日時 = b.CloseTime
	FROM [fxcm].[tClosedTrades] as b
	where
		b.OpenOrderID = [oder].[tOrderHistory].OpenOrderID AND
		b.TradeID = [oder].[tOrderHistory].TradeID AND
		[oder].[tOrderHistory].CloseOrderID IS NULL;

END
GO
