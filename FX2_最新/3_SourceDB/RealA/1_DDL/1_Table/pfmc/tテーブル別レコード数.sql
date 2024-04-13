USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [pfmc].[tテーブル別レコード数](
	[登録日時]			[datetime]	NOT NULL,
	[口座No]			[int]		NOT NULL,
	[StartDate]			[datetime]	NULL,
	[EndDate]			[datetime]	NULL,
	[レコード数]		[int]		NULL,
	[シグマ値]			[float]		NULL,
CONSTRAINT [PK_t集計Day1] PRIMARY KEY CLUSTERED 
(
	[登録日時] ASC,
	[口座No]	ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
