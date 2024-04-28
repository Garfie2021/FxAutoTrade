USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spGetSUM���v]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spGetSUM���v]
    @����No		Int,
	@FromDate	DateTime,
	@ToDate		DateTime,
	@���v		FLOAT			output
AS
BEGIN

	SET @���v = 0;

	SELECT @���v = SUM([pl]) + SUM([interest])
	FROM [oanda].[tTransaction]
	WHERE ����No = @����No AND [type] = 'CloseOrder' AND 
		(@FromDate <= [Time]) AND ([Time] < @ToDate)

END
GO

