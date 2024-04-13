USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oder].[tリミット変更History](
	[口座No]					int				NOT NULL,
	[通貨ペアNo]				[tinyint]		NOT NULL,
	[日時]						[datetime]		NOT NULL,
	[売買モード]				[bit]			NULL,		-- 0:売り　1:買い
	[OANDA_Trade_Side]			[varchar](5)	NULL,		-- buy:売り　sell:買い
	[OANDA_Trade_ID]			[bigint]		NULL,
	[OANDA_Trade_Price]			[float]			NULL,
	[OANDA_Trade_TakeProfit]	[float]			NULL,
	[リミット]					[varchar](50)	NULL,
	[差分リミット通常]			[float]			NULL,
	[差分リミットBS]			[float]			NULL,
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
	[登録日時]			Datetime		NULL,
	[更新日時]			datetime		NULL,
CONSTRAINT [PK_tリミット変更History] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
