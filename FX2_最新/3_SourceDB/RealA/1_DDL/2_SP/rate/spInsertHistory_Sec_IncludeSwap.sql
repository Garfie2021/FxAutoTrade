USE OANDA_DemoB
GO

DROP PROCEDURE [rate].[spInsertHistory_Sec_IncludeSwap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertHistory_Sec_IncludeSwap]
	 @通貨ペアNo tinyint
	,@StartDate datetime
	,@買いRate float
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
		[売りRate],
		[登録日時]
	) VALUES (
		@通貨ペアNo,
		@StartDate,
		(SELECT TOP 1 [買いSwap]
		 FROM [RealA_FX].[hstr].[tHour1]
		 where [通貨ペアNo] = @通貨ペアNo and [買いSwap] <> 0
		 order by [StartDate] desc),
		@買いRate,
		(SELECT TOP 1 [売りSwap]
		 FROM [RealA_FX].[hstr].[tHour1]
		 where [通貨ペアNo] = @通貨ペアNo and [売りSwap] <> 0
		 order by [StartDate] desc),
		@売りRate,
		GETDATE()
	);

END
GO
