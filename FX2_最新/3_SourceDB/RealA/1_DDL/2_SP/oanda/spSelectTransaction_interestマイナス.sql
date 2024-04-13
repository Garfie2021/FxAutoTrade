USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectTransaction_interestマイナス]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectTransaction_interestマイナス]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		 [id]
		,[accountId]
		,[time]
		,[type]
		,[instrument]
		,[side]
		,[units]
		,[price]
		,[lowerBound]
		,[upperBound]
		,[takeProfitPrice]
		,[stopLossPrice]
		,[trailingStopLossDistance]
		,[pl]
		,[interest]
		,[accountBalance]
		,[tradeId]
		,[orderId]
		,[tradeOpened_id]
		,[tradeOpened_units]
		,[tradeOpened_side]
		,[tradeOpened_instrument]
		,[tradeOpened_time]
		,[tradeOpened_price]
		,[tradeOpened_takeProfit]
		,[tradeOpened_stopLoss]
		,[tradeOpened_trailingStop]
		,[tradeOpened_trailingAmount]
		,[tradeReduced_id]
		,[tradeReduced_units]
		,[tradeReduced_side]
		,[tradeReduced_instrument]
		,[tradeReduced_time]
		,[tradeReduced_price]
		,[tradeReduced_takeProfit]
		,[tradeReduced_stopLoss]
		,[tradeReduced_trailingStop]
		,[tradeReduced_trailingAmount]
		,[reason]
		,[expiry]
		,[登録日時]
	FROM [oanda].[tTransaction]
	where 口座No = @口座No AND @from <= [time] and [time] < @to and [instrument] < 0
	order by [time]

END
GO
