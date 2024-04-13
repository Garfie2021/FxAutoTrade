USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [anls].[t注文対象通貨ペア数Daily](
	[StartDate]		[datetime]	NOT NULL,
	[注文対象通貨ペア数_想定]	[tinyint]	NULL,
	[注文対象通貨ペア数_実績]	[tinyint]	NULL,
CONSTRAINT [PK_t注文対象通貨ペア数Daily] PRIMARY KEY CLUSTERED 
(
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

