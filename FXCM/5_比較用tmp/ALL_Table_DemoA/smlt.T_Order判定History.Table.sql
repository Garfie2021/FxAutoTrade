USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [smlt].[T_Order判定History](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [datetime] NOT NULL,
	[処理位置] [tinyint] NOT NULL,
	[買いRate] [float] NULL,
	[売りRate] [float] NULL,
	[OrderEntryRate] [float] NULL,
	[Limit] [float] NULL,
	[危険Rate] [float] NULL,
	[処理位置_補足] [varchar](200) NULL,
	[取引状況] [varchar](100) NULL,
	[注文設定_モード] [varchar](10) NULL,
	[買売モード_15m] [varchar](10) NULL,
	[買売モード_Daily] [varchar](10) NULL,
	[成行をスキップ] [varchar](10) NULL,
	[ポジション有り] [varchar](10) NULL,
	[ボーナスステージ判定] [varchar](10) NULL,
	[ADX上昇判定_15m] [varchar](10) NULL,
	[ASI買い気配] [varchar](10) NULL,
	[DMIplusDI上昇判定] [varchar](10) NULL,
 CONSTRAINT [PK_T_Order判定History] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC,
	[処理位置] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
