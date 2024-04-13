USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [anls].[t想定売買タイミング_Swap判定無し](
	[通貨ペアNo]		[tinyint]			NOT NULL,
	[売買判定]			[varchar](1)		NOT NULL,	-- S:売り　B:買い
	[StartDateMin1]		[datetime]			NOT NULL,
	[StartDateMin5]		[datetime]			NOT NULL,
	[StartDateMin15]	[datetime]			NOT NULL,
	[StartDateHour1]	[datetime]			NOT NULL,
	[StartDateDay1]		[datetime]			NOT NULL,
	[StartDateWeek1]	[datetime]			NOT NULL,
	[StartDateMonth1]	[datetime]			NOT NULL,
	[登録日時]			[datetime]			NOT NULL,
	[更新日時]			[datetime]			NULL,
	[比較結果]			[varchar](1000)		NULL,
CONSTRAINT [PK_t想定売買タイミング_Swap判定無し] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[売買判定] ASC,
	[StartDateMin1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

