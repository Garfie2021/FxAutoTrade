USE [DemoA_FX]
GO

DROP PROCEDURE [oder].[spUpdateOrderHistory_OrderId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderHistory_OrderId]
	@通貨ペアNo		tinyint,
	@日時			datetime,
	@OpenOrderID	varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [oder].[tOrderHistory]
	SET
		[OpenOrderID] = @OpenOrderID
	WHERE 
		[通貨ペアNo] = @通貨ペアNo AND [日時] = @日時
	;

END
GO
