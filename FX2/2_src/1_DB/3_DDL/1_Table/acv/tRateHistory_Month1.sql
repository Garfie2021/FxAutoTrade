USE [FX2_Demo]
GO

DROP TABLE [acv].[tRateHistory_Month1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [acv].[tRateHistory_Month1](
	[通貨ペアNo] [tinyint] NOT NULL,
	[StartDate] [date] NOT NULL,
	[買いRate_始値] [float] NOT NULL,
	[買いRate_高値] [float] NOT NULL,
	[買いRate_安値] [float] NOT NULL,
	[買いRate_終値] [float] NOT NULL,
	[買いWMAs2] [float] NULL,
	[買いWMAs2角度] [float] NULL,
	[買いWMAs2角度シグマ] [float] NULL,
	[買いWMAs2角度持続時間] [int] NULL,	--分
	[買いWMAs2角度持続Rate] [float] NULL,
	[売りRate_始値] [float] NOT NULL,
	[売りRate_高値] [float] NOT NULL,
	[売りRate_安値] [float] NOT NULL,
	[売りRate_終値] [float] NOT NULL,
	[売りWMAs2] [float] NULL,
	[売りWMAs2角度] [float] NULL,
	[売りWMAs2角度シグマ] [float] NULL,
	[売りWMAs2角度持続時間] [int] NULL,	--分
	[売りWMAs2角度持続Rate] [float] NULL,
	[更新日時] [datetime] NULL,
CONSTRAINT [PK_tRateHistory_Month1] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
