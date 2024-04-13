USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [anls].[t注文単位を割る値](
	[通貨ペアNo]		[tinyint]		NOT NULL,
	[売買]				[bit]			NOT NULL,	-- 0:売り　1:買い
	[Rate_High]			[float]			NOT NULL,
	[Rate_Low]			[float]			NOT NULL,
	[注文単位を割る値]	[int]			NOT NULL,	-- 10～1000の間で注文単位を割る。
	[登録日時]			[datetime]		NOT NULL,
	[更新日時]			[datetime]		NULL,
CONSTRAINT [PK_t注文単位を割る値] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[売買] ASC,
	[Rate_High] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

