USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TradeSumury_買い](
	[Date] [datetime] NOT NULL,
	[Rate] [float] NOT NULL,
	[注文Entry数] [int] NOT NULL,
	[決算待ちポジション数] [int] NOT NULL,
	[取引証拠金] [int] NOT NULL,
	[有効証拠金] [int] NOT NULL,
	[維持証拠金] [int] NOT NULL,
	[アラート余剰金] [int] NOT NULL,
 CONSTRAINT [PK_T_TradeSumury_買い] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
