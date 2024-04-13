USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spUpdateOrderStatus_取引状況]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderStatus_取引状況]
	@通貨ペアNo	tinyint,
	@注文対象	varchar(100)
AS
BEGIN

	UPDATE [oder].[tOrderStatus]
	SET [取引状況] = @注文対象
	WHERE [通貨ペアNo] = @通貨ペアNo;

END
GO
/*
*/

