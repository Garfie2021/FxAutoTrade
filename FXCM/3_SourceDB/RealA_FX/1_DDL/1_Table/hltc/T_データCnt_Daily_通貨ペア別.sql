USE [DemoA_FX]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [hltc].[T_データCnt_Daily_通貨ペア別](
	[日時] [date] NOT NULL,
	[通貨ペアNo] [tinyint] NOT NULL,
	[件数_RateHistory] [int] NULL,
	[件数_RateHistory_1m] [int] NULL,
	[件数_RateHistory_5m] [int] NULL,
	[件数_RateHistory_15m] [int] NULL,
	[件数_RateHistory_30m] [int] NULL,
	[件数_RateHistory_1h] [int] NULL,
	[件数_RateHistory_6h] [int] NULL,
	[件数_RateHistory_Day] [int] NULL,
	[件数_RateHistory_Week] [int] NULL,
	[件数_RateHistory_Month] [int] NULL,
	[件数_Indicator_1m] [int] NULL,
	[件数_Indicator_5m] [int] NULL,
	[件数_Indicator_15m] [int] NULL,
	[件数_Indicator_30m] [int] NULL,
	[件数_Indicator_1h] [int] NULL,
	[件数_Indicator_6h] [int] NULL,
	[件数_Indicator_Day] [int] NULL,
	[件数_Indicator_Week] [int] NULL,
	[件数_Indicator_Month] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
CONSTRAINT [PK_T_データCnt_Daily_通貨ペア別] PRIMARY KEY CLUSTERED
(
	[日時] ASC,
	[通貨ペアNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO


