USE [FX_DemoA]
GO
/****** Object:  Table [dbo].[T_RateHistory_Monthly]    Script Date: 01/30/2014 06:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [fxcm].[T_Indicator_30m_ALLIGATOR](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [date] NOT NULL,
	[Jaw] [float] NULL,
	[Teeth] [float] NULL,
	[Lips] [float] NULL,
CONSTRAINT [PK_Indicator_30m_ALLIGATOR] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
