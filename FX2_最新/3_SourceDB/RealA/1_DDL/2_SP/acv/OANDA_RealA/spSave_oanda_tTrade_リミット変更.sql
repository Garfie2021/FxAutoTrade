USE [OANDA_RealA]
GO

DROP PROCEDURE [acv].[spSave_oanda_tTrade_リミット変更]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tTrade_リミット変更]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_RealA_ACV].oanda.tTrade_リミット変更(
		[口座No],
		[日時],
		[リミット変更対象id],
		[id],
		[instrument],
		[units],
		[side],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[trailingStop],
		[trailingAmount],
		[登録日時],
		[更新日時])
	SELECT 
		[口座No],
		[日時],
		[リミット変更対象id],
		[id],
		[instrument],
		[units],
		[side],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[trailingStop],
		[trailingAmount],
		[登録日時],
		[更新日時]
	FROM [OANDA_RealA].oanda.tTrade_リミット変更 as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_RealA_ACV].oanda.tTrade_リミット変更 as b
			WHERE a.[口座No] = b.[口座No] AND a.[日時] = b.[日時] AND a.[リミット変更対象id] = b.[リミット変更対象id] AND a.[instrument] = b.[instrument]
		);

END
GO

