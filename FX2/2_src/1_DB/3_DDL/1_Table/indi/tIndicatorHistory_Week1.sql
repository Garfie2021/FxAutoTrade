USE [FX2_Demo]
GO

DROP TABLE [indi].[tIndicatorHistory_Week1];
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [indi].[tIndicatorHistory_Week1](
	[通貨ペアNo] [tinyint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[買いWMAs2角度] [float] NULL,
	[買いWMAs2角度シグマ] [float] NULL,
	[買いWMAs2角度持続時間] [int] NULL,
	[買いWMAs2角度持続Rate] [float] NULL,
	[売りWMAs2角度] [float] NULL,
	[売りWMAs2角度シグマ] [float] NULL,
	[売りWMAs2角度持続時間] [int] NULL,
	[売りWMAs2角度持続Rate] [float] NULL
CONSTRAINT [PK_tIndicatorHistory_Week1] PRIMARY KEY CLUSTERED
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO


