USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oder].[tOrderHistory2](
	[口座No]			int				NOT NULL,
	[通貨ペアNo]		[tinyint]		NOT NULL,
	[日時]				[datetime]		NOT NULL,
	[買いSwap]			[float]			NULL,
	[売りSwap]			[float]			NULL,
	[Swap判定]			[varchar](1)	NULL,		-- 0:売り　1:買い
	[買いRate]			[float]			NULL,
	[売りRate]			[float]			NULL,
	[売買判定]			[varchar](1)	NULL,		-- S:売り　B:買い
	[売買]				[bit]			NULL,		-- 0:売り　1:買い	※最終的に判断された売買判定
	[保持ポジション]	[varchar](1)	NULL,		-- NULL:保持ポジション無し　0:売り　1:買い
	[BS_Min15_買いWMAs14]			[float]		NULL,
	[BS_Min15_買いWMAs14角度]		[float]		NULL,
	[BS_Min15_買いWMAs14角度シグマ]	[float]		NULL,
	[BS_Min15_売りWMAs14]			[float]		NULL,
	[BS_Min15_売りWMAs14角度]		[float]		NULL,
	[BS_Min15_売りWMAs14角度シグマ]	[float]		NULL,
	[BS_WMA判定_15m]		[varchar](1)	NULL,		-- S:売り　B:買い
	[BS判定_15m]			[varchar](1)	NULL,		-- S:売り　B:買い
	[BS開始]				[bit]			NULL,		-- 0:BB開始ではなくWMA判定　1:BB開始
	[BS判定_前]				[varchar](1)	NULL,		-- B:BonusStage中　ブランク:BonusStageではない
	[BS判定_今]				[varchar](1)	NULL,		-- B:BonusStage中　ブランク:BonusStageではない
	[差分リミット通常]		[float]			NULL,
	[差分リミットBS]		[float]			NULL,
	[ポジション追加_成行_ストップ]		[float]			NULL,
	[ポジション追加_成行_リミット]		[float]			NULL,
	[ポジション追加時のリミット]		[varchar](10)	NULL,
	[注文単位]					[int]		NULL,
	[注文単位を割る値]			[int]		NULL,
	[ロスカット余剰金]			[int]		NULL,
	[ロスカット余剰金調整値]	[int]		NULL,
	[証拠金倍率]				[float]		NULL,
	[Month1_Start]			[datetime]	NULL,
	[Month1_End]			[datetime]	NULL,
	[Month1_買いWMAs2]		[float]		NULL,
	[Month1_買いWMAs2角度]	[float]		NULL,
	[Month1_買いWMAs14]		[float]		NULL,
	[Month1_売りWMAs2]		[float]		NULL,
	[Month1_売りWMAs2角度]	[float]		NULL,
	[Month1_売りWMAs14]		[float]		NULL,
	[Week1_Start]			[datetime]	NULL,
	[Week1_End]				[datetime]	NULL,
	[Week1_買いWMAs2]		[float]		NULL,
	[Week1_買いWMAs2角度]	[float]		NULL,
	[Week1_買いWMAs14]		[float]		NULL,
	[Week1_売りWMAs2]		[float]		NULL,
	[Week1_売りWMAs2角度]	[float]		NULL,
	[Week1_売りWMAs14]		[float]		NULL,
	[Day1_Start]			[datetime]	NULL,
	[Day1_End]				[datetime]	NULL,
	[Day1_買いWMAs2]		[float]		NULL,
	[Day1_買いWMAs14]		[float]		NULL,
	[Day1_買いWMAs2角度]	[float]		NULL,
	[Day1_売りWMAs2]		[float]		NULL,
	[Day1_売りWMAs14]		[float]		NULL,
	[Day1_売りWMAs2角度]	[float]		NULL,
	[Hour1_Start]			[datetime]	NULL,
	[Hour1_End]				[datetime]	NULL,
	[Hour1_買いWMAs2]		[float]		NULL,
	[Hour1_買いWMAs2角度]	[float]		NULL,
	[Hour1_買いWMAs14]		[float]		NULL,
	[Hour1_売りWMAs2]		[float]		NULL,
	[Hour1_売りWMAs2角度]	[float]		NULL,
	[Hour1_売りWMAs14]		[float]		NULL,
	[Min15_Start]			[datetime]	NULL,
	[Min15_End]				[datetime]	NULL,
	[Min15_買いWMAs2]		[float]		NULL,
	[Min15_買いWMAs2角度]	[float]		NULL,
	[Min15_買いWMAs14]		[float]		NULL,
	[Min15_売りWMAs2]		[float]		NULL,
	[Min15_売りWMAs2角度]	[float]		NULL,
	[Min15_売りWMAs14]		[float]		NULL,
	[Min5_Start]			[datetime]		NULL,
	[Min5_End]				[datetime]		NULL,
	[Min5_買いWMAs2]		[float]			NULL,
	[Min5_買いWMAs2角度]	[float]			NULL,
	[Min5_買いWMAs14]		[float]			NULL,
	[Min5_売りWMAs2]		[float]			NULL,
	[Min5_売りWMAs2角度]	[float]			NULL,
	[Min5_売りWMAs14]		[float]			NULL,
	[Min1_Start]			[datetime]		NULL,
	[Min1_End]				[datetime]		NULL,
	[Min1_買いWMAs2]		[float]			NULL,
	[Min1_買いWMAs2角度]	[float]			NULL,
	[Min1_買いWMAs14]		[float]			NULL,
	[Min1_売りWMAs2]		[float]			NULL,
	[Min1_売りWMAs2角度]	[float]			NULL,
	[Min1_売りWMAs14]		[float]			NULL,
	[OpenOrderID]			[varchar](50)	NULL,
	[TradeID]				[varchar](50)	NULL,
	[CloseOrderID]			[varchar](50)	NULL,
	[Close日時]				[datetime]		NULL,
	[Oanda_TradeData_id]	BigInt			NULL,
	[妥当性]				varchar(1000)	NULL,
	[登録日時]				datetime		NULL,
	[更新日時]				datetime		NULL,
CONSTRAINT [PK_tOrderHistory2] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
