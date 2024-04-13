USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spUpdateOrderHistory_OrderId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_OrderId]
    @口座No			Int,
	@通貨ペアNo		tinyint,
	@日時			datetime,
	@OpenOrderID	varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [oder].[tOrderHistory2]
	SET
		[OpenOrderID] = @OpenOrderID
	WHERE 
		口座No = @口座No AND [通貨ペアNo] = @通貨ペアNo AND [日時] = @日時
	;

END
GO
