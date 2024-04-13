USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [cnt].[sp通貨ペア別Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp通貨ペア別Min1]
AS
BEGIN

	SELECT [cmn].[t通貨ペアMst].[No] as 通貨ペアNo, [cmn].[t通貨ペアMst].ペア名 as 通貨ペア名, count(*) as cnt 
	FROM hstr.tMin1 INNER JOIN [cmn].[t通貨ペアMst] ON hstr.tMin1.通貨ペアNo = [cmn].[t通貨ペアMst].[No]
	GROUP BY [cmn].[t通貨ペアMst].[No], [cmn].[t通貨ペアMst].ペア名
	ORDER BY [cmn].[t通貨ペアMst].ペア名;

END
GO
/*
*/