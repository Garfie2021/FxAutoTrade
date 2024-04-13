USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oder].[tCloseHistory](
	[口座No]				[int]		NOT NULL,
	[日時]					[datetime]	NOT NULL,
	[クローズ種別]			[tinyint]	NOT NULL,	-- なんの処理でクローズしたのか
	[通貨ペアNo]			[tinyint]	NULL,
	[OrderData_StartDay1]	[datetime]	NULL,
	[OrderData_EndDay1]		[datetime]	NULL,
	[買いSwap]			[float]			NULL,
	[売りSwap]			[float]			NULL,
	[Swap判定]			[varchar](1)	NULL,		-- 0:売り　1:買い
	[買いRate]			[float]			NULL,
	[売りRate]			[float]			NULL,
	[売買判定]			[varchar](1)	NULL,		-- S:売り　B:買い
	[売買]				[bit]			NULL,		-- 0:売り　1:買い	※最終的に判断された売買判定
	[保持ポジション]	[varchar](1)	NULL,		-- NULL:保持ポジション無し　0:売り　1:買い
	[BS_WMA判定_15m]	[varchar](1)	NULL,		-- S:売り　B:買い
	[BS判定_15m]		[varchar](1)	NULL,		-- S:売り　B:買い
	[BS開始]			[bit]			NULL,		-- 0:BB開始ではなくWMA判定　1:BB開始
	[BS判定_前]			[varchar](1)	NULL,		-- B:BonusStage中　ブランク:BonusStageではない
	[BS判定_今]			[varchar](1)	NULL,		-- B:BonusStage中　ブランク:BonusStageではない
	[差分リミット通常]	[float]			NULL,
	[差分リミットBS]	[float]			NULL,
	[ロスカット余剰金]	[int]			NULL,
	[Oanda_TradeData_id]				[BigInt]		NULL,
	[Oanda_TradeData_side]				[varchar](10)	NULL,
    [Oanda_TradeData_instrument]		[varchar](10)	NULL,
    [Oanda_TradeData_time]				[datetime]		NULL,
    [Oanda_TradeData_price]				[float]			NULL,
    [Oanda_TradeData_units]				[int]			NULL,
    [Oanda_TradeData_takeProfit]		[float]			NULL,
    [Oanda_TradeData_stopLoss]			[float]			NULL,
    [Oanda_TradeData_trailingStop]		[int]			NULL,
    [Oanda_TradeData_trailingAmount]	[float]			NULL,
	[登録日時]	[datetime]		NULL,
	[更新日時]	[datetime]		NULL
CONSTRAINT [PK_tCloseHistory] PRIMARY KEY CLUSTERED 
(
	[口座No]		ASC,
	[日時]			ASC,
	[クローズ種別]	ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
