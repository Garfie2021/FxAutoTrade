USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [anls].[tデルタRate](
	[通貨ペアNo]				[tinyint]		NOT NULL,
	[売買]						[bit]			NOT NULL,	-- 0:売り　1:買い
	[StartDateMonth1_Begin]		[datetime]		NOT NULL,
	[StartDateMonth1_Center]	[datetime]		NOT NULL,
	[StartDateMonth1_End]		[datetime]		NOT NULL,
	[Rate_Begin]				[float]			NOT NULL,
	[Rate_Center]				[float]			NOT NULL,
	[Rate_End]					[float]			NOT NULL,
	[登録日時]					[datetime]		NOT NULL,
	[更新日時]					[datetime]		NULL,
CONSTRAINT [PK_tデルタRate] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[売買] ASC,
	[StartDateMonth1_Center] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

