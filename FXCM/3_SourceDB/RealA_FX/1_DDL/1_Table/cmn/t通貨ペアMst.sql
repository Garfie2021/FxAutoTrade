USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [cmn].[t通貨ペアMst](
	[No] [tinyint] NOT NULL,
	[ペア名] [varchar](50) NOT NULL,
	[SMLT_シグマ閾値] [float] NULL,
	[SMLT_直近1ヵ月の利益Sum] [float] NULL,
	[口座種別] [varchar](10) NULL,
	[Order間隔最小値_買い] [float] NULL,
	[Order間隔最小値_売り] [float] NULL,
	[注文禁止ポジション間隔] [float] NULL,
	[差分リミット] [float] NULL,
	[BS終了時_買いリミット_BS終了時] [float] NULL,
	[BS終了時_売りリミット_BS終了時] [float] NULL,
CONSTRAINT [PK_t通貨ペアMst] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
