USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_RateHistory_5m](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [datetime] NOT NULL,
	[買い_始値] [float] NULL,
	[買い_高値] [float] NULL,
	[買い_安値] [float] NULL,
	[買い_終値] [float] NULL,
	[売り_始値] [float] NULL,
	[売り_高値] [float] NULL,
	[売り_安値] [float] NULL,
	[売り_終値] [float] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_RateHistory_5m3] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
