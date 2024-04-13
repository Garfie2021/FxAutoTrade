USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectOrderResponse]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectOrderResponse]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		 a.[通貨ペアNo]
		,b.[ペア名] as 通貨ペア名
		,a.[time]
		,a.[instrument]
		,a.[BS開始]
		,a.[price]
		,a.[Order_id]
		,a.[Order_instrument]
		,a.[Order_units]
		,a.[Order_side]
		,a.[Order_type]
		,a.[Order_time]
		,a.[Order_price]
		,a.[Order_takeProfit]
		,a.[Order_stopLoss]
		,a.[Order_expiry]
		,a.[Order_upperBound]
		,a.[Order_lowerBound]
		,a.[Order_trailingStop]
		,a.[TradeData_id]
		,a.[TradeData_units]
		,a.[TradeData_side]
		,a.[TradeData_instrument]
		,a.[TradeData_time]
		,a.[TradeData_price]
		,a.[TradeData_takeProfit]
		,a.[TradeData_stopLoss]
		,a.[TradeData_trailingStop]
		,a.[TradeData_trailingAmount]
	FROM [oanda].[tOrderResponse] as a LEFT JOIN [cmn].[t通貨ペアMst] as b 
		ON a.[通貨ペアNo] = b.[No]
	where a.口座No = @口座No AND @from <= a.[time] and a.[time] < @to
	order by a.[time]

END
GO
