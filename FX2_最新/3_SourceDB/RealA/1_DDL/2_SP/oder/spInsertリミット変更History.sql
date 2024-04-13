USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spInsertリミット変更History]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spInsertリミット変更History]
    @口座No					Int,
	@通貨ペアNo				tinyint,
	@OANDA_Trade_Side		varchar(5),
	@OANDA_Trade_ID			bigint,
	@OANDA_Trade_Price		float,
	@OANDA_Trade_TakeProfit	float,
	@リミット			varchar(50),
	@差分リミット通常	float,
	@差分リミットBS		float,
	@買いSwap			float,
	@売りSwap			float,
	@Swap判定			varchar(1),
	@買いRate			float,
	@売りRate			float,
	@売買判定			varchar(1),
	@売買				bit,
	@保持ポジション		varchar(1),
	@BS_WMA判定_15m		varchar(1),
	@BS判定_15m			varchar(1),
	@BS開始				bit,
	@BS判定_前			varchar(1),
	@BS判定_今			varchar(1)
AS
BEGIN

	SET NOCOUNT ON;


	INSERT INTO [oder].[tリミット変更History] (
		口座No,
		通貨ペアNo,
		日時,
		OANDA_Trade_Side,
		OANDA_Trade_ID,
		OANDA_Trade_Price,
		OANDA_Trade_TakeProfit,
		リミット,
		差分リミット通常,
		差分リミットBS,
		買いSwap,
		売りSwap,
		Swap判定,
		買いRate,
		売りRate,
		売買判定,
		売買,
		保持ポジション,
		BS_WMA判定_15m,
		BS判定_15m,
		BS開始,
		BS判定_前,
		BS判定_今,
		登録日時
	) VALUES (
		@口座No,
		@通貨ペアNo,
		GETDATE(),
		@OANDA_Trade_Side,
		@OANDA_Trade_ID,
		@OANDA_Trade_Price,
		@OANDA_Trade_TakeProfit,
		@リミット,
		@差分リミット通常,
		@差分リミットBS,
		@買いSwap,
		@売りSwap,
		@Swap判定,
		@買いRate,
		@売りRate,
		@売買判定,
		@売買,
		@保持ポジション,
		@BS_WMA判定_15m,
		@BS判定_15m,
		@BS開始,
		@BS判定_前,
		@BS判定_今,
		GETDATE()
	);


END
GO
