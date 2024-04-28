USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [cnt].[sp���t��Sec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp���t��Sec]
AS
BEGIN

	SELECT StartDate as StartDate, count(*) as cnt 
	FROM hstr.tSec
	GROUP BY StartDate
	ORDER BY StartDate DESC;

END
GO
/*
*/