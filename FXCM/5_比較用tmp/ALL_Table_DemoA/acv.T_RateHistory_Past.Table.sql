USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [acv].[T_RateHistory_Past](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [datetime] NOT NULL,
	[Rate_買い] [float] NOT NULL,
	[Rate_売り] [float] NOT NULL,
	[Swap_買い] [float] NOT NULL,
	[Swap_売り] [float] NOT NULL,
 CONSTRAINT [PK_RateHistoryPast] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
