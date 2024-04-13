USE OANDA_DemoB
GO

DROP PROCEDURE [rate].[spInsertHistory_Sec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertHistory_Sec]
	 @通貨ペアNo tinyint
	,@StartDate datetime
	,@買いSwap float
	,@買いRate float
	,@売りSwap float
	,@売りRate float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [hstr].[tSec] (
		[通貨ペアNo],
		[StartDate],
		[買いSwap],
		[買いRate],
		[売りSwap],
		[売りRate]
	) VALUES (
		@通貨ペアNo,
		@StartDate,
		@買いSwap,
		@買いRate,
		@売りSwap,
		@売りRate
	);

END
GO
