USE [FX2_Demo]
GO

DROP TABLE [indi].[tIndicatorHistory_Week1];
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [indi].[tIndicatorHistory_Week1](
	[�ʉ݃y�ANo] [tinyint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[����WMAs2�p�x] [float] NULL,
	[����WMAs2�p�x�V�O�}] [float] NULL,
	[����WMAs2�p�x��������] [int] NULL,
	[����WMAs2�p�x����Rate] [float] NULL,
	[����WMAs2�p�x] [float] NULL,
	[����WMAs2�p�x�V�O�}] [float] NULL,
	[����WMAs2�p�x��������] [int] NULL,
	[����WMAs2�p�x����Rate] [float] NULL
CONSTRAINT [PK_tIndicatorHistory_Week1] PRIMARY KEY CLUSTERED
(
	[�ʉ݃y�ANo] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO


