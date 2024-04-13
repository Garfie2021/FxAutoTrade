USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateOrderHistory_CloseOrderID]
	@TradeID varchar(50),
	@CloseOrderID varchar(50),
	@Close区分 varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE
		dbo.T_OrderHistory
	SET
		CloseOrderID = @CloseOrderID,
		Close区分 = @Close区分
	where
		TradeID = @TradeID

END

GO
