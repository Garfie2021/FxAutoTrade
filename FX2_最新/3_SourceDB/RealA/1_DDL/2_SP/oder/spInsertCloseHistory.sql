USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spInsertCloseHistory]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spInsertCloseHistory]
	@口座No					int,
	@日時					datetime,
	@クローズ種別			tinyint,
	@通貨ペアNo				tinyint,
	@OrderData_StartDay1	datetime,
	@OrderData_EndDay1		datetime,
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
	@BS判定_今			varchar(1),
	@差分リミット通常	float,
	@差分リミットBS		float,
	@ロスカット余剰金	int,
	@Oanda_TradeData_id				bigint,
	@Oanda_TradeData_side			varchar(10),
	@Oanda_TradeData_instrument		varchar(10),
	@Oanda_TradeData_time			datetime,
	@Oanda_TradeData_price			float,
	@Oanda_TradeData_units			int,
	@Oanda_TradeData_takeProfit		float,
	@Oanda_TradeData_stopLoss		float,
	@Oanda_TradeData_trailingStop	int,
	@Oanda_TradeData_trailingAmount	float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oder].[tCloseHistory](
         [口座No]
        ,[日時]
        ,[クローズ種別]
        ,[通貨ペアNo]
        ,[OrderData_StartDay1]
        ,[OrderData_EndDay1]
        ,[買いSwap]
        ,[売りSwap]
        ,[Swap判定]
        ,[買いRate]
        ,[売りRate]
        ,[売買判定]
        ,[売買]
        ,[保持ポジション]
        ,[BS_WMA判定_15m]
        ,[BS判定_15m]
        ,[BS開始]
        ,[BS判定_前]
        ,[BS判定_今]
        ,[差分リミット通常]
        ,[差分リミットBS]
        ,[ロスカット余剰金]
        ,[Oanda_TradeData_id]
        ,[Oanda_TradeData_side]
        ,[Oanda_TradeData_instrument]
        ,[Oanda_TradeData_time]
        ,[Oanda_TradeData_price]
        ,[Oanda_TradeData_units]
        ,[Oanda_TradeData_takeProfit]
        ,[Oanda_TradeData_stopLoss]
        ,[Oanda_TradeData_trailingStop]
        ,[Oanda_TradeData_trailingAmount]
        ,[登録日時]
     ) VALUES (
           @口座No,
           @日時,
           @クローズ種別,
           @通貨ペアNo,
           @OrderData_StartDay1,
           @OrderData_EndDay1,
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
           @差分リミット通常,
           @差分リミットBS,
           @ロスカット余剰金,
           @Oanda_TradeData_id,
           @Oanda_TradeData_side,
           @Oanda_TradeData_instrument,
           @Oanda_TradeData_time,
           @Oanda_TradeData_price,
           @Oanda_TradeData_units,
           @Oanda_TradeData_takeProfit,
           @Oanda_TradeData_stopLoss,
           @Oanda_TradeData_trailingStop,
           @Oanda_TradeData_trailingAmount,
           GETDATE()
	);

END
GO
