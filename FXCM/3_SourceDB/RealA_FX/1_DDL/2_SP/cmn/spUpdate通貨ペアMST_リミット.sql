USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spUpdate通貨ペアMST_リミット]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 昨日、変動のあったRate幅の3分の1に設定し直す
-- ジョブで10分おきに実行する。
CREATE PROCEDURE [cmn].[spUpdate通貨ペアMST_リミット]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @通貨ペアNo tinyint = 0;

	WHILE @通貨ペアNo < 44
	BEGIN

		UPDATE [cmn].[t通貨ペアMst]
		SET	[差分リミット] = (SELECT top 1 ABS([買いRate_終値] - [買いRate_始値] ) / 3
								FROM (
									SELECT top 2 [買いRate_始値], [買いRate_終値], [StartDate]
									FROM [hstr].[tDay1]
									WHERE [No] = @通貨ペアNo
									ORDER BY [StartDate] DESC
								) as T
								ORDER BY [StartDate])
		WHERE [No] = @通貨ペアNo;

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END
GO
/*
*/
