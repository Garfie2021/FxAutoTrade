USE OANDA_RealA
GO

DROP PROCEDURE [swap].[spInsertSwap手動登録_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spInsertSwap手動登録_Day1]
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@買いSwap		float,
	@売りSwap		float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_RealA].[swap].[tSwap手動登録_Day1](
		[通貨ペアNo],
		[StartDate],
		[買いSwap],
		[売りSwap],
		[登録日時],
		[更新日時]
    ) VALUES (
		@通貨ペアNo,
		@StartDate,
		@買いSwap,
		@売りSwap,
		GETDATE(),
		GETDATE()
	);

END
GO
