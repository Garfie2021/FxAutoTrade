USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [pfmc].[t集計Day1](
	[口座No]			[int]		NOT NULL,
	[StartDate]			[datetime]	NOT NULL,
	[注文数]			[float]		NULL,
	[リミット変更数]	[int]		NULL,
	[約定数]			[float]		NULL,
	[約定金額]			[float]		NULL,
	[取引証拠金]		[float]		NULL,
	[有効証拠金]		[float]		NULL,
	[維持証拠金]		[float]		NULL,
	[ロスカット余剰金]	[float]		NULL,
	[ポジション数]		[int]		NULL,
CONSTRAINT [PK_t集計Day1] PRIMARY KEY CLUSTERED 
(
	[口座No] ASC,
	[StartDate] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
