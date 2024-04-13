USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SwapHistory_Monthly](
	[通貨ペアNo] [tinyint] NOT NULL,
	[年] [smallint] NOT NULL,
	[月] [tinyint] NOT NULL,
	[AvgSwap_買い] [float] NOT NULL,
	[AvgSwap_売り] [float] NOT NULL,
 CONSTRAINT [PK_T_SwapHistory_Monthly] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[年] ASC,
	[月] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
