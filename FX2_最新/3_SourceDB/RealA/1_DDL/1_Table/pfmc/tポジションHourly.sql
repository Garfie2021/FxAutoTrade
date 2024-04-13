USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [pfmc].[tポジションHourly](
	[口座No]				int			NOT NULL,
	[StartDate]				[datetime]	NOT NULL,
	[保有可能ポジション数]	[float]		NULL,
	[決算待ちポジション数]	[float]		NULL,
	[当日注文数]			[float]		NULL,
	[当日約定数]			[float]		NULL,
	[当日約定金額]			[float]		NULL,
	[取引証拠金]			[float]		NULL,
	[有効証拠金]			[float]		NULL,
	[維持証拠金]			[float]		NULL,
	[ロスカット余剰金]		[float]		NULL,
	[余剰金の割合]			[float]		NULL,
CONSTRAINT [PK_tポジションHourly] PRIMARY KEY CLUSTERED 
(
	[口座No] ASC,
	[StartDate] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
