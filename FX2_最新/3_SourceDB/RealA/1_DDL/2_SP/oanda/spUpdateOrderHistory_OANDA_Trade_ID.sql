USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spUpdateOrderHistory_OANDA_Trade_ID]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_OANDA_Trade_ID]
    @口座No				Int,
	@通貨ペアNo			tinyint,
	@日時				datetime,
	@Oanda_TradeData_id	bigint
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [oder].[tOrderHistory2]
	SET
		[Oanda_TradeData_id] = @Oanda_TradeData_id
	WHERE 
		口座No = @口座No AND [通貨ペアNo] = @通貨ペアNo AND [日時] = @日時
	;

END
GO
