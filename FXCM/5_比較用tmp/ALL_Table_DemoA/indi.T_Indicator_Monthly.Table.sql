USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [indi].[T_Indicator_Monthly](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [datetime] NOT NULL,
	[WMA_買い_WMA] [float] NULL,
	[WMA_売り_WMA] [float] NULL,
	[WMA_買い_WMA上昇角度] [float] NULL,
	[WMA_売り_WMA上昇角度] [float] NULL,
	[WMA_買い_WMA_S2] [nchar](10) NULL,
	[WMA_売り_WMA_S2] [nchar](10) NULL,
	[WMA_買い_WMA上昇角度_S2] [nchar](10) NULL,
	[WMA_売り_WMA上昇角度_S2] [nchar](10) NULL,
 CONSTRAINT [PK_T_Indicator_Monthly] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
