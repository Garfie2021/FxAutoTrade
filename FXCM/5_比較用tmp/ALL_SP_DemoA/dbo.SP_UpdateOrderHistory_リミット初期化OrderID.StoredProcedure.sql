USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateOrderHistory_リミット初期化OrderID]
	@TradeID varchar(50),
	@リミット初期化OrderID varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE
		dbo.T_OrderHistory
	SET
		リミット初期化OrderID = @リミット初期化OrderID
	where
		TradeID = @TradeID

END

GO
