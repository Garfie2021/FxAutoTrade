USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_注文設定History](
	[通貨ペア] [tinyint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[危険度] [smallint] NOT NULL,
	[ポジション] [smallint] NOT NULL,
	[ポジション増加] [smallint] NOT NULL,
	[平均差損益] [smallint] NOT NULL,
	[Order間隔最小値] [float] NOT NULL,
	[Order間隔] [float] NOT NULL,
	[リミット] [float] NOT NULL,
	[モード] [varchar](10) NOT NULL,
	[取引状況] [varchar](100) NOT NULL,
 CONSTRAINT [PK_注文設定History] PRIMARY KEY CLUSTERED 
(
	[通貨ペア] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
