USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [smlt].[T_BonusStageHistory評価](
	[通貨ペアNo] [tinyint] NOT NULL,
	[シグマ閾値] [float] NOT NULL,
	[年月日] [date] NOT NULL,
	[利益Plus] [float] NULL,
	[利益Minus] [float] NULL,
	[利益Sum] [float] NULL,
	[BS発生回数] [float] NULL,
	[BS平均持続時間] [float] NULL,
 CONSTRAINT [PK_T_BonusStageHistory評価] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[シグマ閾値] ASC,
	[年月日] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
