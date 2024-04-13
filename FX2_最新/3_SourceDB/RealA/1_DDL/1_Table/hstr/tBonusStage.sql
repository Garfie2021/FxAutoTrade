USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [hstr].[tBonusStage](
	[日時]						[datetime]		NOT NULL,
	[通貨ペアNo]				[tinyint]		NOT NULL,
	[買いSwap]					[float]			NULL,
	[売りSwap]					[float]			NULL,
	[Swap判定]					[varchar](1)	NULL,		-- 0:売り　1:買い
	[買いRate]					[float]			NULL,
	[買いWMAs14]				[float]			NULL,
	[買いWMAs14上昇角度]		[float]			NULL,
	[買いWMAs14上昇角度シグマ]	[float]			NULL,
	[売りRate]					[float]			NULL,
	[売りWMAs14]				[float]			NULL,
	[売りWMAs14上昇角度]		[float]			NULL,
	[売りWMAs14上昇角度シグマ]	[float]			NULL,
	[BS_WMA判定_15m]			[varchar](1)	NULL,
	[保持ポジション]			[varchar](1)	NULL,
	[BS判定_前]					[varchar](1)	NULL,
	[BS判定_今]					[varchar](1)	NULL,
	[登録日時]					[datetime]		NULL,
	[更新日時]					[datetime]		NULL,
CONSTRAINT [PK_tBonusStage] PRIMARY KEY CLUSTERED 
(
	[日時] ASC,
	[通貨ペアNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
