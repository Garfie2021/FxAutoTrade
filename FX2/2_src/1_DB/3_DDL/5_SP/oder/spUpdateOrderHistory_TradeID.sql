USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [oder].[spUpdateOrderHistory_TradeID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_TradeID]
	@OpenOrderID varchar(50)
AS
BEGIN
	--declare @OpenOrderID varchar(50) = '42769189'

	SET NOCOUNT ON;

	UPDATE [oder].tOrderHistory
	SET TradeID = b.TradeID
	from [fxcm].[tTrades] as b
	where b.OpenOrderID = @OpenOrderID and [oder].tOrderHistory.OpenOrderID = b.OpenOrderID;

END
GO
/*
*/