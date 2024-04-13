USE [FX2_Demo]
GO

DROP PROCEDURE [oder].[spUpdateOrderHistory_CloseOrderID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_CloseOrderID]
	@TradeID		varchar(50),
	@CloseOrderID	varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [oder].tOrderHistory
	SET CloseOrderID = @CloseOrderID
	where TradeID = @TradeID

END
GO
