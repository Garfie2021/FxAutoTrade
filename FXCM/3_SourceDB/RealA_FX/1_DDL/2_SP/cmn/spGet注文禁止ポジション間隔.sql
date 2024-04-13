USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spGet注文禁止ポジション間隔]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet注文禁止ポジション間隔]
	@通貨ペアNo				tinyint,
	@注文禁止ポジション間隔	float	output
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @注文禁止ポジション間隔 = [注文禁止ポジション間隔]
	FROM [cmn].[t通貨ペアMst]
	WHERE [No] = @通貨ペアNo;

END
GO
/*
*/
