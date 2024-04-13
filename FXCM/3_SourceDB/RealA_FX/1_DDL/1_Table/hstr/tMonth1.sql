USE [DemoA_FX]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [hstr].[tMonth1](
	[通貨ペアNo]				[tinyint]	NOT NULL,
	[StartDate]					[datetime]	NOT NULL,
	[買いSwap]					[float]		NULL,
	[買いRate_始値]				[float]		NULL,
	[買いRate_高値]				[float]		NULL,
	[買いRate_安値]				[float]		NULL,
	[買いRate_終値]				[float]		NULL,
	[買いWMAs2]					[float]		NULL,
	[買いWMAs2角度]				[float]		NULL,
	[買いWMAs2角度シグマ]		[float]		NULL,
	[買いWMAs2角度持続時間]		[int]		NULL,	--分
	[買いWMAs2角度持続Rate]		[float]		NULL,
	[買いWMAs14]				[float]		NULL,
	[買いWMAs14角度]			[float]		NULL,
	[買いWMAs14角度シグマ]		[float]		NULL,
	[買いWMAs14角度持続時間]	[int]		NULL,	--分
	[買いWMAs14角度持続Rate]	[float]		NULL,
	[売りSwap]					[float]		NULL,
	[売りRate_始値]				[float]		NULL,
	[売りRate_高値]				[float]		NULL,
	[売りRate_安値]				[float]		NULL,
	[売りRate_終値]				[float]		NULL,
	[売りWMAs2]					[float]		NULL,
	[売りWMAs2角度]				[float]		NULL,
	[売りWMAs2角度シグマ]		[float]		NULL,
	[売りWMAs2角度持続時間]		[int]		NULL,	--分
	[売りWMAs2角度持続Rate]		[float]		NULL,
	[売りWMAs14]				[float]		NULL,
	[売りWMAs14角度]			[float]		NULL,
	[売りWMAs14角度シグマ]		[float]		NULL,
	[売りWMAs14角度持続時間]	[int]		NULL,	--分
	[売りWMAs14角度持続Rate]	[float]		NULL,
	[登録日時]					[datetime]	NULL,
	[更新日時]					[datetime]	NULL,
CONSTRAINT [PK_tMonth1] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

