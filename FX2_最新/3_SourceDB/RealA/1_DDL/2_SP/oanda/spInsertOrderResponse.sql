USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spInsertOrderResponse]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spInsertOrderResponse]
    @口座No			Int,
	@通貨ペアNo		tinyint,
	@time			DateTime,
	@instrument		VarChar(50),
	@BS開始			Bit,
	@price			Float,
	@Order_id		BigInt,
	@Order_instrument	VarChar(50),
	@Order_units	Int,
	@Order_side		VarChar(50),
	@Order_type		VarChar(50),
	@Order_time		DateTime,
	@Order_price		Float,
	@Order_takeProfit	Float,
	@Order_stopLoss		Float,
	@Order_expiry		VarChar,
	@Order_upperBound	Float,
	@Order_lowerBound	Float,
	@Order_trailingStop	Float,
	@TradeData_id		BigInt,
	@TradeData_units	Int,
	@TradeData_side		VarChar(50),
	@TradeData_instrument	VarChar(50),
	@TradeData_time			DateTime,
	@TradeData_price		Float,
	@TradeData_takeProfit	Float,
	@TradeData_stopLoss		Float,
	@TradeData_trailingStop		Int,
	@TradeData_trailingAmount	Float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oanda].[tOrderResponse](
		口座No,
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
		[TradeData_trailingAmount]
    ) VALUES (
		@口座No,
		@通貨ペアNo,
		@time,
		@instrument,
		@BS開始,
		@price,
		@Order_id,
		@Order_instrument,
		@Order_units,
		@Order_side,
		@Order_type,
		@Order_time,
		@Order_price,
		@Order_takeProfit,
		@Order_stopLoss,
		@Order_expiry,
		@Order_upperBound,
		@Order_lowerBound,
		@Order_trailingStop,
		@TradeData_id,
		@TradeData_units,
		@TradeData_side,
		@TradeData_instrument,
		@TradeData_time,
		@TradeData_price,
		@TradeData_takeProfit,
		@TradeData_stopLoss,
		@TradeData_trailingStop,
		@TradeData_trailingAmount
	);

END
GO
