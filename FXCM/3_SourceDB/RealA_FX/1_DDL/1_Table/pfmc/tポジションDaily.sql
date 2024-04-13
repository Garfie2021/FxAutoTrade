USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [pfmc].[tポジションDaily](
	[StartDate]				[datetime]	NOT NULL,
	[保有可能ポジション数_始]	[int]		NULL,
	[保有可能ポジション数_高]	[int]		NULL,
	[保有可能ポジション数_低]	[int]		NULL,
	[保有可能ポジション数_終]	[int]		NULL,
	[決算待ちポジション数_始]	[int]		NULL,
	[決算待ちポジション数_高]	[int]		NULL,
	[決算待ちポジション数_低]	[int]		NULL,
	[決算待ちポジション数_終]	[int]		NULL,
	[取引証拠金_始]				[int]		NULL,
	[取引証拠金_高]				[int]		NULL,
	[取引証拠金_低]				[int]		NULL,
	[取引証拠金_終]				[int]		NULL,
	[有効証拠金_始]				[int]		NULL,
	[有効証拠金_高]				[int]		NULL,
	[有効証拠金_低]				[int]		NULL,
	[有効証拠金_終]				[int]		NULL,
	[維持証拠金_始]				[int]		NULL,
	[維持証拠金_高]				[int]		NULL,
	[維持証拠金_低]				[int]		NULL,
	[維持証拠金_終]				[int]		NULL,
	[ロスカット余剰金_始]		[int]		NULL,
	[ロスカット余剰金_高]		[int]		NULL,
	[ロスカット余剰金_低]		[int]		NULL,
	[ロスカット余剰金_終]		[int]		NULL,
	[余剰金の割合_始]			[int]		NULL,
	[余剰金の割合_高]			[int]		NULL,
	[余剰金の割合_低]			[int]		NULL,
	[余剰金の割合_終]			[int]		NULL,
	[登録日時]					[datetime]	NOT NULL,
	[更新日時]					[datetime]	NULL,
CONSTRAINT [PK_tポジションDaily] PRIMARY KEY CLUSTERED 
(
	[StartDate] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
