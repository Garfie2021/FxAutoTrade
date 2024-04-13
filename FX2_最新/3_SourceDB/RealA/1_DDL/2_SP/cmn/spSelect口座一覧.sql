USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spSelect口座一覧]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spSelect口座一覧]
	--@DemoReal	tinyint,
	--@有効無効	tinyint
AS
BEGIN

	SELECT
		[口座No],
		[OandaAccountId],
		[OandaAccessToken],
		[FX会社],
		[FxServerContry],
		[個人法人],
		[DemoReal],
		[有効無効],
		[取引証拠金上限],
		[毎朝の自動注文開始を行う]
	FROM [cmn].[t口座マスタ]
	ORDER BY [口座No];

END
GO

