USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [oder].[t注文対象通貨ペアDaily](
	[StartDate]		[datetime]	NOT NULL,
	[通貨ペアNo]	[tinyint]	NOT NULL,
CONSTRAINT [PK_t注文対象通貨ペア] PRIMARY KEY CLUSTERED 
(
	[StartDate] ASC,
	[通貨ペアNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

