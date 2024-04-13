USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_swap_tSwap手動登録_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_swap_tSwap手動登録_Day1]
AS
BEGIN

	SET NOCOUNT ON;


	INSERT INTO [OANDA_DemoB_ACV].swap.tSwap手動登録_Day1(
		[通貨ペアNo],
		[StartDate],
		[買いSwap],
		[売りSwap],
		[登録日時],
		[更新日時])
	SELECT 
		[通貨ペアNo],
		[StartDate],
		[買いSwap],
		[売りSwap],
		[登録日時],
		[更新日時]
	FROM [OANDA_DemoB].swap.tSwap手動登録_Day1 as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].swap.tSwap手動登録_Day1 as b
			WHERE a.[通貨ペアNo] = b.[通貨ペアNo] AND a.[StartDate] = b.[StartDate]
		);

END
GO

