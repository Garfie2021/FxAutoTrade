USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oder].[tOrderHistory2](
	[通貨ペアNo]		[tinyint]		NOT NULL,
	[日時]				[datetime]		NOT NULL,
	[買いSwap]			[float]			NOT NULL,
	[売りSwap]			[float]			NOT NULL,
	[Swap判定]			[bit]			NULL,		-- 0:売り　1:買い
	[買いRate]			[float]			NOT NULL,
	[売りRate]			[float]			NOT NULL,
	[売買判定]			[varchar](1)	NOT NULL,		-- S:売り　B:買い
	[売買]				[bit]			NOT NULL,		-- 0:売り　1:買い	※最終的に判断された売買判定
	[保持ポジション]	[bit]			NULL,		-- NULL:保持ポジション無し　0:売り　1:買い
	[BS_Min15_買いWMAs14]			[float]		NULL,
	[BS_Min15_買いWMAs14角度]		[float]		NULL,
	[BS_Min15_買いWMAs14角度シグマ]	[float]		NULL,
	[BS_Min15_売りWMAs14]			[float]		NULL,
	[BS_Min15_売りWMAs14角度]		[float]		NULL,
	[BS_Min15_売りWMAs14角度シグマ]	[float]		NULL,
	[BS_WMA判定_15m]		[varchar](1)	NOT NULL,		-- S:売り　B:買い
	[BS判定_15m]			[varchar](1)	NOT NULL,		-- S:売り　B:買い
	[BS開始]				[bit]			NOT NULL,		-- 0:BB開始ではなくWMA判定　1:BB開始
	[BS判定_前]				[varchar](1)	NOT NULL,		-- B:BonusStage中　ブランク:BonusStageではない
	[BS判定_今]				[varchar](1)	NOT NULL,		-- B:BonusStage中　ブランク:BonusStageではない
	[リミット]				[float]			NOT NULL,
	[注文単位]				[int]			NOT NULL,
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
	[登録日時]				[datetime]		NULL,
	[更新日時]				[datetime]		NULL,
CONSTRAINT [PK_tOrderHistory2] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
