USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spRateダウンロード対象通貨ペア確認]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spRateダウンロード対象通貨ペア確認]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT A.通貨ペアNo, B.ペア名
	FROM [OANDA_DemoB].[swap].[tSwap手動登録_Day1] as A INNER JOIN [OANDA_DemoB].[cmn].[t通貨ペアMst] AS B
		ON A.通貨ペアNo = B.No
	group by A.通貨ペアNo, B.ペア名
	ORDER BY B.ペア名;

END
GO
