USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_oanda_tOrder_注文削除]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tOrder_注文削除]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_DemoB_ACV].oanda.tOrder_注文削除(
		[口座No],
		[日時],
		[注文削除対象id],
		[id],
		[instrument],
		[units],
		[side],
		[type],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[expiry],
		[upperBound],
		[lowerBound],
		[trailingStop],
		[登録日時],
		[更新日時])
	SELECT 
		[口座No],
		[日時],
		[注文削除対象id],
		[id],
		[instrument],
		[units],
		[side],
		[type],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[expiry],
		[upperBound],
		[lowerBound],
		[trailingStop],
		[登録日時],
		[更新日時]
	FROM [OANDA_DemoB].oanda.tOrder_注文削除 as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].oanda.tOrder_注文削除 as b
			WHERE a.[口座No] = b.[口座No] AND a.[日時] = b.[日時] AND a.[注文削除対象id] = b.[注文削除対象id] AND a.[instrument] = b.[instrument]
		);

END
GO

