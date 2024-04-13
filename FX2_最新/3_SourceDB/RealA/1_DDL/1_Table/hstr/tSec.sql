USE 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [hstr].[tSec](
	[通貨ペアNo]	[tinyint]	NOT NULL,
	[StartDate]		[datetime]	NOT NULL,
	[買いSwap]		[float]		NULL,
	[買いRate]		[float]		NULL,
	[売りSwap]		[float]		NULL,
	[売りRate]		[float]		NULL,
CONSTRAINT [PK_tSec] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
