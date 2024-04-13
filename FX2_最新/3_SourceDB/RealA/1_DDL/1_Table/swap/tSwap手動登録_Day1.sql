USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [swap].[tSwap手動登録_Day1](
	[通貨ペアNo]				[tinyint]	NOT NULL,
	[StartDate]					[datetime]	NOT NULL,
	[買いSwap]					[float]		NULL,
	[売りSwap]					[float]		NULL,
	[登録日時]					[datetime]	NULL,
	[更新日時]					[datetime]	NULL,
CONSTRAINT [PK_swap_tSwap手動登録_Day1] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

