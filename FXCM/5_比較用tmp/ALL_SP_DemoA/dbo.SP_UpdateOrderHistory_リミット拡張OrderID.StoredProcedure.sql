USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateOrderHistory_リミット拡張OrderID]
	@TradeID varchar(50),
	@リミット拡張OrderID varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE
		dbo.T_OrderHistory
	SET
		リミット拡張OrderID = @リミット拡張OrderID
	where
		TradeID = @TradeID

END

GO
