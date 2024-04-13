USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spInsert口座マスタ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spInsert口座マスタ]
	@OandaAccountId		int,
	@OandaAccessToken	varchar(100),
	@FX会社				tinyint,
	@FxServerContry		tinyint,
	@個人法人			tinyint,
	@DemoReal			tinyint,
	@有効無効			tinyint,
	@取引証拠金上限		int,
	@毎朝の自動注文開始を行う	tinyint
AS
BEGIN

	SET NOCOUNT ON;

	declare @口座No	int = (SELECT MAX(口座No) + 1 FROM [cmn].[t口座マスタ]);

	if @口座No is null
	begin
		set @口座No = 0;
	end;

	INSERT INTO [cmn].[t口座マスタ] (
		[口座No],
		[OandaAccountId],
		[OandaAccessToken],
		[FX会社],
		[FxServerContry],
		[個人法人],
		[DemoReal],
		[有効無効],
		[取引証拠金上限],
		[毎朝の自動注文開始を行う],
		[登録日時]
     ) VALUES (
        @口座No,
        @OandaAccountId,
        @OandaAccessToken,
		@FX会社,
		@FxServerContry,
		@個人法人,
		@DemoReal,
		@有効無効,
		@取引証拠金上限,
		@毎朝の自動注文開始を行う,
		GETDATE()
	);

END
GO
/*
*/
