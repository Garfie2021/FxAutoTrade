USE DemoA_FX
GO

-- 現行のtOrderHistoryテーブルをtOrderHistory_bkへリネームした後

CREATE TABLE [pfmc].[tポジションHourly](
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
CONSTRAINT [PK_tポジションHourly2] PRIMARY KEY CLUSTERED 
(
	[StartDate] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [pfmc].[tポジションHourly]
           ([StartDate]
           ,[保有可能ポジション数]
           ,[決算待ちポジション数]
           ,[当日注文数]
           ,[当日約定数]
           ,[当日約定金額]
           ,[取引証拠金]
           ,[有効証拠金]
           ,[維持証拠金]
           ,[ロスカット余剰金]
           ,[余剰金の割合])
SELECT [StartDate]
      ,[保有可能ポジション数]
      ,[決算待ちポジション数]
      ,[当日注文数]
      ,[当日約定数]
      ,[当日約定金額]
      ,[取引証拠金]
      ,[有効証拠金]
      ,[維持証拠金]
      ,[ロスカット余剰金]
      ,[余剰金の割合]
  FROM [pfmc].[tポジションHourly_bk]
GO

