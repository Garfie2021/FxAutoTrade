USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [cnt].[sp���t��Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp���t��Min1]
AS
BEGIN

	SELECT StartDate as StartDate, count(*) as cnt 
	FROM hstr.tMin1
	GROUP BY StartDate
	ORDER BY StartDate DESC;

END
GO
/*
*/