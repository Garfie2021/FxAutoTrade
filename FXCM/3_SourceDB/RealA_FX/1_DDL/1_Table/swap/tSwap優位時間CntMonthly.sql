USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [swap].[tSwap優位時間CntMonthly](
	[通貨ペアNo]			[tinyint]	NOT NULL,
	[StartDate]				[datetime]	NOT NULL,
	[買いSwap優位時間Cnt]	[int]		NULL,
	[売りSwap優位時間Cnt]	[int]		NULL,
	[登録日時]				[datetime]	NOT NULL,
	[更新日時]				[datetime]	NULL,
CONSTRAINT [PK_tSwap優位時間CntMonthly] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

