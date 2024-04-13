USE OANDA_DemoB

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [pfmc].[tExecLog_統計](
	[口座No]		[int]			NOT NULL,
	[StartDate]		[datetime]		NOT NULL,
	[処理区分]		[varchar](10)	NOT NULL,
	[処理名]		[varchar](50)	NULL,
	[取引状況]		[varchar](100)	NULL,
	[Count]			[bigint]		NOT NULL,
	[Count_シグマ]	[float]			NULL,
) ON [PRIMARY]
GO

ALTER TABLE [pfmc].[tExecLog_統計] REBUILD PARTITION = ALL
WITH 
(DATA_COMPRESSION = PAGE);
GO
