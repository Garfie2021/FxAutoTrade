USE [OANDA_RealA]
GO

DROP PROCEDURE [acv].[spSave_oanda_tOrderResponse]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tOrderResponse]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_RealA_ACV].oanda.tOrderResponse(
		[口座No],
		[通貨ペアNo],
		[time],
		[instrument],
		[BS開始],
		[price],
		[Order_id],
		[Order_instrument],
		[Order_units],
		[Order_side],
		[Order_type],
		[Order_time],
		[Order_price],
		[Order_takeProfit],
		[Order_stopLoss],
		[Order_expiry],
		[Order_upperBound],
		[Order_lowerBound],
		[Order_trailingStop],
		[TradeData_id],
		[TradeData_units],
		[TradeData_side],
		[TradeData_instrument],
		[TradeData_time],
		[TradeData_price],
		[TradeData_takeProfit],
		[TradeData_stopLoss],
		[TradeData_trailingStop],
		[TradeData_trailingAmount],
		[妥当性],
		[登録日時],
		[更新日時])
	SELECT 
		[口座No],
		[通貨ペアNo],
		[time],
		[instrument],
		[BS開始],
		[price],
		[Order_id],
		[Order_instrument],
		[Order_units],
		[Order_side],
		[Order_type],
		[Order_time],
		[Order_price],
		[Order_takeProfit],
		[Order_stopLoss],
		[Order_expiry],
		[Order_upperBound],
		[Order_lowerBound],
		[Order_trailingStop],
		[TradeData_id],
		[TradeData_units],
		[TradeData_side],
		[TradeData_instrument],
		[TradeData_time],
		[TradeData_price],
		[TradeData_takeProfit],
		[TradeData_stopLoss],
		[TradeData_trailingStop],
		[TradeData_trailingAmount],
		[妥当性],
		[登録日時],
		[更新日時]
	FROM [OANDA_RealA].oanda.tOrderResponse as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_RealA_ACV].oanda.tOrderResponse as b
			WHERE a.[口座No] = b.[口座No] AND a.[通貨ペアNo] = b.[通貨ペアNo] AND a.[time] = b.[time]
		);

END
GO

