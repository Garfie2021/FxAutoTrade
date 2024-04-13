USE OANDA_DemoB
GO

DROP PROCEDURE [cnt].[sp通貨ペア数]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp通貨ペア数]
	@通貨ペア数	tinyint	output
AS
BEGIN

	SELECT @通貨ペア数 = COUNT(*) FROM  cmn.t通貨ペアMst;

END
GO

