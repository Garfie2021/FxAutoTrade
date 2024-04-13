USE [OANDA_RealA]
GO

DROP PROCEDURE [acv].[spSave_oder_tリミット変更History]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oder_tリミット変更History]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_RealA_ACV].oder.tリミット変更History(
		[口座No],
		[通貨ペアNo],
		[日時],
		[リミット],
		[差分リミット通常],
		[OANDA_Trade_ID],
		[買いSwap],
		[売りSwap],
		[Swap判定],
		[買いRate],
		[売りRate],
		[売買判定],
		[売買],
		[保持ポジション],
		[BS_WMA判定_15m],
		[BS判定_15m],
		[BS開始],
		[BS判定_前],
		[BS判定_今],
		[登録日時],
		[更新日時],
		[差分リミットBS],
		[OANDA_Trade_Side],
		[OANDA_Trade_Price],
		[OANDA_Trade_TakeProfit])
	SELECT 
		[口座No],
		[通貨ペアNo],
		[日時],
		[リミット],
		[差分リミット通常],
		[OANDA_Trade_ID],
		[買いSwap],
		[売りSwap],
		[Swap判定],
		[買いRate],
		[売りRate],
		[売買判定],
		[売買],
		[保持ポジション],
		[BS_WMA判定_15m],
		[BS判定_15m],
		[BS開始],
		[BS判定_前],
		[BS判定_今],
		[登録日時],
		[更新日時],
		[差分リミットBS],
		[OANDA_Trade_Side],
		[OANDA_Trade_Price],
		[OANDA_Trade_TakeProfit]
	FROM [OANDA_RealA].oder.tリミット変更History as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_RealA_ACV].oder.tリミット変更History as b
			WHERE a.[口座No] = b.[口座No] AND a.[通貨ペアNo] = b.[通貨ペアNo] AND a.日時 = b.日時
		);

END
GO

