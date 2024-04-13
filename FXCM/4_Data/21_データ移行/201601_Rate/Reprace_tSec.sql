USE [DemoA_FX]
GO

DROP TABLE [hstr].[tSectmp];

CREATE TABLE [hstr].[tSectmp](
	[通貨ペアNo]	[tinyint]	NOT NULL,
	[StartDate]		[datetime]	NOT NULL,
	[買いSwap]		[float]		NULL,
	[買いRate]		[float]		NULL,
	[売りSwap]		[float]		NULL,
	[売りRate]		[float]		NULL,
	[登録日時]		[datetime]	NULL,
CONSTRAINT [PK_tSec] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO [hstr].[tSectmp]
           ([通貨ペアNo]
           ,[StartDate]
			,[買いSwap]
			,[買いRate]
			,[売りSwap]
			,[売りRate]
			,[登録日時])
SELECT [通貨ペアNo]
	      ,[StartDate]
			,[買いSwap]
			,[買いRate]
			,[売りSwap]
			,[売りRate]
			,getdate()
FROM [hstr].[tSec]


DROP TABLE hstr.tSec;

EXEC sp_rename 'hstr.tSectmp', 'tSec';
