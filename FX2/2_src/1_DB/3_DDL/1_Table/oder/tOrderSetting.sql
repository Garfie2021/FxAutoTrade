USE [FX2_Demo]
GO

DROP TABLE [oder].[tOrderSettings];

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oder].[tOrderSettings](
	[通貨ペアNo]	[tinyint]		NOT NULL,
	[計算対象]		[tinyint]		NULL,			-- 0：計算しない 1：計算する
	[注文対象]		[tinyint]		NULL,			-- 0：注文しない 1：注文する
CONSTRAINT [PK_tOrderSettings] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

