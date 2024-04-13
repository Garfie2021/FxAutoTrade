USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_oanda_tDeleteTradeResponse]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_oanda_tDeleteTradeResponse]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_DemoB_ACV].oanda.tDeleteTradeResponse(
		[口座No],
		[id],
		[price],
		[instrument],
		[profit],
		[side],
		[time],
		[登録日時],
		[更新日時])
	SELECT 
		[口座No],
		[id],
		[price],
		[instrument],
		[profit],
		[side],
		[time],
		[登録日時],
		[更新日時]
	FROM [OANDA_DemoB].oanda.tDeleteTradeResponse as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].oanda.tDeleteTradeResponse as b
			WHERE a.[口座No] = b.[口座No] AND a.[id] = b.[id]
		);

END
GO

