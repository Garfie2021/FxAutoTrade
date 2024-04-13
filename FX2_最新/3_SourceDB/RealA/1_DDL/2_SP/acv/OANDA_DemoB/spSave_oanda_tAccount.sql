USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_oanda_tAccount]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tAccount]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_DemoB_ACV].oanda.tAccount(
		[口座No],
		[日時],
		[accountId],
		[accountName],
		[accountCurrency],
		[marginRate],
		[balance],
		[unrealizedPl],
		[realizedPl],
		[marginUsed],
		[marginAvail],
		[openTrades],
		[openOrders],
		[登録日時],
		[更新日時])
	SELECT 
		[口座No],
		[日時],
		[accountId],
		[accountName],
		[accountCurrency],
		[marginRate],
		[balance],
		[unrealizedPl],
		[realizedPl],
		[marginUsed],
		[marginAvail],
		[openTrades],
		[openOrders],
		[登録日時],
		[更新日時]
	FROM [OANDA_DemoB].oanda.tAccount as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].oanda.tAccount as b
			WHERE a.[口座No] = b.[口座No] AND a.日時 = b.日時
		);

END
GO

