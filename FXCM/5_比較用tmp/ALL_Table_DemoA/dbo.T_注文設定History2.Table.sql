USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_注文設定History2](
	[通貨ペア] [tinyint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[ポジション] [smallint] NOT NULL,
	[ポジション増加] [smallint] NOT NULL,
	[平均差損益] [float] NOT NULL,
	[Order間隔最小値] [float] NOT NULL,
	[Order間隔] [float] NOT NULL,
	[リミット] [float] NOT NULL,
	[GrossPL小計] [int] NOT NULL,
	[維持証拠金小計] [int] NOT NULL,
	[モード] [varchar](10) NOT NULL,
	[取引状況] [varchar](100) NULL,
 CONSTRAINT [PK_注文設定History2] PRIMARY KEY CLUSTERED 
(
	[通貨ペア] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[T_注文設定History2] ADD  CONSTRAINT [DF_T_注文設定History2_GrossPL小計]  DEFAULT ((0)) FOR [GrossPL小計]
GO
ALTER TABLE [dbo].[T_注文設定History2] ADD  CONSTRAINT [DF_T_注文設定History2_維持証拠金小計]  DEFAULT ((0)) FOR [維持証拠金小計]
GO
