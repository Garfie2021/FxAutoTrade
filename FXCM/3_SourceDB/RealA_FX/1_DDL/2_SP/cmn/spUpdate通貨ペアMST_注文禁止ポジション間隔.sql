USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spUpdate通貨ペアMST_注文禁止ポジション間隔]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spUpdate通貨ペアMST_注文禁止ポジション間隔]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @注文禁止ポジション間隔 float;

	WHILE @通貨ペアNo < 44
	BEGIN
		
		SELECT top 1 @注文禁止ポジション間隔 = ([買いRate_高値] - [買いRate_安値]) / 2	-- 厳密な比較を必要としないので「買いRate」のみ比較に使う。
		FROM [hstr].[tDay1]
		WHERE [通貨ペアNo] = @通貨ペアNo
		ORDER BY [StartDate] DESC;

		UPDATE [cmn].[t通貨ペアMst]
		SET [注文禁止ポジション間隔] = @注文禁止ポジション間隔
		WHERE [No] = @通貨ペアNo

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END
GO
/*
*/
