USE [OANDA_RealA]
GO

DROP PROCEDURE [acv].[spSave_oanda_tTrade]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tTrade]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_RealA_ACV].oanda.tTrade(
		[口座No],
		[id],
		[units],
		[side],
		[instrument],
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
		[id],
		[units],
		[side],
		[instrument],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[trailingStop],
		[trailingAmount],
		[登録日時],
		[更新日時]
	FROM [OANDA_RealA].oanda.tTrade as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_RealA_ACV].oanda.tTrade as b
			WHERE a.[口座No] = b.[口座No] AND a.[id] = b.[id]
		);

END
GO

