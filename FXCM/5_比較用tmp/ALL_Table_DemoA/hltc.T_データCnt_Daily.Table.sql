USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hltc].[T_データCnt_Daily](
	[日時] [date] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[件数_RateHistory] [int] NULL,
	[件数_RateHistory_1m] [int] NULL,
	[件数_RateHistory_5m] [int] NULL,
	[件数_RateHistory_15m] [int] NULL,
	[件数_RateHistory_30m] [int] NULL,
	[件数_RateHistory_1h] [int] NULL,
	[件数_RateHistory_6h] [int] NULL,
	[件数_RateHistory_Day] [int] NULL,
	[件数_Indicator_1m] [int] NULL,
	[件数_Indicator_5m] [int] NULL,
	[件数_Indicator_15m] [int] NULL,
	[件数_Indicator_30m] [int] NULL,
	[件数_Indicator_1h] [int] NULL,
	[件数_Indicator_6h] [int] NULL,
	[件数_Indicator_Day] [int] NULL,
	[件数_AccountsHistory] [int] NULL,
	[件数_BonusStageHistory] [int] NULL,
	[件数_ClosedTrades] [int] NULL,
	[件数_OrderHistory] [int] NULL,
	[件数_SwapHistory_Hourly] [int] NULL,
	[件数_Trades] [int] NULL,
	[件数_差損益History] [int] NULL,
 CONSTRAINT [PK_T_データCnt_Daily] PRIMARY KEY CLUSTERED 
(
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
