USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spChk注文対象]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk注文対象]
	@通貨ペアNo	tinyint,
	@注文対象	tinyint OUTPUT
AS
BEGIN

	SELECT @注文対象 = [注文対象]
	FROM [oder].[tOrderSettings]
	WHERE [通貨ペアNo] = @通貨ペアNo;

END
GO
/*
*/

