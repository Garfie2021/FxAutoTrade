USE [FX2_Demo]
GO

DROP table [oder].[tOrderHistory];

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oder].[tOrderHistory](
	[通貨ペアNo]	[tinyint]		NOT NULL,
	[OrderDate]		[datetime]		NOT NULL,
	[売買判定]		[tinyint]		NOT NULL,
	[買いRate]		[float]			NOT NULL,
	[売りRate]		[float]			NOT NULL,
	[注文数]		[tinyint]		NOT NULL,
	[Close予定Date]	[datetime]		NOT NULL,		-- 基本は[OrderDate]の15分後
	[OpenOrderID]	[varchar](50)	NOT NULL,
	[TradeID]		[varchar](50)	NULL,
	[Close済み]		[tinyint]		NULL,			-- 0：未クローズ　1：クローズ済み
	[CloseDate]		[datetime]		NULL,
	[CloseOrderID] [varchar](50)	NULL,
CONSTRAINT [PK_tOrderHistory] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[OrderDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
