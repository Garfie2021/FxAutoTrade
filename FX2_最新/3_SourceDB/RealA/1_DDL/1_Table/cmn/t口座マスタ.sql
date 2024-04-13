USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [cmn].[t口座マスタ](
	[口座No]			[int]			NOT NULL,
	[有効無効]			[tinyint]		NULL,	-- 0:無効 1:有効
	[FX会社]			[tinyint]		NULL,	-- 0:FXCM 1:OANDA
	[FxServerContry]	[tinyint]		NULL,	-- 0:JP 1:UK 2:US
	[個人法人]			[tinyint]		NULL,	-- 0:個人 1:法人
	[DemoReal]			[tinyint]		NULL,	-- 0:Demo 1:Real
	[取引証拠金上限]	[int]			NULL,
	[OandaAccountId]	[int]			NULL,
	[OandaAccessToken]	[varchar](100)	NULL,
	[毎朝の自動注文開始を行う]	[tinyint]		NULL,	-- 0:行わない 1:行う
	[登録日時]			[datetime]		NULL,
	[更新日時]			[datetime]		NULL,
CONSTRAINT [PK_t口座マスタ] PRIMARY KEY CLUSTERED 
(
	[口座No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

