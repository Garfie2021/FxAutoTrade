USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [anls].[t想定売買タイミング](
	[通貨ペアNo]		[tinyint]	NOT NULL,
	[売買判定]			[tinyint]	NOT NULL,	-- 1:買い -- 0:売り
	[StartDateMin1]		[datetime]	NOT NULL,
	[StartDateMin5]		[datetime]	NOT NULL,
	[StartDateMin15]	[datetime]	NOT NULL,
	[StartDateHour1]	[datetime]	NOT NULL,
	[StartDateDay1]		[datetime]	NOT NULL,
	[StartDateWeek1]	[datetime]	NOT NULL,
	[StartDateMonth1]	[datetime]	NOT NULL,
	[買いSwap]			[float]		NOT NULL,
	[売りSwap]			[float]		NOT NULL,
	[登録日時]			[datetime]	NOT NULL,
	[更新日時]			[datetime]	NULL,
CONSTRAINT [PK_t想定売買タイミング] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[売買判定] ASC,
	[StartDateMin1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

