USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [hstr].[spGet最新Rate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spGet最新Rate]
	@通貨ペアNo	tinyint,
	@買いRate	float	output,
	@売りRate	float	output
AS
BEGIN

	SELECT TOP 1
		@買いRate = [買いRate],
		@売りRate = [売りRate]
	FROM [hstr].[tSec]
	where [通貨ペアNo] = @通貨ペアNo
	order by [StartDate] desc;

END
GO
/*
*/

