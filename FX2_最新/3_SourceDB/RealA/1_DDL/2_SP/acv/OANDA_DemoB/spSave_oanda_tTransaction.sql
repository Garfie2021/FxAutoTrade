USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_oanda_tTransaction]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tTransaction]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_DemoB_ACV].oanda.tTransaction(
		[口座No],
		[id],
		[accountId],
		[time],
		[type],
		[instrument],
		[side],
		[units],
		[price],
		[lowerBound],
		[upperBound],
		[takeProfitPrice],
		[stopLossPrice],
		[trailingStopLossDistance],
		[pl],
		[interest],
		[accountBalance],
		[tradeId],
		[orderId],
		[tradeOpened_id],
		[tradeOpened_units],
		[tradeOpened_side],
		[tradeOpened_instrument],
		[tradeOpened_time],
		[tradeOpened_price],
		[tradeOpened_takeProfit],
		[tradeOpened_stopLoss],
		[tradeOpened_trailingStop],
		[tradeOpened_trailingAmount],
		[tradeReduced_id],
		[tradeReduced_units],
		[tradeReduced_side],
		[tradeReduced_instrument],
		[tradeReduced_time],
		[tradeReduced_price],
		[tradeReduced_takeProfit],
		[tradeReduced_stopLoss],
		[tradeReduced_trailingStop],
		[tradeReduced_trailingAmount],
		[reason],
		[expiry],
		[登録日時],
		[更新日時])
	SELECT 
		[口座No],
		[id],
		[accountId],
		[time],
		[type],
		[instrument],
		[side],
		[units],
		[price],
		[lowerBound],
		[upperBound],
		[takeProfitPrice],
		[stopLossPrice],
		[trailingStopLossDistance],
		[pl],
		[interest],
		[accountBalance],
		[tradeId],
		[orderId],
		[tradeOpened_id],
		[tradeOpened_units],
		[tradeOpened_side],
		[tradeOpened_instrument],
		[tradeOpened_time],
		[tradeOpened_price],
		[tradeOpened_takeProfit],
		[tradeOpened_stopLoss],
		[tradeOpened_trailingStop],
		[tradeOpened_trailingAmount],
		[tradeReduced_id],
		[tradeReduced_units],
		[tradeReduced_side],
		[tradeReduced_instrument],
		[tradeReduced_time],
		[tradeReduced_price],
		[tradeReduced_takeProfit],
		[tradeReduced_stopLoss],
		[tradeReduced_trailingStop],
		[tradeReduced_trailingAmount],
		[reason],
		[expiry],
		[登録日時],
		[更新日時]
	FROM [OANDA_DemoB].oanda.tTransaction as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].oanda.tTransaction as b
			WHERE a.[口座No] = b.[口座No] AND a.[id] = b.[id] AND a.[accountId] = b.[accountId] AND a.[time] = b.[time]
		);

END
GO

