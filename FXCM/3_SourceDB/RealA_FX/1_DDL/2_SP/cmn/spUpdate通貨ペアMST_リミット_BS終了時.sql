USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spUpdate通貨ペアMST_リミット_BS終了時]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ジョブで10分おきに実行する。
CREATE PROCEDURE [cmn].[spUpdate通貨ペアMST_リミット_BS終了時]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @通貨ペアNo tinyint = 0;

	WHILE @通貨ペアNo < 44
	BEGIN

		UPDATE [cmn].[t通貨ペアMst]
		SET	[買いリミット_BS終了時] = (SELECT top 1 [買いRate_高値]
										FROM (
											SELECT top 3 [買いRate_高値]
											FROM [hstr].[tHour1]
											WHERE [No] = @通貨ペアNo
											ORDER BY [StartDate] DESC
										) as T
										ORDER BY [買いRate_高値] DESC),
			[売りリミット_BS終了時] = (SELECT top 1 [売りRate_安値]
										FROM (
											SELECT top 3 [売りRate_安値]
											FROM [hstr].[tHour1]
											WHERE [No] = @通貨ペアNo
											ORDER BY [StartDate] DESC
										) as T
										ORDER BY [売りRate_安値])
		WHERE [No] = @通貨ペアNo;

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END
GO
/*
*/
