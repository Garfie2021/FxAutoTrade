USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [acv].[T_Indicator_1m_Past_tmp](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [date] NOT NULL,
	[WMA_買い_WMA] [float] NULL,
	[WMA_売り_WMA] [float] NULL,
	[WMA_買い_WMA上昇角度] [float] NULL,
	[WMA_売り_WMA上昇角度] [float] NULL,
	[WMA_買い_WMA_S2] [float] NULL,
	[WMA_売り_WMA_S2] [float] NULL,
	[WMA_買い_WMA上昇角度_S2] [float] NULL,
	[WMA_売り_WMA上昇角度_S2] [float] NULL,
 CONSTRAINT [PK_T_Indicator_1m_Past] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
