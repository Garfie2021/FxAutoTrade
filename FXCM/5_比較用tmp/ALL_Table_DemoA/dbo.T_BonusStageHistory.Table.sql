USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_BonusStageHistory](
	[通貨ペアNo] [tinyint] NOT NULL,
	[シグマ閾値] [float] NOT NULL,
	[日時] [datetime] NOT NULL,
	[買いRate] [float] NULL,
	[売りRate] [float] NULL,
	[WMA判定_15m] [varchar](10) NULL,
	[BS開始終了] [varchar](1) NULL,
	[補足] [varchar](200) NULL,
 CONSTRAINT [PK_T_BonusStageHistory] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[シグマ閾値] ASC,
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
