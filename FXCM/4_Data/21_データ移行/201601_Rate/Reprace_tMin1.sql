USE [DemoA_FX]
GO

DROP TABLE [hstr].[tMin1tmp];

CREATE TABLE [hstr].[tMin1tmp](
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
CONSTRAINT [PK_tMin1tmp] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO [hstr].[tMin1tmp]
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いSwap]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[買いWMAs2]
           ,[買いWMAs2角度]
           ,[買いWMAs2角度シグマ]
           ,[買いWMAs2角度持続時間]
           ,[買いWMAs2角度持続Rate]
           ,[買いWMAs14]
           ,[買いWMAs14角度]
           ,[買いWMAs14角度シグマ]
           ,[買いWMAs14角度持続時間]
           ,[買いWMAs14角度持続Rate]
           ,[売りSwap]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値]
           ,[売りWMAs2]
           ,[売りWMAs2角度]
           ,[売りWMAs2角度シグマ]
           ,[売りWMAs2角度持続時間]
           ,[売りWMAs2角度持続Rate]
           ,[売りWMAs14]
           ,[売りWMAs14角度]
           ,[売りWMAs14角度シグマ]
           ,[売りWMAs14角度持続時間]
           ,[売りWMAs14角度持続Rate]
           ,[更新日時])
SELECT [通貨ペアNo]
      ,[StartDate]
      ,[買いSwap]
      ,[買いRate_始値]
      ,[買いRate_高値]
      ,[買いRate_安値]
      ,[買いRate_終値]
      ,[買いWMAs2]
      ,[買いWMAs2角度]
      ,[買いWMAs2角度シグマ]
      ,[買いWMAs2角度持続時間]
      ,[買いWMAs2角度持続Rate]
      ,[買いWMAs14]
      ,[買いWMAs14角度]
      ,[買いWMAs14角度シグマ]
      ,[買いWMAs14角度持続時間]
      ,[買いWMAs14角度持続Rate]
      ,[売りSwap]
      ,[売りRate_始値]
      ,[売りRate_高値]
      ,[売りRate_安値]
      ,[売りRate_終値]
      ,[売りWMAs2]
      ,[売りWMAs2角度]
      ,[売りWMAs2角度シグマ]
      ,[売りWMAs2角度持続時間]
      ,[売りWMAs2角度持続Rate]
      ,[売りWMAs14]
      ,[売りWMAs14角度]
      ,[売りWMAs14角度シグマ]
      ,[売りWMAs14角度持続時間]
      ,[売りWMAs14角度持続Rate]
      ,[更新日時]
FROM [hstr].[tMin1]


DROP TABLE [hstr].[tMin1];


EXEC sp_rename 'hstr.tMin1tmp', 'tMin1';
