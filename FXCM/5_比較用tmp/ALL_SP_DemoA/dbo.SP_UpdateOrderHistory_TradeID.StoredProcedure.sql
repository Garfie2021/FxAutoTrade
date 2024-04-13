USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateOrderHistory_TradeID]
	@OpenOrderID varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE
		dbo.T_OrderHistory
	SET
		TradeID = b.TradeID
	from
		dbo.T_Trades as b
	where
		b.OpenOrderID = @OpenOrderID and 
		dbo.T_OrderHistory.OpenOrderID = b.OpenOrderID

END

GO
